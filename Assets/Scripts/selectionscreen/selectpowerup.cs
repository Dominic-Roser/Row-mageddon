using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public Button button;
    private GameObject slot1;
    private GameObject slot2;
    private GameObject slot3;
    private GameObject slot4;
    private GameObject grid;
    public Sprite newSprite;
    public static bool[] selectedVariablesCT;
    public static string[] selectedVariables;

    public static int playerLevel = 0; // this is a placeholder for the future, 
    // to make sure the player has the correct number of slots allocataed

    void Start()
    {
        newSprite = button.GetComponent<Image>().sprite;
        selectedVariablesCT = new bool[4];
        button.onClick.AddListener(ChangeSprite);
        slot1 = GameObject.Find("Slot1");
        slot2 = GameObject.Find("Slot2");
        slot3 = GameObject.Find("Slot3");
        slot4 = GameObject.Find("Slot4");
        grid = GameObject.Find("PowerupGrid");
        selectedVariables = new string[4];
    }

    void ChangeSprite()
    {
        grid.GetComponent<AudioSource>().Play(); // play click sound for audio feedback
        if(!selectedVariables.Contains(button.name) && button.GetComponent<Image>().sprite.name != "lockicon_0"){
            if(!selectedVariablesCT[0]){ 
                slot1.GetComponent<Image>().sprite = newSprite; 
                selectedVariablesCT[0] = true;
                selectedVariables[0] = button.name;
            //                                slot 2 unlocked at level 2  
            } else if(!selectedVariablesCT[1] && playerLevel>=2) {
                slot2.GetComponent<Image>().sprite = newSprite;
                selectedVariablesCT[1] = true;
                selectedVariables[1] = button.name;
            //                                slot 3 unlocked at level 4  
            } else if(!selectedVariablesCT[2] && playerLevel>=4) {
                slot3.GetComponent<Image>().sprite = newSprite;
                selectedVariablesCT[2] = true;
                selectedVariables[2] = button.name;
            //                                slot 4 unlocked at level 6  
            } else if(!selectedVariablesCT[3] && playerLevel>=6) {
                slot4.GetComponent<Image>().sprite = newSprite;
                selectedVariablesCT[3] = true;
                selectedVariables[3] = button.name;
            } 
        }
    }
}
