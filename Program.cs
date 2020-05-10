using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();     //"see", "create", "remove"
            const string ExitProgramKeyword = "exit";
            string commandPrompt = "Please enter " + notebook.show + ", " + notebook.delete + ", or " + notebook._new;

            Console.WriteLine(Notebook.IntroMessage);
            Console.WriteLine(commandPrompt);
            string input = "";

            do
            {
                input = Console.ReadLine();

                //breaks input up into tokens in an array
                string[] commands = input.Split();


                try {
                    /*get the first command...show, new, or delete
                    and pass the second command to the functions
                    still needs to be in the correct format*/
                    notebook[commands[0]]((commands.Length > 1) ? commands[1] : "");
                }
                //Stops the program is ExitProgramKeyword is entered
                catch (KeyNotFoundException)
                {
                    if (input != ExitProgramKeyword)
                    {
                        Console.WriteLine(commandPrompt);
                    }
                }
            } while (input != ExitProgramKeyword);

            Console.WriteLine(Notebook.OuttroMessage);

        }
    }
}
