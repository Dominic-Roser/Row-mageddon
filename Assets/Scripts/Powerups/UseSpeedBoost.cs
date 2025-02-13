using System.Xml.Serialization;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class UseSpeedBoost : MonoBehaviour
{
    private float boostMultiplier;
    public float boostDuration;
    private bool speedBoosting;
    private float currentTime;
    private KeyCode speedkc;
    private float currentCooldownTime;
    private float speedboostcooldown;


    void Start() {
        speedboostcooldown = 8.0f;
        currentCooldownTime = speedboostcooldown;
        boostMultiplier = 0.01f;
        boostDuration = 2.0f;
        speedBoosting = false;
        speedkc = PowerupDisplay.getKeyCodeOfPowerup("watergun_2");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update() {
        if(Input.GetKeyUp(speedkc) && !speedBoosting && !isOnCooldown()){
            startBoostTimer();
        }
        currentCooldownTime+=Time.deltaTime;
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

    public bool isOnCooldown(){
        return currentCooldownTime<=speedboostcooldown;
    }
}
