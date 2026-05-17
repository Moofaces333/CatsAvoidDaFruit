using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public ObstaclePoolItem[] obstacles;

     private Dictionary<GameObject, List<GameObject>>
        poolDictionary =
        new Dictionary<GameObject, List<GameObject>>();

    void Start()
    {
        foreach (ObstaclePoolItem item in obstacles)
        {
            List<GameObject> objectPool =
                new List<GameObject>();

            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject obj =
                    Instantiate(item.prefab);

                obj.SetActive(false);

                objectPool.Add(obj);
            }

            poolDictionary.Add(item.prefab, objectPool);
        }
    }

    public GameObject GetObstacle(GameObject prefab)
    {
        List<GameObject> pool =
            poolDictionary[prefab];

        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);

                return obj;
            }
        }

        // Optional expansion
        GameObject newObj =
            Instantiate(prefab);

        newObj.SetActive(true);

        pool.Add(newObj);

        return newObj;
    }
}