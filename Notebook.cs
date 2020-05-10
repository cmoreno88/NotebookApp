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
        public const string OuttrMessage = "Hope you'll use the notebook again, GoodBye!";

        //list of pages
        List<IPageable> pages = new List<IPageable>();

        public delegate void SimpleFunction(string command);
        private Dictionary<string, SimpleFunction> commandLineArgs = new Dictionary<string, SimpleFunction>();
        //these are our keys
        public readonly string show = "show", _new = "new", delete = "delete";

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
        }

        //this key word calls the basic constructor before utilizing this one
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
                    case 3:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeywords[i], Delete);
                        break;

                }
            }
        }

        public void Show(string command)
        {

        }

        public void New(string command)
        {

        }

        public void Delete(string command)
        {

        }
    }
}
