using UnityEngine;

public class CameraMouseZoom : CameraZoom
{
    public const string MouseScrollWheel = "Mouse ScrollWheel";

    private void Update()
    {
        float scroll = Input.GetAxis(MouseScrollWheel);

        if (scroll != 0f)
        {
                Camera.orthographicSize -= scroll * ZoomSensitivity.ZoomSpeed;
                Camera.orthographicSize = Mathf.Clamp(Camera.orthographicSize, ZoomSensitivity.MinZoom, ZoomSensitivity.MaxZoom);
        }
    }
}