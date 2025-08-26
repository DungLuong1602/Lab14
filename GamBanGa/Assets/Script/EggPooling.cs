using System.Collections.Generic;
using UnityEngine;

public class EggPooling : MonoBehaviour
{
    public static EggPooling Instance;

    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> eggPool = new Queue<GameObject>();

    private void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Tạo sẵn các egg
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(eggPrefab);
            obj.SetActive(false);
            eggPool.Enqueue(obj);
        }
    }

    public GameObject GetEgg()
    {
        if (eggPool.Count > 0)
        {
            GameObject obj = eggPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(eggPrefab);
            return obj;
        }
    }

    public void ReturnEgg(GameObject obj)
    {
        obj.SetActive(false);
        eggPool.Enqueue(obj);
    }
}

