using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public int levelnum;
    void Start()
    {
        string levelname = this.gameObject.name;
        int spaceindex = levelname.IndexOf(" ");
        levelnum = (spaceindex >= 0) ? int.Parse(levelname.Substring(spaceindex + 1)) : int.Parse(levelname);
        if (!levelUnlocked()) {
            Color tempcolor = GetComponent<Image>().color;
            tempcolor.a = 1f;
            GetComponent<Image>().color = tempcolor;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Materials/lock");
        }
    }


    public void LoadScene(string levelName)
    {
        if (levelUnlocked()) {
            Debug.Log("Setting levelToLoad in PlayerData: " + levelName);
            PlayerData.levelToLoad = levelName;
            PlayerData.previousScene = SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadScene("RacePlan");
        }
    }
    public bool levelUnlocked() {
        return PlayerData.playerLevel >= levelnum;
    }
}
