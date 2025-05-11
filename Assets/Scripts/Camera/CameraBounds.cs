using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    [Header("Boundary Settings")]
    [SerializeField] private float _leftBound = -10f;
    [SerializeField] private float _rightBound = 10f;
    [SerializeField] private float _bottomBound = -5f;
    [SerializeField] private float _topBound = 5f;

    private Camera _camera;
    private float _cameraHalfWidth;
    private float _cameraHalfHeight;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        CalculateCameraDimensions();
    }

    private void CalculateCameraDimensions()
    {
        _cameraHalfHeight = _camera.orthographicSize;
        _cameraHalfWidth = _cameraHalfHeight * _camera.aspect;
    }

    private void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;

        // ќграничиваем позицию камеры с учетом ее размеров
        clampedPosition.x = Mathf.Clamp(
            clampedPosition.x,
            _leftBound + _cameraHalfWidth,
            _rightBound - _cameraHalfWidth);

        clampedPosition.y = Mathf.Clamp(
            clampedPosition.y,
            _bottomBound + _cameraHalfHeight,
            _topBound - _cameraHalfHeight);

        transform.position = clampedPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 center = new Vector3(
            (_leftBound + _rightBound) * 0.5f,
            (_bottomBound + _topBound) * 0.5f,
            0f);

        Vector3 size = new Vector3(
            _rightBound - _leftBound,
            _topBound - _bottomBound,
            0.1f);

        Gizmos.DrawWireCube(center, size);
    }
}