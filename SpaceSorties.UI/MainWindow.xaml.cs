using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpaceSorties.Core;

namespace SpaceSorties.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Tools tools = new Tools();

            // Проходимся по всем доступным дискам в системе и добавляем их в ComboBox для выбора.
            foreach (DriveInfo item in tools.AllDrives)
            {
                disksComboBox.Items.Add(new ListBoxItem() { Content = item.Name });
            }

        }

    }
}