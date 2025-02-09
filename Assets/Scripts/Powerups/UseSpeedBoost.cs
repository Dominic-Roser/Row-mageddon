using System.Xml.Serialization;
using UnityEngine;

public class UseSpeedBoost : MonoBehaviour
{
    private float boostMultiplier;
    public float boostDuration;
    private bool speedBoosting;
    private float currentTime;


    void Start() {
        boostMultiplier = 0.01f;
        boostDuration = 2.0f;
        speedBoosting = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update() {
        if(Input.GetKeyUp(KeyCode.Q) && !speedBoosting){
            startBoostTimer();
        }
        if(speedBoosting) {
            Debug.Log("currtime");
            Debug.Log(currentTime);
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
