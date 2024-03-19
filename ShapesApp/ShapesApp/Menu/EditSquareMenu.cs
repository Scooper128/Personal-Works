using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class EditSquareMenu: EditShapeMenu
{
    private Square _square;

    public EditSquareMenu(Square square) : base(square)
    {
        _square = square;
    }

    public override void CreateMenu()
    {
        base.CreateMenu();
        _menuItems.Add(new EditSquareSideMenuItem(_square));
        _menuItems.Add(new ExitMenuItem(this));
    }
    
}