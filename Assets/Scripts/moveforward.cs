using UnityEngine;

public class moveforward : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(-6, 0, 0), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.6f*Time.deltaTime, 0, 0));

        if(Input.GetKeyDown(KeyCode.Space)){ 
            transform.Translate(new Vector3(80f*Time.deltaTime, 0, 0));
        }
    }
}
