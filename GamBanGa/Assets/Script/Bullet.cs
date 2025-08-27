using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public bool IsActive = false;
    public int Damage = 1;

    // Update is called once per frame
    void Update()
    {
        if(IsActive)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if(transform.position.y > 6.0f)
            {
                IsActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void Shoot(Vector3 startpoint)
    {
        transform.position = startpoint;
        IsActive = true;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy") && IsActive)
        {
            collision.GetComponent<EnemyControl>().TakeDamage(Damage);
        }
        if(collision.CompareTag("Boss") && IsActive)
        { 
            collision.GetComponent<BossControl>().BossTakeDamage(Damage);
        }
        IsActive = false;
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("boundary") && IsActive)
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }
}
