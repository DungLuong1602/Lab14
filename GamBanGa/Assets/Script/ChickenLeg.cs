using UnityEngine;

public class ChickenLeg : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rb;
    public float life = 5f;
    float timer = 0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= life)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("eating");
            PlayerController player = collision.GetComponent<PlayerController>();
            if(player != null)
            {
                player.GetPoint(100);
            }
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        timer = 0f;
        if(rb == null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.rotation = Random.Range(0f, 360f);
        }
    }

    public void Launch(Vector2 impulse, float Torque)
    {
        if(rb != null)
        {
            rb.AddForce(impulse, ForceMode2D.Impulse);
            rb.AddTorque(Torque, ForceMode2D.Impulse);
        }

    }
}
