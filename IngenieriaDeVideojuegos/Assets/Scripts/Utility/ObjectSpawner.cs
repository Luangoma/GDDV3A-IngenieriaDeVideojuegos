using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectSpawner
{
    #region PublicMethods

    public static GameObject SpawnGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return InstantiateGameObject(prefab, position, rotation);
    }

    public static GameObject SpawnGameObject(GameObject prefab)
    {
        return InstantiateGameObject(prefab, Vector3.zero, Quaternion.identity);
    }

    #endregion

    #region PrivateMethods

    private static GameObject InstantiateGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject game_object = Object.Instantiate(prefab, position, rotation);
        return game_object;
    }

    #endregion
}
