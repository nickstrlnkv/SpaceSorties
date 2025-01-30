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
    }
}
