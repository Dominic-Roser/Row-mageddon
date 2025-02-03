using Microsoft.Win32.SafeHandles;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class enemymoving : MonoBehaviour
{
    public float defaultSpeed;
    public bool hit;
    public int slowdownFrames;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSpeed = 1f;
        hit = false;
        slowdownFrames = 0;
        transform.SetPositionAndRotation(new Vector3(-6, 1.5f, 0), new Quaternion());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(defaultSpeed*Time.deltaTime, 0, 0));
        if(hit) { 
            performSlowdown();
        }
        if(enemyWins()){
            openLoseScreen();
        }
    }
    bool enemyWins(){
        return transform.position.x>8.5;
    }
    void openLoseScreen() {
        SceneManager.LoadScene("LoseScene");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bow Ball")
        {
            hit=true;
        }
    }

    void performSlowdown() {
        if(slowdownFrames<600){
            defaultSpeed = 0.3f;
            slowdownFrames++;
        } else {
            defaultSpeed = 1f;
            slowdownFrames=0;
            hit=false;
        }
    } 

}
