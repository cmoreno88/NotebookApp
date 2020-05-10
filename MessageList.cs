using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    //A list of TextualMessages
    class MessageList : TextualMessage      //inherits from TextualMessage, who inherits from IPageable
    {
        private enum BulletType { Dashed, Numbered, Star}
        private BulletType bulletType;
    }
}
