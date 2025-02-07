using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject hat;
    private int dialogueIndex;
    private string[] dialogues;
    private float hatSpeed;
    private Vector2 targetPos;
    private TextMeshPro dialogue;
    private GameObject boat;
    private GameObject HUD;
    private bool moving = false;
    void Start()
    {
        HUD = GameObject.Find("HUD");
        boat = GameObject.Find("Boat");
        hat = GameObject.Find("Hat");
        boat.GetComponent<NewMovement>().enabled = false;
        dialogueIndex = 0;
        dialogues = new string[6];
        dialogues[0] = "--hat flies away";
        dialogues[1] = "Oh no! Your hat grandpa";
        dialogues[2] = "Let's row to it";
        dialogues[3] = "This is your rowing rhythm, press SPACE while in the green to speed up!";
        dialogues[4] = "homboclaat";
        GameObject.Find("HUD").SetActive(false);
        hatSpeed = 2f;
        targetPos = new Vector2(6,14);
        dialogue = GameObject.Find("Text").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the index is 0 that means the hat is moving 
        if(dialogueIndex == 0){
            hat.transform.position = Vector2.MoveTowards(transform.position, targetPos, hatSpeed * Time.deltaTime);
            if ((Vector2)hat.transform.position == targetPos) {
                dialogueIndex++;
            }                
        } else {
            dialogue.text = dialogues[dialogueIndex];
            if(!moving && dialogueIndex == 3) {
                HUD.SetActive(true);
                boat.GetComponent<NewMovement>().enabled = true;
                moving = true;
            }
            if (dialogueIndex<3 && Input.GetKeyUp(KeyCode.Space)){
                dialogueIndex++;
            }
        }
    }

    void OnTriggerEnter2D() {
        if(moving && dialogueIndex == 3) {
            dialogueIndex++;
            boat.GetComponent<NewMovement>().enabled = false;
            HUD.SetActive(false);
        }
    }
}
