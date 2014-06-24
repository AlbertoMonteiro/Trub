﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TreHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                VisualStateManager.GoToElementState(grid, "FirstStep", true);
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Thread.Sleep(3000);
                    grid.Dispatcher.Invoke(() =>
                    {
                        VisualStateManager.GoToElementState(grid, "SecondStep", true);
                    });
                });

            };
        }
    }
}
