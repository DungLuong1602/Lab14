using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int hp = 1;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
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
        // Add death effects or animations here if needed
        ani.SetBool("IsDead",true);
        Destroy(gameObject,0.5f);
    }
}
