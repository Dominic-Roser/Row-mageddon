using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopLoader : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(loadShop);
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void loadShop()
    {
        Debug.Log("Loading scene...");
        SceneManager.LoadScene("Shop");
    }
}
