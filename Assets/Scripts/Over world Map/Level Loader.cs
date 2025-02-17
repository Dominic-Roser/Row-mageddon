using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        string levelname = this.gameObject.name;
        int spaceindex = levelname.IndexOf(" ");
        string levelnum = (spaceindex >= 0) ? levelname.Substring(spaceindex + 1) : levelname;
        Debug.Log(levelnum);
        if (PlayerData.playerLevel < int.Parse(levelnum)) {
            Color tempcolor = GetComponent<Image>().color;
            tempcolor.a = 1f;
            GetComponent<Image>().color = tempcolor;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/lock");
        }
    }


    public void LoadScene(string levelName)
    {
        Debug.Log("Setting levelToLoad in PlayerData: " + levelName);
        PlayerData.levelToLoad = levelName;
        PlayerData.previousScene = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene("RacePlan"); 
    }
}
