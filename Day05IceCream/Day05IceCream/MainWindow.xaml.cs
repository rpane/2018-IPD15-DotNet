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

namespace Day05IceCream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string str = lbFlav.SelectedItem.ToString().Remove(0, 37);

            lbSelected.Items.Add(str);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lbSelected.Items.Remove(lbSelected.SelectedValue);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbSelected.Items.Clear();
        }
    }
}
