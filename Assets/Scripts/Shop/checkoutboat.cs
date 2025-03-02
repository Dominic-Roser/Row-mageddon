using UnityEngine;
using UnityEngine.UI;

public class checkoutboat : MonoBehaviour {
  
    private GameObject displayedBoat;
    public static Sprite[] boats;
    public static int selectedBoatIndex;

    void Start()
    {
      displayedBoat = GameObject.Find("Canvas/Boat");
      if(PlayerData.UnlockedBoatNames.Contains(ShopData.displayBoatName)){
        Color hazy = displayedBoat.GetComponent<Image>().color;
        hazy.a = 0.3f;
        displayedBoat.GetComponent<Image>().color = hazy;
      } else {
        Color opaq = displayedBoat.GetComponent<Image>().color;
        opaq.a = 1f;
        displayedBoat.GetComponent<Image>().color = opaq;
      }
      boats = new Sprite[ShopData.allBoats.Count];
      for (int i = 0; i<boats.Length; i++) {
        boats[i] = Resources.Load<Sprite>("TinsleyPieces/"+ShopData.allBoats[i]);
      }
      gameObject.GetComponent<Button>().onClick.AddListener(ChangeSprite);
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
      ShopData.displayBoatName = ShopData.allBoats[selectedBoatIndex];
      Debug.Log("display name: "+ShopData.displayBoatName);
      displayedBoat.GetComponent<Image>().sprite = boats[selectedBoatIndex];
      if(PlayerData.UnlockedBoatNames.Contains(ShopData.displayBoatName)){
        Color hazy = displayedBoat.GetComponent<Image>().color;
        hazy.a = 0.3f;
        displayedBoat.GetComponent<Image>().color = hazy;
      } else {
        Color opaq = displayedBoat.GetComponent<Image>().color;
        opaq.a = 1f;
        displayedBoat.GetComponent<Image>().color = opaq;
      }
    }
}