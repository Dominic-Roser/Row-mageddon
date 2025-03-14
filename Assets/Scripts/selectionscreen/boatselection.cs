using UnityEngine;
using UnityEngine.UI;

public class boatselection : MonoBehaviour
{
    public Button arrow;
    public GameObject selectedBoatObj;
    public static Sprite[] boats;
    public static int selectedBoatIndex;

    void Start()
    {
        selectedBoatObj = GameObject.Find("Canvas/Boat");
        boats = new Sprite[PlayerData.UnlockedBoatNames.Count];
        for (int i = 0; i<boats.Length; i++) {
            boats[i] = Resources.Load<Sprite>("TinsleyPieces/"+PlayerData.UnlockedBoatNames[i]);
        }
        arrow.onClick.AddListener(ChangeSprite);
    }

    void ChangeSprite()
    {
        if (this.name == "RButton") {
            selectedBoatIndex++;
        } else {
            selectedBoatIndex--;
        }
        if (selectedBoatIndex>=boats.Length){
            selectedBoatIndex = 0;
        } else if (selectedBoatIndex<=-1) {
            selectedBoatIndex = boats.Length-1;
        }
        selectedBoatObj.GetComponent<Image>().sprite = boats[selectedBoatIndex];
        PlayerData.boatName = PlayerData.UnlockedBoatNames[selectedBoatIndex];
        Debug.Log("boat name: "+ PlayerData.boatName);
    }
}
