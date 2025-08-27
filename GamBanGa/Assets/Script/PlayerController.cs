using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform firepoint;
    public int Hp = 3;
    private Rigidbody2D rb;
    private string currentBulletTag = "Bulletlevel1";
    private int level = 1;
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
            AudioManager.Instance.PlaySFX("a");
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
        GameObject bullet = ObjectPooling.Instance.SpawnFromPool(currentBulletTag, firepoint.position, Quaternion.identity);
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
        AudioManager.Instance.PlaySFX("dead");
        Destroy(gameObject);
    }

    public void AddLevel()
    {
        level++;
        if(level == 2)
        {
            UpgradeWeapon("Bulletlevel2");
        }
        else if(level == 3)
        {
            UpgradeWeapon("Bulletlevel3");
        }
    }
    public void UpgradeWeapon(string Tag)
    {
        currentBulletTag = Tag;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            //AudioManager.Instance.PlaySFX("Player_hurt");
            TakeDam(1);
            EnemyControl enemy = collision.gameObject.GetComponent<EnemyControl>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        }
        //    if(collision.gameObject.CompareTag("Boss"))
        //    {
        //        //AudioManager.Instance.PlaySFX("Player_hurt");
        //        TakeDam(1);
        //        BossControl boss = collision.gameObject.GetComponent<BossControl>();
        //        if (boss != null)
        //        {
        //            boss.TakeDamage(1);
        //        }
        //    }
        
    }
}
