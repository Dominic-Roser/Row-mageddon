using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ContinueToOverworld);   
    }

    // Update is called once per frame
    void ContinueToOverworld()
    {
        PlayerData.gold += 5;
        PlayerData.playerLevel++;
        SceneManager.LoadScene("OverWorld Map");
    }
}
