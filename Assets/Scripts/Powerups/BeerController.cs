using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BeerController : MonoBehaviour
{
    private GameObject Beer;
    public bool beingShot;
    public static bool collided;
    private float beerDuration;
    private GameObject nearestEnemy;
    private float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Beer = GameObject.Find("Beer");
        beerDuration = 5f;
        Beer.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if it hasen't been shot yet
        if(!beingShot) { 
            Beer.transform.position = transform.position;
            Beer.transform.rotation = transform.rotation;
            if(Input.GetKeyDown(KeyCode.E)) {
                beingShot = true;
                Beer.GetComponent<SpriteRenderer>().enabled = true;
                Beer.transform.position = transform.position + (transform.up * 2.5f);
            }
        // if it has been shot
        } if (beingShot) {
            currentTime -= Time.deltaTime;
            Beer.GetComponent<BoxCollider2D>().enabled = true;
            Beer.transform.Translate(new Vector3(0f, 0.015f, 0f));
            //on a hit, hide and come back
            if(collided || currentTime<=0) {
                // on hit disappear and move back to the boat
                Beer.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                Beer.transform.position = transform.position;
                collided = false;
                Beer.GetComponent<BoxCollider2D>().enabled = false;
                currentTime = beerDuration;
            }
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
