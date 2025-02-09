using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject hat;
    private int dialogueIndex;
    private string[] dialogues;
    private float hatSpeed;
    private Vector2 targetPos;
    private TextMeshProUGUI dialogue;
    private GameObject boat;
    private GameObject RowingRhythm;
    private GameObject HSBoat;
    private GameObject text;
    private GameObject Spacebartip;
    private bool moving = false;
    private bool BeingStolen = false;
    void Start()
    {
        Spacebartip = GameObject.Find("Spacebartip");
        text = GameObject.Find("Text");
        HSBoat = GameObject.Find("HSBoat");
        RowingRhythm = GameObject.Find("RowingRhythm");
        boat = GameObject.Find("Boat");
        hat = GameObject.Find("Hat");
        dialogue = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        boat.GetComponent<NewMovement>().enabled = false;
        Spacebartip.SetActive(false);
        dialogueIndex = 0;
        dialogues = new string[9];
        dialogues[0] = "--hat flies away--"; //placeholder
        dialogues[1] = "Oh no! Your hat grandpa";
        dialogues[2] = "Let's row to it";
        dialogues[3] = "This is your rowing rhythm, press SPACE while in the green to speed up!";
        dialogues[4] = "Use A and D to steer!";
        dialogues[5] = "bomboclaat";
        dialogues[6] = "Haha you silly slow rowers, no way a hat is faster than you"; // insert hs rowers
        dialogues[7] = "lets race them for it";
        dialogues[8] = "--enter the racing scene--"; //placeholder

        GameObject.Find("RowingRhythm").SetActive(false);
        hatSpeed = 4.2f;
        targetPos = new Vector2(6,14);
    }

    // Update is called once per frame
    void Update()
    {
        // if the index is 0 that means the hat is moving 
        if(dialogueIndex == 0){
            boat.GetComponent<Animator>().enabled = false;
            hat.transform.position = Vector2.MoveTowards(transform.position, targetPos, hatSpeed * Time.deltaTime);
            if ((Vector2)hat.transform.position == targetPos) {
                Spacebartip.SetActive(true);
                dialogueIndex++;
            }   
        // if the player is in dialogue scrolling             
        } else {
            dialogue.text = dialogues[dialogueIndex];
            // if they can now see
            if(!moving && dialogueIndex == 3) {
                RowingRhythm.SetActive(true);
                boat.GetComponent<NewMovement>().enabled = true;
                moving = true;
            }
            // they are now rowing
            if(dialogueIndex == 4) {
                boat.GetComponent<Animator>().enabled = true;
            }

            // scroll through dialogue
            if (dialogueIndex<4 && Input.GetKeyUp(KeyCode.Space)){
                dialogueIndex++;
            }
            // the hat is being stolen by the Hs
            if (BeingStolen) {
                Spacebartip.SetActive(false);
                hat.transform.position = Vector2.MoveTowards(transform.position, HSBoat.transform.position, hatSpeed * Time.deltaTime);
                //once they've stolen it, continue dialogue
                if(transform.position == HSBoat.transform.position){
                    dialogueIndex++;
                    text.GetComponent<RectTransform>().anchoredPosition += new Vector2(-800.0f, 0); //move textbox to the hs boat
                    BeingStolen = false;
                }
            }
            //move it back when its our turn ti speak
            if(dialogueIndex >= 6 && dialogueIndex < 7 && Input.GetKeyUp(KeyCode.Space)){
                text.GetComponent<RectTransform>().anchoredPosition += new Vector2(800.0f, 0);
                dialogueIndex++;
            // load the race tutorial    
            } else if (dialogueIndex == 7 && Input.GetKeyUp(KeyCode.Space)){
                SceneManager.LoadScene("SScene");
            }
        }
    }

    void OnTriggerEnter2D() {
        if(moving && dialogueIndex == 4) {
            dialogueIndex++;
            boat.GetComponent<NewMovement>().enabled = false;
            boat.GetComponent<Animator>().enabled = false;

            RowingRhythm.SetActive(false);
            BeingStolen = true;
        }
    }
}
