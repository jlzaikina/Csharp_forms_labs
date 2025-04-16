using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    interface IVectorable : IComparable, ICloneable
    {
        int Length { get; }
        double this[int i]
        {
            get;
            set;
        }
        double GetNorm();
    }
}
