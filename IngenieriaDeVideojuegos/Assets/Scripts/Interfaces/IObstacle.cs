using UnityEngine;

public interface IObstacle
{
    public void FollowTarget(float delta);
    public void OnCollideTarget(Collision collision);
    public float GetDistanceFromTarget();
    public void SetType(AsteroidType type);
    public void SetRandomType();
}