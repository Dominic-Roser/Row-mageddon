using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the player gets there first
        if (other.gameObject.name == "Boat")
        {
            SceneManager.LoadScene("WinScene");
        } else { // if the player doesn't get there first
            SceneManager.LoadScene("LoseScene");
        }
    }
}