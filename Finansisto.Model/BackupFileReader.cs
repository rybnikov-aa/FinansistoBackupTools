using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansisto.Model
{
    public sealed class BackupFileReader : IDisposable
    {
        public Dictionary<string, string> Header { get; private set; }

        public EntitySet ReadEntitySet()
        {
            return new EntitySet(_dataSet ?? (_dataSet = ReadDataSet()));
        }

        private StreamReader _backupDataStreamReader;
        private DataSet _dataSet;

        private BackupFileReader(Stream backupFileStream)
        {
            _backupDataStreamReader = new StreamReader(backupFileStream);
            Header = ReadHeader();
        }

        private Dictionary<string, string> ReadHeader()
        {
            string line = null;
            Dictionary<string, string> header = new Dictionary<string, string>();
            while ((line = _backupDataStreamReader.ReadLine()) != null && !line.StartsWith("#START"))
            {
                CollectKeyValueFromLine(line, header);
            }
            return header;
        }

        private DataSet ReadDataSet()
        {
            DataSet dataSet = new DataSet();
            string line = null;
            bool insideEntity = false;
            string entityName = null;
            Dictionary<string, string> entityValues = new Dictionary<string, string>();
            while ((line = _backupDataStreamReader.ReadLine()) != null)
            {
                if (line.StartsWith("$"))
                {
                    if ("$$".Equals(line))
                    {
                        StoreEntity(dataSet, entityName, entityValues);
                        entityName = null;
                        entityValues.Clear();
                        insideEntity = false;
                    }
                    else
                    {
                        int i = line.IndexOf(":");
                        if (i > 0)
                        {
                            entityName = line.Substring(i + 1);
                        }
                        insideEntity = true;
                    }
                }
                else if (insideEntity)
                {
                    CollectKeyValueFromLine(line, entityValues);
                }
            }
            return dataSet;
        }

        private void CollectKeyValueFromLine(string line, Dictionary<string, string> collector)
        {
            int i = line.IndexOf(":");
            if (i > 0)
            {
                collector[line.Substring(0, i)] = line.Substring(i + 1);
            }
        }

        private void StoreEntity(DataSet dataSet, string entityName, Dictionary<string, string> entityValues)
        {
            if (!dataSet.Tables.Contains(entityName))
            {
                dataSet.Tables.Add(entityName);
            }
            DataTable dt = dataSet.Tables[entityName];

            DataRow dr = dt.NewRow();
            foreach (var pair in entityValues)
            {
                if (!dt.Columns.Contains(pair.Key))
                {
                    dt.Columns.Add(pair.Key);
                }
                dr[pair.Key] = pair.Value;
            }
            dt.Rows.Add(dr);
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _backupDataStreamReader?.Dispose();
                    _dataSet?.Dispose();
                }

                _dataSet = null;
                disposedValue = true;
            }
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
        }
        #endregion

        #region Статические члены
        public static bool IsBackupFile(string fileName)
        {
            try
            {
                return File.Exists(fileName) && OpenBackupFile(fileName).Header?.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public static BackupFileReader OpenBackupFile(string fileName)
        {
            FileStream fileStream = File.OpenRead(fileName);
            if (IsGZipStream(fileStream))
            {
                return new BackupFileReader(new GZipStream(fileStream, CompressionMode.Decompress));
            }
            else
            {
                return new BackupFileReader(fileStream);
            }
        }

        private static bool IsGZipStream(Stream stream)
        {
            if (stream.Length >= 2)
            {
                byte[] gzipMagic = new byte[] { 0x1F, 0x8B };
                byte[] testBytes = new byte[2];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(testBytes, 0, 2);
                stream.Seek(0, SeekOrigin.Begin);
                return gzipMagic[0] == testBytes[0] && gzipMagic[1] == testBytes[1];
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
