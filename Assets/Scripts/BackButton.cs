using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Back()
    {
        SceneManager.LoadScene(PlayerData.previousScene);
    }
}
