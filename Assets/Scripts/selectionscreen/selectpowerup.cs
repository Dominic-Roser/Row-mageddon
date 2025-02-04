using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteOnClick : MonoBehaviour
{
    public Button button;
    public GameObject targetObject;
    public Sprite newSprite;

    void Start()
    {

        button.onClick.AddListener(ChangeSprite);
    }

    void ChangeSprite()
    {
        targetObject.GetComponent<Image>().sprite = newSprite; 
    }
}
