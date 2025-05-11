using System.Collections.Generic;
using UnityEngine;

public class RingHoleBuilder : MonoBehaviour
{
    [SerializeField] private RingEdgeColliderWithHole _ringEdgeColliderWithHole;
    [SerializeField] private HolePart _holePartPrefab;
    [SerializeField] private Transform _container;

    private List<HolePart> _holeParts;

    private void Awake()
    {
        _holeParts = new List<HolePart>();
    }

    private void OnEnable()
    {
        _ringEdgeColliderWithHole.ColliderRebuilt += BuildHole;
    }

    private void OnDisable()
    {
        _ringEdgeColliderWithHole.ColliderRebuilt -= BuildHole;
    }

    private void BuildHole()
    {
        DestroyHole();

        InstantiatePartHole(RingEdgeColliderWithHole.EndFirstHalfAngle, _ringEdgeColliderWithHole.HoleStartAngle, true);
        InstantiatePartHole(_ringEdgeColliderWithHole.HoleEndAngle, RingEdgeColliderWithHole.StartSecondHalfAngle, false);
    }

    private void DestroyHole()
    {
        foreach (HolePart part in _holeParts)
        {
            Destroy(part.gameObject);
        }

        _holeParts.Clear();
    }

    private void InstantiatePartHole(float startAngle, float endAngle, bool isTopPart)
    {
        if (startAngle == endAngle)
            return;

        int rotationSide = 1;
        int additional = rotationSide;

        if (isTopPart)
        {
            rotationSide = -1;
            additional = 0;
        }

        for (int i = 0 + additional; i < startAngle - endAngle + additional; i++)
        {
            HolePart holePart = Instantiate(_holePartPrefab);
            _holeParts.Add(holePart);
            holePart.transform.parent = _container;
            holePart.transform.Rotate(new Vector3(0, 0, rotationSide * i));
        }
    }
}