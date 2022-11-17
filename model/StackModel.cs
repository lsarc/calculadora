using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.ComponentModel;
using System.Windows;

namespace calculadora.model
{
    public class StackModel
    {
        private int start;
        private int size;
        private Complex[] stack;

        public StackModel()
        {
            start = 0;
            size = 0;
            stack = new Complex[100];
        }

        public void Push(Complex num)
        {
            size++;
            stack[start++] = num;
        }

        public Complex Pop()
        {
            size--;
            return stack[--start];  
        }

        public void Switch(int index1, int index2)
        {
            var temp = stack[index1];
            stack[index1] = stack[index2];
            stack[index2] = temp;
        }

        public string PrintStack()
        {
            string str = string.Empty;
            for (int i = 0; i < size; i++)
            {
                 str += stack[i].ToString() + "\n";
               
            }
            return str;
        }
    }

    
}
