using System;
using UnityEngine;

public enum AsteroidType
{
    Default = 0,
    Projectile,
    Explosive,
    Shooter,
    NUM_TYPES
}

[Serializable]
public struct AsteroidTypeData
{
    public float speed;
    public float scale;
    public Sprite spriteOn;
    public Sprite spriteOff;
}
