using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class bowballcontroller : MonoBehaviour
{
    private GameObject parentBoat;
    public bool beingShot;
    public bool collided;
    private float beerDuration;
    private GameObject nearestEnemy;
    private float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beerDuration = 5f;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        parentBoat = GameObject.Find("Boat");
    }

    // Update is called once per frame
    void Update()
    {
        // if it hasen't been shot yet
        if(!beingShot) { 
            transform.position = parentBoat.transform.position;
            transform.rotation = parentBoat.transform.rotation;
            if(Input.GetKeyDown(KeyCode.E)) {
                beingShot = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                transform.position = parentBoat.transform.position + (transform.up * 2.5f);
            }
        // if it has been shot
        } if (beingShot) {
            currentTime -= Time.deltaTime;
            GetComponent<BoxCollider2D>().enabled = true;
            transform.Translate(new Vector3(0f, 0.015f, 0f));
            //on a hit, hide and come back
            if(collided || currentTime<=0) {
                // on hit disappear and move back to the boat
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                transform.position = parentBoat.transform.position;
                collided = false;
                GetComponent<BoxCollider2D>().enabled = false;
                currentTime = beerDuration;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "HSBoat")
        {
            collided = true;
        }
    }
    // void updateCooldown() {
    //     // on cooldown for 1000 frames
    //     if(cooldownFrames < 1000){
    //         cooldownFrames++;
    //     } else {
    //         // once its gone 1000 frames out or collided (functionality defined above), 
    //         // move it back to the boat and prepare for another firing
    //         cooldownFrames = 0;
    //         onCooldown = false;
    //         GetComponent<BoxCollider2D>().enabled = false;
    //         transform.position = parentBoat.transform.position;
    //         transform.rotation = parentBoat.transform.rotation;
    //         collided = false;
    //         beingShot = false;
    //         this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

    //     }
    // }
    public void startBeerTimer() {
        currentTime = beerDuration;
        beingShot = true;
    }
}
