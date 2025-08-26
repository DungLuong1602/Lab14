using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyZigzag : MonoBehaviour
{
    public float speed = 5f;
    public float frequency = 2f; // tần số zigzag
    public float magnitude = 1f; // biên độ zigzag
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.position = new Vector3(startPos.x + Mathf.Sin(Time.time * frequency) * magnitude, transform.position.y, 0);
    }
}
