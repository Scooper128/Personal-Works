using System.Text;
using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class AddCircleMenuItem: MenuItem
{
    private ShapeManager _manager;
    
    public AddCircleMenuItem(ShapeManager manager)
    {
        _manager = manager;
    }
    
    public override string MenuText()
    {
        return "Add Circle Menu";
    }
    
    public override void Select()
    {
        StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
        ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
        selectColourMenu.Select();
        Shape.Colour colour = selectColourMenu.Colour;
        int radius = ConsoleHelpers.GetIntegerInRange(Circle.MIN_RADIUS, Circle.MAX_RADIUS, "What is the radius");
        Circle circle = new Circle(radius, colour);
        _manager.AddShape(circle);
    }
}