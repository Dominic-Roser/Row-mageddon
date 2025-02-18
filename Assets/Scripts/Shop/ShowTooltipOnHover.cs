using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltipOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject tooltip; // Assign your tooltip object in the inspector

    void Start() {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData) {
        tooltip.SetActive(true);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(true);
        if(ShopData.availableItems.Contains(name)){
            tooltip.GetComponent<TextMeshProUGUI>().text = ShopData.powerupPrices[name].ToString() + " Gold";
        } else {
            tooltip.GetComponent<TextMeshProUGUI>().text = "Already Owned";
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(false);
    }
}
