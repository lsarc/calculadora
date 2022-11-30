using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.ComponentModel;
using System.Windows;
using System.IO;

namespace calculadora.model
{
    public class StackModel
    {
        private int start;
        private int size;
        private double[] stack;

        public StackModel()
        {
            start = 0;
            size = 0;
            stack = new double[100];
        }

        public void Push(double num)
        {
            size++;
            stack[start++] = num;
        }

        public double Pop()
        {
            stack[size] = 0.0;
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

        public int getSize()
        {
            return size;
        }

        public void SaveStack()
        {
            using (StreamWriter writer = new StreamWriter(@".\stack.sav"))
            {
                writer.WriteLine(PrintStack());
            }
        }

        public void RestoreStack()
        {
            string[] readText = File.ReadAllText(@".\stack.sav").Split("\n", StringSplitOptions.RemoveEmptyEntries);
            int i;
            for (i = 0; i < readText.Length-1; i++)
            {
                stack[i] = double.Parse(readText[i].Trim());
            }
            size = i;
            start = i;
           
        }
    }

    
}
