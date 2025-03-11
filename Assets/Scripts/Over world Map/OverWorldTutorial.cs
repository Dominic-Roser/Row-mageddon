using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverWorldTutorial : MonoBehaviour {
    private string[] dialogues;
    private TextMeshProUGUI dialogue;
    private static int dialogueIndex=0;
    private Button nextButton;

    void Start()
    {
      Debug.Log("I have been started");
      if (PlayerData.OverWorldTutorialFinished) {
        enabled = false;
        gameObject.SetActive(false);
      } else {

        dialogue = GameObject.Find("Level Buttons/DialogueBox/Text").GetComponent<TextMeshProUGUI>();
        nextButton = GameObject.Find("Level Buttons/DialogueBox/NextButton").GetComponent<Button>();

        dialogues = new string[3];
        dialogues[0] = "Welcome to the Level Selection Scene!";
        dialogues[1] = "Below is the shop where you can buy new powerups and boats! You can also redo the tutorial!";
        dialogues[2] = "Click on the level one icon to start the level!";
        nextButton.onClick.AddListener(AdvanceDialogue);
        
        if(dialogueIndex == 1) {
          GetComponent<RectTransform>().anchoredPosition = new Vector3(-357, -161, 0);
          gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.12f,0.12f,0.12f);
          dialogue.fontSize = 37;
          dialogue.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-11, 100, 0);
        } else if (dialogueIndex == 2) {
          GetComponent<RectTransform>().anchoredPosition = new Vector3(-361, -95, 0);
          gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.12f,0.12f,0.12f);
          dialogue.fontSize = 37;
          dialogue.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-11, 100, 0);
        }
      }

    }

    void Update()
    {
      if(dialogueIndex >= 3){
        PlayerData.OverWorldTutorialFinished = true;
      }
      if (PlayerData.OverWorldTutorialFinished) {
        enabled = false;
        gameObject.SetActive(false);
      } else {
        if (dialogueIndex<2) {
          GameObject.Find("Level Buttons/Level 1").GetComponent<Button>().enabled=false;
        } else {
          GameObject.Find("Level Buttons/Level 1").GetComponent<Button>().enabled=true;
        }
        dialogue.text = dialogues[dialogueIndex];
      }
    }

    public void AdvanceDialogue()
    {
      //ogpos = 27,48,0
      if(dialogueIndex == 0) {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(-357, -161, 0);
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.12f,0.12f,0.12f);
        dialogue.fontSize = 42;
        dialogue.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-11, 100, 0);
      }
      if(dialogueIndex == 1) {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(-361, -95, 0);
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.12f,0.12f,0.12f);
        dialogue.fontSize = 37;
        dialogue.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-11, 100, 0);
      }
      dialogueIndex++;
    }
}