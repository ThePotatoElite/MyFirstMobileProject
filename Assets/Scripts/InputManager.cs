using TMPro;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int tapRequiredToJump = 2;
    [SerializeField] private float maxIntervalBetweenTaps;
    [Header("Debug texts")]
    [SerializeField] private TextMeshProUGUI debugTouchCountNumber;
    [SerializeField] private TextMeshProUGUI debugTouchesText;
    private int tapCounter = 0;
    private float timeLeftForCounterReset;
    private void PlayerTapped()
    {
        tapCounter++;
        if (tapCounter >= tapRequiredToJump)
        {
            gameManager.PlayerJump();
            tapCounter = 0;
        }
    }
    private void Start()
    {
        timeLeftForCounterReset = maxIntervalBetweenTaps;
    }
    void Update()
    {
        int touchCount = Input.touchCount;
        debugTouchCountNumber.text = touchCount.ToString();
        debugTouchesText.text = string.Empty;
        if(touchCount > 0)
        { 
            for (int i = 0; i < touchCount; i++)
            {
                if (Input.touches[i].phase  == TouchPhase.Began ) 
                {
                    PlayerTapped();    
                }
            }
        }
        timeLeftForCounterReset -= Time.deltaTime;
        if (timeLeftForCounterReset <= 0)
        {
            tapCounter = 0;
            timeLeftForCounterReset = maxIntervalBetweenTaps;
        }
    }
}