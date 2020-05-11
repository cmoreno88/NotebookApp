﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Image : IPageable
    {
        private PageData myData;
        private string asciiImage;

        //methods inherrited from IPageable
        public IPageable Input()
        {
            Console.WriteLine("Please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input the message title");
            myData.title = Console.ReadLine();
            Console.WriteLine("Start inputting your image, press enter to create as many lines as you like.");
            Console.WriteLine("Press Ctrl+D then enter on a single line to stop creating your image");
            bool finishedImage = false;

            while (!finishedImage)
            {
                string input = Console.ReadLine();
                // (there must be input) and (control D must not be pressed)
                if((input.Length > 0) && (input[0] == 4))
                {
                    finishedImage = true;
                }
                else
                {
                    asciiImage += "\t" + input + "\n";
                }
            }
            return this;

        }

        public void Output()
        {
            Console.WriteLine();
            Console.WriteLine("/---------------------  Image ----------------------\\");
            Console.WriteLine(" Title: " + myData.title);
            Console.WriteLine(" Author: " + myData.author);
            Console.WriteLine();
            Console.WriteLine(asciiImage);
            Console.WriteLine("\\---------------------------------------------------/");
        }

        //retieves or returns page data
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
