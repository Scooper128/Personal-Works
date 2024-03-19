using System.Text;
using ShapesApp.Shapes;

namespace ShapesApp.Menu;

internal class AddSqaureMenuItem: MenuItem
{
    private ShapeManager _manager;
    
    public AddSqaureMenuItem(ShapeManager manager)
    {
        _manager = manager;
    }
    
    public override string MenuText()
    {
        return "Add Square Menu";
    }
    
    public override void Select()
    {
        StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
        ColourShapeMenuItem selectColourMenu = new ColourShapeMenuItem();
        selectColourMenu.Select();
        Shape.Colour colour = selectColourMenu.Colour;
        int side = ConsoleHelpers.GetIntegerInRange(Square.MIN_SIDE, Square.MAX_SIDE, "What is the side length");
        Square square = new Square(side, colour);
        _manager.AddShape(square);
    }
}