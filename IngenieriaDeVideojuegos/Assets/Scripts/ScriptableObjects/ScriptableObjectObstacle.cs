using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class ScriptableObjectObstacle : ScriptableObject
{
    #region Variables

    // Elementos comunes a todos los obstaculos de cierto tipo.

    private GameObject target;

    [SerializeField] private AsteroidTypeData defaultData;
    [SerializeField] private AsteroidTypeData projectileData;
    [SerializeField] private AsteroidTypeData explosiveData;
    [SerializeField] private AsteroidTypeData shooterData;

    #endregion

    #region Getters

    public GameObject Target { get { return target; } set { target = value; } }

    #endregion

    #region PublicMethods

    public AsteroidTypeData GetTypeData(AsteroidType type)
    {
        switch (type)
        {
            default:
                return defaultData;
            case AsteroidType.Projectile:
                return projectileData;
            case AsteroidType.Explosive:
                return explosiveData;
            case AsteroidType.Shooter:
                return shooterData;
        }
    }

    public float GetSpeed(AsteroidType type)
    {
        return GetTypeData(type).speed;
    }

    public float GetScale(AsteroidType type)
    {
        return GetTypeData(type).scale;
    }

    public Sprite GetSpriteOn(AsteroidType type)
    {
        return GetTypeData(type).spriteOn;
    }

    public Sprite GetSpriteOff(AsteroidType type)
    {
        return GetTypeData(type).spriteOff;
    }

    #endregion
}
