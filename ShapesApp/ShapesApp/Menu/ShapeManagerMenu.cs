using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class ShapeManagerMenu: ConsoleMenu
{
    private ShapeManager _manager;
    
    public ShapeManagerMenu(ShapeManager manager)
    {
        _manager = manager;
    }

    public override void CreateMenu()
    {
        _menuItems.Clear();
        _menuItems.Add(new AddCircleMenuItem(_manager));
        _menuItems.Add(new AddSqaureMenuItem(_manager));
        if (_manager.Shapes.Count > 0)
        {
            _menuItems.Add(new EditExistingShapeMenu(_manager));
        }
        _menuItems.Add(new ExitMenuItem(this));
    }
    
    public override string MenuText()
    {
        return "Shape Manager Menu"+Environment.NewLine+_manager.ToString();
    }
}