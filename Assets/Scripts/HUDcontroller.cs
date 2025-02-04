using UnityEngine;

public class HUDcontroller : MonoBehaviour
{
    public GameObject MainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, 0f);
        transform.rotation = MainCamera.transform.rotation;

    }
}
