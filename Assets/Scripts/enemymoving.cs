using UnityEngine;
using UnityEngine.SceneManagement;

public class enemymoving : MonoBehaviour
{
    public float defaultSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSpeed = 1f;
        transform.SetPositionAndRotation(new Vector3(-6, 1.5f, 0), new Quaternion());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(defaultSpeed*Time.deltaTime, 0, 0));
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bow Ball")
        {
            defaultSpeed = -1f;
        }
    }
}
