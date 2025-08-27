using UnityEngine;

public class BossControl : MonoBehaviour
{
    public int hp = 20;
    public Animator ani;
    public float dropInterval = 2.0f;
    private float dropTimer;
    public Transform[] Firepoint;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        SetRandomTimeInterval();
    }
    private void Update()
    {
        dropTimer -= Time.deltaTime;

        if (dropTimer <= 0f)
        {
            BossDropping();
            SetRandomTimeInterval();
        }
    }
    public void BossTakeDamage(int damage)
    {
        AudioManager.Instance.PlaySFX("Chick_hurt1");
        hp -= damage;
        if (hp <= 0)
        {
            BossDie();
        }
    }
    private void BossDropping()
    {
        GameObject egg = EggPooling.Instance.GetEgg();
        int randomIndex = Random.Range(0, Firepoint.Length);
        Transform firepoint = this.Firepoint[randomIndex];
        egg.GetComponent<EggDam>().Drop(firepoint.position);
    }
    private void BossDie()
    {
        AudioManager.Instance.PlaySFX("Chicken_death1");
        Vector2 currentVel = rb != null ? rb.linearVelocity : Vector2.zero;
        ChickenPooling.Instance.SpawnChicken(transform.position, currentVel);
        ani.SetBool("IsDead", true);
        Destroy(gameObject, 0.5f);
    }
    public void SetRandomTimeInterval()
    {
        dropInterval = Random.Range(3, 7f);
        dropTimer = dropInterval;
    }
}
