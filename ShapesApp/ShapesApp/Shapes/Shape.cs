namespace ShapesApp.Shapes;

internal abstract class Shape
{
    public enum Colour
    {
        Red,
        Green,
        Blue
    }
    public Colour ShapeColour { get; set; }

    public abstract float Area();
    public abstract float Perimeter();
}