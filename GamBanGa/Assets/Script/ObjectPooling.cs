using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{
    public GameObject objectPrefab;
    public static ObjectPooling Instance;
    public int poolSize = 20;


    private List<GameObject> pool;
    
    void Awake()
    {
        Instance = this;
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        foreach (var obj in pool)
        {
            if(!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject newObj = Instantiate(objectPrefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }

}
