using System.IO;
using System.Windows;
using System.Windows.Controls;

using SpaceSorties.Core;

namespace SpaceSorties.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool scanAllDisksStatus;
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

        /// <summary>
        /// Отрисовать дерево для всех доступных дисков в системе
        /// </summary>
        private void BuildFoldersTree()
        {
            Tree.Items.Clear();

            foreach (DriveInfo disk in DriveInfo.GetDrives())
            {
                // Пропускаем диски, к которым нет доступа
                if (disk.IsReady)
                {
                    // Добавляем диск в дерево
                    TreeViewItem driveItem = new TreeViewItem
                    {
                        Header = $"{disk.Name} - {Tools.FormatSize(disk.TotalSize)}",
                        Tag = disk.RootDirectory
                    };

                    // Добавляем фиктивный дочерний узел, чтобы у узла появился значок раскрытия
                    driveItem.Items.Add(null);
                    driveItem.Expanded += Folder_Expanded;

                    Tree.Items.Add(driveItem);
                }
            }
        }

        // Динамическая подгрузка подпапки. Если пользователь хочет раскрыть папку,
        // то используем эту функцию.
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            // Проверяем, загружались ли уже папки
            if (item.Items.Count == 1 && item.Items[0] == null)
            {
                // Очищаем фиктивный узел
                item.Items.Clear();

                DirectoryInfo dir = (DirectoryInfo)item.Tag;
                try
                {
                    foreach (DirectoryInfo subDir in dir.GetDirectories())
                    {
                        // Добавляем подпапку папки
                        TreeViewItem subItem = new TreeViewItem
                        {
                            Header = $"{subDir.Name} - {Tools.FormatSize(GetDirectorySize(subDir))}",
                            Tag = subDir
                        };

                        subItem.Items.Add(null);
                        subItem.Expanded += Folder_Expanded;

                        item.Items.Add(subItem);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Добавляем заглушку системной папки
                    // TODO:
                    // 1) Хер знает что с этим делать. Удалить или пусть так будет
                    //item.Items.Add(new TreeViewItem { Header = "Доступ запрещен" });
                }
            }
        }

        /// <summary>
        /// Получить размер директории.
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <returns>Размер директории в битах.</returns>
        private static long GetDirectorySize(DirectoryInfo dir)
        {
            long size = 0;

            try
            {
                foreach (FileInfo file in dir.GetFiles())
                    size += file.Length;

                foreach (DirectoryInfo subDir in dir.GetDirectories())
                    size += GetDirectorySize(subDir);
            }
            catch (UnauthorizedAccessException) { /* Пропускаем системные папки */ }

            return size;
        }

        // Обработчик для RadioButton сканирования всех дисков
        private void scanAllDisk_Checked(object sender, RoutedEventArgs e)
        {
            scanAllDisksStatus = true;
        }

        // Обработчик для RadioButton сканирования выбранного диска
        private void scanSelectedDisk_Checked(object sender, RoutedEventArgs e)
        {
            scanAllDisksStatus = false;
        }

        // Обработчик для Button сканировать
        private void scanButton_Click(object sender, RoutedEventArgs e)
        {
            if (scanAllDisksStatus)
            {
                BuildFoldersTree();
            }
            // TODO:
            // 1) Добавить обработку выбранной папки
        }
    }
}