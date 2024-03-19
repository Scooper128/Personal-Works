namespace ShapesApp.Shapes;

public class ShapeManager
{
    public List<Shape> Shapes { get; private set; }
 
    public ShapeManager()
    {
        Shapes = new List<Shape>();
    }
 
    public void AddShape(Shape pShape)
    {
        Shapes.Add(pShape);
    }
}