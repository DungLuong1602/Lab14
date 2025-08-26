using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavwManagement : MonoBehaviour 
{
    public GameObject enemyPrefab; // Prefab của kẻ thù
    public int rows = 3; // Số hàng
    public int cols = 5; // Số cột
    public int count = 7;
    public float radius = 4;
    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        SpawnWave1();
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("enemy").Length == 0);
        SpawnWave2();
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("enemy").Length == 0);
        SpawnWave3();
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("enemy").Length == 0);

        // Tất cả các đợt đã hoàn thành
        Debug.Log("All waves completed!");
    }
    void SpawnWave1()
    {
        for (int i = 0; i < rows ; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 targetPos = new Vector3(j - 2, i + 3, 0);
                Vector3 spawnPos = targetPos + new Vector3(0,6,0);

                GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                enemy.GetComponent<EnemyControl>().hp = 1;
                //gameObject.tag = "enemy";

                var move = enemy.AddComponent<EnemyMovingToTarget>();
                move.targetPosition = targetPos;
                move.speed = 2f;
            }
        }
    }

    void SpawnWave2()
    {
        Vector3 center = new Vector3(0, 2, 0);

        for (int i = 0; i <count; i++)
        {
            float angle = i * Mathf.PI * 2 / count;
            Vector3 targetPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius + center;
            Vector3 spawnPos = targetPos + new Vector3(0, 6, 0);

            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<EnemyControl>().hp = 2;
            //gameObject.tag = "enemy";

            var move = enemy.AddComponent<EnemyMovingToTarget>();
            move.targetPosition = targetPos;
            move.speed = 2f;

            EnemyCircleMovement circleMove = enemy.AddComponent<EnemyCircleMovement>();
            circleMove.Center = center;
            circleMove.Radius = radius;
            circleMove.Speed = 30f;
            circleMove.enabled = false; // Vô hiệu hóa ban đầu

            // Kích hoạt di chuyển vòng tròn khi kẻ thù đến vị trí mục tiêu
            StartCoroutine(EnableCircleAfterReach(move, circleMove));
        }
    }

    IEnumerator EnableCircleAfterReach(EnemyMovingToTarget mover, EnemyCircleMovement circle)
    {
        yield return new WaitUntil(() => mover.ReachedTarget());
        circle.enabled = true;
        Destroy(mover); // không cần script moveToTarget nữa
    }


    void SpawnWave3()
    {
        for (int i = 0;  i < 30; i++)
        {
            Vector3 spawnPos = new Vector3((i % 10) - 5, 6 + (i / 10), 0);
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<EnemyControl>().hp = 2;
            //enemy.tag = "enemy";

            enemy.AddComponent<EnemyZigzag>();
        }
    }


}
