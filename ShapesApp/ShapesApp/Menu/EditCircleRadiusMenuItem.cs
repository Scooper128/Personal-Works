using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class EditCircleRadiusMenuItem: MenuItem
{
    private Circle _circle;
 
    public EditCircleRadiusMenuItem(Circle circle)
    {
        _circle = circle;
    }
 
    public override string MenuText()
    {
        return "Edit radius";
    }
 
    public override void Select()
    {
        _circle.Radius = ConsoleHelpers.GetIntegerInRange(Circle.MIN_RADIUS, Circle.MAX_RADIUS, "Enter new radius");
    }
}