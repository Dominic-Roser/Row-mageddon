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

    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(-6, 0, 0), new Quaternion());
        speedOnSpace = 0f;
        defaultSpeed = 0f;
        boostFrames=0;
        boosting = false;
        started = false;
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

            // if they hit in green
            if(!boosting && Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x) < 1.7){ 
                speedBoostStart();
            }
            // if they hit in red slow down immediately
            if(Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x) > 1.7){ 
                defaultSpeed -= 0.07f;
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
            defaultSpeed += 0.01f;
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
