using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class boatselection : MonoBehaviour
{
    public Button arrow;
    public GameObject boat;
    public static string selectedBoat;
    public static Sprite[] boats;
    public static int selectedBoatIndex;

    void Start()
    {
        boats = new Sprite[4];
        boats[0] = Resources.Load<Sprite>("Materials/Boats/boat");
        boats[1] = Resources.Load<Sprite>("Materials/Boats/boattuah");
        boats[2] = Resources.Load<Sprite>("Materials/Boats/boatthreeah");
        boats[3] = Resources.Load<Sprite>("Materials/Boats/boatfourah");

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
        boat.GetComponent<Image>().sprite = boats[selectedBoatIndex];
    }
}
