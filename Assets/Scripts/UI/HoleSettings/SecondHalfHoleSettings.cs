public class SecondHalfHoleSettings : HoleSettings
{
    protected override void SetInputFieldValue(float value)
    {
        base.SetInputFieldValue(value);
        RingEdgeColliderWithHole.SetHoleEndAngle((int)value);
    }
}