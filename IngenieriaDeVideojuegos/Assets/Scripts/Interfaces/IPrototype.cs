using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrototype<T> where T : class
{
    public T Clone();
}
