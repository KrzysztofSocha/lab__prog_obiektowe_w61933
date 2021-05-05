using System;
using System.IO;
using Newtonsoft.Json;


namespace lab4
{
    class Program
    {
        static void toolsFile()
        {
            Console.WriteLine("Podaj nazwę pliku");
            //using (var sr = new StreamReader("nr_albumu.txt"))
            string nameFile = Console.ReadLine();
            bool endLoop = false;
            do
            {
                Console.WriteLine("Wybierz działanie na pliku");
                Console.WriteLine("1 - zapis do pliku");
                Console.WriteLine("2 - wczytanie pliku");

                int choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        using (var sw = new StreamWriter(nameFile))
                        {
                            Console.WriteLine("Wpisz treść");
                            string contentFile = Console.ReadLine();
                            sw.WriteLine(contentFile);

                        }
                        break;
                    case 2:
                        using (var sr = new StreamReader(nameFile))
                        {
                            var line = sr.ReadToEnd();
                            Console.WriteLine(line);
                        }
                        break;
                    default:
                        endLoop = true;
                        break;
                }
            } while (endLoop != true);
        }
        static void peselsAnalize()
        {
            int numberMen = 0;
            int numberWomen = 0;
            bool errorWrite = false;
            double checkReturn;
            bool checkDouble;

            using (var sr = new StreamReader("pesels.txt"))
            {
                var line = sr.ReadLine();
                while (line != null)
                {
                    //Pesel powinien mieścić się w typie double, jęśli nie będzie typu liczbowego zbiór nie zostanie przeanalizowany
                    checkDouble = double.TryParse(line, out checkReturn);

                    //Jeśli przedostatnia cyfra peselu jest parzyta, to pesel ten należy do kobiety
                    if (line[9] % 2 == 0 && checkDouble == true)
                    {
                        numberWomen++;
                    }
                    else if (line[9] % 2 != 0 && checkDouble == true)
                    {
                        numberMen++;
                    }
                    else
                    {
                        Console.WriteLine("Natrafiono na błędną wartość");
                        errorWrite = true;
                        break;
                    }

                    line = sr.ReadLine();
                }
                if (errorWrite == false)
                {

                    Console.WriteLine("W podanym zbiorze peseli jest " + numberWomen + " kobiet oraz " + numberMen + " mężczyzn");

                }
            }

        }
        static void Main(string[] args)
        {
            //toolsFile();
            //peselsAnalize();
        }
    }
}