using System.Xml.Serialization;
using UnityEngine;

public class UseSpeedBoost : MonoBehaviour
{
    private float boostMultiplier;
    public float boostDuration;
    private bool speedBoosting;
    private float currentTime;
    private KeyCode speedkc;


    void Start() {
        boostMultiplier = 0.01f;
        boostDuration = 2.0f;
        speedBoosting = false;
        speedkc = PowerupDisplay.getKeyCodeOfPowerup("watergun_2");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update() {
        if(Input.GetKeyUp(speedkc) && !speedBoosting){
            startBoostTimer();
        }
        if(speedBoosting) {
            currentTime -= Time.deltaTime;
            // Apply speed boost
            if (currentTime <= 0) {
                speedBoosting = false;
                currentTime = boostDuration;

            } else if (currentTime >= boostDuration/2f) {
                NewMovement.speed += boostMultiplier;
                NewMovement.maxSpeed += boostMultiplier;
            } else if (currentTime < boostDuration/2f) {
                NewMovement.speed -= boostMultiplier;
                NewMovement.maxSpeed -= boostMultiplier;
            }
        }
    }
    public void startBoostTimer() {
        currentTime = boostDuration;
        speedBoosting = true;
    }
}
