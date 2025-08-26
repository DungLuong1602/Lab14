using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed = 0.2f;  // tốc độ cuộn
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = Vector2.zero;
    }

    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime; // cuộn xuống theo trục Y
        rend.material.mainTextureOffset = offset;
    }
}
