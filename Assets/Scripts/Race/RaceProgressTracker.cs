using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class RaceProgressTracker : MonoBehaviour
{
    private SplineContainer trackSpline;
    private Transform boat;
    private float raceProgress = 0f; // 0-100% 
    public float RaceProgress => raceProgress;
    //private float lastLoggedProgress = -1f;
    void Start()
    {
        GameObject splineObject = GameObject.Find("raceSpline");

        if (splineObject == null)
        {
            Debug.LogError("RaceProgressTracker: No GameObject named 'raceSpline' found");
            return;
        }

        trackSpline = splineObject.GetComponent<SplineContainer>();

        if (trackSpline == null)
        {
            Debug.LogError("RaceProgressTracker: 'raceSpline' does not have a SplineContainer component");
            return;
        }

        boat = transform;
    }

    // part of printing out boat name and progress
    void Update()
    {
        // Get the spline track
        Spline spline = trackSpline.Splines[0];

        // Convert the boat position to the local space of the spline
        float3 boatLocalPosition = trackSpline.transform.InverseTransformPoint(boat.position);

        // Get nearest point on the spline 
        float3 nearestPoint;
        float t;
        SplineUtility.GetNearestPoint(spline, boatLocalPosition, out nearestPoint, out t, 100); 

        // Convert nearest point back to world space
        nearestPoint = trackSpline.transform.TransformPoint(nearestPoint);

        // Convert t (0-1) to percentage (0-100%)
        raceProgress = t * 100f;

        /*
        // Draw line from boat to nearest point
        Debug.DrawLine(boat.position, nearestPoint, Color.red, 0.01f);

        // prints out boat name and progress for debugging
        if (Mathf.Abs(raceProgress - lastLoggedProgress) >= 1f)
        {
            Debug.Log($"{boat.name} Progress: {raceProgress}%");
            lastLoggedProgress = raceProgress; // Update last logged value
        }
        */
    }
}
