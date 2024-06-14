using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectSpawner
{
    #region PublicMethods

    public static GameObject SpawnGameObject(GameObject prefab, Vector3 position, Quaternion rotation, bool spawnActive = true)
    {
        return InstantiateGameObject(prefab, position, rotation, spawnActive);
    }

    public static GameObject SpawnGameObject(GameObject prefab, bool spawnActive = true)
    {
        return InstantiateGameObject(prefab, Vector3.zero, Quaternion.identity, spawnActive);
    }

    public static GameObject SpawnGameObject(GameObject prefab, Transform transform, bool spawnActive = true)
    {
        return InstantiateGameObject(prefab, transform.position, transform.rotation, spawnActive);
    }

    #endregion

    #region PrivateMethods

    private static GameObject InstantiateGameObject(GameObject prefab, Vector3 position, Quaternion rotation, bool spawnActive)
    {
        GameObject obj = Object.Instantiate(prefab, position, rotation);
        obj.SetActive(spawnActive);
        return obj;
    }

    #endregion
}
