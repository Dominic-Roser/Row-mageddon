using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public Button button;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public Sprite newSprite;
    public static bool[] selectedVariablesCT;
    public static string[] selectedVariables;

    void Start()
    {
        newSprite = button.GetComponent<Image>().sprite;
        selectedVariablesCT = new bool[4];
        button.onClick.AddListener(ChangeSprite);
        slot1 = GameObject.Find("Slot1");
        slot2 = GameObject.Find("Slot2");
        slot3 = GameObject.Find("Slot3");
        slot4 = GameObject.Find("Slot4");
        selectedVariables = new string[4];
    }

    void ChangeSprite()
    {
        if(!selectedVariablesCT[0]){ 
            slot1.GetComponent<Image>().sprite = newSprite; 
            selectedVariablesCT[0] = true;
            selectedVariables[0] = button.name;
            
        } else if(!selectedVariablesCT[1]) {
            slot2.GetComponent<Image>().sprite = newSprite;
            selectedVariablesCT[1] = true;
            selectedVariables[1] = button.name;

        } else if(!selectedVariablesCT[2]) {
            slot3.GetComponent<Image>().sprite = newSprite;
            selectedVariablesCT[2] = true;
            selectedVariables[2] = button.name;

        } else if(!selectedVariablesCT[3]) {
            slot4.GetComponent<Image>().sprite = newSprite;
            selectedVariablesCT[3] = true;
            selectedVariables[3] = button.name;
        } 
    }
}
