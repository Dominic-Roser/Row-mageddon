using UnityEngine;

public class level7dynamic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerData.halfwaycheckpointcrossed) {
            transform.position = new Vector3(-82f, 1.2f, 0);
            transform.rotation = Quaternion.Euler(0,0,90f);
        }
    }
}
