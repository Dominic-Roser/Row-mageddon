using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManagerRacingTutorial : MonoBehaviour
{
    private int dialogueIndex;
    private string[] dialogues;
    private TextMeshProUGUI dialogue;
    private GameObject boat;
    private GameObject RowingRhythm;
    private GameObject DialogueBox;
    private Button nextButton;
    private GameObject PowerupDisplay;
    private bool ranTutorial;
    private GameObject enemy;
    void Start()
    {
        RowingRhythm = GameObject.Find("RowingRhythm");
        boat = GameObject.Find("Boat");
        dialogue = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        DialogueBox = GameObject.Find("DialogueBox");
        PowerupDisplay = GameObject.Find("Powerups");
        enemy = GameObject.Find("EnemyBoat");
        dialogueIndex = 0;
        ranTutorial = false;

        dialogues = new string[6];
        dialogues[0] = "--Race started--";
        dialogues[1] = "Oh no! They're getting away!";
        dialogues[2] = "Hook them back with my old fishing rod!";
        dialogues[3] = "These are your power-ups. Each one has a different effect";
        dialogues[4] = "Try using grandpa's fishing rod by pressing 1. It reel the closest enemy towards you";
        dialogues[5] = "Great job! Each power up has a cooldown, so be strategic when you use them";

        DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1000f, -200f, 0f);
        PowerupDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1000f, -200f, 0f);
        nextButton.onClick.AddListener(AdvanceDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdvanceDialogue()
    {
        if (dialogueIndex == 1)
        {
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
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
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBoat" && ranTutorial == false)
        {
            Debug.Log("IT HIIIIIIIIIIIIIIIIIIIIIIIT");
            dialogueIndex++;
            enemy.GetComponent<enemyPath>().enabled = false;
            enemy.GetComponent<Animator>().enabled = false;
            boat.GetComponent<RacingTutorialMovement>().enabled = false;
            boat.GetComponent<Animator>().enabled = false;
            RowingRhythm.SetActive(false);
            ranTutorial = true;
        }
    }
}
