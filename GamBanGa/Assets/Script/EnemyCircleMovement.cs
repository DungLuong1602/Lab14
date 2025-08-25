using UnityEngine;

public class EnemyCircleMovement : MonoBehaviour
{
    public Vector3 Center;
    public float Radius;
    public float Speed = 1.0f;
    private float angle;

    private void Start()
    {
        Vector3 offset = transform.position - Center;
        angle = Mathf.Atan2(offset.y, offset.x);
        Radius = offset.magnitude;
    }

    void Update()
    {
        angle += Speed * Time.deltaTime * Mathf.Deg2Rad;
        float x = Radius * Mathf.Cos(angle);
        float y = Radius * Mathf.Sin(angle);
        transform.position = Center + new Vector3(x, y, 0);
    }
}
