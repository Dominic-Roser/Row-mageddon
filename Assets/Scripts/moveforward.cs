using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveforward : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject line;
    public float speedOnSpace;
    public float defaultSpeed;
    public int boostFrames;
    public bool started;
    public bool boosting;
    public float rotation;

    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(-6, 0, 0), new Quaternion());
        speedOnSpace = 0f;
        defaultSpeed = 0f;
        boostFrames = 0;
        boosting = false;
        started = false;
        rotation = 0f;
    }

    void Update()
    {
        // not moving yet
        if(!started && Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x)<1.7){ 
            speedOnSpace = 80f;
            defaultSpeed = 0.6f;
            started = true;
        }
        // moving now
        if(started){
            transform.Translate(new Vector3(defaultSpeed * Time.deltaTime, 0, 0));

            if(Input.GetKey(KeyCode.A)){
                rotation += 0.0015f;
            }
            else if(Input.GetKey(KeyCode.D)){
                rotation -= 0.0015f;
            } else {
                rotation = 0;
            }
            transform.Rotate(new Vector3(0,0,rotation));

            // if they hit in green
            if(!boosting && Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x) < 1.3){ 
                speedBoostStart();
            }
            // if they hit in red slow down immediately
            if(Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x) > 1.3){ 
                defaultSpeed *= 0.80f;
            }
            performSpeedBoostOnHit();

            if(playerWins()){
                openWinScreen();
            }

        }
    }
    void speedBoostStart () {
        boosting=true;
        boostFrames=0;
    }
    void performSpeedBoostOnHit() {
        if(boosting && boostFrames<=200){
            defaultSpeed += 0.015f;
            boostFrames++;
        }
        if(boosting && boostFrames>200){
            boostFrames=0;
            defaultSpeed=0.6f;
            boosting=false;
        }
    }
    bool playerWins(){
        return transform.position.x>8.5;
    }
    void openWinScreen() {
        SceneManager.LoadScene("WinScene");
    }
}
