using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlameController : MonoBehaviour
{
    #region Variables

    [SerializeField] PlayerController playerController;
    [SerializeField] float minLength = 0;
    [SerializeField] float maxLength = 1.5f;

    private const float scaleFactor = 10;

    #endregion

    #region MonoBehaviour

    void Start()
    {

    }

    void Update()
    {
        float delta = Time.deltaTime;
        UpdateFlameLength(delta);
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods

    private bool AllComponentsAreValid()
    {
        return this.playerController != null;
    }

    private void UpdateFlameLength(float delta)
    {
        if (!AllComponentsAreValid())
            return;
        float length = Mathf.Lerp(minLength, maxLength, playerController.GetForwardLinearVelocity() * delta * scaleFactor);
        SetFlameLength(length);
    }

    private void SetFlameLength(float length)
    {
        length = Mathf.Clamp(length, minLength, maxLength);
        this.transform.localScale = new Vector3(this.transform.localScale.x, length, this.transform.localScale.z);
        print($"length is : {this.transform.localScale.y}");
    }

    #endregion
}
