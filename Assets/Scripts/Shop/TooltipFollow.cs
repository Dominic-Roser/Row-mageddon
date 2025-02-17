using UnityEngine;

public class TooltipFollow : MonoBehaviour {
    void Update() {
        transform.position = Input.mousePosition;
    }
}
