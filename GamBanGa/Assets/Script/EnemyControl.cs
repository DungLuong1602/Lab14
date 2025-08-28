using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int hp = 1;
    private Animator ani;
    public float dropInterval = 2.0f;
    private float dropTimer;
    public Transform Firepoint;
    private Rigidbody2D rb;
    private void Start()    
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SetRandomTimeInterval();
    }

    private void Update()
    {
        dropTimer -= Time.deltaTime;

        if (dropTimer <= 0f)
        {
            Dropping();
            SetRandomTimeInterval();
        }
    }
    public void TakeDamage(int damage)
    {
        AudioManager.Instance.PlaySFX("Chick_hurt1");
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        AudioManager.Instance.PlaySFX("Chicken_death1");
        Vector2 currentVel = rb != null ? rb.linearVelocity : Vector2.zero;
        ChickenPooling.Instance.SpawnChicken(transform.position,currentVel);
        ani.SetBool("IsDead", true);
        Destroy(gameObject,0.3f);
    }

    private void Dropping()
    {
        GameObject egg = EggPooling.Instance.GetEgg();
        egg.GetComponent<EggDam>().Drop(Firepoint.position);
    }

    public void SetRandomTimeInterval()
    {
        dropInterval = Random.Range(4f, 9f);
        dropTimer = dropInterval;
    }
}
