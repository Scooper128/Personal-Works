// See https://aka.ms/new-console-template for more information

using ShapesApp.Menu;
using ShapesApp.Shapes;
 
Console.WriteLine("Hello, OO Console Menu!");
 
ShapeManager shapeManager = new ShapeManager();
ShapeManagerMenu menu = new ShapeManagerMenu(shapeManager);
menu.Select();