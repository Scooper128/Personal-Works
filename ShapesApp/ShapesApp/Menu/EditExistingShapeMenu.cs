using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class EditExistingShapeMenu:ConsoleMenu
{
    private ShapeManager _manager;
    
    public EditExistingShapeMenu(ShapeManager manager)
    {
        _manager = manager;
    }
    
    public override string MenuText()
    {
        return "Edit an existing shape menu";
    }
    
    public override void CreateMenu()
    {
        _menuItems.Clear();
        foreach (Shape shape in _manager.Shapes)
        {
            switch (shape)
            {
                case Circle:
                    _menuItems.Add(new EditCircleMenu(shape as Circle));
                    break;
                case Square:
                    _menuItems.Add(new EditSquareMenu(shape as Square));
                    break;
            }
        }
        _menuItems.Add(new ExitMenuItem(this));
    }
}