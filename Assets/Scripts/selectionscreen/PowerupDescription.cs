using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject tooltip; // Assign your tooltip object in the inspector

    void Start() {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/Image").SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData) {
        GameObject.Find("Canvas/TooltipParent/Image").SetActive(true);
        tooltip.SetActive(true);
        string itemName = name; // Get the GameObject name
        if(name == "Boat"){
            tooltip.GetComponent<TextMeshProUGUI>().text = PowerupData.itemStats[PlayerData.boatName];
        } else {
            if (PlayerData.UnlockedPowerupNames.Contains(itemName)) {
                tooltip.GetComponent<TextMeshProUGUI>().text = PowerupData.itemStats[itemName];
            } else {
                tooltip.GetComponent<TextMeshProUGUI>().text = getActualName(itemName) + "...";
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/Image").SetActive(false);
    }
    public string getActualName(string name) {
        if(name == "SideCannon")
            return "Side Cannon";
        if(name == "WaterGun")
            return "Water Gun";
        if(name == "SpeedBoost")
            return "Speed Boost";
        if(name == "Forcefield")
            return "Force-field";
        if(name == "WoodenBoat")
            return "Wooden Boat";
        if(name == "Dragon boat")
            return "Dragon Boat";
        if(name == "PurpleBoat")
            return "Purple Boat";
        else {
            return name;
        }
    }
}
