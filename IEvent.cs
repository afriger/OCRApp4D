using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp4D
{
    public interface IEvent
    {
        void invoke(int arg);
    }
}
