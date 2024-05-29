namespace FMClient
{
    partial class FileManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.fileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletePathContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptySpaceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uploadContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.modDate = new System.Windows.Forms.ColumnHeader();
            this.type = new System.Windows.Forms.ColumnHeader();
            this.size = new System.Windows.Forms.ColumnHeader();
            this.fileView = new System.Windows.Forms.ListView();
            this.backButton = new System.Windows.Forms.Button();
            this.forewardButton = new System.Windows.Forms.Button();
            this.upFolderButton = new System.Windows.Forms.Button();
            this.objectCount = new System.Windows.Forms.StatusBar();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.fileContextMenu.SuspendLayout();
            this.folderContextMenu.SuspendLayout();
            this.emptySpaceContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileContextMenu
            // 
            this.fileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.downloadContextItem, this.deleteFileContextItem });
            this.fileContextMenu.Name = "fileContextMenu";
            this.fileContextMenu.Size = new System.Drawing.Size(119, 48);
            // 
            // downloadContextItem
            // 
            this.downloadContextItem.Name = "downloadContextItem";
            this.downloadContextItem.Size = new System.Drawing.Size(118, 22);
            this.downloadContextItem.Text = "Скачать";
            this.downloadContextItem.Click += new System.EventHandler(this.downloadContextItem_Click);
            // 
            // deleteFileContextItem
            // 
            this.deleteFileContextItem.Name = "deleteFileContextItem";
            this.deleteFileContextItem.Size = new System.Drawing.Size(118, 22);
            this.deleteFileContextItem.Text = "Удалить";
            this.deleteFileContextItem.Click += new System.EventHandler(this.deleteContextItem_Click);
            // 
            // folderContextMenu
            // 
            this.folderContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.deletePathContextItem });
            this.folderContextMenu.Name = "folderContextMenu";
            this.folderContextMenu.Size = new System.Drawing.Size(119, 26);
            // 
            // deletePathContextItem
            // 
            this.deletePathContextItem.Name = "deletePathContextItem";
            this.deletePathContextItem.Size = new System.Drawing.Size(118, 22);
            this.deletePathContextItem.Text = "Удалить";
            this.deletePathContextItem.Click += new System.EventHandler(this.deleteContextItem_Click);
            // 
            // emptySpaceContextMenu
            // 
            this.emptySpaceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.uploadContextItem, this.createFolderContextItem });
            this.emptySpaceContextMenu.Name = "emptySpaceContextMenu";
            this.emptySpaceContextMenu.Size = new System.Drawing.Size(161, 48);
            // 
            // uploadContextItem
            // 
            this.uploadContextItem.Name = "uploadContextItem";
            this.uploadContextItem.Size = new System.Drawing.Size(160, 22);
            this.uploadContextItem.Text = "Загрузить файл";
            this.uploadContextItem.Click += new System.EventHandler(this.uploadContextItem_Click);
            // 
            // createFolderContextItem
            // 
            this.createFolderContextItem.Name = "createFolderContextItem";
            this.createFolderContextItem.Size = new System.Drawing.Size(160, 22);
            this.createFolderContextItem.Text = "Создать папку";
            this.createFolderContextItem.Click += new System.EventHandler(this.createFolderContextItem_Click);
            // 
            // name
            // 
            this.name.Text = "Имя";
            this.name.Width = 300;
            // 
            // modDate
            // 
            this.modDate.Text = "Дата изменения";
            this.modDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.modDate.Width = 100;
            // 
            // type
            // 
            this.type.Text = "Тип";
            this.type.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // size
            // 
            this.size.Text = "Размер";
            this.size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.size.Width = 80;
            // 
            // fileView
            // 
            this.fileView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.name, this.modDate, this.type, this.size });
            this.fileView.HideSelection = false;
            this.fileView.Location = new System.Drawing.Point(12, 51);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(696, 418);
            this.fileView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.fileView.TabIndex = 0;
            this.fileView.UseCompatibleStateImageBehavior = false;
            this.fileView.View = System.Windows.Forms.View.Details;
            this.fileView.DoubleClick += new System.EventHandler(this.fileView_DoubleClick);
            this.fileView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fileView_MouseUp);
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(27, 28);
            this.backButton.TabIndex = 1;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // forewardButton
            // 
            this.forewardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forewardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forewardButton.Image = ((System.Drawing.Image)(resources.GetObject("forewardButton.Image")));
            this.forewardButton.Location = new System.Drawing.Point(45, 12);
            this.forewardButton.Name = "forewardButton";
            this.forewardButton.Size = new System.Drawing.Size(27, 28);
            this.forewardButton.TabIndex = 2;
            this.forewardButton.UseVisualStyleBackColor = true;
            this.forewardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // upFolderButton
            // 
            this.upFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("upFolderButton.Image")));
            this.upFolderButton.Location = new System.Drawing.Point(89, 12);
            this.upFolderButton.Name = "upFolderButton";
            this.upFolderButton.Size = new System.Drawing.Size(27, 28);
            this.upFolderButton.TabIndex = 4;
            this.upFolderButton.UseVisualStyleBackColor = true;
            this.upFolderButton.Click += new System.EventHandler(this.upFolderButton_Click);
            // 
            // objectCount
            // 
            this.objectCount.Location = new System.Drawing.Point(0, 467);
            this.objectCount.Name = "objectCount";
            this.objectCount.Size = new System.Drawing.Size(722, 22);
            this.objectCount.TabIndex = 5;
            this.objectCount.Text = "Элементов: 0";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathTextBox.Location = new System.Drawing.Point(122, 12);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.pathTextBox.Size = new System.Drawing.Size(586, 29);
            this.pathTextBox.TabIndex = 3;
            this.pathTextBox.Text = "/";
            this.pathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pathTextBox_KeyPress);
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 489);
            this.Controls.Add(this.objectCount);
            this.Controls.Add(this.upFolderButton);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.forewardButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.fileView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FileManager";
            this.Text = "Файловый менеджер";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.fileContextMenu.ResumeLayout(false);
            this.folderContextMenu.ResumeLayout(false);
            this.emptySpaceContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.StatusBar objectCount;

        private System.Windows.Forms.Button upFolderButton;

        private System.Windows.Forms.ToolStripMenuItem deletePathContextItem;

        private System.Windows.Forms.ToolStripMenuItem deleteFileContextItem;

        private System.Windows.Forms.ToolStripMenuItem uploadContextItem;
        private System.Windows.Forms.ToolStripMenuItem createFolderContextItem;

        private System.Windows.Forms.ContextMenuStrip fileContextMenu;
        private System.Windows.Forms.ContextMenuStrip folderContextMenu;
        private System.Windows.Forms.ContextMenuStrip emptySpaceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem downloadContextItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContextItem;

        private System.Windows.Forms.TextBox pathTextBox;

        private System.Windows.Forms.Button forewardButton;

        private System.Windows.Forms.Button backButton;

        private System.Windows.Forms.ColumnHeader type;

        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader modDate;

        private System.Windows.Forms.ColumnHeader name;

        private System.Windows.Forms.ListView fileView;

        #endregion
    }
}