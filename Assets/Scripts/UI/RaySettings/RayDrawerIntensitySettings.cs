public class RayDrawerIntensitySettings : RayDrawerSettings
{
    protected override void ChangeValue(string value)
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