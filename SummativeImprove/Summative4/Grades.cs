using System.Diagnostics.Contracts;

namespace Summative4;

public class Grades
{
    public int Max { get; set; }
    public int Weighting { get; set; }
    
    public Grades(int maxMark, int weighting)
    {
        Max = maxMark;
        Weighting = weighting;
    }
}