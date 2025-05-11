public class FirstHalfHoleSettings : HoleSettings
{
    protected override void SetInputFieldValue(float value)
    {
        base.SetInputFieldValue(value);
        RingEdgeColliderWithHole.SetHoleStartAngle((int)value);
    }
}