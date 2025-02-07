using UnityEngine;

public class SliderMover : MonoBehaviour
{
    public RectTransform sliderMeter; // The moving black bar
    public RectTransform sliderBar;   // The full red and green bar
    public float speed = 2f;          // Speed of black bar
    private float minX, maxX;         // Movement bounds
    private float direction = 1f;     // Moving right initially

    void Start()
    {
        if (sliderMeter == null || sliderBar == null)
        {
            Debug.LogError("Assign both the sliderMeter and sliderBar in the Inspector.");
            return;
        }

        // The size of the red and green bar
        float barWidth = sliderBar.rect.width * 2;
        float meterWidth = sliderMeter.rect.width;

        // Movement boundaries based on bar width
        minX = -((barWidth - meterWidth) / 2f);
        maxX = (barWidth - meterWidth) / 2f;
    }

    void Update()
    {
        if (sliderMeter == null || sliderBar == null) return;

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
