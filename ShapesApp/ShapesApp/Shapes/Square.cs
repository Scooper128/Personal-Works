namespace ShapesApp.Shapes;

public class Square : Shape
{
    public const int MIN_SIDE = 0;
    public const int MAX_SIDE = 50;

    private float _Side;

    public float Side
    {
        get { return _Side; }
        set
        {
            if (value >= MIN_SIDE && value <= MAX_SIDE)
            {
                _Side = value;
            }
        }
    }

    public Square(float side, Colour colour)
    {
        Side = side;
        ShapeColour = colour;
    }

    public override float Area()
    {
        return _Side * _Side;
    }

    public override float Perimeter()
    {
        return 4 * _Side;
    }
    public override string ToString()
    {
        return $"{ShapeColour} square with side {Side}.";
    }
    
}