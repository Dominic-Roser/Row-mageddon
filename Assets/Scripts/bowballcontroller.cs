using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class bowballcontroller : MonoBehaviour
{
    public GameObject parentBoat;
    public bool beingShot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        beingShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!beingShot) { 
            transform.position = parentBoat.transform.position;
            if(Input.GetKeyDown(KeyCode.Q)) {
                beingShot=true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        } else { 
            transform.Translate(new Vector3(0f, 0.01f, 0f));
        }
    }
}
