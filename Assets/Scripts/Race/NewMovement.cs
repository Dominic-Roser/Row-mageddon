﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMovement : MonoBehaviour
{
    public RectTransform sliderMeter; // The moving black bar
    public RectTransform sliderBar;   // The entire red and green slider bar
    public float slowAmount = 1.2f;   // Speed decrease on hitting red
    public float decayRate = 0.5f;    // Speed decrease per second after decay starts
    public float decayInterval = 2f;  // Time before speed starts decaying
    private bool canBoost = true;     // Prevents repeated boosting
    private bool isDecaying = false;  // Tracks if speed is currently decaying
    private Animator boatAnimator;    // Reference to the Animator component
    private GameObject SpaceResponse; // visual response to good or bad spacebar
    private Sprite good;
    private Sprite bad;
    private void Start()
    {
        SpaceResponse = GameObject.Find("UI/RowingRhythm/SpaceResponse");
        good = Resources.Load<Sprite>("Materials/good");
        bad = Resources.Load<Sprite>("Materials/bad");
        PlayerData.maxSpeed = BoatData.boatDefaultMaxSpeed[PlayerData.boatName];
        PlayerData.speed = PlayerData.defaultSpeed;
        // Get the Animator component
        boatAnimator = GetComponent<Animator>();
        // Disable animation if the countdown is active
        if (GameManager.instance.GetGameState() == GameStates.countDown && boatAnimator != null)
        {
            boatAnimator.enabled = false;
        }
    }

    void Update()
    {
        // Disable movement if the game is still in countdown
        if (GameManager.instance.GetGameState() == GameStates.countDown)
        {
            if(SceneManager.GetActiveScene().name.Substring(0,5)=="Level") {
                //boat = GameObject.Find("Boat");
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TinsleyPieces/"+PlayerData.boatName);
                GetComponent<Animator>().runtimeAnimatorController = 
                    Resources.Load<RuntimeAnimatorController>("TinsleyPieces/"+PlayerData.boatName);
            }
            return;
        }

        // Enable animation when countdown ends
        if (boatAnimator != null && !boatAnimator.enabled && GameManager.instance.GetGameState() == GameStates.running)
        {
            boatAnimator.enabled = true;
        }
        // Move the boat forward
        transform.Translate(Vector3.right * PlayerData.speed * Time.deltaTime, Space.Self);

        // Rotate the boat
        float turnAmount = PlayerData.turnSpeed * Time.deltaTime;
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
        float greenHalfWidth = (barWidth * PlayerData.greenZonePercent) / 2f;
        float greenCenter = sliderBar.anchoredPosition.x;
        float greenMinX = greenCenter - greenHalfWidth;
        float greenMaxX = greenCenter + greenHalfWidth;

        // Boost if inside Green, Slow if inside red
        if (meterX >= greenMinX && meterX <= greenMaxX)
        {
            // Inside the green zone = Increase speed and start decay timer
            StartCoroutine(blinkSpaceResponse(0.2f, true));
            PlayerData.speed = Mathf.Min(PlayerData.speed + PlayerData.boostAmount, PlayerData.maxSpeed);
            isDecaying = false;
            Invoke(nameof(StartDecay), decayInterval); // Start decay after the interval
        }
        else
        {
            StartCoroutine(blinkSpaceResponse(0.2f, false));
            // Inside the red zone = Decrease speed
            PlayerData.speed = Mathf.Max(PlayerData.speed - slowAmount, PlayerData.minSpeed);
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
        if (isDecaying && PlayerData.speed > PlayerData.minSpeed)
        {
            // Gradually reduce speed by decayRate after decayInterval ends
            PlayerData.speed = Mathf.Max(PlayerData.speed - (decayRate * Time.deltaTime), PlayerData.minSpeed);
        }
    }

    void ResetBoost()
    {
        canBoost = true;
    }
    IEnumerator blinkSpaceResponse(float duration, bool goodhit) {
        Color opaque = SpaceResponse.GetComponent<Image>().color;
        opaque.a = 255f;
        SpaceResponse.GetComponent<Image>().color = opaque;
        if(goodhit){
            SpaceResponse.GetComponent<Image>().sprite = good;
        } else {
            SpaceResponse.GetComponent<Image>().sprite = bad;
        }
        yield return new WaitForSeconds(duration);
        Color transparent = SpaceResponse.GetComponent<Image>().color;
        transparent.a = 0f;
        SpaceResponse.GetComponent<Image>().color = transparent;
    }
}
