using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RingEdgeColliderWithHole))]
public class RingEdgeColliderWithHoleViewer : MonoBehaviour
{
    [SerializeField] private RingEdgeColliderWithHole _ring;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float stepAngle = 360f / _ring.CountSegmentsPerHalfCircle;

        List<Vector3> currentSegment = new List<Vector3>();

        for (float angle = 0; angle <= 360f; angle += stepAngle)
        {
            if (_ring.IsInHole(angle))
            {
                if (currentSegment.Count > 0)
                {
                    DrawGizmoSegment(currentSegment);
                    currentSegment.Clear();
                }
                continue;
            }

            float rad = angle * Mathf.Deg2Rad;
            Vector3 point = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * _ring.Radius + transform.position;
            currentSegment.Add(point);
        }

        if (currentSegment.Count > 0)
        {
            DrawGizmoSegment(currentSegment);
        }
    }

    private void DrawGizmoSegment(List<Vector3> segment)
    {
        for (int i = 1; i < segment.Count; i++)
        {
            Gizmos.DrawLine(segment[i - 1], segment[i]);
        }
    }
}