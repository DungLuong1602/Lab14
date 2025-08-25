using UnityEngine;

public class EnemyMovingToTarget : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2.0f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public bool ReachedTarget()
    {
        return Vector3.Distance(transform.position, targetPosition) < 0.1f;
    }
}
