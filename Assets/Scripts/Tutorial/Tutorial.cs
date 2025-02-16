using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    private GameObject hat;
    private int dialogueIndex;
    private string[] dialogues;
    private float hatSpeed;
    private float HSBoatSpeed;
    private Vector2 targetPos;
    private TextMeshProUGUI dialogue;
    private GameObject boat;
    private GameObject RowingRhythm;
    private GameObject HSBoat;
    private GameObject text;
    private GameObject DialogueBox;
    
    private Button nextButton;
    private bool moving = false;
    private bool BeingStolen = false;

    void Start()
    {
        
        text = GameObject.Find("Text");
        HSBoat = GameObject.Find("Enemy");
        RowingRhythm = GameObject.Find("RowingRhythm");
        boat = GameObject.Find("Boat");
        hat = GameObject.Find("Hat");
        dialogue = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        DialogueBox = GameObject.Find("DialogueBox");

        boat.GetComponent<TutorialMovement>().enabled = false;
        
        dialogueIndex = 0;

        dialogues = new string[9];
        dialogues[0] = "--hat flies away--"; //placeholder
        dialogues[1] = "Oh no! Your hat grandpa";
        dialogues[2] = "Let's row to it";
        dialogues[3] = "This is your rowing rhythm, press SPACE while in the green to speed up!";
        dialogues[4] = "Use A and D to steer!";
        dialogues[5] = "Hahahahaha";
        dialogues[6] = "Haha you silly slow rowers, no way a hat is faster than you"; // insert hs rowers
        dialogues[7] = "lets race them for it";
        dialogues[8] = "--enter the racing scene--"; //placeholder

        DialogueBox.SetActive(false);
        RowingRhythm.SetActive(false);
        hatSpeed = 40f;
        HSBoatSpeed = 10f;
        targetPos = new Vector2(70f, 82.5f);
        GameManager.instance.OnRaceStart();

        nextButton.onClick.AddListener(AdvanceDialogue);
    }

    void Update()
    {
        if (dialogueIndex == 0)
        {
            boat.GetComponent<Animator>().enabled = false;
            hat.transform.position = Vector2.MoveTowards(transform.position, targetPos, hatSpeed * Time.deltaTime);
            if ((Vector2)hat.transform.position == targetPos)
            {
                DialogueBox.SetActive(true);
                dialogueIndex++;
            }
        }
        else
        {
            dialogue.text = dialogues[dialogueIndex];

            if (!moving && dialogueIndex == 3)
            {
                RowingRhythm.SetActive(true);
                boat.GetComponent<TutorialMovement>().enabled = true;
                boat.GetComponent<Animator>().enabled = true;
                moving = true;
                
            } 

            if (BeingStolen)
            {
                DialogueBox.SetActive(true);
                boat.GetComponent<Animator>().enabled = false;
                HSBoat.GetComponent<Animator>().enabled = true;
                HSBoat.transform.position = Vector2.MoveTowards(HSBoat.transform.position, new Vector2(70f, 82.5f), HSBoatSpeed * Time.deltaTime);

                if (Vector2.Distance(HSBoat.transform.position, new Vector2(70f, 82.5f)) < 0.01f)
                {
                    HSBoat.GetComponent<Animator>().enabled = false;
                    hat.transform.position = Vector2.MoveTowards(transform.position, HSBoat.transform.position, hatSpeed * Time.deltaTime);
                }

                if (transform.position == HSBoat.transform.position)
                {
                    BeingStolen = false;
                }
            }
        }
    }

    public void AdvanceDialogue()
    {
        if (dialogueIndex < 4)
        {
            dialogueIndex++;
        }
        else if (dialogueIndex == 4)
        {
            DialogueBox.SetActive(false);

        }
        else if (dialogueIndex == 6) 
        {
            dialogueIndex++;
        }
        else if (dialogueIndex == 7)
        {
            SceneManager.LoadScene("DomRacePlan");
        }
    }

    void OnTriggerEnter2D()
    {
        if (dialogueIndex >= 3)
        {       
            dialogueIndex++;
            boat.GetComponent<TutorialMovement>().enabled = false;
            boat.GetComponent<Animator>().enabled = false;
            RowingRhythm.SetActive(false);
            BeingStolen = true;
        }        
    }
}
