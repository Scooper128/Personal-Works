using System.Text.RegularExpressions;

namespace Summative4;

public class Student
{
    //student info
    public int id { get; }
    public string lName { get; }
    public string fName { get; }
    //student performance
    private int[] challenges;
    public int Challenges { get; }
    public int project { get; }
    public int exam { get; }
    
    public Student(string line)
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
            Challenges = getChallengeScore(challenges);
        }
        
    }

    private int getChallengeScore(int[] scores)
    {
        int[] firstChal = new int[5];
        int[] lastChal = new int[4];
        for (int index = 0; index < 5; index++)
        {
            firstChal[index] = scores[index];
        }

        for (int index = 5; index < 9; index++)
        {
            lastChal[index - 5] = scores[index];
        }
        Array.Sort(firstChal);
        Array.Sort(lastChal);
        Array.Reverse(firstChal);
        Array.Reverse(lastChal);
        return firstChal[0] + firstChal[1] + firstChal[2] + firstChal[3] + lastChal[0] + lastChal[1] + lastChal[2];
    }
}