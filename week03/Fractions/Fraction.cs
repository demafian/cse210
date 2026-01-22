using System;

public class Fraction
{
    // Private attributes (Encapsulation)
    private int _top;
    private int _bottom;

    // Constructor: 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor: wholeNumber/1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor: top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop() { return _top; }
    public void SetTop(int top) { _top = top; }

    public int GetBottom() { return _bottom; }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Error: Denominator cannot be zero. Setting to 1.");
            _bottom = 1;
        }
    }

    // Representation methods
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        // Cast to double to avoid integer division
        return (double)_top / _bottom;
    }
}