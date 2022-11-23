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

namespace calculadora.controller
{
    public class CalcController
    {
        public StackModel stack;
        public CalcController()
        {
            stack = new StackModel();
        }

        public void Push(Complex num)
        {
            stack.Push(num);
        }

        public Complex Pop()
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

        public void Add()
        {
            stack.Push(stack.Pop() + stack.Pop());
        }

        public void Sub()
        {
            stack.Push(- stack.Pop() + stack.Pop());
        }

        public void Mult()
        {
            stack.Push(stack.Pop() * stack.Pop());
        }

        public void Div()
        {
            stack.Push(1/stack.Pop() * stack.Pop());
        }

        public void Sqrt()
        {
            stack.Push(new Complex (Math.Sqrt(stack.Pop().Real), Math.Sqrt(stack.Pop().Imaginary)));
        }

        public void Percent()
        {
            var num = stack.Pop();
            if (num.Imaginary != 0)
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
    }
}
