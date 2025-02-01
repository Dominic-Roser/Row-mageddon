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
        transform.position = new Vector3(playerBoat.transform.position.x, 0f, -10f);
    }
}
