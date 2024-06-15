using System.Collections;
using System.Collections.Generic;
using System;

public class ObservableVariable<T>
{
    #region Variables

    private T data;
    public Action<T, T> OnValueChanged;
    
    #endregion

    #region GettersAndSetters
    
    T Value { get { return data; } set { T temp = data; data = value; OnValueChanged?.Invoke(temp, data); } }
    
    #endregion

    #region PublicMethods
    
    public void ClearObservers()
    {
        OnValueChanged = null;
    }

    public void AddObserver(Action<T, T> action)
    {
        OnValueChanged += action;
    }

    public void RemoveObserver(Action<T, T> action)
    {
        OnValueChanged -= action;
    }
    
    #endregion
}
