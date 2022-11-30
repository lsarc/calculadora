using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using calculadora.model;
using System.Numerics;
using System.Collections;
using Microsoft.Win32;

namespace calculadora.controller
{
    public class CalcController
    {
        private StackModel stack;
        private HistoryModel history;
        public CalcController()
        {
            stack = new StackModel();
            history = new HistoryModel();
        }

        public void Push(double num)
        {
            stack.Push(num);
        }

        public double Pop()
        {
            return stack.Pop();
        }

        public void Switch(int index1, int index2)
        {
            stack.Switch(index1, index2);
        }

        public string PrintStack()
        {
            return stack.PrintStack();
        }

        public void Sum()
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num1} + {num2}");
            stack.Push(num1 + num2);
        }

        public void Sub()
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num2} - {num1}");
            stack.Push(num2 - num1);
        }

        public void Mult()
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num1} * {num2}");
            stack.Push(num1 * num2);
        }

        public void Div()
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num2} / {num1}");
            stack.Push(num2 / num1);
        }

        public void Sqrt()
        {
            var num = Math.Sqrt(stack.Pop());
            history.AddToHistory($"sqrt({num})");
            stack.Push(num);
        }

        public void Copy()
        {
            double num = stack.Pop();
            stack.Push(num);
            stack.Push(num);
        }

        public void Percent()
        {
            var num = stack.Pop();
            if (num > 1.0)
            {
                stack.Push(num);
                throw new InvalidOperationException();
            }
            else
            {
                stack.Push(num*100);
            }
        }

        public void Clean()
        {
            for (int i = stack.getSize(); i > 0; i--)
            {
                stack.Pop();
            }
        }

        public List<string> getHistory()
        {
            return history.getHistory();
        }

        public void Save()
        {
            stack.SaveStack();
            history.SaveHistory();
        }

        public void Restore()
        {
            
            history.RestoreHistory();
            stack.RestoreStack();
        }
    }
}
