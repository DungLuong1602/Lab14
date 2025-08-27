using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChickenPooling : MonoBehaviour
{
    public static ChickenPooling Instance;
    public GameObject ChickenPrefab;
    public int poolSize = 30;

    private List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        // Singleton
         Instance = this;

        // Tạo sẵn các chicken
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(ChickenPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject SpawnChicken(Vector2 position, Vector2 BaseVelo)
    {
        int SpawnChance = Random.Range(3,6);
        for (int i = 0; i < SpawnChance; i++)
        {
            foreach (var obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.transform.position = position;
                    obj.SetActive(true);

                    ChickenLeg leg = obj.GetComponent<ChickenLeg>();
                    if (leg != null)
                    {
                        Vector2 impulse = BaseVelo * 0.5f + Random.insideUnitCircle * 2f;
                        float torque = Random.Range(-2f, 2f);
                        leg.Launch(impulse, torque);
                    }
                    return obj;
                }
            }
        }        
        return null;
    }

    }



