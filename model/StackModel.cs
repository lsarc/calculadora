using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<double> stack;

        public StackModel()
        {
            stack = new ObservableCollection<double>();
        }

        public void Push(double num)
        {
            stack.Add(num);
        }

        public double Pop()
        {
            double num = stack[stack.Count-1];
            stack.RemoveAt(stack.Count - 1);
            return num;  
        }

        public void Switch(int index1, int index2)
        {
            var temp = stack[index1];
            stack[index1] = stack[index2];
            stack[index2] = temp;
        }

        public List<double> getStack()
        {
            return stack.ToList();
        }

        public int getSize()
        {
            return stack.Count;
        }

        public void SaveStack()
        {
            using (StreamWriter writer = new StreamWriter(@".\stack.sav"))
                foreach (var element in getStack())
                {
                    writer.WriteLine(element);
                }
        }

        public void RestoreStack()
        {
            try
            {
                string[] readText = File.ReadAllText(@".\stack.sav").Split("\n", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < readText.Length; i++)
                {
                    double num = double.Parse(readText[i].TrimEnd('\r'));
                    stack.Add(num);
                }
            }
            catch
            {
                throw new Exception("Erro de Leitura");
            }
           
        }

        public void Clear()
        {
            stack.Clear();
        }
    }

    
}
