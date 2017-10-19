namespace FinansistoBackupConverter
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.backupFolderTextBox = new System.Windows.Forms.TextBox();
            this.changeBackupFolderButton = new System.Windows.Forms.Button();
            this.getFromGoogleDriveButton = new System.Windows.Forms.Button();
            this.backupFilesListView = new System.Windows.Forms.ListView();
            this.fileNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileDateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileTimeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backupListViewSmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.backupFileHeaderListView = new System.Windows.Forms.ListView();
            this.backupFileHeaderKeyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backupFileHeaderValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.loadSelectedFileButton = new System.Windows.Forms.Button();
            this.exportSelectedFileToCsvButton = new System.Windows.Forms.Button();
            this.backupFileEntitiesListView = new System.Windows.Forms.ListView();
            this.entityNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entityCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.backupFilesListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.backupFolderTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.changeBackupFolderButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.getFromGoogleDriveButton, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(610, 45);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Папка с резервными копиями Finansisto";
            // 
            // backupFolderTextBox
            // 
            this.backupFolderTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.backupFolderTextBox.Location = new System.Drawing.Point(3, 17);
            this.backupFolderTextBox.Name = "backupFolderTextBox";
            this.backupFolderTextBox.ReadOnly = true;
            this.backupFolderTextBox.Size = new System.Drawing.Size(392, 22);
            this.backupFolderTextBox.TabIndex = 1;
            // 
            // changeBackupFolderButton
            // 
            this.changeBackupFolderButton.Location = new System.Drawing.Point(401, 17);
            this.changeBackupFolderButton.Name = "changeBackupFolderButton";
            this.changeBackupFolderButton.Size = new System.Drawing.Size(100, 25);
            this.changeBackupFolderButton.TabIndex = 2;
            this.changeBackupFolderButton.Text = "Выбор папки...";
            this.changeBackupFolderButton.UseVisualStyleBackColor = true;
            this.changeBackupFolderButton.Click += new System.EventHandler(this.changeBackupFolderButton_Click);
            // 
            // getFromGoogleDriveButton
            // 
            this.getFromGoogleDriveButton.Location = new System.Drawing.Point(507, 17);
            this.getFromGoogleDriveButton.Name = "getFromGoogleDriveButton";
            this.getFromGoogleDriveButton.Size = new System.Drawing.Size(100, 25);
            this.getFromGoogleDriveButton.TabIndex = 3;
            this.getFromGoogleDriveButton.Text = "Google Drive...";
            this.getFromGoogleDriveButton.UseVisualStyleBackColor = true;
            this.getFromGoogleDriveButton.Click += new System.EventHandler(this.getFromGoogleDriveButton_Click);
            // 
            // backupFilesListView
            // 
            this.backupFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameColumnHeader,
            this.fileDateColumnHeader,
            this.fileTimeColumnHeader});
            this.backupFilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backupFilesListView.FullRowSelect = true;
            this.backupFilesListView.GridLines = true;
            this.backupFilesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.backupFilesListView.Location = new System.Drawing.Point(7, 58);
            this.backupFilesListView.MultiSelect = false;
            this.backupFilesListView.Name = "backupFilesListView";
            this.backupFilesListView.Size = new System.Drawing.Size(610, 156);
            this.backupFilesListView.SmallImageList = this.backupListViewSmallImageList;
            this.backupFilesListView.TabIndex = 1;
            this.backupFilesListView.UseCompatibleStateImageBehavior = false;
            this.backupFilesListView.View = System.Windows.Forms.View.Details;
            this.backupFilesListView.SelectedIndexChanged += new System.EventHandler(this.backupFilesListView_SelectedIndexChanged);
            this.backupFilesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.backupFilesListView_KeyDown);
            // 
            // fileNameColumnHeader
            // 
            this.fileNameColumnHeader.Text = "Имя файла";
            this.fileNameColumnHeader.Width = 340;
            // 
            // fileDateColumnHeader
            // 
            this.fileDateColumnHeader.Text = "Дата создания";
            this.fileDateColumnHeader.Width = 120;
            // 
            // fileTimeColumnHeader
            // 
            this.fileTimeColumnHeader.Text = "Время создания";
            this.fileTimeColumnHeader.Width = 120;
            // 
            // backupListViewSmallImageList
            // 
            this.backupListViewSmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("backupListViewSmallImageList.ImageStream")));
            this.backupListViewSmallImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.backupListViewSmallImageList.Images.SetKeyName(0, "financisto.bmp");
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.85113F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.14887F));
            this.tableLayoutPanel3.Controls.Add(this.backupFileHeaderListView, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 220);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(610, 294);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // backupFileHeaderListView
            // 
            this.backupFileHeaderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.backupFileHeaderKeyColumnHeader,
            this.backupFileHeaderValueColumnHeader});
            this.backupFileHeaderListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backupFileHeaderListView.FullRowSelect = true;
            this.backupFileHeaderListView.GridLines = true;
            this.backupFileHeaderListView.Location = new System.Drawing.Point(3, 3);
            this.backupFileHeaderListView.Name = "backupFileHeaderListView";
            this.backupFileHeaderListView.ShowItemToolTips = true;
            this.backupFileHeaderListView.Size = new System.Drawing.Size(261, 288);
            this.backupFileHeaderListView.TabIndex = 1;
            this.backupFileHeaderListView.UseCompatibleStateImageBehavior = false;
            this.backupFileHeaderListView.View = System.Windows.Forms.View.Details;
            // 
            // backupFileHeaderKeyColumnHeader
            // 
            this.backupFileHeaderKeyColumnHeader.Text = "Поле";
            this.backupFileHeaderKeyColumnHeader.Width = 100;
            // 
            // backupFileHeaderValueColumnHeader
            // 
            this.backupFileHeaderValueColumnHeader.Text = "Значение";
            this.backupFileHeaderValueColumnHeader.Width = 140;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.backupFileEntitiesListView, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(267, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(343, 294);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.loadSelectedFileButton);
            this.flowLayoutPanel1.Controls.Add(this.exportSelectedFileToCsvButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(343, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // loadSelectedFileButton
            // 
            this.loadSelectedFileButton.Enabled = false;
            this.loadSelectedFileButton.Location = new System.Drawing.Point(3, 3);
            this.loadSelectedFileButton.Name = "loadSelectedFileButton";
            this.loadSelectedFileButton.Size = new System.Drawing.Size(100, 25);
            this.loadSelectedFileButton.TabIndex = 0;
            this.loadSelectedFileButton.Text = "Загрузить";
            this.loadSelectedFileButton.UseVisualStyleBackColor = true;
            this.loadSelectedFileButton.Click += new System.EventHandler(this.loadSelectedFileButton_Click);
            // 
            // exportSelectedFileToCsvButton
            // 
            this.exportSelectedFileToCsvButton.Enabled = false;
            this.exportSelectedFileToCsvButton.Location = new System.Drawing.Point(109, 3);
            this.exportSelectedFileToCsvButton.Name = "exportSelectedFileToCsvButton";
            this.exportSelectedFileToCsvButton.Size = new System.Drawing.Size(100, 25);
            this.exportSelectedFileToCsvButton.TabIndex = 1;
            this.exportSelectedFileToCsvButton.Text = "Экспорт в CSV...";
            this.exportSelectedFileToCsvButton.UseVisualStyleBackColor = true;
            this.exportSelectedFileToCsvButton.Click += new System.EventHandler(this.exportSelectedFileToCsvButton_Click);
            // 
            // backupFileEntitiesListView
            // 
            this.backupFileEntitiesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.entityNameColumnHeader,
            this.entityCountColumnHeader});
            this.backupFileEntitiesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backupFileEntitiesListView.FullRowSelect = true;
            this.backupFileEntitiesListView.GridLines = true;
            this.backupFileEntitiesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.backupFileEntitiesListView.Location = new System.Drawing.Point(3, 34);
            this.backupFileEntitiesListView.MultiSelect = false;
            this.backupFileEntitiesListView.Name = "backupFileEntitiesListView";
            this.backupFileEntitiesListView.ShowItemToolTips = true;
            this.backupFileEntitiesListView.Size = new System.Drawing.Size(337, 257);
            this.backupFileEntitiesListView.TabIndex = 1;
            this.backupFileEntitiesListView.UseCompatibleStateImageBehavior = false;
            this.backupFileEntitiesListView.View = System.Windows.Forms.View.Details;
            // 
            // entityNameColumnHeader
            // 
            this.entityNameColumnHeader.Text = "Сущность";
            this.entityNameColumnHeader.Width = 186;
            // 
            // entityCountColumnHeader
            // 
            this.entityCountColumnHeader.Text = "Количество";
            this.entityCountColumnHeader.Width = 115;
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.Path = global::FinansistoBackupConverter.Properties.Settings.Default.BackupFolder;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 521);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finansisto Backup Converter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox backupFolderTextBox;
        private System.Windows.Forms.Button changeBackupFolderButton;
        private System.Windows.Forms.Button getFromGoogleDriveButton;
        private System.Windows.Forms.ListView backupFilesListView;
        private System.Windows.Forms.ColumnHeader fileNameColumnHeader;
        private System.Windows.Forms.ColumnHeader fileDateColumnHeader;
        private System.Windows.Forms.ColumnHeader fileTimeColumnHeader;
        private System.Windows.Forms.ImageList backupListViewSmallImageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView backupFileHeaderListView;
        private System.Windows.Forms.ColumnHeader backupFileHeaderKeyColumnHeader;
        private System.Windows.Forms.ColumnHeader backupFileHeaderValueColumnHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button loadSelectedFileButton;
        private System.Windows.Forms.Button exportSelectedFileToCsvButton;
        private System.Windows.Forms.ListView backupFileEntitiesListView;
        private System.Windows.Forms.ColumnHeader entityNameColumnHeader;
        private System.Windows.Forms.ColumnHeader entityCountColumnHeader;
        private System.IO.FileSystemWatcher fileSystemWatcher;
    }
}

