using UnityEngine;

[RequireComponent(typeof(Camera))]
public abstract class CameraDrag : MonoBehaviour
{
    [SerializeField] protected DragSensitivity Sensitivity;

    protected Vector3 DragOrigin;
    protected Camera Camera;

    private void Start()
    {
        Camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Drag();
    }

    protected abstract void Drag();
}