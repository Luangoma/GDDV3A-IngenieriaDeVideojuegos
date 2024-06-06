using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool<T> where T : class
{
    public IPooleableObject<T> Get();
    
    public void Release(IPooleableObject<T> objectToRelease);

    public int GetActiveCount();
    
    public int GetCount();

    public int GetInactiveCount();

    public void Clear();

}
