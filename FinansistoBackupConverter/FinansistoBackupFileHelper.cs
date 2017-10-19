using Finansisto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinansistoBackupConverter
{
    static class FinansistoBackupFileHelper
    {
        /// <summary>
        /// Считывает заголовок файла резервной копии
        /// </summary>
        /// <param name="fileName">Файл резервной копии Finansisto</param>
        /// <returns>Набор ключ-значение со сведениями из заголовка файла резервной копии</returns>
        public static Dictionary<string, string> ReadHeader(string fileName)
        {
            using (BackupFileReader reader = BackupFileReader.OpenBackupFile(fileName))
            {
                return reader.Header;
            }
        }

        /// <summary>
        /// Считывает заданный файл резервной копии в набор сущностей Finansisto
        /// </summary>
        /// <param name="fileName">Файл резервной копии Finansisto</param>
        /// <returns>Набор сущностей Finansisto из считанного файла резервной копии</returns>
        public static EntitySet ReadEntities(string fileName)
        {
            using (BackupFileReader reader = BackupFileReader.OpenBackupFile(fileName))
            {
                return reader.ReadEntitySet();
            }
        }
    }
}
