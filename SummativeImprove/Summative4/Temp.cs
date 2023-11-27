using System.Text.RegularExpressions;

namespace Summative4;

public class Temp
{
    //student info
    private int id;
    private string lName;
    private string fName; 
    //student performance
    private int[] challenges;
    private int project;
    private int exam;
    
    public Temp(string line)
    {
        string data = line;
        Regex regex = new Regex(@"Student:\[ID:(\d+),lastName:(\w+),FirstName:(\w+)\]Marks:\[Challenges:\[([0-9]+)\],Exam:(\d+),Capstone:(\d+)\]");
        Match match = regex.Match(data);
        if(match.Success)
        {
            id = int.Parse(match.Groups[1].Value);
            lName = match.Groups[2].Value;
            fName = match.Groups[3].Value;
            challenges = match.Groups[4].Value.Split(',').Select(int.Parse).ToArray();
            exam = int.Parse(match.Groups[5].Value);
            project = int.Parse(match.Groups[6].Value);
        }
        
    }
}