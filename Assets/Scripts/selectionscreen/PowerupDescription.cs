using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public GameObject tooltip; // Assign your tooltip object in the inspector

    void Start() {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData) {
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(true);
        tooltip.SetActive(true);
        tooltip.GetComponent<TextMeshProUGUI>().text = PowerupData.powerupTooltips[name];
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltip.SetActive(false);
        GameObject.Find("Canvas/TooltipParent/bg").SetActive(false);
    }
}
