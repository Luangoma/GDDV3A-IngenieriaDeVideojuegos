using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : IObjectPool<T> where T : class
{
    #region Classes

    public class PooleableObjectWrapper<U> : IPooleableObject<U> where U : class
    {
        private U data;
        private bool isActive;

        public PooleableObjectWrapper(U obj, bool active = false)
        {
            this.data = obj;
            this.isActive = active;
        }

        public void SetActive(bool active)
        {
            this.isActive = active;
        }

        public bool GetActive()
        {
            return this.isActive;
        }

        public U GetObject()
        {
            return this.data;
        }

    }

    #endregion

    #region Variables

    private List<PooleableObjectWrapper<T>> objects;
    private int activeObjects;
    private int initialCapacity;
    private int maxCapacity;

    // Delegates. These will be called (if available) internally when the ObjectPool functions are called.
    private Func<T> onCreateFn;
    private Action<IPooleableObject<T>> onDestroyFn;
    private Action<IPooleableObject<T>> onGetFn;
    private Action<IPooleableObject<T>> onReleaseFn;

    #endregion

    #region Constructor

    public ObjectPool(
        Func<T> newOnCreateFn = null,
        Action<IPooleableObject<T>> newOnGetFn = null,
        Action<IPooleableObject<T>> newOnReleaseFn = null,
        Action<IPooleableObject<T>> newOnDestroyFn = null,
        int initialCapacity = 100,
        int maxCapacity = 1000,
        bool preallocate = true)
    {
        this.onCreateFn = newOnCreateFn;
        this.onDestroyFn = newOnDestroyFn;
        this.onGetFn = newOnGetFn;
        this.onReleaseFn = newOnReleaseFn;
        this.objects = new List<PooleableObjectWrapper<T>>(initialCapacity);
        this.activeObjects = 0;
        this.initialCapacity = initialCapacity;
        this.maxCapacity = maxCapacity;

        // Preallocate everything to prevent memory fragmentation.
        if (preallocate)
        {
            for (int i = 0; i < initialCapacity; ++i)
            {
                var obj = CreateObject();
                var wrapper = new PooleableObjectWrapper<T>(obj, false);
                objects.Add(wrapper);
            }
        }
    }

    #endregion

    // The main dish of an ObjectPool: Get() and Release()
    #region PrimaryPublicMethods

    public IPooleableObject<T> Get()
    {
        for (int i = 0; i < objects.Count; ++i)
        {
            if (!objects[i].GetActive())
            {
                objects[i].SetActive(true);
                onGetFn(objects[i]);
                ++activeObjects;
                return objects[i];
            }
        }

        if(CanRegrow())
        {
            T obj = CreateObject();
            var wrapper = new PooleableObjectWrapper<T>(obj, true);
            wrapper.SetActive(true);
            onGetFn(wrapper);
            ++activeObjects;
            objects.Add(wrapper);
            return wrapper;
        }

        return null;
    }

    public void Release(IPooleableObject<T> obj)
    {
        if(onReleaseFn != null)
            onReleaseFn(obj);
        obj.SetActive(false);
        --activeObjects;
    }

    public void Clear()
    {
        if (onDestroyFn != null)
        {
            foreach (var obj in objects)
            {
                onDestroyFn(obj);
            }
        }
        objects.Clear();
        activeObjects = 0;
    }

    #endregion

    // Things like getters and such.
    #region SecondaryPublicMethods

    public int GetActiveCount()
    {
        return this.activeObjects;
    }

    public int GetCount()
    {
        return this.objects.Count;
    }

    public int GetInactiveCount()
    {
        return this.objects.Count - this.activeObjects;
    }

    #endregion

    #region PrivateMethods

    private T CreateObject()
    {
        if (onCreateFn != null)
            return onCreateFn();
        return default(T);
    }

    private bool CanRegrow()
    {
        return objects.Count < maxCapacity;
    }

    #endregion

}
