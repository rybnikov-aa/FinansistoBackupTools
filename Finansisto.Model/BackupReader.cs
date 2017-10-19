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
    [Obsolete]
    public class BackupReader
    {
        public Dictionary<string, string> Header { get { return _header; } }

        public BackupReader(string backupFileName)
        {
            FillDataSet(backupFileName);
        }

        public EntitySet GetEntitySet()
        {
            return new EntitySet(_dataSet);
        }

        private readonly DataSet _dataSet = new DataSet();
        private readonly Dictionary<string, string> _header = new Dictionary<string,string>();

        private void FillDataSet(string backupFileName)
        {
            _dataSet.DataSetName = backupFileName;
            using (FileStream fileStream = File.OpenRead(backupFileName))
            {
                if (IsGZipStream(fileStream))
                {
                    using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                    {
                        ReadStream(gzipStream);
                    }
                }
                else
                {
                    ReadStream(fileStream);
                }
            }
        }

        private bool IsGZipStream(Stream stream)
        {
            byte[] gzipMagic = new byte[] { 0x1F, 0x8B };
            byte[] testBytes = new byte[2];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(testBytes, 0, 2);
            stream.Seek(0, SeekOrigin.Begin);
            return gzipMagic[0] == testBytes[0] && gzipMagic[1] == testBytes[1];
        }

        private void ReadStream(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = null;
                bool insideHeader = true;
                bool insideEntity = false;
                string entityName = null;
                Dictionary<string, string> entityValues = new Dictionary<string, string>();
                while((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("$"))
                    {
                        insideHeader = false;
                        if ("$$".Equals(line))
                        {
                            StoreEntity(entityName, entityValues);
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
                    else
                    {
                        if (insideEntity)
                        {
                            CollectKeyValueFromLine(line, entityValues);
                        }
                        else if (insideHeader)
                        {
                            CollectKeyValueFromLine(line, _header);
                        }
                    }
                }
            }
        }

        private void CollectKeyValueFromLine(string line, Dictionary<string, string> collector)
        {
            int i = line.IndexOf(":");
            if (i > 0)
            {
                collector[line.Substring(0, i)] = line.Substring(i + 1);
            }
        }

        private void StoreEntity(string entityName, Dictionary<string, string> entityValues)
        {
            if (!_dataSet.Tables.Contains(entityName))
            {
                _dataSet.Tables.Add(entityName);
            }
            DataTable dt = _dataSet.Tables[entityName];

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
    }
}
