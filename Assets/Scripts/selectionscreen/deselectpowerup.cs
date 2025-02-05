using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class deselectpowerup : MonoBehaviour
{
    public Button button;
    public Sprite unselectedImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(ChangeSprite);
    }

    // Update is called once per frame
    void ChangeSprite()
    {
        // if we click the first slot, and its already got a p-up selected free it;
        if(button.gameObject.name == "Slot1" && ChangeSpriteOnClick.selectedVariablesCT[0]) { 
            GetComponent<Image>().sprite = unselectedImage;
            ChangeSpriteOnClick.selectedVariablesCT[0] = false;
            
        } else if(button.gameObject.name == "Slot2" && ChangeSpriteOnClick.selectedVariablesCT[1]) { 
            GetComponent<Image>().sprite = unselectedImage;
            ChangeSpriteOnClick.selectedVariablesCT[1] = false;

        } else if(button.gameObject.name == "Slot3" && ChangeSpriteOnClick.selectedVariablesCT[2]) { 
            GetComponent<Image>().sprite = unselectedImage;
            ChangeSpriteOnClick.selectedVariablesCT[2] = false;

        } else if(button.gameObject.name == "Slot4" && ChangeSpriteOnClick.selectedVariablesCT[3]) { 
            GetComponent<Image>().sprite = unselectedImage;
            ChangeSpriteOnClick.selectedVariablesCT[3] = false;
        }
        GetComponent<Image>().sprite = unselectedImage;
    }
}
