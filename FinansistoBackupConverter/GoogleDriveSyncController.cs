using FinansistoBackupConverter.Properties;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinansistoBackupConverter
{
    public class GoogleDriveSyncController
    {
        /// <summary>
        /// Асинхронно запрашивает список файлов из папки Google Drive
        /// </summary>
        /// <param name="parent">Папка Google Drive, для которой будет возвращет список файлов, или null, для корневой папки /></param>
        /// <param name="searchForFolders">Eсли true, осуществляется поиск дочерних папок, иначе, осуществляется false</param>
        /// <returns>Задача, предствляющая запущенную асинхронную операцию получения списка файлов</returns>
        public async Task<FileList> RequestFilesAsync(Google.Apis.Drive.v3.Data.File parent = null, bool searchForFolders = false)
        {
            StringBuilder q = new StringBuilder();
            q.Append("'");
            q.Append(parent == null ? "root" : parent.Id);
            q.Append("'");
            q.Append(" in parents");
            q.Append(" and ");
            q.Append("mimeType");
            q.Append(searchForFolders ? " = " : " != ");
            q.Append("'application/vnd.google-apps.folder'");

            var request = (await GetDriveServiceAsync()).Files.List();
            request.Q = q.ToString();
            request.Fields = "files(id, name, createdTime)";
            return await request.ExecuteAsync();
        }

        /// <summary>
        /// Возвращает true, если указанный файл Google Drive отсутствует в локальной папке резервных копий, иначе, возвращает false
        /// </summary>
        /// <param name="file">Файл Google Drive, для которого необходимо проверить наличие локальной копии</param>
        /// <returns>Результат проверки на наличие локальной копии файла</returns>
        public bool DownloadNeeded(Google.Apis.Drive.v3.Data.File file) => !System.IO.File.Exists(GetLocalFileName(file));

        /// <summary>
        /// Асинхронно загружает указанный файл Google Drive в локальную папку резервных копий
        /// </summary>
        /// <param name="file">Файл Google Drive, который необходимо загрузить в локальную папку резервных копий</param>
        /// <returns>Задача, предствляющая запущенную асинхронную операцию скачивания</returns>
        public async Task DownloadAsync(Google.Apis.Drive.v3.Data.File file)
        {
            var request = (await GetDriveServiceAsync()).Files.Get(file.Id);
            using (var stream = System.IO.File.Create(GetLocalFileName(file)))
            {
                await request.DownloadAsync(stream);
            }
            if (file.CreatedTime.HasValue)
            {
                System.IO.File.SetCreationTime(GetLocalFileName(file), file.CreatedTime.Value);
            }
        }

        private DriveService _driveService;

        private async Task<DriveService> GetDriveServiceAsync()
        {
            if (_driveService != null)
            {
                return _driveService;
            }
            Task<UserCredential> authorizeTask;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                authorizeTask = GoogleWebAuthorizationBroker.AuthorizeAsync(stream, driveScopes, "user", CancellationToken.None, new FileDataStore(GetCredentialPath(), true));
            }
            return _driveService = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = await authorizeTask, ApplicationName = Properties.Resources.ApplicationName });
        }

        private string GetLocalFileName(Google.Apis.Drive.v3.Data.File file) => System.IO.Path.Combine(Settings.Default.BackupFolder, file.Name);

        private string GetCredentialPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".credentials/finansisto-backup-converter.json");

        private static readonly string[] driveScopes = new string[] { DriveService.Scope.DriveReadonly };
    }
}
