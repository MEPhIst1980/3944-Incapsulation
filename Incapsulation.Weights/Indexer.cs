using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    public class Indexer
    {
        private double[] data;
        private int min = 0;
        private int max = 0;

        public int Length
        {
            get { return max; }
        }

        public Indexer(double[] array, int start, int length)
        {
            if (array == null) {
                throw new ArgumentException();
            }
            if (array.Length == 0) {
                throw new ArgumentException();
            }
            if (start < 0) {
                throw new ArgumentException();
            }
            if (length <= 0) {
                throw new ArgumentException();
            }
            if (array.Length < start) {
                throw new ArgumentException();
            }
            if (array.Length < length)
            {
                throw new ArgumentException();
            }
            if (array.Length < start + length)
            {
                throw new ArgumentException();
            }
            this.data = array;
            this.max = length;
            this.min = start;
        }

        public double this[int index]
        {
            get {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (max < min + index)
                {
                    throw new IndexOutOfRangeException();
                }
                return data[min + index];
            }
            set {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (max < min + index)
                {
                    throw new IndexOutOfRangeException();
                }
                data[min + index] = value;
            }
        }
    }
}
