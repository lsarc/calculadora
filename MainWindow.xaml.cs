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
using System.ComponentModel;

namespace calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string num = string.Empty;
        private bool error = false;
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
                error = true;
                num = ex.Message;
            }
            Refresh();

        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            controller.Save();
        }

        public void ParsePush()
        {
            double res;
            bool ch = double.TryParse(this.num, out res);
            this.num = string.Empty;
            if (!ch)
            {
                throw new Exception("Invalid Input");
            }
            else
            {
                controller.Push(res);
            }
        }

        public void Refresh()
        {
            history.ItemsSource = controller.getHistory();
            stack.ItemsSource = controller.getStack();
            
            numDisplay.Text = num;
            var index = stack.Items.Count - 1;
            if (index >= 0)
            {
                stack.ScrollIntoView(stack.Items.GetItemAt(index));
            }
            
        }

        public void Switch(object sender, EventArgs e)
        {
            var index = (sender as ListView).SelectedIndex;
            try 
            { 
                controller.Switch(index);
                Refresh();
            }
            catch (Exception ex)
            {
                error = true;
                num = ex.Message;
            }
        }

        public void KeypadAlpha(object sender, RoutedEventArgs e)
        {
            if (error)
            {
                num = string.Empty;
                error = false;
            }
            int len = sender.ToString().Length;
            num += sender.ToString()[len - 1];
            numDisplay.Text = num;
        }

        public void KeypadChangeSignal(object sender, RoutedEventArgs e)
        {
            if (error)
            {
                num = string.Empty;
                error = false;
            }
            if (num != string.Empty)
            {
                if (num[0] != '-')
                {
                    num = '-' + num;
                    numDisplay.Text = num;
                }
                else
                {
                    num = num.Remove(0, 1);
                    numDisplay.Text = num;
                }
            }
        }

        public void KeypadEnter(object sender, RoutedEventArgs e)
        {
            if (error)
            {
                num = string.Empty;
                error = false;
            }
            try
            {
                if (num == string.Empty)
                {
                    controller.Copy();
                }
                else
                {
                    ParsePush();
                }
            }
            catch (Exception ex)
            {
                error = true;
                num = ex.Message;
            }
            
            
            Refresh();
           
        }

        public void KeypadDelete(object sender, RoutedEventArgs e)
        {
            if (error)
            {
                num = string.Empty;
                error = false;
            }
            try
            {
                if (num == string.Empty)
                {
                    controller.Pop();
                }
                else
                {
                    num = num.Remove(num.Length - 1);
                }
            }
            catch 
            {
                error = true;
                num = "Too Few Operands";
            }
            
            Refresh();

        }

        public void KeypadClearSt(object sender, RoutedEventArgs e)
        {
            controller.ClearStack();

            Refresh();

        }
        public void KeypadClearHs(object sender, RoutedEventArgs e)
        {
            controller.ClearHistory();

            Refresh();

        }

        public void KeypadOp(object sender, RoutedEventArgs e)
        {
            try
            {
                if (error)
                {
                    num = string.Empty;
                    error = false;
                }
                if (num != string.Empty)
                {
                    ParsePush();
                }
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
                    case ('%'):
                        controller.Percent();
                        break;
                    case ('d'):
                        controller.Mod();
                        break;
                    case ('g'):
                        controller.Log();
                        break;
                    case ('y'):
                        controller.Pow();
                        break;
                    case ('p'):
                        controller.Exp();
                        break;
                    case ('i'):
                        controller.Pi();
                        break;
                    case ('!'):
                        controller.Factorial();
                        break;
                    case ('t'):
                        controller.Sqrt();
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                error = true;
                num = ex.Message;
            }
            Refresh();
        }

        private void ShowHistory(object sender, RoutedEventArgs e)
        {
            var select = (sender as CheckBox).IsChecked.ToString();
            if (select == "True")
            {
                this.Width = 600;
            }
            else
            {
                this.Width = 300;
            }
        }
    }
}
