using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class RingEdgeColliderWithHole : MonoBehaviour
{
    public const float StartFirstHalfAngle = 0f;
    public const float EndFirstHalfAngle = 180f;
    public const float StartSecondHalfAngle = 180f;
    public const float EndSecondHalfAngle = 360f;

    [Header("Circle Parameters")]
    [SerializeField] private float _radius = 2f;

    [Header("The hole is in degrees")]
    [SerializeField][Range(StartFirstHalfAngle, EndFirstHalfAngle)] private float _holeStartAngle = 90f;
    [SerializeField][Range(StartSecondHalfAngle, EndSecondHalfAngle)] private float _holeEndAngle = 270f;

    [Header("Resolution")]
    [SerializeField] private int _countSegmentsPerHalfCircle = 1000;

    [Header("Colliders")]
    [SerializeField] private List<EdgeCollider2D> _colliders;

    public float Radius => _radius;
    public int CountSegmentsPerHalfCircle => _countSegmentsPerHalfCircle;
    public float HoleStartAngle => _holeStartAngle;
    public float HoleEndAngle => _holeEndAngle;

    public event Action ColliderRebuilt;

    private void Start()
    {
        BuildPartialCircle();
    }

    [ContextMenu("Rebuild Collider")]
    private void BuildPartialCircle()
    {
        float stepAngle = 360f /  (2 * _countSegmentsPerHalfCircle);
        List<Vector2> currentSegment = new List<Vector2>();

        for (float angle = 0; angle <= 360f; angle += stepAngle)
        {
            bool isInHole = IsInHole(angle);

            if (isInHole)
            {
                if (currentSegment.Count > 0)
                {
                    AddCollider(_colliders[0], currentSegment);
                    currentSegment.Clear();
                }

                continue;
            }

            float rad = angle * Mathf.Deg2Rad;
            Vector2 point = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * _radius;
            currentSegment.Add(point);
        }

        AddCollider(_colliders[1], currentSegment);

        ColliderRebuilt?.Invoke();
    }

    private void AddCollider(EdgeCollider2D collider, List<Vector2> points)
    {
        collider.points = points.ToArray();
    }

    public bool IsInHole(float angle)
    {
        return angle >= _holeStartAngle && angle <= _holeEndAngle;
    }

    public void SetHoleStartAngle(int angle)
    {
        _holeStartAngle = angle;
        BuildPartialCircle();
    }

    public void SetHoleEndAngle(int angle)
    {
        _holeEndAngle = angle;
        BuildPartialCircle();
    }
}