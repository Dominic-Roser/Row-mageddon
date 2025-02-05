using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public GameObject playerBoat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerBoat.transform.position.x + 2, playerBoat.transform.position.y + 3, -10f);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            transform.rotation = playerBoat.transform.rotation; //(new Vector3(0f,0f,playerBoat.transform.rotation.z));
        }
    }
}
