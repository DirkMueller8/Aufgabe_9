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

namespace Aufgabe_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SortedDictionary<int, char> dyRoman = new SortedDictionary<int, char>
        {
            {1000, 'M'}, {500, 'D'}, {100, 'C'}, {50, 'L'}, {5, 'V'}, {1, 'I'}
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string numberRoman = txtInputRoman.Text;
            StringBuilder sb = new StringBuilder();
            int numberM = 0;
            sb.Append(numberRoman);
            if (DeterminePositionOFLetter(sb, 'X') != null)
                numberM = (int)DeterminePositionOFLetter(sb, 'X');
        }
        private int? DeterminePositionOFLetter(StringBuilder sbQuery, char letter)
        {
            int? position;
            for (int i = 0; i < sbQuery.Length; i++)
            {
                if (sbQuery[i] == letter)
                {
                    position = i;
                    return i;
                }
            }
            return null;
        }
        private StringBuilder RemoveLetter(StringBuilder sbQuery, int position)
        {
            return sbQuery.Remove(position, sbQuery.Length - position);
        }
    }
}