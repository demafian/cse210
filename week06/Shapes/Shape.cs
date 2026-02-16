namespace Shapes;

public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor() => _color;
    public void SetColor(string color) => _color = color;

    // This is abstract because a generic "Shape" has no area math.
    public abstract double GetArea();
}