using UnityEngine;

public class CameraMouseDrag : CameraDrag
{
    public const int RightMouseButton = 0;

    protected override void Drag()
    {
        if (Input.GetMouseButtonDown(RightMouseButton))
        {
            DragOrigin = Camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(RightMouseButton))
        {
            Vector3 mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = DragOrigin - mousePosition;

            transform.position += difference * Sensitivity.SensitivityValue;
        }
    }
}