using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    #region Variables

    [SerializeField] private Camera cameraReference;
    [SerializeField] private CameraTarget followTarget;
    [SerializeField] private UpdateType updateType = UpdateType.Update;
    [SerializeField] private bool updatePosition;
    [SerializeField] private bool updateRotation;
    [SerializeField] private bool lerpCameraTransform;
    [SerializeField] private float lerpCameraFactor;

    #endregion

    #region PrivateEnums

    private enum UpdateType
    {
        Update,
        FixedUpdate,
        LateUpdate
    }

    #endregion

    #region MonoBehaviour

    void Start()
    {

    }

    void Update()
    {
        if (updateType == UpdateType.Update)
            UpdateCamera(Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (updateType == UpdateType.FixedUpdate)
            UpdateCamera(Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        if (updateType == UpdateType.LateUpdate)
            UpdateCamera(Time.deltaTime);
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods

    private void UpdateCamera(float delta)
    {
        if (cameraReference == null || followTarget == null)
            return;
        if (lerpCameraTransform)
        {
            if (updatePosition) cameraReference.transform.position = Vector3.Lerp(cameraReference.transform.position, followTarget.cameraSocket.position, lerpCameraFactor * delta);
            if (updateRotation) cameraReference.transform.rotation = Quaternion.Lerp(cameraReference.transform.rotation, followTarget.cameraSocket.rotation.normalized, lerpCameraFactor * delta);
        }
        else
        {
            if (updatePosition) cameraReference.transform.position = followTarget.cameraSocket.position;
            if (updateRotation) cameraReference.transform.rotation = followTarget.cameraSocket.rotation;
        }
    }

    #endregion
}
