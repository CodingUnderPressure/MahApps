﻿using MahApps.Metro.Controls;
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

namespace Mahapps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public string RemainingBalance { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            double balance = 1600;
            RemainingBalance = $"${balance}";
        }

        private void NewBudgetButton_Click(object sender, RoutedEventArgs e)
        {
            if (BudgetStackPanel.Visibility == Visibility.Collapsed)
                BudgetStackPanel.Visibility = Visibility.Visible;
        }
    }
}
