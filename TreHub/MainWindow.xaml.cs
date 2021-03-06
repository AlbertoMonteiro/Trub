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
using TreHub.ViewModel;

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
                var mainViewModel = (MainViewModel)DataContext;
                mainViewModel.PropertyChanged += (o, eventArgs) =>
                {
                    if (eventArgs.PropertyName == "Step")
                        VisualStateManager.GoToElementState(grid, mainViewModel.Step, true);
                };
                VisualStateManager.GoToElementState(grid, "FirstStep", true);
            };
        }
    }
}
