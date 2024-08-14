using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation) {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name); // lambda expression

        /*
        equivalent: 
        PooledObjectInfo pool = null;
        foreach(PooledObjectInfo p in ObjectPools) {
            if (p.LookupString == objectToSpawn.name) {
                pool = p;
                break;
            }
        }
        */

        // If the pool doesn't exist, create it
        if (pool == null) {
            pool = new PooledObjectInfo() {LookupString = objectToSpawn.name};
            ObjectPools.Add(pool);
        }

        // Check if there are any inactive objects in the pool 
        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

        if (spawnableObj == null) {
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        }

        else {
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;

    }

    public static void ReturnObjectToPool(GameObject obj) {
        string goName = obj.name.Substring(0, obj.name.Length - 7); // by taking off 7, we are removing the (Clone) from the name of the passed in obj

        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

        if (pool == null) {
            Debug.LogWarning("Trying to rlease an object that is not pooled: " + obj.name);
        }

        else {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }

}

public class PooledObjectInfo {
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
