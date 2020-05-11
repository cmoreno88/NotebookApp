using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Notebook
    {
        //notification messages
        public const string IntroMessage = "Welcome to notebook program";
        public const string OuttroMessage = "Hope you'll use the notebook again, GoodBye!";

        //list of pages
        List<IPageable> pages = new List<IPageable>();

        public delegate void SimpleFunction(string command);
        public delegate void BooleanFunction(bool isOn);
        public event SimpleFunction ItemAdded, ItemRemoved, InputBadCommand;
        //event is set in LOG();
        public event BooleanFunction loggingToggled;
        private Dictionary<string, SimpleFunction> commandLineArgs = new Dictionary<string, SimpleFunction>();
        
        //these are our keys
        public readonly string show = "show", _new = "new", delete = "delete", log = "logger";

        //define our indexer
        public SimpleFunction this[string command]
        {
            get { return commandLineArgs[command]; }
        }

        //we specify an access modifier and then say the name of the class to create constructors
        //Initialize our dictionary by associating word keys with methods, in Notebook constructor
        public Notebook()
        {
            commandLineArgs.Add(show, Show);
            commandLineArgs.Add(_new, New);
            commandLineArgs.Add(delete, Delete);
            commandLineArgs.Add(log, Log);
        }

        //this key word calls the basic constructor BEFORE utilizing this one
        //it allows us to specify which words access which methods
        /// <summary>
        /// Creates a new notebook with input keywords for commands instead of default ones
        /// </summary>
        /// <param name="commandLineKeywords">index 0 = show, 1 = new, 3 = delete</param>
        public Notebook(params string[] commandLineKeywords) : this()
        {
            for(int i = 0; i < commandLineKeywords.Length; ++i)
            {
                //if nothing is input jump to next iteration
                if (commandLineKeywords[i] == "")
                {
                    continue;
                }
                switch (i)
                {
                    //show, remove show and set it equal to the input of the current item
                    case 0:
                        commandLineArgs.Remove(show);
                        commandLineArgs.Add(show = commandLineKeywords[i], Show);
                        break;
                    
                    //_new
                    case 1:
                        commandLineArgs.Remove(_new);
                        commandLineArgs.Add(_new = commandLineKeywords[i], New);
                        break;

                    //delete
                    case 2:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeywords[i], Delete);
                        break;

                }
            }
        }

        //property methods, set to private because they are called by the accessor
        private void New(string command)
        {
            //Console.WriteLine("New method " + command);
            switch (command)
            {
                case "":
                    Console.WriteLine("New commands:");
                    Console.WriteLine("message  create new message page");
                    Console.WriteLine("list     create new list page");
                    Console.WriteLine("image    create new image page");
                    break;
                case "message":
                    pages.Add(new TextualMessage().Input());
                    if(ItemAdded != null)
                    {
                        ItemAdded("Textual Message");
                    }
                    break;
                case "list":
                    pages.Add(new MessageList().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Message List");
                    }
                    break;
                case "image":
                    pages.Add(new Image().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Image");
                    }
                    break;
                default:
                    if(InputBadCommand != null)
                    {
                        InputBadCommand("You didn't enter message, list, or image please try again");
                    }
                    break;
            }
        }

        private void Show(string command)
        {
            //Console.WriteLine("Show method " + command);
            switch (command)
            {
                case "":
                    Console.WriteLine("Show commands:");
                    Console.WriteLine("pages          lists all created pages");
                    Console.WriteLine("id of page    display that page");
                    break;
                case "pages":
                    Console.WriteLine("//--------------------Pages--------------------\\");
                    for(int i = 0; i < pages.Count; ++i)
                    {
                        Console.WriteLine("ID: " + i + " " + pages[i].MyData.title);
                    }
                    break;
                default:
                    int number;
                    //if the second value is an integer then it will be parsed
                    if(int.TryParse(command, out number))
                    {
                        Console.WriteLine("Showing page " + number);
                        if (number < pages.Count)
                        {
                            pages[number].Output();
                        }
                        else
                        {
                            if(InputBadCommand != null)
                            {
                                InputBadCommand("Your number was outside of the range of pages please try again");
                            }
                        }
                    }
                    else
                    {
                        if(InputBadCommand != null)
                        {
                            InputBadCommand("You didn't enter pages or a valid nuumber please try again");
                        }
                    }
                    break;
            }
        }

        private void Delete(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Delete commands:");
                    Console.WriteLine("all          delete all created pages");
                    Console.WriteLine("id of page   delete that page");
                    break;

                case "all":
                    pages.Clear();
                    if (ItemRemoved != null)
                    {
                        ItemRemoved("");
                    }
                    break;
                default:
                    int number;
                    //if the second value is an integer then it will be parsed
                    if (int.TryParse(command, out number))
                    {
                        if (number < pages.Count)
                        {
                            pages.RemoveAt(number);
                            if (ItemRemoved != null)
                            {
                                //+ "", below apparently will convert int number to string
                                ItemRemoved(number + "");
                            }
                        }
                        else
                        {
                            if (InputBadCommand != null)
                            {
                                InputBadCommand("Your number was outside of the range of pages please try again");
                            }
                        }
                    }
                    else
                    {
                        if (InputBadCommand != null)
                        {
                            InputBadCommand("You didn't input all, or your number was outside of the range of pages please try again");
                        }
                    }
                    break;
            }
        }
        private void Log(string command)
        {
            //Console.WriteLine("New method " + command);
            switch (command)
            {
                case "":
                    Console.WriteLine("Logger commands:");
                    Console.WriteLine("on         turn logger on");
                    Console.WriteLine("off        turn logger off");
                    break;
                case "on":
                    if (loggingToggled != null)
                    {
                        loggingToggled(true);
                    }
                    break;

                case "off":
                    if (loggingToggled != null)
                    {
                        loggingToggled(false);
                    }
                    break;
                default:
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("Please enter on or off after inputting the log command");
                    }
                    break;
            }
        }
    }
}
