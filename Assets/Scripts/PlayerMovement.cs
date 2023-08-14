using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 69;
    [SerializeField] private Rigidbody2D rb;
    private float lastTouchTime = 0f;
    private float doubleTapDelay = 0.7f;
    void Update()
    {
        DoubleTap();
    }
    private void DoubleTap()
    {
        if (Input.anyKeyDown)
        {
            if (Time.time - lastTouchTime <= doubleTapDelay)
            {
                rb.AddForce(Vector2.up * jumpHeight * Time.deltaTime, ForceMode2D.Impulse);
            }
            lastTouchTime = Time.time;
        }
    }
}