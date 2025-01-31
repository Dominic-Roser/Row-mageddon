using UnityEngine;
using UnityEngine.SceneManagement;

public class enemymoving : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(-6, 1.5f, 0), new Quaternion());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.92f*Time.deltaTime, 0, 0));
        if(enemyWins()){
            openLoseScreen();
        }
    }
    bool enemyWins(){
        return transform.position.x>8.5;
    }
    void openLoseScreen() {
        SceneManager.LoadScene("LoseScene");
    }
}
