using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{

    //holds 2 fields
    public struct PageData
    {
        public string title;
        public string author;

    }
    //Interfaces provides specification rather than implementation for its members
    public interface IPageable            
    {
        //gets and sets the page data struct
        PageData MyData { get; set; }
        //How we are going to input our item
        IPageable Input();
        //How do we output this item
        void Output();
    }
}
