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
        
        //DEFINE LATER, just have them put in place for now
        /*
        page data input method
        must be virtual so child classes
        can override methods later if needed
        */
        public virtual IPageable Input()
        {
            throw new NotImplementedException();
        }


        //page data output method
        public void Output()
        {
            throw new NotImplementedException();
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
