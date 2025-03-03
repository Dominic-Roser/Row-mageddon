using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialMovement : MonoBehaviour
{
    public RectTransform sliderMeter; // The moving black bar
    public RectTransform sliderBar;   // The entire red and green slider bar
    public float speed = 0f;          // Current speed of the boat
    public float maxSpeed = 10f;      // Maximum speed of the boat
    public float minSpeed = 2f;       // Minimum speed of the boat
    public float boostAmount = 2f;    // Speed increase on hitting green
    public float slowAmount = 0.5f;   // Speed decrease on hitting red
    public float decayRate = 0.5f;    // Speed decrease per second after decay starts
    public float decayInterval = 2f;  // Time before speed starts decaying
    [SerializeField] private float turnSpeed = 200f;  // Turning speed
    public float greenZonePercent = 0.3f; // Green zone percentage in the slider bar
    private bool canBoost = true;     // Prevents repeated boosting
    private bool isDecaying = false;  // Tracks if speed is currently decaying
    private GameObject SpaceResponse; // visual response to good or bad spacebar
    private Sprite good;
    private Sprite bad;

    private void Start()
    {

        
        transform.SetPositionAndRotation(new Vector3(0f, 0f, 0f), new Quaternion());
        transform.Rotate(0, 0, 90);
        SpaceResponse = GameObject.Find("UI/RowingRhythm/SpaceResponse");
        good = Resources.Load<Sprite>("Materials/good");
        bad = Resources.Load<Sprite>("Materials/bad");

    }
    void Update()
    {
        // Move the boat forward
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);

        // Rotate the boat
        float turnAmount = turnSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnAmount); // Left turn
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
            StartCoroutine(blinkSpaceResponse(0.2f, true));
            speed = Mathf.Min(speed + boostAmount, maxSpeed);
            isDecaying = false;
            Invoke(nameof(StartDecay), decayInterval); // Start decay after the interval
        }
        else
        {
            // Inside the red zone = Decrease speed
            StartCoroutine(blinkSpaceResponse(0.2f, false));
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

    IEnumerator blinkSpaceResponse(float duration, bool goodhit)
    {
        Color opaque = SpaceResponse.GetComponent<Image>().color;
        opaque.a = 255f;
        SpaceResponse.GetComponent<Image>().color = opaque;
        if (goodhit)
        {
            SpaceResponse.GetComponent<Image>().sprite = good;
        }
        else
        {
            SpaceResponse.GetComponent<Image>().sprite = bad;
        }
        yield return new WaitForSeconds(duration);
        Color transparent = SpaceResponse.GetComponent<Image>().color;
        transparent.a = 0f;
        SpaceResponse.GetComponent<Image>().color = transparent;
    }

}