using System;
using UnityEngine;

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

    // Update is called once per frame
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

            if(Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x) < 1.7){ 
                //transform.Translate(new Vector3(speedOnSpace * Time.deltaTime, 0, 0));
                boosting=true;
                boostFrames=0;
            }
            if(Input.GetKeyDown(KeyCode.Space) && Math.Abs(line.transform.position.x) > 1.7){ 
                //transform.Translate(new Vector3((speedOnSpace - 110f) * Time.deltaTime, 0, 0));
                defaultSpeed -= 0.07f;
            }
            if(boosting && boostFrames<=40){
                defaultSpeed += 0.1f;
                boostFrames++;
            }
            if(boosting && boostFrames>40){
                boostFrames=0;
                defaultSpeed=0.6f;
                boosting=false;
            }

        }

        
    }
}
