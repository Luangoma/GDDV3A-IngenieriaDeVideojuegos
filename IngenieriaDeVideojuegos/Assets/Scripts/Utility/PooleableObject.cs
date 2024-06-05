using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooleableObject : MonoBehaviour, IPooleableObject
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

    public IPooleableObject Clone()
    {
        GameObject obj = Instantiate(gameObject, this.transform.position, this.transform.rotation);
        IPooleableObject ans = obj.GetComponent<IPooleableObject>();
        this.SetActive(false);
        return ans;
    }
}
