using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class EditSquareSideMenuItem: MenuItem
{
    private Square _square;
    
    public EditSquareSideMenuItem(Square square)
    {
        _square = square;
    }
    
    public override string MenuText()
    {
        return "Edit side length";
    }
    
    public override void Select()
    {
        _square.Side = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "Enter new side length");
    }
}