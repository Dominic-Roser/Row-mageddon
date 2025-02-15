using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        // Takes the button name as the scene to load
        GetComponent<Button>().onClick.AddListener(() => LoadScene("Sean" + gameObject.name));
    }

    public void LoadScene(string levelName)
    {
        Debug.Log("Loading scene: " + levelName);
        SceneManager.LoadScene(levelName);
    }
}
