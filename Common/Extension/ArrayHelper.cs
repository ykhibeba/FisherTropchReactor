using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extension
{
    public static class ArrayHelper
    {
        public static double[,] AddArray(this double[,] destination, double[] value, int index)
        {
            for (int i = 0; i < value.Length; i++)
            {
                destination[index, i] = value[i];
            }

            return destination;
        }
    }
}
