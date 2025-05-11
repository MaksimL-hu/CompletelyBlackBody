public class StartRayAngleSettingsButton : RayDrawerSettings
{
    protected override void ChangeValue(string value)
    {
        int intValue = int.Parse(value);

        if (intValue < 0)
            intValue = 0;
        if (intValue > Constants.PerpendicularValue)
            intValue = Constants.PerpendicularValue;

        InputField.text = intValue.ToString();
        RayDrawer.PathBuilder.SetStartAngle(intValue);
    }
}
