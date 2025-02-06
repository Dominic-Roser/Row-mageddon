using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class readyup : MonoBehaviour
{
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(Ready);
    }

    // Update is called once per frame
    void Ready()
    {
        SceneManager.LoadScene("Domscene");
    }
}
