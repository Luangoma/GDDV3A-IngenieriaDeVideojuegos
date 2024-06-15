using System;
using UnityEngine;

public enum AsteroidType
{
    Projectile,
    Explosive,
    Shooter
}

[Serializable]
public struct AsteroidTypeData
{
    public float speed;
    public float scale;
    public Sprite spriteOn;
    public Sprite spriteOff;
}
