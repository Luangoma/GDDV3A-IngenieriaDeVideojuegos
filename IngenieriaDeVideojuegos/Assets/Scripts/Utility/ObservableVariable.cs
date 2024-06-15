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
    
    public T Value { get { return data; } set { T temp = data; data = value; OnValueChanged?.Invoke(temp, data); } }

    #endregion

    #region Constructors

    public ObservableVariable(T initialValue = default(T))
    {
        this.data = initialValue;
        OnValueChanged = null;
    }

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
