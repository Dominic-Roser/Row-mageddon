using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{
    public Button start;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start.onClick.AddListener(NewGame);
    }

    // Update is called once per frame
    void NewGame()
    {
        SceneManager.LoadScene("Domscene");
    }
}
