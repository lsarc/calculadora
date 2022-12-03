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
using System.Collections.ObjectModel;

namespace calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string num = string.Empty;
        CalcController controller = new CalcController();
        public MainWindow()
        {
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
            //controller.Push(20);
            //controller.Push(50);
            //controller.Push(80);
            //controller.Push(100);

            //controller.Sum();
            //controller.Sub();
            //controller.Copy();
            //controller.Mult();
            //controller.Switch(1, 0);
            //controller.Div();
            //controller.Sqrt();
            //controller.Push(20);
            //controller.Push(50);
            //controller.Push(80);
            //controller.Push(100);
            //foreach (var element in controller.getHistory())
            //{
            //    Trace.WriteLine(element);
            //}
            //controller.Save();
            stack.ItemsSource = controller.getStack();
            history.ItemsSource = controller.getHistory();
            numDisplay.Text = num;

        }

        public void Refresh()
        {
            stack.ItemsSource = controller.getStack();
            history.ItemsSource = controller.getHistory();
            numDisplay.Text = num;
        }

        public void KeypadAlpha(object sender, RoutedEventArgs e)
        {
            int len = sender.ToString().Length;
            num += sender.ToString()[len - 1];
            numDisplay.Text = num;
        }

        public void KeypadEnter(object sender, RoutedEventArgs e)
        {
            controller.Push(double.Parse(num));
            num = "";
            Refresh();
        }

        public void KeypadOp(object sender, RoutedEventArgs e)
        {
            int len = sender.ToString().Length;
            var op = sender.ToString()[len - 1];
            switch (op)
            {
                case ('+'):
                    controller.Sum();
                    break;
                case ('-'):
                    controller.Sub();
                    break;
                case ('*'):
                    controller.Mult();
                    break;
                case ('/'):
                    controller.Div();
                    break;

            }
            Refresh();
                
        }

    }
}
