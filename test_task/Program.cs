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
            StreamReader reader = new StreamReader("d:\\text.txt", Encoding.Default);
            //узнаю сколько строк в файле всего(что бы разбить на файлы);
            double count_line =File.ReadAllLines("d:\\text.txt").Length;
            double res = count_line / con;
            int res_1 = Convert.ToInt32(count_line / con);
            double devi = res - res_1;
            //открываю файл словаря 
            String[] translate = File.ReadAllLines("d:\\trans.txt", Encoding.Default);
            for (int i = 0; i < res_1; i++)
            {
                File.AppendAllText("d:\\index_" + i + ".html", "<html> <head> <meta charset='utf8'> </head> <body>");
                        for (int j = 0; j < con; j++)
                        {
                    String s = reader.ReadLine();
                    if (j != 0) {
                        File.AppendAllText("d:\\index_" + i + ".html", "</br>");
                    }
                    String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    


                    foreach (String life in words)
                    {
                        foreach (String half in translate)
                        {
                            if (half == life)
                            {
                                File.AppendAllText("d:\\index_" + i + ".html", " <i><b>" + life + "</i></b> ");
                                break;

                            }
                        }
                        File.AppendAllText("d:\\index_" + i + ".html", " " + life + " ");
                    }
                }
                        
            }

            
            reader.Close();
            Console.WriteLine();
            Console.WriteLine("Файл успешно создан...");
            Console.ReadKey();

        }
    }
}
