using CSharpProjCore.ViewModel;
using System.Windows;

namespace CSharpProjCore.View
{
    public partial class ThemeListWin : Window
    {
        public ThemeListWin()
        {
            InitializeComponent();
            this.DataContext = new ThemeListViewModel();
        }
    }
}
