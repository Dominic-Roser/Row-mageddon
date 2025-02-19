using UnityEngine;

public class GameManagerRacingTutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerData.SelectedPowerupNames[0] = "FishingRod";
        PlayerData.selectedPowerupSprites[0] = Resources.Load<Sprite>("Materials/PowerUpIcons/fishingRod");
        PlayerData.selectedVariablesCT[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
