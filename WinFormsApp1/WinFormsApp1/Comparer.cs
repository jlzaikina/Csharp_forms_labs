using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Comparer : IComparer<IVectorable>
    {
        public int Compare(IVectorable obj1, IVectorable obj2)
        {
            if (obj1.GetNorm() > obj2.GetNorm())
                return 1;
            else if (obj1.GetNorm() < obj2.GetNorm())
                return -1;
            else
                return 0;
        }
    }
}
