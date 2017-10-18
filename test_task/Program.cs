using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test_task
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("привет, в общем я программа которая делает html файлы \n");
            Console.Write("Сколько строк должно быть в одном файле? - ");
 //нужно проверить на ошибки, защита от шутников ->.......................................................
            String count = Console.ReadLine();
            try
            {
                int counts = Convert.ToInt32(count);
            }
            catch (Exception){
                Console.WriteLine("ошибка ввода. Попробуй снова, но будь внимательнее");
                Console.ReadKey();
 //насильно торможу программу во избежании вылета во время ошибки->
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
             int con = Convert.ToInt32(count);
            //проверка на ошибки закончена................................................................
            //после проверки открываю потоковое соединение.->.............................................
            //узнаю сколько строк в файле всего(что бы разбить на файлы);
            double count_line =File.ReadAllLines("d:\\text.txt").Length;
            double res = count_line / con;
            StreamReader reader = new StreamReader("d:\\text.txt", Encoding.Default);
            String[] translate = File.ReadAllLines("d:\\trans.txt", Encoding.Default);
            for (int i = 0; i < 3; i++)
            {
                File.AppendAllText("d:\\index_" + i + ".html", "<meta charset='utf8'>");
                        for (int j = 0; j < con; j++)
                        {
                             File.AppendAllText("d:\\index_" + i + ".html", reader.ReadLine() + "</br>");
                        }
                        
            }
            reader.Close();
            Console.WriteLine();
            Console.WriteLine("Файл успешно создан...");
            Console.ReadKey();

        }
    }
}
