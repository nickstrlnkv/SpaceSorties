namespace SpaceSorties.Core
{
    public class Folder
    {
        
        private readonly string _name;
        private readonly long _size;

        /// <summary>
        /// Название папки
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Размер папки в битах
        /// </summary>
        public long Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Создать объект папки с названием и размером
        /// </summary>
        /// <param name="name">Название папки</param>
        /// <param name="size">Размер папки в битах</param>
        public Folder(string name, long size)
        {
            this._name = name;
            this._size = size;
        }

        /// <summary>
        /// Получить размер файла, директории в привычном виде, например '5.00MB', '22.05 GB'.
        /// </summary>
        /// <returns>Возвращает размер в отформатированом виде.</returns>
        public string GetFormatSize()
        {
            if (Size >= 1024 * 1024 * 1024)
                return $"{Size / (1024.0 * 1024 * 1024):F2} GB";

            else if (Size >= 1024 * 1024)
                return $"{Size / (1024.0 * 1024):F2} MB";

            else if (Size >= 1024)
                return $"{Size / 1024.0:F2} KB";
            else
                return $"{Size} bytes";
        }
    }
}
