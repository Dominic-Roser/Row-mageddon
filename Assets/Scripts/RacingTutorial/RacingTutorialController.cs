using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class RacingTutorialController : MonoBehaviour
{
   
    private int dialogueIndex;
    private string[] dialogues;
    private TextMeshProUGUI dialogue;
    private GameObject boat;
    private GameObject RowingRhythm;
    private GameObject text;
    private GameObject DialogueBox;
    private Button nextButton;
    private GameObject PowerupDisplay;
    private bool moving;
    private bool ranTutorial;
    private GameObject enemy;

   
    void Start()
    {
        text = GameObject.Find("Text");
        RowingRhythm = GameObject.Find("RowingRhythm");    
        boat = GameObject.Find("Boat");
        dialogue = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        DialogueBox = GameObject.Find("DialogueBox");
        PowerupDisplay = GameObject.Find("Powerups");
        enemy = GameObject.Find("EnemyBoat");
        moving = false;
        dialogueIndex = 0;
        ranTutorial = false;
        //enemy.GetComponent<RacingTutorialEnemy>().defaultSpeed = 70;

        dialogues = new string[6];
        dialogues[0] = "--Race started--";
        dialogues[1] = "Oh no! They're getting away!";
        dialogues[2] = "Hook them back with my old fishing rod!";
        dialogues[3] = "These are your power-ups. Each one has a different effect";
        dialogues[4] = "Try using grandpa's fishing rod by pressing 1. It reel the closest enemy towards you";
        dialogues[5] = "Great job! Each power up has a cooldown, so be strategic when you use them";

        DialogueBox.SetActive(false);
        PowerupDisplay.SetActive(true);
        handleBoats(false);
        PowerupDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1000f, -200f, 0f);
        nextButton.onClick.AddListener(AdvanceDialogue);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GetGameState() == GameStates.running && moving == false)
        {
            handleBoats(true);
            moving = true;
        }
        dialogue.text = dialogues[dialogueIndex];

        if (dialogueIndex == 4 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            dialogueIndex++;
        }
    }

    public void AdvanceDialogue()
    {
        if (dialogueIndex < 2)
        {
            dialogueIndex++;
        }
        else if (dialogueIndex == 2)
        {
            PowerupDisplay.SetActive(true);
            PowerupDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-500f, -375f, 0f);
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(-450f, -200f, 0f);
            dialogueIndex++;
        }
        else if (dialogueIndex == 3)
        {
            dialogueIndex++;
        }      
        else if (dialogueIndex == 5)
        {
            DialogueBox.SetActive(false);
            //enemy.GetComponent<RacingTutorialEnemy>().defaultSpeed = 6.5f;
            //enemy.GetComponent<RacingTutorialEnemy>().currentSpeed = 6.5f;
            handleBoats(true);
        }
    }

    private void handleBoats(bool onOf)
    {
        enemy.GetComponent<RacingTutorialEnemy>().enabled = onOf;
        enemy.GetComponent<Animator>().enabled = onOf;
        boat.GetComponent<RacingTutorialMovement>().enabled = onOf;
        boat.GetComponent<Animator>().enabled = onOf;
        RowingRhythm.SetActive(onOf);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "EnemyBoat" && ranTutorial == false)
        {
            dialogueIndex++;
            handleBoats(false);
            DialogueBox.SetActive(true);
            ranTutorial = true;
        }
        
    }
}
