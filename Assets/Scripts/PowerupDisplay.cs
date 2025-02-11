//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class PowerupDisplay : MonoBehaviour
{
    private Sprite lockFab;
    private GameObject p1;
    private GameObject p2;
    private GameObject p3;
    private GameObject p4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockFab = Resources.Load<Sprite>("Materials/lockicon");
        p1 = GameObject.Find("Powerup1");
        p2 = GameObject.Find("Powerup2");
        p3 = GameObject.Find("Powerup3");
        p4 = GameObject.Find("Powerup4");
        
        // set each of the powerup slots on the hud to the right png
        if (ChangeSpriteOnClick.selectedVariablesCT[0]) {
            p1.GetComponent<Image>().sprite = ChangeSpriteOnClick.selectedPowerupSprites[0];
        } else { // if it has not been assigned it displays a lock icon
            p1.GetComponent<Image>().sprite = lockFab;
        }

        if (ChangeSpriteOnClick.selectedVariablesCT[1]) {
            p2.GetComponent<Image>().sprite = ChangeSpriteOnClick.selectedPowerupSprites[1];
        } else {
            p2.GetComponent<Image>().sprite = lockFab;
        }

        if (ChangeSpriteOnClick.selectedVariablesCT[2]) {
            p3.GetComponent<Image>().sprite = ChangeSpriteOnClick.selectedPowerupSprites[2];
        } else {
            p3.GetComponent<Image>().sprite = lockFab;
        }

        if (ChangeSpriteOnClick.selectedVariablesCT[3]) {
            p4.GetComponent<Image>().sprite = ChangeSpriteOnClick.selectedPowerupSprites[3];
        } else {
            p4.GetComponent<Image>().sprite = lockFab;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
