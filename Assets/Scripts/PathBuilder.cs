using System;
using System.Collections.Generic;
using UnityEngine;

public class PathBuilder : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _startAngleDeg;
    [SerializeField] private RingEdgeColliderWithHole _ring;
    [SerializeField] int _maxReflections = 1000;
    [SerializeField] private float _maxDistance = 10000;

    private List<Vector2> _pathPoints;

    public int PathPointCount => _pathPoints.Count - 1;

    public event Action PathBuilt;

    private void Start()
    {
        _pathPoints = new List<Vector2>();
    }

    private Vector2 AngleToVector(float angleDeg)
    {
        float rad = angleDeg * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
    }

    public Vector2 GetPoint(int index)
    {
        return _pathPoints[index];
    }

    [ContextMenu("Build Path")]
    public void BuildPath()
    {
        _pathPoints.Clear();

        Vector2 direction = AngleToVector(_startAngleDeg);
        Vector2 currentPosition = _startPosition.position;

        _pathPoints.Add(currentPosition);

        for (int i = 0; i < _maxReflections; i++)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(currentPosition + direction * 0.01f, direction, _maxDistance);

            if (hits.Length == 0)
            {
                _pathPoints.Add(currentPosition + direction * _maxDistance);
                PathBuilt?.Invoke();
                return;
            }

            Vector2 hitPoint;

            foreach (RaycastHit2D hit in hits)
            {
                if (currentPosition != hit.point)
                {
                    hitPoint = hit.point;
                    _pathPoints.Add(hitPoint);
                    currentPosition = hitPoint;
                    Debug.DrawRay(hitPoint, hit.normal, Color.yellow, 100f);
                    direction = Vector2.Reflect(direction, hit.normal).normalized;
                }
            }
        }

        PathBuilt?.Invoke();
    }

    public void SetStartAngle(float angle)
    {
        _startAngleDeg = angle;
    }
}