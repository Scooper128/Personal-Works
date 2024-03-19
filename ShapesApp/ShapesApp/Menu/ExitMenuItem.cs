namespace ShapesApp.Menu;

class ExitMenuItem : MenuItem
{
    private ConsoleMenu _menu;
 
    public ExitMenuItem(ConsoleMenu parentItem)
    {
        _menu = parentItem;
    }
 
    public override string MenuText()
    {
        return "Exit";
    }
 
    public override void Select()
    {
        _menu.IsActive = false;
    }
}