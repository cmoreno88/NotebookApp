using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    //A list of TextualMessages
    class MessageList : TextualMessage                      //inherits from TextualMessage, who inherits from IPageable
    {

        private enum BulletType { Dashed, Numbered, Star}
        private BulletType bulletType;                     //bullettype field 


        //Define later
        public override IPageable Input()
        {
            Console.WriteLine("Please input your name:");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input the message title:");
            myData.title = Console.ReadLine();
            Console.WriteLine("What type of bullet point would you like to use?");
            Console.WriteLine("Please enter dashed, numbered, or star");

            //good input ensures the while will only exit if a valid input is entered
            bool goodInput = false;
            while (!goodInput)
            {
                goodInput = true;
                switch (Console.ReadLine())
                {
                    case "dashed":
                        bulletType = BulletType.Dashed;
                        break;
                        
                    case "numbered":
                        bulletType = BulletType.Numbered;
                        break;

                    case "star":
                        bulletType = BulletType.Star;
                        break;
                    default:
                        Console.WriteLine("Please enter dashed, numbered, or star");
                        goodInput = false;
                        break;
                }
            }


            Console.WriteLine("Start typing your list. Everytime you press enter a new item will be created");
            Console.WriteLine("Press enter with a blank list to end your list input.");
            //write list
            bool finishedList = false;
            int i = 1;
            while (!finishedList)
            {
                string input = Console.ReadLine();

                //if they enter nothing our list is finished
                if(input == "")
                {
                    finishedList = true;
                }
                else
                {
                    switch (bulletType)
                    {
                        case BulletType.Dashed:
                            message += "- " + input + " \n";
                            break;
                        case BulletType.Numbered:
                            message += ". " + input + " \n";
                            ++i;
                            break;
                        case BulletType.Star:
                            message += "* " + input + " \n";
                            break;
                    }
                }
            }
            return this;
        }

    }
}
