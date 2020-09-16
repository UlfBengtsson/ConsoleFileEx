using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleFileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool keepLooping = true;

            List<string> femaleFirstNames = ReadFileToStringList("FemaleFirstNames.txt");
            List<string> maleFirstNames = ReadFileToStringList("MaleFirstNames.txt");
            List<string> lastNames = ReadFileToStringList("LastNames.txt");

            do
            {
                Console.WriteLine("----- Names Menu -----\nPress 1: Show female first names\nPress 2: Show male first names\nPress 3: Show last names\nPress q to quit\n");
                char selection = Console.ReadKey(true).KeyChar;

                switch (selection)
                {
                    case '1':
                        PrintList(femaleFirstNames);
                        break;
                    case '2':
                        PrintList(maleFirstNames);
                        break;
                    case '3':
                        PrintList(lastNames);
                        break;
                    case '4':
                        Console.WriteLine("Random female first name: " + RandomPickString(femaleFirstNames,random));
                        break;

                    case '5':

                        break;

                    case '6':

                        break;

                    case '7':

                        break;

                    case 'q':
                        keepLooping = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid selection");
                        break;
                }

                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();

            } while (keepLooping);
        }


        static void PrintList(List<string> listOfStrings)
        {
            foreach (var item in listOfStrings)
            {
                Console.WriteLine(item);
            }
        }

        static string RandomPickString(List<string> names, Random random)
        {
            return names[random.Next(names.Count)];
        }

        static string RandomPickFullName(List<string> firstNames, List<string> lastNames, Random random)
        {
            string fullName = RandomPickString(firstNames, random) + ' ' + RandomPickString(lastNames, random);
            return fullName;
        }

        static List<string> ReadFileToStringList(string fileName)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("was unable to open file: " + fileName);
            }
            catch (IOException)
            {
                Console.WriteLine("IO error - file: " + fileName);
            }

            return lines;
        }
    }
}
