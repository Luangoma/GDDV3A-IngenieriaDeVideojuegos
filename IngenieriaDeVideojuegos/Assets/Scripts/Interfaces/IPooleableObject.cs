using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject<T> : IPrototype<T> where T : class
{
    public bool GetActive();
    public void SetActive(bool newActive);
    public void Reset();

}
