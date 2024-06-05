using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : IObjectPool
{
    #region Variables

    private IPooleableObject pooleableObjectType;
    private bool allowRegrow;
    private List<IPooleableObject> objectList;
    private int activeObjects;

    #endregion

    #region PublicMethods

    public ObjectPool(IPooleableObject pooleableObjectType, int initialNumberOfElements, bool allowRegrow = false)
    {
        this.pooleableObjectType = pooleableObjectType;
        this.allowRegrow = allowRegrow;
        this.objectList = new List<IPooleableObject>(initialNumberOfElements);
        this.activeObjects = 0;
        for (int i = 0; i < initialNumberOfElements; ++i)
        {
            objectList.Add(CreateObject());
        }
    }

    public IPooleableObject Get()
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
            IPooleableObject obj = CreateObject();
            obj.SetActive(true);
            objectList.Add(obj);
            activeObjects++;
            return obj;
        }

        return null;
    }

    public void Release(IPooleableObject obj)
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

    private IPooleableObject CreateObject()
    {
        return this.pooleableObjectType.Instantiate();
    }

    #endregion

}
