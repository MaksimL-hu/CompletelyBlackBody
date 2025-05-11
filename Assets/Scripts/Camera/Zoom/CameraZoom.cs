using UnityEngine;

[RequireComponent (typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField] protected ZoomSensitivity ZoomSensitivity;

    protected Camera Camera;

    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
}