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
        if (nextButton == null)
        {
            Debug.LogError("NextButton not found! Check the GameObject name in the Hierarchy.");
        }
        DialogueBox = GameObject.Find("DialogueBox");
        PowerupDisplay = GameObject.Find("Powerups");
        enemy = GameObject.Find("EnemyBoat");
        moving = false;
        dialogueIndex = 0;
        ranTutorial = false;

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
            Debug.Log("1 key pressed! Advancing dialogue.");
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
            dialogueIndex++;
        }
        else if (dialogueIndex == 3)
        {
            dialogueIndex++;
        }      
        else if (dialogueIndex == 5)
        {
            DialogueBox.SetActive(false);
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
            Debug.Log(dialogueIndex);
            dialogueIndex++;
            Debug.Log(dialogueIndex);
            handleBoats(false);
            DialogueBox.SetActive(true);
            ranTutorial = true;
        }
        
    }
}
