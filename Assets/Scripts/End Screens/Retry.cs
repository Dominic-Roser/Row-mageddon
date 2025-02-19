using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        GetComponent<Button>().onClick.AddListener(RetryLevel);   
    }

    // Update is called once per frame
    void RetryLevel()
    {
        if (PlayerData.playerLevel == 0)
        {

            SceneManager.LoadScene("RowingTutorial");
        }
        else
        {
            SceneManager.LoadScene("RacePlan");
        }
    }
}
