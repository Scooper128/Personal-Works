
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
            double challenge = (double)chalScore;
            double examDub = (double)examScore;
            double project = (double)projScore;
            
            bool capped = false;
            double challengePer = (challenge / chal.Max) * 100;
            double examPer = (examDub / exam.Max) * 100;
            double projper = (project / proj.Max) * 100;
            if (examPer < 40 || projper < 40)
            {
                capped = true;
            }
            double overall = (double)Math.Round(((challengePer * chal.Weighting) / 100) + ((projper * proj.Weighting) / 100) +
                             ((examPer * exam.Weighting) / 100), 2);
            if (overall > 34 && capped)
            {
                return 34;
            }
            else
            {
               return overall; 
            }
            
        }
        static void Main(string[] args)
        {
            int firstCount = 0;
            int twoOneCount = 0;
            int twoTwoCount = 0;
            int thirdCount = 0;
            int failCount = 0;
            
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
                switch (students[i].overall)
                {
                    case (>= 70):
                        firstCount++;
                        break;
                    case (>= 60):
                        twoOneCount++;
                        break;
                    case (>= 50):
                        twoTwoCount++;
                        break;
                    case (>= 40):
                        thirdCount++;
                        break;
                    default:
                        failCount++;
                        break;
                }
            }

            Student temp;
            for (int outer = 0; outer < students.Count; outer++)
            {
                for (int inner = 0; inner < students.Count; inner++)
                {
                    if (inner < students.Count - 1 && students[inner].overall < students[inner + 1].overall)
                    {
                        temp = students[inner];
                        students[inner] = students[inner + 1];
                        students[inner + 1] = temp;
                    }
                }
            }
            
            StreamWriter sw = new StreamWriter("Output.txt");
            for (int write = 0; write < students.Count; write++)
            {
                sw.WriteLine($"{students[write].overall} - {students[write].fName} {students[write].lName} ({students[write].id})");
            }
            sw.Close();
            Console.WriteLine($"{firstCount} First\n{twoOneCount} 2:1\n{twoTwoCount} 2:2\n{thirdCount} Third\n{failCount} Fail");
        }
    }
}