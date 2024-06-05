using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IObjectPool<T> where T : class, IPooleableObject<T>
{
    #region Variables

    private T pooleableObjectType;
    private bool allowRegrow;
    private List<T> objectList;
    private int activeObjects;

    #endregion

    #region PublicMethods

    public ObjectPool(T pooleableObjectType, int initialNumberOfElements, bool allowRegrow = false)
    {
        this.pooleableObjectType = pooleableObjectType;
        this.allowRegrow = allowRegrow;
        this.objectList = new List<T>(initialNumberOfElements);
        this.activeObjects = 0;
        for (int i = 0; i < initialNumberOfElements; ++i)
        {
            objectList.Add(CreateObject());
        }
    }

    public T Get()
    {
        for (int i = 0; i < objectList.Count; ++i)
        {
            if (!objectList[i].GetActive())
            {
                objectList[i].SetActive(true);
                activeObjects++;
                return objectList[i];
            }
        }

        if (allowRegrow)
        {
            T obj = CreateObject();
            obj.SetActive(true);
            objectList.Add(obj);
            activeObjects++;
            return obj;
        }

        return null;
    }

    public void Release(T obj)
    {
        obj.SetActive(false);
        obj.Reset();
        --this.activeObjects;
    }

    public int GetActiveCount()
    {
        return this.activeObjects;
    }
    
    public int GetCount()
    {
        return this.objectList.Count;
    }

    public int GetInactiveCount()
    {
        return this.objectList.Count - this.activeObjects;
    }

    public bool GetAllowRegrow()
    {
        return this.allowRegrow;
    }

    public void SetAllowRegrow(bool newAllowRegrow)
    {
        this.allowRegrow = newAllowRegrow;
    }

    #endregion

    #region PrivateMethods

    private T CreateObject()
    {
        return this.pooleableObjectType.Clone();
    }

    #endregion

}
