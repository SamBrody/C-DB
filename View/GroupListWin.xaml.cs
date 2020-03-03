using CSharpDB.Context;
using CSharpDB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using CSharpProjCore.ViewModel;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for GroupListWin.xaml
    /// </summary>
    public partial class GroupListWin : Window
    {        
        public GroupListWin()
        {            
            InitializeComponent();
            this.DataContext = new GroupViewModel();
        }        
    }
}
