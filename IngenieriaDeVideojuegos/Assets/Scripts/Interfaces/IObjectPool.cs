using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool<T> where T : class
{
    public T Get();
    public void Release(T objectToRelease);

    public int GetActiveCount();
    public int GetCount();
    public int GetInactiveCount();

    public bool GetAllowRegrow();
    public void SetAllowRegrow(bool newAllowRegrow);

}
