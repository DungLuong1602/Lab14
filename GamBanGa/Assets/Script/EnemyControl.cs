using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int hp = 1;
    private Animator ani;
    public float dropInterval = 2.0f;
    private float dropTimer;
    public Transform Firepoint;
    private void Start()
    {
        ani = GetComponent<Animator>();
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
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        ani.SetBool("IsDead",true);
        Destroy(gameObject,0.5f);
    }

    private void Dropping()
    {
        GameObject egg = EggPooling.Instance.GetEgg();
        egg.GetComponent<EggDam>().Drop(Firepoint.position);
    }

    public void SetRandomTimeInterval()
    {
        dropInterval = Random.Range(7f, 15f);
        dropTimer = dropInterval;
    }
}
