using UnityEngine;
using UnityEngine.UI;

public class BuildRayButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private PathBuilder _pathBuilder;
    [SerializeField] private RayDrawer _rayDrawer;

    private void OnEnable()
    {
        _button.onClick.AddListener(BuildRay);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(BuildRay);
    }

    private void BuildRay()
    {
        _pathBuilder.BuildPath();
        _rayDrawer.Draw();
    }
}