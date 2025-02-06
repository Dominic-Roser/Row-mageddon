using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadSaveFiles);
    }

    // Update is called once per frame
    void LoadSaveFiles()
    {
        
    }
}
