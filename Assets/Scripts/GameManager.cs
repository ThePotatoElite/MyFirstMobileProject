using UnityEngine;
public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Rigidbody playerRigidbody;
    public float jumpForce = 1f;
    [Header("Jump Parameters")]
    public int tapRequiredToJump = 2;
    public float maxIntervalBetweenTaps = 0.5f;
    private int tapCounter = 0;
    private float timeLeftForCounterReset;
    private void Start()
    {
        timeLeftForCounterReset = maxIntervalBetweenTaps;
    }
    void Update()
    {
        HandleTouchInput();
        ResetTapCounter();
    }
    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    PlayerTapped();
                }
            }
        }
    }
    private void PlayerTapped()
    {
        tapCounter++;
        if (tapCounter >= tapRequiredToJump)
        {
            PlayerJump();
            tapCounter = 0;
        }
    }
    public void PlayerJump()
    {
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetTapCounter()
    {
        timeLeftForCounterReset -= Time.deltaTime;
        if (timeLeftForCounterReset <= 0)
        {
            tapCounter = 0;
            timeLeftForCounterReset = maxIntervalBetweenTaps;
        }
    }
}