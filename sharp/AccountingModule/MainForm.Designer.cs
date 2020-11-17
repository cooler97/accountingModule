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
        private AccountingModule.TextBoxWithBtn customerNameFilterBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox docNameFilter;
        private System.Windows.Forms.ComboBox accountingSignFilterBox;
        private AccountingModule.TextBoxWithBtn customerCodeFilterBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton paymentsLoadBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem подборШиринывсеКолонкиToolStripMenuItem;
        private System.Windows.Forms.ComboBox dateComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem менеджерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePeopleList;
        private System.Windows.Forms.ToolStripButton closeFinPeriodBtn;
        private System.Windows.Forms.ComboBox docTypeComboBox;
        private System.Windows.Forms.ComboBox managerComboBox;
        
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.clsBtn = new System.Windows.Forms.Button();
            this.docTypeComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.paymentsLoadBtn = new System.Windows.Forms.ToolStripButton();
            this.closeFinPeriodBtn = new System.Windows.Forms.ToolStripButton();
            this.totalPanel = new System.Windows.Forms.Panel();
            this.accountingListView = new AccountingModule.AccountListView();
            this.accountingSignFilterBox = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.подборШиринывсеКолонкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.менеджерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePeopleList = new System.Windows.Forms.ToolStripMenuItem();
            this.customerCodeFilterBox = new AccountingModule.TextBoxWithBtn();
            this.customerNameFilterBox = new AccountingModule.TextBoxWithBtn();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.managerComboBox = new System.Windows.Forms.ComboBox();
            this.docNameFilter = new System.Windows.Forms.TextBox();
            this.bottomPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingListView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomPanel.Controls.Add(this.button1);
            this.bottomPanel.Controls.Add(this.saveBtn);
            this.bottomPanel.Controls.Add(this.refreshBtn);
            this.bottomPanel.Controls.Add(this.clsBtn);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 422);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(956, 46);
            this.bottomPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(15, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Печать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(786, 9);
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
            this.refreshBtn.Location = new System.Drawing.Point(705, 9);
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
            this.clsBtn.Location = new System.Drawing.Point(867, 9);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(75, 23);
            this.clsBtn.TabIndex = 0;
            this.clsBtn.Text = "Закрыть";
            this.clsBtn.UseVisualStyleBackColor = true;
            this.clsBtn.Click += new System.EventHandler(this.ClsBtnClick);
            // 
            // docTypeComboBox
            // 
            this.docTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docTypeComboBox.FormattingEnabled = true;
            this.docTypeComboBox.Location = new System.Drawing.Point(491, 0);
            this.docTypeComboBox.Name = "docTypeComboBox";
            this.docTypeComboBox.Size = new System.Drawing.Size(93, 21);
            this.docTypeComboBox.TabIndex = 3;
            this.docTypeComboBox.Text = "Все";
            this.docTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.DocTypeComboBoxSelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsLoadBtn,
            this.closeFinPeriodBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(956, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // paymentsLoadBtn
            // 
            this.paymentsLoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("paymentsLoadBtn.Image")));
            this.paymentsLoadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paymentsLoadBtn.Name = "paymentsLoadBtn";
            this.paymentsLoadBtn.Size = new System.Drawing.Size(143, 32);
            this.paymentsLoadBtn.Text = "Загрузка платежей";
            this.paymentsLoadBtn.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // closeFinPeriodBtn
            // 
            this.closeFinPeriodBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeFinPeriodBtn.Image")));
            this.closeFinPeriodBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeFinPeriodBtn.Name = "closeFinPeriodBtn";
            this.closeFinPeriodBtn.Size = new System.Drawing.Size(106, 32);
            this.closeFinPeriodBtn.Text = "Закрыть год";
            this.closeFinPeriodBtn.Click += new System.EventHandler(this.ToolStripButton2Click);
            // 
            // totalPanel
            // 
            this.totalPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalPanel.Location = new System.Drawing.Point(0, 390);
            this.totalPanel.Name = "totalPanel";
            this.totalPanel.Size = new System.Drawing.Size(956, 32);
            this.totalPanel.TabIndex = 4;
            // 
            // accountingListView
            // 
            this.accountingListView.AccountingSignFilterBox = this.accountingSignFilterBox;
            this.accountingListView.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.accountingListView.AutoGenerateColumns = false;
            this.accountingListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.accountingListView.CellEditEnterChangesRows = true;
            this.accountingListView.CellEditUseWholeCell = false;
            this.accountingListView.ContextMenuStrip = this.contextMenuStrip1;
            this.accountingListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.accountingListView.CustomerCodeFilterBox = this.customerCodeFilterBox;
            this.accountingListView.CustomerNameFilterBox = this.customerNameFilterBox;
            this.accountingListView.DataSource = null;
            this.accountingListView.DateFilter = this.dateComboBox;
            this.accountingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountingListView.DocTypeFilter = this.docTypeComboBox;
            this.accountingListView.FilterPanel = this.filterPanel;
            this.accountingListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountingListView.FullRowSelect = true;
            this.accountingListView.GridLines = true;
            this.accountingListView.HeaderWordWrap = true;
            this.accountingListView.IsSearchOnSortColumn = false;
            this.accountingListView.Location = new System.Drawing.Point(0, 65);
            this.accountingListView.ManagerFilterBox = this.managerComboBox;
            this.accountingListView.Name = "accountingListView";
            this.accountingListView.NameDocFilterBox = this.docNameFilter;
            this.accountingListView.OwnerDrawnHeader = true;
            this.accountingListView.ShowFilterMenuOnRightClick = false;
            this.accountingListView.ShowGroups = false;
            this.accountingListView.Size = new System.Drawing.Size(956, 325);
            this.accountingListView.TabIndex = 7;
            this.accountingListView.TotalPanel = this.totalPanel;
            this.accountingListView.UseAlternatingBackColors = true;
            this.accountingListView.UseCompatibleStateImageBehavior = false;
            this.accountingListView.UseFilterIndicator = true;
            this.accountingListView.UseFiltering = true;
            this.accountingListView.View = System.Windows.Forms.View.Details;
            this.accountingListView.VirtualMode = true;
            this.accountingListView.DoubleClick += new System.EventHandler(this.AccountingListViewDoubleClick);
            // 
            // accountingSignFilterBox
            // 
            this.accountingSignFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountingSignFilterBox.FormattingEnabled = true;
            this.accountingSignFilterBox.Location = new System.Drawing.Point(421, 0);
            this.accountingSignFilterBox.Name = "accountingSignFilterBox";
            this.accountingSignFilterBox.Size = new System.Drawing.Size(64, 21);
            this.accountingSignFilterBox.TabIndex = 8;
            this.accountingSignFilterBox.Text = "Все";
            this.accountingSignFilterBox.SelectedIndexChanged += new System.EventHandler(this.AccountingSignFilterBoxSelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подборШиринывсеКолонкиToolStripMenuItem,
            this.toolStripMenuItem1,
            this.менеджерToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(248, 54);
            // 
            // подборШиринывсеКолонкиToolStripMenuItem
            // 
            this.подборШиринывсеКолонкиToolStripMenuItem.Name = "подборШиринывсеКолонкиToolStripMenuItem";
            this.подборШиринывсеКолонкиToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.подборШиринывсеКолонкиToolStripMenuItem.Text = "Подбор ширины (все колонки)";
            this.подборШиринывсеКолонкиToolStripMenuItem.Click += new System.EventHandler(this.ПодборШиринывсеКолонкиToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(244, 6);
            // 
            // менеджерToolStripMenuItem
            // 
            this.менеджерToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePeopleList});
            this.менеджерToolStripMenuItem.Name = "менеджерToolStripMenuItem";
            this.менеджерToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.менеджерToolStripMenuItem.Text = "Менеджер";
            // 
            // changePeopleList
            // 
            this.changePeopleList.Name = "changePeopleList";
            this.changePeopleList.Size = new System.Drawing.Size(128, 22);
            this.changePeopleList.Text = "Изменить";
            // 
            // customerCodeFilterBox
            // 
            this.customerCodeFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerCodeFilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.customerCodeFilterBox.Location = new System.Drawing.Point(97, 0);
            this.customerCodeFilterBox.Name = "customerCodeFilterBox";
            this.customerCodeFilterBox.Size = new System.Drawing.Size(51, 21);
            this.customerCodeFilterBox.TabIndex = 14;
            this.customerCodeFilterBox.TextChanged += new System.EventHandler(this.CustomerCodeFilterBoxTextChanged);
            // 
            // customerNameFilterBox
            // 
            this.customerNameFilterBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerNameFilterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.customerNameFilterBox.Location = new System.Drawing.Point(165, 0);
            this.customerNameFilterBox.Name = "customerNameFilterBox";
            this.customerNameFilterBox.Size = new System.Drawing.Size(123, 21);
            this.customerNameFilterBox.TabIndex = 11;
            this.customerNameFilterBox.TextChanged += new System.EventHandler(this.CustomerNameFilterBoxTextChanged);
            // 
            // dateComboBox
            // 
            this.dateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(3, 1);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(88, 21);
            this.dateComboBox.TabIndex = 16;
            this.dateComboBox.DropDown += new System.EventHandler(this.DateComboBoxDropDown);
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.accountingSignFilterBox);
            this.filterPanel.Controls.Add(this.managerComboBox);
            this.filterPanel.Controls.Add(this.docTypeComboBox);
            this.filterPanel.Controls.Add(this.dateComboBox);
            this.filterPanel.Controls.Add(this.customerCodeFilterBox);
            this.filterPanel.Controls.Add(this.docNameFilter);
            this.filterPanel.Controls.Add(this.customerNameFilterBox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 35);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(956, 30);
            this.filterPanel.TabIndex = 6;
            // 
            // managerComboBox
            // 
            this.managerComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managerComboBox.FormattingEnabled = true;
            this.managerComboBox.Location = new System.Drawing.Point(294, 1);
            this.managerComboBox.Name = "managerComboBox";
            this.managerComboBox.Size = new System.Drawing.Size(121, 21);
            this.managerComboBox.TabIndex = 17;
            this.managerComboBox.Text = "Все";
            this.managerComboBox.SelectedIndexChanged += new System.EventHandler(this.ManagerComboBoxSelectedIndexChanged);
            // 
            // docNameFilter
            // 
            this.docNameFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.docNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.docNameFilter.Location = new System.Drawing.Point(601, 0);
            this.docNameFilter.Name = "docNameFilter";
            this.docNameFilter.Size = new System.Drawing.Size(100, 21);
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
            this.Size = new System.Drawing.Size(956, 468);
            this.Text = "Финансовый учет";
            this.bottomPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingListView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

