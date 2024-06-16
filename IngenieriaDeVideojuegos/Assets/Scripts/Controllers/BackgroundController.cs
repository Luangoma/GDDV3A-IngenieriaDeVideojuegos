using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    #region Variables

    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private float offsetFactor = 1.0f;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region PublicMethods

    public void SetBackgroundOffset(Vector3 targetPosition, float delta)
    {
        this.gameObject.transform.position = targetPosition;
        Vector3 offset3D = Vector3.zero - targetPosition;
        Vector2 offset2D = new Vector2(offset3D.x, offset3D.y);
        offset2D *= offsetFactor;
        offset2D *= delta;
        mesh.materials[0].mainTextureOffset = offset2D;
    }

    #endregion

    #region PrivateMethods
    #endregion
}
