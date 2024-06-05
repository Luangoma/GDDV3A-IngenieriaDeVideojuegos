using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool
{
    public IPooleableObject Get();
    public void Release(IPooleableObject objectToRelease);

    public int GetActiveCount();
    public int GetCount();
    public int GetInactiveCount();

    public bool GetAllowRegrow();
    public void SetAllowRegrow(bool newAllowRegrow);

}
