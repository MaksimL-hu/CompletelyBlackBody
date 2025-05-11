using UnityEngine;

public class CameraTouchZoom : CameraZoom
{
    [SerializeField] private float touchZoomSpeed = 0.1f;

    private float initialDistance;
    private Vector3 initialPosition;

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch0.position, touch1.position);
                initialPosition = Camera.transform.position;
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);
                float difference = initialDistance - currentDistance;

                Camera.orthographicSize += difference * touchZoomSpeed;
                Camera.orthographicSize = Mathf.Clamp(Camera.orthographicSize,
                    ZoomSensitivity.MinZoom, ZoomSensitivity.MaxZoom);
            }
        }
    }
}