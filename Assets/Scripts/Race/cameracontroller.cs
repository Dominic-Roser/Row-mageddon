using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBoat; // Reference to the boat
    public Vector3 offset;      // Initial offset

    void Start()
    {
        offset = transform.position - playerBoat.position;
        transform.position = playerBoat.position;

    }

    void LateUpdate()
    {
        if (playerBoat == null) return;

        //  Keep the camera at the same offset relative to the player
        transform.position = new Vector3(playerBoat.position.x + 4.0f, playerBoat.position.y + 2.0f, -10.0f);
    }
}
