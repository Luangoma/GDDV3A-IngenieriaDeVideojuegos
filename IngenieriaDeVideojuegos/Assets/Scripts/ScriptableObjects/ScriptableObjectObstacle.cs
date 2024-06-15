using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class ScriptableObjectObstacle : ScriptableObject
{
    #region Variables

    // Elementos comunes a todos los obstaculos de cierto tipo.

    private GameObject target;

    // Speeds:
    [Header("Speed Data")]
    [SerializeField] private float defaultSpeed = 20;
    [SerializeField] private float projectileSpeed = 20;
    [SerializeField] private float explosiveSpeed = 20;
    [SerializeField] private float shooterSpeed = 20;

    // Sprites (ON):
    [Header("Sprites (ON)")]
    [SerializeField] private Sprite defaultSpriteOn;
    [SerializeField] private Sprite projectileSpriteOn;
    [SerializeField] private Sprite explosiveSpriteOn;
    [SerializeField] private Sprite shooterSpriteOn;

    // Sprites (OFF):
    [Header("Sprites (OFF)")]
    [SerializeField] private Sprite defaultSpriteOff;
    [SerializeField] private Sprite projectileSpriteOff;
    [SerializeField] private Sprite explosiveSpriteOff;
    [SerializeField] private Sprite shooterSpriteOff;


    #endregion

    #region Getters

    public GameObject Target { get { return target; } set { target = value; } }

    #endregion

    #region PublicMethods

    public float GetSpeed(AsteroidType type)
    {
        switch (type)
        {
            default:
                return defaultSpeed;
            case AsteroidType.Projectile:
                return projectileSpeed;
            case AsteroidType.Explosive:
                return explosiveSpeed;
            case AsteroidType.Shooter:
                return shooterSpeed;
        }
    }

    public Sprite GetSpriteOn(AsteroidType type)
    {
        switch (type)
        {
            default:
                return defaultSpriteOn;
            case AsteroidType.Projectile:
                return projectileSpriteOn;
            case AsteroidType.Explosive:
                return explosiveSpriteOn;
            case AsteroidType.Shooter:
                return shooterSpriteOn;
        }
    }

    public Sprite GetSpriteOff(AsteroidType type)
    {
        switch (type)
        {
            default:
                return defaultSpriteOff;
            case AsteroidType.Projectile:
                return projectileSpriteOff;
            case AsteroidType.Explosive:
                return explosiveSpriteOff;
            case AsteroidType.Shooter:
                return shooterSpriteOff;
        }
    }

    #endregion
}
