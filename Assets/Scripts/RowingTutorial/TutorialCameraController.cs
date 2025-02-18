using UnityEngine;

public class TutorialCameraController : MonoBehaviour
{
    public Transform playerBoat; // Reference to the boat
    public Vector3 offset;      // Initial offset

    void Start()
    {
        //  Set initial offset relative to the player’s position
        offset = new Vector3(0f, 2f, -10f);
    }

    void LateUpdate()
    {
        if (playerBoat == null) return;

        //  Keep the camera at the same offset relative to the player
        transform.position = playerBoat.position + offset;
    }
}
