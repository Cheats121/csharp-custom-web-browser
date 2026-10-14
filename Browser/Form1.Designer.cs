using System;
using System.Windows.Forms;

namespace Browser
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.homeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.goHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favouritesButton = new System.Windows.Forms.ToolStripButton();
            this.bookmarkButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.historyButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.bulkDownloadButton = new System.Windows.Forms.ToolStripButton();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.webBox = new System.Windows.Forms.TextBox();
            this.panelSearchBar = new System.Windows.Forms.Panel();
            this.loadingIndicator = new System.Windows.Forms.PictureBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelSearchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIndicator)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.13496F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.64863F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.27458F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.forwardButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.reloadButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.searchButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.webBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelSearchBar, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1443, 822);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeButton,
            this.favouritesButton,
            this.bookmarkButton,
            this.historyButton,
            this.bulkDownloadButton});
            this.toolStrip1.Location = new System.Drawing.Point(1295, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(148, 36);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // homeButton
            // 
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.homeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.homeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goHomeToolStripMenuItem,
            this.setHomeToolStripMenuItem});
            this.homeButton.Image = global::Browser.Properties.Resources.home;
            this.homeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.homeButton.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(33, 36);
            this.homeButton.Text = "Home Button";
            // 
            // goHomeToolStripMenuItem
            // 
            this.goHomeToolStripMenuItem.Name = "goHomeToolStripMenuItem";
            this.goHomeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.goHomeToolStripMenuItem.Text = "Go to Home";
           
            // 
            // setHomeToolStripMenuItem
            // 
            this.setHomeToolStripMenuItem.Name = "setHomeToolStripMenuItem";
            this.setHomeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.setHomeToolStripMenuItem.Text = "Set as Home";
             
            // 
            // favouritesButton
            // 
            this.favouritesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.favouritesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.favouritesButton.Image = global::Browser.Properties.Resources.star;
            this.favouritesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.favouritesButton.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.favouritesButton.Name = "favouritesButton";
            this.favouritesButton.Size = new System.Drawing.Size(24, 36);
            this.favouritesButton.Text = "Favourites Button";
            
            // 
            // bookmarkButton
            // 
            this.bookmarkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bookmarkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bookmarkButton.Image = global::Browser.Properties.Resources.save_instagram;
            this.bookmarkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bookmarkButton.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bookmarkButton.Name = "bookmarkButton";
            this.bookmarkButton.Size = new System.Drawing.Size(33, 36);
            this.bookmarkButton.Text = "Bookmarks Button";
            // 
            // historyButton
            // 
            this.historyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.historyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.historyButton.Image = global::Browser.Properties.Resources.history;
            this.historyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyButton.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(33, 24);
            this.historyButton.Text = "History Button";
            // 
            // bulkDownloadButton
            // 
            this.bulkDownloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bulkDownloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bulkDownloadButton.Image = global::Browser.Properties.Resources.download;
            this.bulkDownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bulkDownloadButton.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.bulkDownloadButton.Name = "bulkDownloadButton";
            this.bulkDownloadButton.Size = new System.Drawing.Size(24, 24);
            this.bulkDownloadButton.Text = "Bulk Download";
            this.bulkDownloadButton.Click += new System.EventHandler(this.bulkDownloadButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackgroundImage = global::Browser.Properties.Resources.left_arrow;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(88, 30);
            this.backButton.TabIndex = 0;
            this.backButton.UseVisualStyleBackColor = true;
              
            // 
            // forwardButton
            // 
            this.forwardButton.BackgroundImage = global::Browser.Properties.Resources.right_arrow;
            this.forwardButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.forwardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forwardButton.Location = new System.Drawing.Point(97, 3);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(84, 30);
            this.forwardButton.TabIndex = 1;
            this.forwardButton.UseVisualStyleBackColor = true;
            
            // 
            // reloadButton
            // 
            this.reloadButton.BackgroundImage = global::Browser.Properties.Resources.reload2;
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.reloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reloadButton.Location = new System.Drawing.Point(187, 3);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(50, 30);
            this.reloadButton.TabIndex = 2;
            this.reloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reloadButton.UseVisualStyleBackColor = true;
            reloadButton.Click += new EventHandler(ReloadButton_Click);  
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(1110, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(182, 30);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += new EventHandler(SearchButton_Click); 
            // 
            // webBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.webBox, 6);
            this.webBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webBox.Location = new System.Drawing.Point(3, 39);
            this.webBox.Multiline = true;
            this.webBox.Name = "webBox";
            this.webBox.Size = new System.Drawing.Size(1437, 780);
            this.webBox.TabIndex = 0;
            // 
            // panelSearchBar
            // 
            this.panelSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchBar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelSearchBar.Controls.Add(this.loadingIndicator);
            this.panelSearchBar.Controls.Add(this.searchBox);
            this.panelSearchBar.Location = this.searchBox.Location;
            this.panelSearchBar.Name = "panelSearchBar";
            this.panelSearchBar.Size = new System.Drawing.Size(861, 30);
            this.panelSearchBar.TabIndex = 1;
            // 
            // loadingIndicator
            // 
            this.loadingIndicator.Image = global::Browser.Properties.Resources.Rolling_1x_1_0s_200px_200px;
            this.loadingIndicator.Location = new System.Drawing.Point(838, 0);
            this.loadingIndicator.Name = "loadingIndicator";
            this.loadingIndicator.Size = new System.Drawing.Size(20, 20);
            this.loadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingIndicator.TabIndex = 0;
            this.loadingIndicator.TabStop = false;
            this.loadingIndicator.Visible = false;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(0, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(861, 26);
            this.searchBox.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1443, 822);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Custom Browser";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelSearchBar.ResumeLayout(false);
            this.panelSearchBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIndicator)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox webBox;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton homeButton;
        private System.Windows.Forms.ToolStripMenuItem goHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton favouritesButton;
        private System.Windows.Forms.ToolStripDropDownButton bookmarkButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ToolStripDropDownButton historyButton;
        private System.Windows.Forms.ToolStripButton bulkDownloadButton;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.PictureBox loadingIndicator;
        private System.Windows.Forms.Panel panelSearchBar;
        
    }
}