using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMovement : MonoBehaviour
{
    public RectTransform sliderMeter; // The moving black bar
    public RectTransform sliderBar;   // The entire red and green slider bar
    public static float speed = 2f;          // Current speed of the boat
    public static float maxSpeed = 10f;      // Maximum speed of the boat
    public float minSpeed = 2f;       // Minimum speed of the boat
    public float boostAmount = 2f;    // Speed increase on hitting green
    public float slowAmount = 0.5f;   // Speed decrease on hitting red
    public float decayRate = 0.5f;    // Speed decrease per second after decay starts
    public float decayInterval = 2f;  // Time before speed starts decaying
    [SerializeField] private float turnSpeed = 200f;  // Turning speed
    public float greenZonePercent = 0.3f; // Green zone percentage in the slider bar
    private bool canBoost = true;     // Prevents repeated boosting
    private bool isDecaying = false;  // Tracks if speed is currently decaying

    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
        transform.SetPositionAndRotation(new Vector3(-9.5f, 0.5f, 0f), new Quaternion());
    }
    void Update()
    {
        // Move the boat forward
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);

        // Rotate the boat
        float turnAmount = turnSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnAmount); // Left turn
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * turnAmount); // Right turn
        }

        // Handle speed decay
        HandleSpeedDecay();

        // Handle boosting with Spacebar
        if (Input.GetKeyDown(KeyCode.Space) && canBoost)
        {
            CheckBoost();
        }

        // Win condition (x position of finish line)
        if (transform.position.x > 47.5f)
        {
            OpenWinScreen();
        }
    }

    void CheckBoost()
    {
        // Green zone detection
        float meterX = sliderMeter.anchoredPosition.x;
        float barWidth = sliderBar.rect.width * 2;
        float greenHalfWidth = (barWidth * greenZonePercent) / 2f;
        float greenCenter = sliderBar.anchoredPosition.x;
        float greenMinX = greenCenter - greenHalfWidth;
        float greenMaxX = greenCenter + greenHalfWidth;

        // Boost if inside Green, Slow if inside red
        if (meterX >= greenMinX && meterX <= greenMaxX)
        {
            // Inside the green zone = Increase speed and start decay timer
            speed = Mathf.Min(speed + boostAmount, maxSpeed);
            isDecaying = false;
            Invoke(nameof(StartDecay), decayInterval); // Start decay after the interval
        }
        else
        {
            // Inside the red zone = Decrease speed
            speed = Mathf.Max(speed - slowAmount, minSpeed);
        }

        canBoost = false; // Prevent immediate re-boost
        Invoke(nameof(ResetBoost), 0.5f); // Cooldown
    }

    void StartDecay()
    {
        isDecaying = true;
    }

    void HandleSpeedDecay()
    {
        if (isDecaying && speed > minSpeed)
        {
            // Gradually reduce speed by decayRate after decayInterval ends
            speed = Mathf.Max(speed - (decayRate * Time.deltaTime), minSpeed);
        }
    }

    void ResetBoost()
    {
        canBoost = true;
    }

    void OpenWinScreen()
    {
        SceneManager.LoadScene("WinScene");
    }
}