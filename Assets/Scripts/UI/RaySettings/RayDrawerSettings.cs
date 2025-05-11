using TMPro;
using UnityEngine;

public class RayDrawerSettings : MonoBehaviour
{
    [SerializeField] protected TMP_InputField InputField;
    [SerializeField] protected RayDrawer RayDrawer;

    private void OnEnable()
    {
        InputField.onEndEdit.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        InputField.onEndEdit.RemoveListener(ChangeValue);
    }

    protected virtual void ChangeValue(string value)
    {
        int intValue = int.Parse(value);

        if (intValue < Constants.ZeroPercent)
            intValue = Constants.ZeroPercent;
        if (intValue > Constants.OneHundredPercent)
            intValue = Constants.OneHundredPercent;

        InputField.text = intValue.ToString();
        RayDrawer.SetExtinctionInPercent(intValue);
    }
}