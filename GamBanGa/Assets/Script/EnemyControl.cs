using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int hp = 1;
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
        Destroy(gameObject);
    }
}
