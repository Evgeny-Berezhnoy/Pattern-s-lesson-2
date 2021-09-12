public class Health
{
    public float Max { get; }
    public float Current { get; set; }

    public Health(float max, float current)
    {
        Max = max;
        Current = current;
    }
}
