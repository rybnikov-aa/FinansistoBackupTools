namespace FinansistoBackupConverter
{
    partial class CsvExportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.backupFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.csvExportFolderTextBox = new System.Windows.Forms.TextBox();
            this.changeCsvExportFolderButton = new System.Windows.Forms.Button();
            this.useBackupFolderForCsvExportCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.csvExportFileNameTextBox = new System.Windows.Forms.TextBox();
            this.useBackupFileNameForCsvExportCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.openInExplorerCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.backupFileNameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.openInExplorerCheckBox, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.useBackupFolderForCsvExportCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.csvExportFileNameTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.useBackupFileNameForCsvExportCheckBox, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label1.Size = new System.Drawing.Size(449, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл резервной копии Finansisto";
            // 
            // backupFileNameTextBox
            // 
            this.backupFileNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.backupFileNameTextBox.Location = new System.Drawing.Point(3, 25);
            this.backupFileNameTextBox.Name = "backupFileNameTextBox";
            this.backupFileNameTextBox.ReadOnly = true;
            this.backupFileNameTextBox.Size = new System.Drawing.Size(449, 22);
            this.backupFileNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label2.Size = new System.Drawing.Size(449, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Папка для сохранения файла CSV";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.csvExportFolderTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.changeCsvExportFolderButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 72);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 31);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // csvExportFolderTextBox
            // 
            this.csvExportFolderTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.csvExportFolderTextBox.Location = new System.Drawing.Point(3, 3);
            this.csvExportFolderTextBox.Name = "csvExportFolderTextBox";
            this.csvExportFolderTextBox.ReadOnly = true;
            this.csvExportFolderTextBox.Size = new System.Drawing.Size(343, 22);
            this.csvExportFolderTextBox.TabIndex = 0;
            // 
            // changeCsvExportFolderButton
            // 
            this.changeCsvExportFolderButton.Location = new System.Drawing.Point(352, 3);
            this.changeCsvExportFolderButton.Name = "changeCsvExportFolderButton";
            this.changeCsvExportFolderButton.Size = new System.Drawing.Size(100, 25);
            this.changeCsvExportFolderButton.TabIndex = 1;
            this.changeCsvExportFolderButton.Text = "Выбор папки...";
            this.changeCsvExportFolderButton.UseVisualStyleBackColor = true;
            this.changeCsvExportFolderButton.Click += new System.EventHandler(this.changeCsvExportFolderButton_Click);
            // 
            // useBackupFolderForCsvExportCheckBox
            // 
            this.useBackupFolderForCsvExportCheckBox.AutoSize = true;
            this.useBackupFolderForCsvExportCheckBox.Location = new System.Drawing.Point(3, 103);
            this.useBackupFolderForCsvExportCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.useBackupFolderForCsvExportCheckBox.Name = "useBackupFolderForCsvExportCheckBox";
            this.useBackupFolderForCsvExportCheckBox.Size = new System.Drawing.Size(259, 18);
            this.useBackupFolderForCsvExportCheckBox.TabIndex = 4;
            this.useBackupFolderForCsvExportCheckBox.Text = "Использовать папку с резервными копиями";
            this.useBackupFolderForCsvExportCheckBox.UseVisualStyleBackColor = true;
            this.useBackupFolderForCsvExportCheckBox.CheckedChanged += new System.EventHandler(this.useBackupFolderForCsvExportCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label3.Size = new System.Drawing.Size(449, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя файла CSV";
            // 
            // csvExportFileNameTextBox
            // 
            this.csvExportFileNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.csvExportFileNameTextBox.Location = new System.Drawing.Point(3, 149);
            this.csvExportFileNameTextBox.Name = "csvExportFileNameTextBox";
            this.csvExportFileNameTextBox.Size = new System.Drawing.Size(449, 22);
            this.csvExportFileNameTextBox.TabIndex = 6;
            // 
            // useBackupFileNameForCsvExportCheckBox
            // 
            this.useBackupFileNameForCsvExportCheckBox.AutoSize = true;
            this.useBackupFileNameForCsvExportCheckBox.Location = new System.Drawing.Point(3, 174);
            this.useBackupFileNameForCsvExportCheckBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.useBackupFileNameForCsvExportCheckBox.Name = "useBackupFileNameForCsvExportCheckBox";
            this.useBackupFileNameForCsvExportCheckBox.Size = new System.Drawing.Size(378, 18);
            this.useBackupFileNameForCsvExportCheckBox.TabIndex = 7;
            this.useBackupFileNameForCsvExportCheckBox.Text = "Использовать имя файла резервной копии (сменить расширение)";
            this.useBackupFileNameForCsvExportCheckBox.UseVisualStyleBackColor = true;
            this.useBackupFileNameForCsvExportCheckBox.CheckedChanged += new System.EventHandler(this.useBackupFileNameForCsvExportCheckBox_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.exportButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 219);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(455, 43);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(352, 11);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exportButton.Location = new System.Drawing.Point(246, 11);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 25);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Экспорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // openInExplorerCheckBox
            // 
            this.openInExplorerCheckBox.AutoSize = true;
            this.openInExplorerCheckBox.Checked = global::FinansistoBackupConverter.Properties.Settings.Default.OpenCsvExportFolder;
            this.openInExplorerCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FinansistoBackupConverter.Properties.Settings.Default, "OpenCsvExportFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openInExplorerCheckBox.Location = new System.Drawing.Point(3, 198);
            this.openInExplorerCheckBox.Name = "openInExplorerCheckBox";
            this.openInExplorerCheckBox.Size = new System.Drawing.Size(148, 18);
            this.openInExplorerCheckBox.TabIndex = 2;
            this.openInExplorerCheckBox.Text = "Открыть в проводнике";
            this.openInExplorerCheckBox.UseVisualStyleBackColor = true;
            // 
            // CsvExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(471, 278);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CsvExportDialog";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Экспорт в CSV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CsvExportDialog_FormClosing);
            this.Load += new System.EventHandler(this.CsvExportDialog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox backupFileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox csvExportFolderTextBox;
        private System.Windows.Forms.Button changeCsvExportFolderButton;
        private System.Windows.Forms.CheckBox useBackupFolderForCsvExportCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox csvExportFileNameTextBox;
        private System.Windows.Forms.CheckBox useBackupFileNameForCsvExportCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.CheckBox openInExplorerCheckBox;
    }
}