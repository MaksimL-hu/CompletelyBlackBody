using UnityEngine;

public class ZoomSensitivity : MonoBehaviour
{
    [Header("Zoom Settings")]
    [SerializeField] private float _zoomSpeed = 10f;
    [SerializeField] private float _minZoom = 2f;
    [SerializeField] private float _maxZoom = 20f;

    public float ZoomSpeed => _zoomSpeed;
    public float MinZoom => _minZoom;
    public float MaxZoom => _maxZoom;
}