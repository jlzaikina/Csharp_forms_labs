using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ArrayVector : IVectorable
    {
        public double[] vector;
        public int Length { get; set; }

        public ArrayVector(int length)
        {
            Length = length;
            vector = new double[Length];
        }
        public ArrayVector()
        {
            Length = 5;
            vector = new double[Length];
        }
        public double this[int i]
        {
            get
            {
                try
                {
                    return vector[i];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Выход за пределы");
                    return 0;
                }
            }
            set
            {
                try
                {
                    vector[i] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Выход за пределы");
                }
            }
        }
        public double GetNorm()
        {
            double mod = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                mod = mod + Math.Pow(vector[i], 2);
            }
            mod = Math.Sqrt(mod);
            return mod;
        }
        public override string ToString()
        {
            string str = " ";
            for (int i = 0; i < vector.Length; i++)
            {
                str = str + vector[i] + "\t";
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            if (ToString() == obj.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CompareTo(Object obj)
        {
            IVectorable v = obj as IVectorable;
            if (v != null)
            {
                if (v.Length < vector.Length)
                    return -1;
                else if (v.Length > vector.Length)
                    return 1;
                else return 0;
            }
            else
                throw new Exception();
        }
        public object Clone()
        {
            ArrayVector a = new ArrayVector(vector.Length);
            for (int i = 0; i < vector.Length; i++)
            {
                a[i] = vector[i];
            }
            return a;
        }
    }
}
