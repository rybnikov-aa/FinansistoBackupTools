using FinansistoBackupConverter.Properties;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansistoBackupConverter
{
    public partial class GoogleDriveSyncDialog : Form
    {
        public GoogleDriveSyncDialog()
        {
            InitializeComponent();
            _googleDriveSyncController = new GoogleDriveSyncController();
        }

        private GoogleDriveSyncController _googleDriveSyncController;

        private async void UpdateFilesListViewAsync()
        {
            try
            {
                filesListView.BeginUpdate();
                filesListView.Items.Clear();
                foreach (var file in (await _googleDriveSyncController.RequestFilesAsync(GetSelectedFolder(), false)).Files.OrderByDescending(f => f.CreatedTime))
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add(file.CreatedTime?.ToShortDateString());
                    item.SubItems.Add(file.CreatedTime?.ToShortTimeString());
                    item.Tag = file;
                    item.Checked = _googleDriveSyncController.DownloadNeeded(file);
                    filesListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    filesListView.EndUpdate();
                }
            }
        }

        private File GetSelectedFolder() => (File)folderComboBox.SelectedItem;

        private async void GoogleDriveSyncDialog_Load(object sender, EventArgs e)
        {
            try
            {
                folderComboBox.Items.Clear();
                foreach (var file in (await _googleDriveSyncController.RequestFilesAsync(null, true)).Files)
                {
                    folderComboBox.Items.Add(file);
                }
                if (!string.IsNullOrEmpty(Settings.Default.GoogleDriveFolder))
                {
                    folderComboBox.SelectedIndex = folderComboBox.FindString(Settings.Default.GoogleDriveFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateFilesListViewAsync();
        }

        private void folderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilesListViewAsync();
            Settings.Default.GoogleDriveFolder = GetSelectedFolder()?.Name;
            Settings.Default.Save();
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Maximum = filesListView.CheckedItems.Count;
            progressBar.Show();
            try
            {
                foreach (ListViewItem item in filesListView.CheckedItems)
                {
                    progressBar.PerformStep();
                    await _googleDriveSyncController.DownloadAsync((Google.Apis.Drive.v3.Data.File)item.Tag);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    progressBar.Hide();
                }
            }
        }

        private void filesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            downloadButton.Enabled = filesListView.CheckedItems.Count > 0;
        }

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in filesListView.Items)
            {
                item.Checked = true;
            }
        }
    }
}
