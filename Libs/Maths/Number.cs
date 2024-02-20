namespace Maths;

public class Number
{
    private int _number;
    public int Value
    {
        get
        {
            return _number;
        }
        set
        {
            _number = value;
        }
    }

    public int MaxValue => int.MaxValue;
    public int MinValue => int.MinValue;

    public Number()
    {

    }

    public Number(int x)
    {
        _number = x;
    }

    public int Multiply(int coefficient)
    {
        _number = coefficient * _number;
        return _number;
    }

    public int Multiply()
    {
        _number = 2 * _number;
        return _number;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
