using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finansisto.Model;
using System.IO;
using FinansistoBackupConverter.Properties;

namespace FinansistoBackupConverter
{
    /// <summary>
    /// Контроллер работы с файловой системой и файлами резервных копий Finansisto
    /// </summary>
    public class MainController
    {
        /// <summary>
        /// Путь к папке, в которой осуществляется поиск файлов резервных копий Finansisto
        /// </summary>
        public string BackupFolder
        {
            get
            {
                return Settings.Default.BackupFolder;
            }
            set
            {
                Settings.Default.BackupFolder = value;
                Settings.Default.Save();
                OnBackupFolderChanged();
            }
        }

        /// <summary>
        /// Создает новый экземпляр контроллера
        /// </summary>
        public MainController()
        {
            if (!Directory.Exists(BackupFolder))
            {
                BackupFolder = Directory.GetCurrentDirectory();
            }
        }

        /// <summary>
        /// Происходит при изменении значения свойства BackupFolder
        /// </summary>
        public event EventHandler BackupFolderChanged;

        /// <summary>
        /// Возвращает перечисляемую коллекцию объектов с информацией о файлах резервных копий Finansisto в папке BackupFolder
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileInfo> EnumerateFiles() => from fileName in Directory.EnumerateFiles(BackupFolder, _backupFilesSearchPattern) select new FileInfo(fileName);

        /// <summary>
        /// Считывает заголовок файла резервной копии
        /// </summary>
        /// <param name="fileName">Файл резервной копии Finansisto</param>
        /// <returns>Набор ключ-значение со сведениями из заголовка файла резервной копии</returns>
        public Dictionary<string, string> ReadHeader(string fileName) => FinansistoBackupFileHelper.ReadHeader(fileName);

        /// <summary>
        /// Считывает заданный файл резервной копии в набор сущностей Finansisto
        /// </summary>
        /// <param name="fileName">Файл резервной копии Finansisto</param>
        /// <returns>Набор сущностей Finansisto из считанного файла резервной копии</returns>
        public EntitySet ReadEntities(string fileName) => FinansistoBackupFileHelper.ReadEntities(fileName);

        protected virtual void OnBackupFolderChanged()
        {
            BackupFolderChanged?.Invoke(this, new EventArgs());
        }

        private const string _backupFilesSearchPattern = "*.backup";
    }
}
