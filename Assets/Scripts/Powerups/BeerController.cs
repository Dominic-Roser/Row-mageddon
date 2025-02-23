using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;

public class BeerController : MonoBehaviour
{
    private GameObject Beer;
    public bool beingShot;
    public static bool collided;
    private float beerCooldown;
    private GameObject nearestEnemy;
    private float currentCooldownTime;
    private KeyCode beerkc;
    public GameObject beerCooldownAnimationObj;
    private bool holdingDown;
    private bool forwards;
    private float speedDir;
    private Vector3 holdpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forwards = true;
        speedDir = 0f;
        holdingDown = true;
        Beer = GameObject.Find("Beer");
        beerCooldown = 5f;
        Beer.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        beerkc = PowerupDisplay.getKeyCodeOfPowerup("Beer");
        beerCooldownAnimationObj = PowerupDisplay.getCooldownObject(beerkc);

    }

    // Update is called once per frame
    void Update()
    {
        if(beerkc != KeyCode.None) {
            if(isOnCooldown()){
                beerCooldownAnimationObj.SetActive(true);
            } else {
                beerCooldownAnimationObj.SetActive(false);
            }
        }
        currentCooldownTime -= Time.deltaTime;
        // if it hasen't been shot yet
        if(!beingShot) { 
            if(Input.GetKeyDown(beerkc) && !isOnCooldown()) {
                speedDir = 0.15f;
                holdingDown = true;
                Beer.GetComponent<SpriteRenderer>().enabled = true;
                holdpos = transform.position + (transform.right * 2.5f);
                Beer.transform.position = holdpos;
            } else if (Input.GetKeyUp(beerkc) && !isOnCooldown()) {
                currentCooldownTime = beerCooldown;
                beingShot = true;
                holdingDown = false;
            } 
            if(!beingShot){
                Beer.transform.rotation = transform.rotation;
                if(!holdingDown){
                    holdpos = transform.position + (transform.right * 2.5f);
                    Beer.transform.position = holdpos;
                } else if (holdingDown && forwards) {
                    holdpos = transform.position + (transform.right * 2.5f);
                    speedDir = 0.15f;
                    Beer.transform.position = holdpos;

                } else if (holdingDown && !forwards) {
                    holdpos = transform.position + (transform.right * -2.5f);
                    speedDir = -0.15f;
                    Beer.transform.position = holdpos;
                }

                if (Input.GetKeyDown(KeyCode.W)) {
                    forwards = true;
                } else if(Input.GetKeyDown(KeyCode.S)){
                    forwards = false;
                }
            }
        // if it has been shot
        } if (beingShot) {
            Beer.GetComponent<BoxCollider2D>().enabled = true;
            Beer.transform.Translate(new Vector3(speedDir, 0f, 0f));
            //on a hit, hide and come back
            if(collided || currentCooldownTime<=0) {
                // on hit disappear and move back to the boat
                Beer.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                Beer.transform.position = transform.position;
                collided = false;
                Beer.GetComponent<BoxCollider2D>().enabled = false;
                forwards = true;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
    public bool isOnCooldown(){
        return currentCooldownTime>0;
    }

}
