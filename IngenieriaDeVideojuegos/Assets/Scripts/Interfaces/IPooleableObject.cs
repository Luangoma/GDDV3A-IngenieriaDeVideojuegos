using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject<T> where T : class
{
    public bool GetActive();
    public void SetActive(bool newActive);
    public T GetObject();

}
