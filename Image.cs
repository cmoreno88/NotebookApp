using System;
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

        //DEFINE later
        public IPageable Input()
        {
            throw new NotImplementedException();
        }

        public void Output()
        {
            throw new NotImplementedException();
        }

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
