using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class EditShapeMenu: ConsoleMenu
{
    
    protected Shape _shape;
 
    public EditShapeMenu(Shape shape)
    {
        _shape = shape;
    }
 
    public override void CreateMenu()
    {
        _menuItems.Clear();
        _menuItems.Add(new ColourShapeMenuItem(_shape));
    }
 
    public override string MenuText()
    {
        return _shape.ToString();
    }
 
    public override string ToString()
    {
        return $"Edit {base.ToString()}";
    }
}