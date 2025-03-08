using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private GameObject highlight; // Assign your tooltip object in the inspector

    void Start() {
        highlight = transform.Find("Highlight").gameObject;
        highlight.SetActive(false);

    }
    public void OnPointerEnter(PointerEventData eventData) {
      highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
      highlight.SetActive(false);
    }
}
