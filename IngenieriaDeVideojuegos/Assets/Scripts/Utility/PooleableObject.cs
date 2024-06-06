using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class PooleableGameObject : MonoBehaviour, IPooleableObject<PooleableGameObject>
{
    public bool GetActive()
    {
        return this.gameObject.activeSelf;
    }
    public void SetActive(bool newActive)
    {
        this.gameObject.SetActive(newActive);
    }

    public void Reset()
    {}

    public PooleableGameObject Clone()
    {
        PooleableGameObject obj = Instantiate<PooleableGameObject>(this, this.transform.position, this.transform.rotation);
        this.SetActive(false);
        return this;
    }
}
*/