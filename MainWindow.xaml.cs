﻿using System;
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
using System.ComponentModel;

namespace calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string num = string.Empty;
        private CalcController controller = new CalcController();
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
            try
            {
                controller.Restore();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

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
            Refresh();

        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            controller.Save();
        }

        public void Refresh()
        {
            history.ItemsSource = controller.getHistory();
            stack.ItemsSource = controller.getStack();
            
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
            if (num == string.Empty)
            {
                controller.Copy();
            }
            else
            {
                controller.Push(double.Parse(num));
                num = string.Empty;
            }
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
                default:
                    break;

            }
            Refresh();

        }

    }
}
