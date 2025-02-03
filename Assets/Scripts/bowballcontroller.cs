using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class bowballcontroller : MonoBehaviour
{
    public GameObject parentBoat;
    public bool beingShot;
    public bool collided;
    public int cooldownFrames;
    private bool onCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
        cooldownFrames = 0;
        onCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if it hasen't been shot yet
        if(!beingShot && !onCooldown) { 
            transform.position = parentBoat.transform.position;
            if(Input.GetKeyDown(KeyCode.Q)) {
                beingShot=true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        // if it has been shot
        } else { 
            onCooldown = true;
            transform.rotation = parentBoat.transform.rotation;
            transform.Translate(new Vector3(0f, 0.01f, 0f));
            //on a hit, hide and come back
            if(collided){
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                beingShot = false;
                transform.position = parentBoat.transform.position;
                collided = false;
            }
        }
        if(onCooldown) {
            updateCooldown();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "enemyboat")
        {
            collided = true;
        }
    }
    void updateCooldown() {
        //on cooldown
        if(cooldownFrames < 1000){
            cooldownFrames++;
        } else {
            cooldownFrames=0;
            onCooldown = false;
            transform.position = parentBoat.transform.position;
            collided = false;
            beingShot = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}
