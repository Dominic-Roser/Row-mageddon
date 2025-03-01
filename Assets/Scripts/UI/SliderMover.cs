using UnityEngine;

public class SliderMover : MonoBehaviour
{
    public RectTransform sliderMeter; // The moving black bar

    //54 pixels long
    public RectTransform sliderBar;   // The full red and green bar
    public float speed = 2f; // Speed of black bar
    private float minX, maxX; // Movement bounds
    private float direction = 1f; // Moving right initially
    private bool isPaused = false; // checks if the slider should be paused for countdown
    void Start()
    {
        if (sliderMeter == null || sliderBar == null)
        {
            Debug.LogError("Assign both the sliderMeter and sliderBar in the Inspector.");
            return;
        }

        // The size of the red and green bar
        float barWidth = sliderBar.rect.width - 30f;
        float meterWidth = sliderMeter.rect.width;

        // Movement boundaries based on bar width
        minX = -((barWidth - meterWidth) / 2f);
        maxX = (barWidth - meterWidth) / 2f;

        // Disable movement if the countdown is active
        if (GameManager.instance.GetGameState() == GameStates.countDown)
        {
            isPaused = true;
        }
    }

    void Update()
    {
        if (sliderMeter == null || sliderBar == null) return;

        // Pause animation during countdown
        if (GameManager.instance.GetGameState() == GameStates.countDown)
        {
            isPaused = true;
            return;
        }

        // Play animation when the countdown ends
        if (isPaused && GameManager.instance.GetGameState() == GameStates.running)
        {
            isPaused = false;
        }

        if (!isPaused)
        {
            MoveSlider();
        }      
    }

    private void MoveSlider()
    {
        float movement = sliderMeter.anchoredPosition.x + (speed * direction * Time.deltaTime);

        // Reverse direction when reaching limits
        if (movement >= maxX || movement <= minX)
        {
            direction *= -1f; // Flip direction
            movement = Mathf.Clamp(movement, minX, maxX); // Keep within bounds
        }

        // Apply movement while keeping Y position unchanged
        sliderMeter.anchoredPosition = new Vector2(movement, sliderMeter.anchoredPosition.y);
    }
}
