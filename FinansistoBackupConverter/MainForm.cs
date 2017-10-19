using Finansisto.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansistoBackupConverter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            _mainController.BackupFolderChanged += _fileSystemController_BackupFolderChanged;
        }

        public FileInfo SelectedBackupFile
        {
            get
            {
                if (backupFilesListView.SelectedItems.Count > 0)
                {
                    return backupFilesListView.SelectedItems[0].Tag as FileInfo;
                }
                return null;
            }
        }

        public event EventHandler SelectedBackupFileChanged;

        protected virtual void OnSelectedBackupFileChanged()
        {
            SelectedBackupFileChanged?.Invoke(this, new EventArgs());
        }

        private MainController _mainController = new MainController();

        private ListViewItem CreateCollectionCountListViewItem<T>(string name, IEnumerable<T> collection) 
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(collection != null ? collection.Count().ToString() : Properties.Resources.ValueUnknown);
            item.Tag = collection;
            return item;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateBackupFolderControls();
        }

        private void _fileSystemController_BackupFolderChanged(object sender, EventArgs e)
        {
            UpdateBackupFolderControls();
        }

        private void UpdateBackupFolderControls()
        {
            backupFolderTextBox.Text = _mainController.BackupFolder;
            backupFilesListView.BeginUpdate();
            backupFilesListView.Items.Clear();
            foreach (var fi in _mainController.EnumerateFiles().OrderByDescending(fi => fi.CreationTime))
            {
                ListViewItem item = new ListViewItem(fi.Name);
                item.SubItems.Add(fi.CreationTime.ToShortDateString());
                item.SubItems.Add(fi.CreationTime.ToShortTimeString());
                item.ImageIndex = 0;
                item.Tag = fi;
                backupFilesListView.Items.Add(item);
            }
            backupFilesListView.EndUpdate();
        }

        private void LoadSelectedBackupFile()
        {
            backupFileEntitiesListView.Items.Clear();
            if (SelectedBackupFile != null)
            {
                try
                {
                    EntitySet entities = _mainController.ReadEntities(SelectedBackupFile.FullName);
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Accounts, entities.Accounts));
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Budgets, entities.Budgets));
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Categories, entities.Categories));
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Currencies, entities.Currencies));
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Projects, entities.Projects));
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Transactions, entities.Transactions));
                    backupFileEntitiesListView.Items.Add(CreateCollectionCountListViewItem(Properties.Resources.Templates, entities.Templates));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadSelectedFileButton.Enabled = false;
            }
            else
            {
                MessageBox.Show(this, Properties.Resources.SelectedFileNeededMessage, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeBackupFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = Properties.Resources.ChangeBackupFolderDescription, SelectedPath = _mainController.BackupFolder, ShowNewFolderButton = false })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _mainController.BackupFolder = dialog.SelectedPath;
                }
            }
        }

        private void backupFilesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            backupFileHeaderListView.Items.Clear();
            backupFileEntitiesListView.Items.Clear();
            loadSelectedFileButton.Enabled = false;
            exportSelectedFileToCsvButton.Enabled = false;
            if (SelectedBackupFile != null)
            {
                try
                {
                    // Заголовок файла резервной копии
                    foreach (var item in _mainController.ReadHeader(SelectedBackupFile.FullName))
                    {
                        backupFileHeaderListView.Items.Add(item.Key).SubItems.Add(item.Value);
                    }
                    // Свойства с информацией файловой системы для выбраного файла
                    foreach (var pi in SelectedBackupFile.GetType().GetMembers().OfType<System.Reflection.PropertyInfo>().OrderBy(p => p.Name))
                    {
                        backupFileHeaderListView.Items.Add(pi.Name).SubItems.Add(string.Format("{0}", pi.GetValue(SelectedBackupFile)));
                    }
                    loadSelectedFileButton.Enabled = true;
                    exportSelectedFileToCsvButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void entityLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(string.Format("{0}", (sender as LinkLabel)?.Tag));
        }

        private void loadSelectedFileButton_Click(object sender, EventArgs e)
        {
            LoadSelectedBackupFile();
        }

        private void exportSelectedFileToCsvButton_Click(object sender, EventArgs e)
        {
            if (SelectedBackupFile != null)
            {
                using (CsvExportDialog dialog = new CsvExportDialog(SelectedBackupFile.FullName))
                {
                    dialog.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show(this, Properties.Resources.SelectedFileNeededMessage, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getFromGoogleDriveButton_Click(object sender, EventArgs e)
        {
            using (GoogleDriveSyncDialog dialog = new GoogleDriveSyncDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateBackupFolderControls();
                }
            }
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            UpdateBackupFolderControls();
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            UpdateBackupFolderControls();
        }

        private void backupFilesListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SelectedBackupFile != null)
            {
                LoadSelectedBackupFile();
            }
        }
    }
}
