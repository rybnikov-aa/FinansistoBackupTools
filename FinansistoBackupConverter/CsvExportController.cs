using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using FinansistoBackupConverter.Properties;
using Finansisto.Model;

namespace FinansistoBackupConverter
{
    public class CsvExportController
    {
        /// <summary>
        /// Путь к папке, в которую осуществляется сохранения файлов экспорта в CSV. Если не задано, используется папка резервных копий Finansisto
        /// </summary>
        public string CustomCsvExportFolder
        {
            get
            {
                return Settings.Default.CustomCsvExportFolder;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Settings.Default.CustomCsvExportFolder = value;
                    Settings.Default.UseBackupFolderForCsvExport = false;
                    Settings.Default.Save();
                    OnCustomCsvExportFolderChanged();
                }
                else
                {
                    ResetCsvExportFolder();
                }
            }
        }

        /// <summary>
        /// Возвращает true, если для сохранения файлов экспорта в CSV используется папка резервных копий Finansisto, иначе, возвращает false
        /// </summary>
        public bool UseBackupFolderForCsvExport => Settings.Default.UseBackupFolderForCsvExport;

        /// <summary>
        /// Происходит при изменении значения свойства CsvExportFolder
        /// </summary>
        public event EventHandler CustomCsvExportFolderChanged;

        /// <summary>
        /// Имя файла (без пути и расширения), используемое для сохранения файлов экспорта в CSV. Если не задано, для сохранения используется имя файла
        /// резервной копии Finansisto (сменяется расширение)
        /// </summary>
        public string CustomCsvFileName
        {
            get
            {
                return Settings.Default.CustomCsvFileName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Settings.Default.CustomCsvFileName = value;
                    Settings.Default.UseBackupFileNameForCsvExport = false;
                    Settings.Default.Save();
                    OnCustomCsvExportFileNameChanged();
                }
                else
                {
                    ResetCsvExportFileName();
                }
            }
        }

        /// <summary>
        /// Возвращает true, если для сохранения файлов экспорта в CSV используется исходное имя файла резервной копии (сменяется расширение), иначе, возвращает false
        /// </summary>
        public bool UseBackupFileNameForCsvExport => Settings.Default.UseBackupFileNameForCsvExport;

        /// <summary>
        /// Происходит при изменении значения свойства CsvExportFileName
        /// </summary>
        public event EventHandler CustomCsvExportFileNameChanged;

        /// <summary>
        /// Сбрасывает путь к сохранению файлов CSV на значение по умолчанию, которое совпадает с папкой хранения резервных копий Finansisto
        /// </summary>
        public void ResetCsvExportFolder()
        {
            Settings.Default.UseBackupFolderForCsvExport = true;
            Settings.Default.CustomCsvExportFolder = string.Empty;
            Settings.Default.Save();
            OnCustomCsvExportFolderChanged();
        }

        public void ResetCsvExportFileName()
        {
            Settings.Default.UseBackupFileNameForCsvExport = true;
            Settings.Default.CustomCsvFileName = string.Empty;
            Settings.Default.Save();
            OnCustomCsvExportFileNameChanged();
        }

        /// <summary>
        /// Выполняет экспорт указанного файла резервной копии Finansisto в файл CSV в соответствии с текущими настройками контроллера
        /// </summary>
        /// <param name="backupFileName">Имя файла резервной копии Finansisto</param>
        public void ExportToCsv(string backupFileName)
        {
            ExportTransactions(FinansistoBackupFileHelper.ReadEntities(backupFileName), Path.Combine(GetCsvExportFolder(), GetCsvExportFileName(backupFileName)));
        }

        /// <summary>
        /// Возвращает фактическое имя файла (без пути), которое будет использовано для экспорта в файл CSV
        /// </summary>
        /// <param name="backupFileName">Имя файла резервной копии Finansisto</param>
        /// <returns></returns>
        public string GetCsvExportFileName(string backupFileName)
        {
            return (UseBackupFileNameForCsvExport ? Path.GetFileNameWithoutExtension(backupFileName) : CustomCsvFileName) + ".csv";
        }

        /// <summary>
        /// Возвращает фактическую папку, в которую будут сохраняться файлы экспорта в CSV
        /// </summary>
        /// <returns></returns>
        public string GetCsvExportFolder()
        {
            return UseBackupFolderForCsvExport ? Settings.Default.BackupFolder : CustomCsvExportFolder;
        }

        /// <summary>
        /// Устанавливает путь к папке для сохранения файлов экспорта в CSV
        /// </summary>
        /// <param name="useBackupFolderForCsvExport">True, если файлы экспорта необходимо сохранять в папке резервных копий, иначе, false</param>
        /// <param name="customCsvExportFolder">Путь к папке для сохранения файлов экспорта в CSV, если не используется папке резервных копий</param>
        public void SetCsvExportFolder(bool useBackupFolderForCsvExport, string customCsvExportFolder)
        {
            if (useBackupFolderForCsvExport)
            {
                ResetCsvExportFolder();
            }
            else
            {
                CustomCsvExportFolder = customCsvExportFolder;
            }
        }

        /// <summary>
        /// Устанавливает имя файла экспорта в CSV
        /// </summary>
        /// <param name="useBackupFileNameForCsvExport">True, если для экспорта используется имя файла резервной копии (сменяется расширение), иначе, false</param>
        /// <param name="customCsvFileName">Имя файла CSV, если не используется имя файла резервной копии</param>
        public void SetCsvExportFileName(bool useBackupFileNameForCsvExport, string customCsvFileName)
        {
            if (useBackupFileNameForCsvExport)
            {
                ResetCsvExportFileName();
            }
            else
            {
                CustomCsvFileName = customCsvFileName;
            }
        }

        protected virtual void OnCustomCsvExportFolderChanged()
        {
            CustomCsvExportFolderChanged?.Invoke(this, new EventArgs());
        }

        protected virtual void OnCustomCsvExportFileNameChanged()
        {
            CustomCsvExportFileNameChanged?.Invoke(this, new EventArgs());
        }

        private void ExportTransactions(EntitySet entitySet, string csvFileName)
        {
            using (StreamWriter sw = File.CreateText(csvFileName))
            {
                using (CsvWriter csv = new CsvWriter(sw))
                {
                    // Транзакции выгружаем без сплитов, чтобы избежать дублирования
                    csv.WriteRecords(entitySet.Transactions.Where(t => !t.IsSplit).Select(t => new CsvExportTransactionWrapper(t)));
                }
            }
        }
    }
}