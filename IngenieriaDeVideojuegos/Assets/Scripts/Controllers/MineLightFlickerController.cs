using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineLightFlickerController : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject spriteOn;
    [SerializeField] private GameObject spriteOff;
    [SerializeField] private float flickerTime;

    private float elapsedTime = 0.0f;
    private bool isGlowing = false;

    #endregion

    #region MonoBehaviour
    
    void Start()
    {
        
    }

    void Update()
    {
        float delta = Time.deltaTime;
        UpdateFlicker(delta);
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods

    private bool AllComponentsAreValid()
    {
        return this.spriteOn != null && this.spriteOff != null;
    }

    private void UpdateFlicker(float delta)
    {
        if (!AllComponentsAreValid())
            return;
        elapsedTime += delta;
        if (elapsedTime >= flickerTime)
        {
            SwitchSprites();
            elapsedTime -= flickerTime;
        }
    }

    private void SwitchSprites()
    {
        SetGlow(!this.isGlowing);
    }

    private void SetGlow(bool glowOn)
    {
        this.isGlowing = glowOn;
        this.spriteOn.gameObject.SetActive(glowOn);
        this.spriteOff.gameObject.SetActive(!glowOn);
    }

    #endregion
}
