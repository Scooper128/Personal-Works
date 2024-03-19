using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class EditCircleMenu: EditShapeMenu
{
    private Circle _circle;
 
    public EditCircleMenu(Circle circle) : base(circle)
    {
        _circle = circle;
    }
 
    public override void CreateMenu()
    {
        base.CreateMenu();
        _menuItems.Add(new EditCircleRadiusMenuItem(_circle));
        _menuItems.Add(new ExitMenuItem(this));
    }
}