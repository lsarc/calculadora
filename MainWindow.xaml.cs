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
            var pilha = new StackModel();

            pilha.Push(20);
            pilha.Push(10);
            pilha.Push(50);
            pilha.Push(90);
            Trace.WriteLine(pilha.Pop());
            pilha.Switch(0, 2);
            Trace.WriteLine(pilha.Pop());
            Trace.WriteLine(pilha.Pop());
            Trace.WriteLine(pilha.PrintStack());


        }
    }
}
