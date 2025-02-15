//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class deselectpowerup : MonoBehaviour
{
    public Button button;
    private GameObject grid;
    public Sprite unselectedImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(ChangeSprite);
        unselectedImage = Resources.Load<Sprite>("materials/transparent");
        grid = GameObject.Find("PowerupGrid");
    }

    // Update is called once per frame
    void ChangeSprite()
    {
        if(button.GetComponent<Image>().sprite.name != "Lock") {
            grid.GetComponent<AudioSource>().Play();
            // if we click the first slot, and its already got a p-up selected free it;
            if(button.gameObject.name == "Slot1" && ChangeSpriteOnClick.selectedVariablesCT[0]) { 
                GetComponent<Image>().sprite = unselectedImage;
                ChangeSpriteOnClick.selectedVariablesCT[0] = false;
                ChangeSpriteOnClick.selectedPowerups[0] = null;
                ChangeSpriteOnClick.selectedPowerupSprites[0] = null;
                PlayerData.SelectedPowerupNames[0] = "";

                
            } else if(button.gameObject.name == "Slot2" && ChangeSpriteOnClick.selectedVariablesCT[1]) { 
                GetComponent<Image>().sprite = unselectedImage;
                ChangeSpriteOnClick.selectedVariablesCT[1] = false;
                ChangeSpriteOnClick.selectedPowerups[1] = null;
                ChangeSpriteOnClick.selectedPowerupSprites[1] = null;
                PlayerData.SelectedPowerupNames[1] = "";


            } else if(button.gameObject.name == "Slot3" && ChangeSpriteOnClick.selectedVariablesCT[2]) { 
                GetComponent<Image>().sprite = unselectedImage;
                ChangeSpriteOnClick.selectedVariablesCT[2] = false;
                ChangeSpriteOnClick.selectedPowerups[2] = null;
                ChangeSpriteOnClick.selectedPowerupSprites[2] = null;
                PlayerData.SelectedPowerupNames[2] = "";



            } else if(button.gameObject.name == "Slot4" && ChangeSpriteOnClick.selectedVariablesCT[3]) { 
                GetComponent<Image>().sprite = unselectedImage;
                ChangeSpriteOnClick.selectedVariablesCT[3] = false;
                ChangeSpriteOnClick.selectedPowerups[3] = null;
                ChangeSpriteOnClick.selectedPowerupSprites[3] = null;
                PlayerData.SelectedPowerupNames[3] = "";


            }
            GetComponent<Image>().sprite = unselectedImage;
        }
    }
}
