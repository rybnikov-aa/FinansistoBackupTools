using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansistoBackupConverter
{
    public partial class CsvExportDialog : Form
    {
        public CsvExportDialog(string backupFileName)
        {
            InitializeComponent();
            _backupFileName = backupFileName;
            _csvExportController.CustomCsvExportFolderChanged += _csvExportController_CsvExportFolderChanged;
            _csvExportController.CustomCsvExportFileNameChanged += _csvExportController_CsvExportFileNameChanged;
        }

        private string _backupFileName;
        private CsvExportController _csvExportController = new CsvExportController();

        private void CsvExportDialog_Load(object sender, EventArgs e)
        {
            backupFileNameTextBox.Text = _backupFileName;
            useBackupFolderForCsvExportCheckBox.Checked = _csvExportController.UseBackupFolderForCsvExport;
            useBackupFileNameForCsvExportCheckBox.Checked = _csvExportController.UseBackupFileNameForCsvExport;
            csvExportFolderTextBox.Text = _csvExportController.CustomCsvExportFolder;
            csvExportFileNameTextBox.Text = _csvExportController.CustomCsvFileName;
        }

        private void _csvExportController_CsvExportFolderChanged(object sender, EventArgs e)
        {
            csvExportFolderTextBox.Text = _csvExportController.CustomCsvExportFolder;
        }

        private void _csvExportController_CsvExportFileNameChanged(object sender, EventArgs e)
        {
            csvExportFileNameTextBox.Text = _csvExportController.CustomCsvFileName;
        }

        private void useBackupFolderForCsvExportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            csvExportFolderTextBox.Enabled = !useBackupFolderForCsvExportCheckBox.Checked;
            changeCsvExportFolderButton.Enabled = !useBackupFolderForCsvExportCheckBox.Checked;
        }

        private void useBackupFileNameForCsvExportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            csvExportFileNameTextBox.Enabled = !useBackupFileNameForCsvExportCheckBox.Checked;
        }

        private void changeCsvExportFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = Properties.Resources.ChangeCsvExportFolderDescription, SelectedPath = _csvExportController.CustomCsvExportFolder, ShowNewFolderButton = false })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    csvExportFolderTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            _csvExportController.SetCsvExportFolder(useBackupFolderForCsvExportCheckBox.Checked, csvExportFolderTextBox.Text);
            _csvExportController.SetCsvExportFileName(useBackupFileNameForCsvExportCheckBox.Checked, csvExportFileNameTextBox.Text);
            try
            {
                _csvExportController.ExportToCsv(_backupFileName);
                MessageBox.Show(Properties.Resources.CsvExportSuccessMessage, Properties.Resources.InfoCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (openInExplorerCheckBox.Checked)
                {
                    Process.Start(_csvExportController.GetCsvExportFolder());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CsvExportDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
