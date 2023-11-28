
namespace Summative4
{
    class Program
    {
        static bool InRange(int value, int max, int min)//checks value is in correct range
        {
            if(value>max || value < min)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        static string FileSelection()//selection of file is made
        {  
            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.mark");
            int count = 0;
            foreach(string file in files)//loops through all files and lists them
            {
                Console.WriteLine($"{count}. {Path.GetFileName(file)}");
                count++;
            }
            var input = Console.ReadLine();//selection made
            if (int.TryParse(input, out int result) && InRange(result, files.Length, 0))
            {
                return Path.GetFileName(files[result]);
            }
            else
            {
                return null;
            }
        }

        static double OverallClass(Grades chal, int chalScore, Grades exam, int examScore, Grades proj, int projScore)
        {
            double challengePer = (chalScore / chal.Max) * 100;
            double examPer = (examScore / exam.Max) * 100;
            double projper = (projScore / proj.Max) * 100;
            double overall = ((challengePer * chal.Weighting) / 100) + ((projper * proj.Weighting) / 100) +
                             ((examPer * exam.Weighting) / 100);
            return overall;
        }
        static void Main(string[] args)
        {
            Grades challenge = new Grades(35,50);
            Grades exam = new Grades(7,25);
            Grades project = new Grades(100,25);
            string file;

            do
            {
                file = FileSelection();
                if (file == null)
                {
                    Console.WriteLine("That was not a valid input");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);

            string[] lines = File.ReadAllLines(file);

            var students = new List<Student>();
            for(int i = 0; i<lines.Length; i++)
            {
                students.Add(new Student(lines[i]));
            }

            for (int i = 0; i < students.Count; i++)
            {
                students[i].overall = OverallClass(challenge, students[i].Challenges, exam, students[i].exam, project,
                    students[i].project);
            }
        }
    }
}