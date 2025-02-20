using UnityEngine;
using UnityEngine.SceneManagement;
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
    private bool moving;
    private GameObject enemy;
    private bool rodEnabled;
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
        moving = false;

        dialogues = new string[6];
        dialogues[0] = "--Race started--";
        dialogues[1] = "Oh no! They're getting away! I dont know where i ";
        dialogues[2] = "Hook them back with my old fishing rod!";
        dialogues[3] = "These are your power-ups. Each one has a different effect";
        dialogues[4] = "Each power-up has a cooldown, so be strategic when you use them";
        dialogues[5] = "Try using grandpa's fishing rod by pressing 1. It reel the closest enemy towards you";

        DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2000f, -200f, 0f);
        PowerupDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-1000f, -200f, 0f);

        enemy.GetComponent<enemyPath>().enabled = true;
        boat.GetComponent<RacingTutorialMovement>().enabled = false;
        boat.GetComponent<Animator>().enabled = false;
        boat.GetComponent<FishingRod>().enabled = false;
        rodEnabled = false;
        nextButton.onClick.AddListener(AdvanceDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetGameState() == GameStates.running && moving == false)
        {
            enemy.GetComponent<enemyPath>().enabled = true;
            enemy.GetComponent<Animator>().enabled = true;
            boat.GetComponent<RacingTutorialMovement>().enabled =true;
            boat.GetComponent<Animator>().enabled = true;
            RowingRhythm.SetActive(true);
            moving = true;
        }
        dialogue.text = dialogues[dialogueIndex];
        if (!rodEnabled && dialogueIndex == 5) {
            boat.GetComponent<FishingRod>().enabled = true;
            rodEnabled = true;
        }

        if (dialogueIndex == 5 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemy.GetComponent<enemyPath>().enabled = true;
            enemy.GetComponent<Animator>().enabled = true;
            boat.GetComponent<RacingTutorialMovement>().enabled = true;
            boat.GetComponent<Animator>().enabled = true;
            RowingRhythm.SetActive(true);
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(-2000f, -200f, 0f);
        }
    }
    public void AdvanceDialogue()
    {
        if (dialogueIndex == 1)
        {
            dialogueIndex++;
        }
        else if (dialogueIndex == 2)
        {
            PowerupDisplay.SetActive(true);
            PowerupDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector3(-350f, -230f, 0f);
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(-290f, -130f, 0f);
            dialogueIndex++;
        }
        else if (dialogueIndex == 3)
        {
            dialogueIndex++;
        }
        else if (dialogueIndex == 4)
        {
            dialogueIndex++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EnemyBoat" && ranTutorial == false)
        {
            Debug.Log("It's collided with the guy");
            dialogueIndex++;
            enemy.GetComponent<enemyPath>().enabled = false;
            enemy.GetComponent<Animator>().enabled = false;
            boat.GetComponent<RacingTutorialMovement>().enabled = false;
            boat.GetComponent<Animator>().enabled = false;
            RowingRhythm.SetActive(false);
            DialogueBox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
            ranTutorial = true;
        }
    }
}
