using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class TextualMessage : IPageable
    {
        /*
        Protected access modifier allows the parent & its children to only access this
        textual messages have fields for pagedata and a message
        PageData is the struct defined in IPageable containing fields: title & author
        */
        protected PageData myData;
        protected string message;
        
        
        /*
        page data input method
        must be virtual so child classes
        can override methods later if needed
        */
        public virtual IPageable Input()
        {
            Console.WriteLine("Please input your name:");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input the message title:");
            myData.title = Console.ReadLine();
            Console.WriteLine("Please input the message:");
            message = Console.ReadLine();
            return this;
        }


        //page data output method
        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine("//-------------------Message----------------\\");
            Console.WriteLine(" Title: " + myData.title);
            Console.WriteLine(" Author: "+ myData.author);
            Console.WriteLine(" Message: \n \n" + message);
            Console.WriteLine("\\-------------------------------------------//");
        }

        //property that allows for the setting & getting of page data
        public PageData MyData
        {
            get
            {
                return myData;
            }

            set
            {
                myData = value;
            }
        }

    }
}
