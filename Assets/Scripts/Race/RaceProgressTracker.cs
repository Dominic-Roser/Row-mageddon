using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class RaceProgressTracker : MonoBehaviour
{
    private SplineContainer trackSpline;
    private Transform boat;
    private float raceDistance = 0f; // Distance traveled along the spline

    public float RaceDistance => raceDistance;

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

    void Update()
    {
        Spline spline = trackSpline.Splines[0];

        float3 boatLocalPosition = trackSpline.transform.InverseTransformPoint(boat.position);

        float3 nearestPoint;
        float t;
        SplineUtility.GetNearestPoint(spline, boatLocalPosition, out nearestPoint, out t, 100);

        nearestPoint = trackSpline.transform.TransformPoint(nearestPoint);

        float splineLength = SplineUtility.CalculateLength(spline, trackSpline.transform.localToWorldMatrix);

        raceDistance = t * splineLength; // Use distance instead of percentage

        //Debug.DrawLine(boat.position, nearestPoint, Color.red, 0.01f);
    }
}
