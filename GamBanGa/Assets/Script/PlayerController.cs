using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform firepoint;
    public int Hp = 3;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 targetPos = new Vector3(mousePos.x, mousePos.y, 0);

        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);

    }

    private void Shooting()
    {
         GameObject bullet = ObjectPooling.Instance.GetBullet();
         bullet.GetComponent<Bullet>().Shoot(firepoint.position);

    }
    
    public void TakeDam(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add death effects or animations here if needed
        Destroy(gameObject);
    }

}
