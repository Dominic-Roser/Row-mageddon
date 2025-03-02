using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowTooltipOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject tooltip; // Assign your tooltip object in the inspector

    void Start() {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData) {
        tooltip.SetActive(true);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(true);
        if (ShopData.availableBoats.Contains(ShopData.displayBoatName) && name == "Boat") {
            tooltip.GetComponent<TextMeshProUGUI>().text = PowerupData.raceplanTooltips[ShopData.displayBoatName]+ "\n" +
            ShopData.itemPrices[ShopData.displayBoatName].ToString() + " Gold";
        } else {
            if(ShopData.availableItems.Contains(name)){
                tooltip.GetComponent<TextMeshProUGUI>().text = PowerupData.raceplanTooltips[name]+ "\n" +
                ShopData.itemPrices[name].ToString() + " Gold";
            } else {
                tooltip.GetComponent<TextMeshProUGUI>().text = "Already Owned";
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(false);
    }
}
