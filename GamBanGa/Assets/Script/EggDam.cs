using UnityEngine;

public class EggDam : MonoBehaviour
{
    public float speed = 2.0f;
    public bool IsActive = false;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (IsActive)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y < -6.0f)
            {
                IsActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void Drop(Vector3 startpoint)
    {
        transform.position = startpoint;
        IsActive = true;
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Explosion", true);
            collision.GetComponent<PlayerController>().TakeDam(1);
            //IsActive = false;
            //gameObject.SetActive(false);
            //Destroy(gameObject,0.3f);
            EggPooling.Instance.ReturnEgg(gameObject);
        }
    }
}
