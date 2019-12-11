/*
 * Created by SharpDevelop.
 * User: At
 * Date: 18.09.2019
 * Time: 12:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AccountingModule
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button clsBtn;
        private System.Windows.Forms.Panel totalPanel;
        private AccountingModule.AccountListView accountingListView;
        private System.Windows.Forms.Panel filterPanel;
        private AccountingModule.TextBoxWithBtn dateFilterBox;
        private AccountingModule.TextBoxWithBtn customerNameFilterBox;
        private System.Windows.Forms.Button saveBtn;
        private AccountingModule.TextBoxWithBtn docTypeFilter;
        private System.Windows.Forms.TextBox docNameFilter;
        private AccountingModule.TextBoxWithBtn accountingSignFilterBox;
        private AccountingModule.TextBoxWithBtn customerCodeFilterBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStriPeriodSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// 
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.clsBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStriPeriodSelect = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.totalPanel = new System.Windows.Forms.Panel();
            this.accountingListView = new AccountingModule.AccountListView();
            this.accountingSignFilterBox = new AccountingModule.TextBoxWithBtn();
            this.customerCodeFilterBox = new AccountingModule.TextBoxWithBtn();
            this.customerNameFilterBox = new AccountingModule.TextBoxWithBtn();
            this.dateFilterBox = new AccountingModule.TextBoxWithBtn();
            this.docTypeFilter = new AccountingModule.TextBoxWithBtn();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.docNameFilter = new System.Windows.Forms.TextBox();
            this.bottomPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingListView)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomPanel.Controls.Add(this.saveBtn);
            this.bottomPanel.Controls.Add(this.refreshBtn);
            this.bottomPanel.Controls.Add(this.clsBtn);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 460);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(972, 46);
            this.bottomPanel.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(721, 9);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Location = new System.Drawing.Point(802, 9);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Обновить";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.RefreshBtnClick);
            // 
            // clsBtn
            // 
            this.clsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clsBtn.Location = new System.Drawing.Point(883, 9);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(75, 23);
            this.clsBtn.TabIndex = 0;
            this.clsBtn.Text = "Закрыть";
            this.clsBtn.UseVisualStyleBackColor = true;
            this.clsBtn.Click += new System.EventHandler(this.ClsBtnClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStriPeriodSelect,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(972, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel1.Text = "Период для документов";
            // 
            // toolStriPeriodSelect
            // 
            this.toolStriPeriodSelect.DropDownWidth = 141;
            this.toolStriPeriodSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolStriPeriodSelect.Name = "toolStriPeriodSelect";
            this.toolStriPeriodSelect.Size = new System.Drawing.Size(141, 25);
            this.toolStriPeriodSelect.DropDown += new System.EventHandler(this.ToolStriPeriodSelectDropDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(122, 22);
            this.toolStripButton1.Text = "Добавить платеж";
            // 
            // totalPanel
            // 
            this.totalPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalPanel.Location = new System.Drawing.Point(0, 428);
            this.totalPanel.Name = "totalPanel";
            this.totalPanel.Size = new System.Drawing.Size(972, 32);
            this.totalPanel.TabIndex = 4;
            // 
            // accountingListView
            // 
            this.accountingListView.AccountingSignFilterBox = this.accountingSignFilterBox;
            this.accountingListView.AutoGenerateColumns = false;
            this.accountingListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.accountingListView.CellEditEnterChangesRows = true;
            this.accountingListView.CellEditUseWholeCell = false;
            this.accountingListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.accountingListView.CustomerCodeFilterBox = this.customerCodeFilterBox;
            this.accountingListView.CustomerNameFilterBox = this.customerNameFilterBox;
            this.accountingListView.DataSource = null;
            this.accountingListView.DateFilter = this.dateFilterBox;
            this.accountingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountingListView.DocTypeFilter = this.docTypeFilter;
            this.accountingListView.FilterPanel = this.filterPanel;
            this.accountingListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountingListView.FullRowSelect = true;
            this.accountingListView.GridLines = true;
            this.accountingListView.HeaderWordWrap = true;
            this.accountingListView.Location = new System.Drawing.Point(0, 57);
            this.accountingListView.Name = "accountingListView";
            this.accountingListView.NameDocFilterBox = this.docNameFilter;
            this.accountingListView.OwnerDrawnHeader = true;
            this.accountingListView.ShowFilterMenuOnRightClick = false;
            this.accountingListView.ShowGroups = false;
            this.accountingListView.Size = new System.Drawing.Size(972, 371);
            this.accountingListView.TabIndex = 7;
            this.accountingListView.TotalPanel = this.totalPanel;
            this.accountingListView.UseCompatibleStateImageBehavior = false;
            this.accountingListView.UseFiltering = true;
            this.accountingListView.View = System.Windows.Forms.View.Details;
            this.accountingListView.VirtualMode = true;
            this.accountingListView.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.AccountingListViewItemsChanged);
            // 
            // accountingSignFilterBox
            // 
            this.accountingSignFilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountingSignFilterBox.Location = new System.Drawing.Point(302, 0);
            this.accountingSignFilterBox.Name = "accountingSignFilterBox";
            this.accountingSignFilterBox.Size = new System.Drawing.Size(68, 26);
            this.accountingSignFilterBox.TabIndex = 15;
            this.accountingSignFilterBox.TextChanged += new System.EventHandler(this.AccountingSignFilterBoxTextChanged);
            // 
            // customerCodeFilterBox
            // 
            this.customerCodeFilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerCodeFilterBox.Location = new System.Drawing.Point(97, 0);
            this.customerCodeFilterBox.Name = "customerCodeFilterBox";
            this.customerCodeFilterBox.Size = new System.Drawing.Size(51, 26);
            this.customerCodeFilterBox.TabIndex = 14;
            this.customerCodeFilterBox.TextChanged += new System.EventHandler(this.CustomerCodeFilterBoxTextChanged);
            // 
            // customerNameFilterBox
            // 
            this.customerNameFilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerNameFilterBox.Location = new System.Drawing.Point(165, 0);
            this.customerNameFilterBox.Name = "customerNameFilterBox";
            this.customerNameFilterBox.Size = new System.Drawing.Size(123, 26);
            this.customerNameFilterBox.TabIndex = 11;
            this.customerNameFilterBox.TextChanged += new System.EventHandler(this.CustomerNameFilterBoxTextChanged);
            // 
            // dateFilterBox
            // 
            this.dateFilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateFilterBox.Location = new System.Drawing.Point(3, 1);
            this.dateFilterBox.Name = "dateFilterBox";
            this.dateFilterBox.Size = new System.Drawing.Size(88, 26);
            this.dateFilterBox.TabIndex = 10;
            this.dateFilterBox.TextChanged += new System.EventHandler(this.DateFilterBoxTextChanged);
            // 
            // docTypeFilter
            // 
            this.docTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docTypeFilter.Location = new System.Drawing.Point(397, 0);
            this.docTypeFilter.Name = "docTypeFilter";
            this.docTypeFilter.Size = new System.Drawing.Size(77, 26);
            this.docTypeFilter.TabIndex = 12;
            this.docTypeFilter.TextChanged += new System.EventHandler(this.DocTypeFilterTextChanged);
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.accountingSignFilterBox);
            this.filterPanel.Controls.Add(this.customerCodeFilterBox);
            this.filterPanel.Controls.Add(this.docNameFilter);
            this.filterPanel.Controls.Add(this.docTypeFilter);
            this.filterPanel.Controls.Add(this.customerNameFilterBox);
            this.filterPanel.Controls.Add(this.dateFilterBox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 25);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(972, 32);
            this.filterPanel.TabIndex = 6;
            // 
            // docNameFilter
            // 
            this.docNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.docNameFilter.Location = new System.Drawing.Point(498, 0);
            this.docNameFilter.Name = "docNameFilter";
            this.docNameFilter.Size = new System.Drawing.Size(100, 26);
            this.docNameFilter.TabIndex = 13;
            this.docNameFilter.TextChanged += new System.EventHandler(this.DocNameFilterTextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.accountingListView);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.totalPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bottomPanel);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(972, 506);
            this.Text = "AccountingModule";
            this.FormClosing += new Atechnology.Components.FormClosing(this.MainFormFormClosing);
            this.bottomPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingListView)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        }
    }
}

