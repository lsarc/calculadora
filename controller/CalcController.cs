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

        public void Switch(int index1)
        {
            stack.Switch(index1, stack.getSize()-1);
        }

        public List<double> getStack()
        {
            return stack.getStack();
        }

        public void Sum()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num1} + {num2} = {num2 + num1}");
            stack.Push(num1 + num2);
        }

        public void Sub()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num2} - {num1} = {num2 - num1}");
            stack.Push(num2 - num1);
        }

        public void Mult()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num1} * {num2} = {num1 * num2}");
            stack.Push(num1 * num2);
        }

        public void Div()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            if (num1 == 0.0)
            {
                stack.Push(num1);
                throw new InvalidOperationException("Divided by Zero");
            }
            double num2 = stack.Pop();
            history.AddToHistory($"{num2} / {num1} = {num2/num1}");
            stack.Push(num2 / num1);
        }

        public void Sqrt()
        {
            if (stack.getSize() < 1)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            var num = stack.Pop();
            if (stack.getSize() < 0)
            {
                stack.Push(num);
                throw new InvalidOperationException("Invalid Operand");
            }
            if (num > 0) { 
            var res = Math.Sqrt(num);
            history.AddToHistory($"sqrt({num}) = {res}");
            stack.Push(res);
            } else
            {
                stack.Push(num);
                throw new InvalidOperationException("Invalid Operation");
            }
        }

        public void Copy()
        {
            if (stack.getSize() < 1)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num = stack.Pop();
            stack.Push(num);
            stack.Push(num);
        }

        public void Percent()
        {
            if (stack.getSize() < 1)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
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

        public void Mod()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            if (num1 == 0.0)
            {
                stack.Push(num1);
                throw new InvalidOperationException("Divided by Zero");
            }
            double num2 = stack.Pop();
            history.AddToHistory($"{num2} % {num1} = {num2 % num1}");
            stack.Push(num2 % num1);
        }

        public void Exp()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num2} * 10^{num1} = {num2 * Math.Pow(10, num1)}");
            stack.Push(num2*Math.Pow(10,num1));
        }

        public void Pow()
        {
            if (stack.getSize() < 2)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            history.AddToHistory($"{num1}^{num2} = {Math.Pow(num1, num2)}");
            stack.Push(Math.Pow(num1, num2));
        }

        public void Log()
        {
            if (stack.getSize() < 1)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            var num = stack.Pop();
            if (num < 0.0)
            {
                stack.Push(num);
                throw new InvalidOperationException("Invalid Operand");
            }
            else
            {
                history.AddToHistory($"log{num} = {Math.Log10(num)}");
                stack.Push(Math.Log10(num));
            }
        }
        public void Pi()
        {
            stack.Push(Math.PI);
        }
        public void Factorial()
        {
            if (stack.getSize() < 1)
            {
                throw new InvalidOperationException("Too Few Operands");
            }
            var num = stack.Pop();
            if (num%1.0 > 0.0)
            {
                stack.Push(num);
                throw new InvalidOperationException("Invalid Operand");
            }
            else
            {
                double num1 = num;
                double res = 1;
                while(num > 0.0)
                {
                    res *= num;
                    num--;
                }
                history.AddToHistory($"{num1}! = {res}");
                stack.Push(res);
            }
        }

        public void ClearStack()
        {
            stack.Clear();
        }
        public void ClearHistory()
        {
            history.Clear();
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
