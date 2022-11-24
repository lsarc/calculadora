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

namespace calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var controller = new CalcController();
            controller.Push(20);
            controller.Push(50);
            controller.Push(80);
            controller.Push(100);
            Trace.WriteLine(controller.PrintStack());
            controller.Sum();
            Trace.WriteLine(controller.PrintStack());
            controller.Sub();
            controller.Copy();
            Trace.WriteLine(controller.PrintStack());
            controller.Mult();
            Trace.WriteLine(controller.PrintStack());
            controller.Switch(1,0);
            controller.Div();
            Trace.WriteLine(controller.PrintStack());
            controller.Sqrt();
            Trace.WriteLine(controller.PrintStack());


        }
    }
}
