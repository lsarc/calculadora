using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using calculadora.model;
using calculadora.controller;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;

namespace calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var controller = new CalcController();
            InitializeComponent();
            //try
            //{
            //    controller.Restore();
            //}
            //catch
            //{

            //}

            //foreach (var element in controller.getStack())
            //{
            //    Trace.WriteLine(element);
            //}
            //foreach (var element in controller.getHistory())
            //{
            //    Trace.WriteLine(element);
            //}
            controller.Push(20);
            controller.Push(50);
            controller.Push(80);
            controller.Push(100);

            controller.Sum();
            controller.Sub();
            controller.Copy();
            controller.Mult();
            controller.Switch(1, 0);
            controller.Div();
            controller.Sqrt();
            controller.Push(20);
            controller.Push(50);
            controller.Push(80);
            controller.Push(100);
            foreach (var element in controller.getHistory())
            {
                Trace.WriteLine(element);
            }
            //controller.Save();
            stack.ItemsSource = controller.getStack();
            history.ItemsSource = controller.getHistory();

        }
    }
}
