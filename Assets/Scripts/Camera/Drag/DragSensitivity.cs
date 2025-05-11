using UnityEngine;

public class DragSensitivity : MonoBehaviour
{
    [SerializeField] private float _sensitivityValue = 0.06f;

    public float SensitivityValue => _sensitivityValue;

    public void SetSensitivity(float sensitivityValue)
    {
        _sensitivityValue = sensitivityValue;
    }
}