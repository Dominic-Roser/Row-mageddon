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
    public static GameObject[] selectedPowerups;
    public static Sprite[] selectedPowerupSprites;

    void Start()
    {
        selectedVariablesCT = new bool[4];
        button.onClick.AddListener(ChangeSprite);
        slot1 = GameObject.Find("Slot1");
        slot2 = GameObject.Find("Slot2");
        slot3 = GameObject.Find("Slot3");
        slot4 = GameObject.Find("Slot4");
        grid = GameObject.Find("PowerupGrid");
        selectedPowerups = new GameObject[4];
        selectedPowerupSprites = new Sprite[4];
        setSelectedPowerupSlotsOnStart();
        setUnlockedSpritesOnStart();
        newSprite = button.GetComponent<Image>().sprite;
    }

    void ChangeSprite()
    {
        grid.GetComponent<AudioSource>().Play(); // play click sound for audio feedback
        if (!selectedPowerups.Contains(button.gameObject) && button.GetComponent<Image>().sprite.name != "lock"){
            if (!selectedVariablesCT[0]){ 
                slot1.GetComponent<Image>().sprite = newSprite; 
                selectedVariablesCT[0] = true;
                selectedPowerups[0] = button.gameObject;
                PlayerData.SelectedPowerupNames[0] = button.gameObject.name;
                selectedPowerupSprites[0] = button.gameObject.GetComponent<Image>().sprite;
            //                                slot 2 unlocked at level 2  
            } else if (!selectedVariablesCT[1] && PlayerData.playerLevel>=2) {
                slot2.GetComponent<Image>().sprite = newSprite;
                selectedVariablesCT[1] = true;
                selectedPowerups[1] = button.gameObject;
                PlayerData.SelectedPowerupNames[1] = button.gameObject.name;
                selectedPowerupSprites[1] = button.gameObject.GetComponent<Image>().sprite;
            //                                slot 3 unlocked at level 4  
            } else if (!selectedVariablesCT[2] && PlayerData.playerLevel>=4) {
                slot3.GetComponent<Image>().sprite = newSprite;
                selectedVariablesCT[2] = true;
                selectedPowerups[2] = button.gameObject;
                PlayerData.SelectedPowerupNames[2] = button.gameObject.name;
                selectedPowerupSprites[2] = button.gameObject.GetComponent<Image>().sprite;

            //                                slot 4 unlocked at level 6  
            } else if (!selectedVariablesCT[3] && PlayerData.playerLevel>=6) {
                slot4.GetComponent<Image>().sprite = newSprite;
                selectedVariablesCT[3] = true;
                selectedPowerups[3] = button.gameObject;
                PlayerData.SelectedPowerupNames[3] = button.gameObject.name;
                selectedPowerupSprites[3] = button.gameObject.GetComponent<Image>().sprite;

            } 
        }
    }

    void setUnlockedSpritesOnStart() {
        // if the player has unlocked the powerup show it
        if(PlayerData.UnlockedPowerupNames.Contains(button.gameObject.name)) {
            button.gameObject.GetComponent<Image>().sprite = PlayerData.powerupIconDictionary[button.gameObject.name];
        } else {
            button.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/lock");
        }
    }


    // sets each of the selection powerups on start to lock based on playerLevel
    void setSelectedPowerupSlotsOnStart() {
        //slot 1 is always open
        if(PlayerData.playerLevel<6){
            slot4.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/lock");
        }
        if(PlayerData.playerLevel<4){
            slot3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/lock");
        }
        if(PlayerData.playerLevel<2){
            slot2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/lock");
        }
    }
}
