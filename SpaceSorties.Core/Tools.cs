namespace SpaceSorties.Core
{
    /// <summary>
    /// Инструментарий для работы с библиотекой
    /// </summary>
    public class Tools
    {
        
        private DriveInfo[] _allDrives;

        /// <summary>
        /// Массив дисков на компьютере
        /// </summary>
        public DriveInfo[] AllDrives
        {
            get
            {
                return _allDrives;
            }
        }

        /// <summary>
        /// Инициализируем объект инструментов с доступными дисками
        /// </summary>
        public Tools()
        {
            _allDrives = DriveInfo.GetDrives();
        }

        /// <summary>
        /// Вывести на консоль доступные диски
        /// </summary>
        public void PrintAvailableDrives()
        {
            foreach (DriveInfo drive in _allDrives)
            {
                Console.WriteLine($"Drive: {drive.Name}");
            }
        }

        
        public static long GetDirectorySizeNoEnumerate(string path)
        {
            try
            {
                Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException)
            {
                return 0;
            }
            string[] files = Directory.GetFiles(path);
            string[] folders = Directory.GetDirectories(path);
            long totalBytes = 0;
            FileInfo info;
            foreach (string file in files)
            {
                info = new FileInfo(file);
                totalBytes += info.Length;
            }
            
            if (folders.Length != 0)
            {
                foreach (string folder in folders)
                {
                    totalBytes += GetDiskSize(folder);
                }
                return totalBytes;
            }
            return totalBytes;
        }
        
        /// <summary>
        /// Получить размер директории, например 'C:\'
        /// </summary>
        /// <param name="path">Путь к директории</param>
        /// <returns>Возвращает размер директории в битах</returns>
        public static long GetDiskSize(string path)
        {
            try
            {
                long totalBytes = 0;

                foreach (var file in Directory.EnumerateFiles(path))
                {
                    try
                    {
                        totalBytes += new FileInfo(file).Length;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Пропускаем файлы, к которым нет доступа
                        continue;
                    }
                }
                foreach (var folder in Directory.EnumerateDirectories(path))
                {
                    try
                    {
                        totalBytes += GetDiskSize(folder);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Пропускаем директории, к которым нет доступа
                        continue;
                    }
                }
                return totalBytes;
            }
            catch (UnauthorizedAccessException)
            {
                // Пропускаем текущую директории, если к ней нет доступа
                return 0;
            }
        }
        
        /// <summary>
        /// Получить размер файла, директории в привычном виде, например '5.00MB', '22.05 GB'.
        /// </summary>
        /// <param name="size">размер в битах</param>
        /// <returns>Возвращает размер в отформатированом виде.</returns>
        public static string FormatSize(long size)
        {
            if (size >= 1024 * 1024 * 1024)
                return $"{size / (1024.0 * 1024 * 1024):F2} GB";

            else if (size >= 1024 * 1024)
                return $"{size / (1024.0 * 1024):F2} MB";

            else if (size >= 1024)
                return $"{size / 1024.0:F2} KB";
            else
                return $"{size} bytes";
        }

    }
}

