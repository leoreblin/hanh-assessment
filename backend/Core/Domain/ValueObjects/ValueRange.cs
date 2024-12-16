namespace Domain.ValueObjects;

public sealed class ValueRange
{
    public ValueRange(int max, int min) : this()
    {
        EnsureMinMax(max, min);

        Max = max;
        Min = min;
    }

    private ValueRange() { }

    public int Max { get; }

    public int Min { get; }

    private static void EnsureMinMax(int max, int min)
    {
        if (max <= min)
        {
            throw new ArgumentException("Max parameter cannot be less than or equal to min parameter.", nameof(max));
        }

        if (max <= 0)
        {
            throw new ArgumentException("Max parameter cannot be less than or equal to zero.", nameof(max));
        }

        if (min <= 0)
        {
            throw new ArgumentException("Min parameter cannot be less than or equal to zero.", nameof(min));
        }
    }
}
