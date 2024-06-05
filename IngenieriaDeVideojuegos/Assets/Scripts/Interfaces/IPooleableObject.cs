using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject
{
    public bool GetActive();
    public void SetActive(bool newActive);
    public void Reset();
    public IPooleableObject Clone();
}
