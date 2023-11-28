
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
        static void Main(string[] args)
        {
            
            
            
            
            //main function starts here
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
        }
    }
}