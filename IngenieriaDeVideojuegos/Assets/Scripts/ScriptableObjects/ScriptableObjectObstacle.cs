using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle", menuName = "Obstacle")]
public class ScriptableObjectObstacle : ScriptableObject
{
    // Elementos comunes a todos los obstaculos de cierto tipo
    // public string objectName;
    public GameObject target;
    public float speed = 20;
}
