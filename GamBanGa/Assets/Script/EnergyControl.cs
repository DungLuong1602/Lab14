using UnityEngine;

public class EnergyControl : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("levelUp");
            PlayerController player = collision.GetComponent<PlayerController>();
            if(player != null)
            {
                player.AddLevel();
            }
            Destroy(gameObject);
        }
    }
}
