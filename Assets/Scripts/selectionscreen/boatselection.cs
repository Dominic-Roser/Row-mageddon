using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class boatselection : MonoBehaviour
{
    public Button arrow;
    public GameObject boat;
    private GameObject grid;
    public static string selectedBoat;
    public static Sprite[] boats;
    public static int selectedBoatIndex;

    void Start()
    {
        boats = new Sprite[4];
        boats[0] = Resources.Load<Sprite>("Materials/WoodenBoat");
        boats[1] = Resources.Load<Sprite>("Materials/lock");
        boats[2] = Resources.Load<Sprite>("Materials/lock");
        boats[3] = Resources.Load<Sprite>("Materials/lock");
        grid = GameObject.Find("PowerupGrid");
        arrow.onClick.AddListener(ChangeSprite);
    }

    void ChangeSprite()
    {
        grid.GetComponent<AudioSource>().Play();

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
