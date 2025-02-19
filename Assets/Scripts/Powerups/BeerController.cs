using UnityEngine;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            Beer.transform.position = transform.position;
            Beer.transform.rotation = transform.rotation;
            if(Input.GetKeyDown(beerkc) && !isOnCooldown()) {
                currentCooldownTime = beerCooldown;
                beingShot = true;
                Beer.GetComponent<SpriteRenderer>().enabled = true;
                Beer.transform.position = transform.position + (transform.up * 2.5f);
            }
        // if it has been shot
        } if (beingShot) {
            Beer.GetComponent<BoxCollider2D>().enabled = true;
            Beer.transform.Translate(new Vector3(0f, 0.15f, 0f));
            //on a hit, hide and come back
            if(collided || currentCooldownTime<=0) {
                // on hit disappear and move back to the boat
                Beer.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                Beer.transform.position = transform.position;
                collided = false;
                Beer.GetComponent<BoxCollider2D>().enabled = false;
                //currentCooldownTime = beerCooldown;
            }
        }
    }
    public bool isOnCooldown(){
        return currentCooldownTime>0;
    }

}
