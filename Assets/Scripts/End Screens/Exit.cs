using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ExitLevel);   

    }

    // Update is called once per frame
    void ExitLevel()
    {
        SceneManager.LoadScene("OverWorld Map");
   
    }
}
