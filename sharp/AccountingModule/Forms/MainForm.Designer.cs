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
        private AccountingModule.AccountListView mainListView;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox customerNameFilterBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox docNameFilter;
        private System.Windows.Forms.ComboBox accountingSignFilterBox;
        private System.Windows.Forms.TextBox customerCodeFilterBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton paymentsLoadBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem подборШиринывсеКолонкиToolStripMenuItem;
        private System.Windows.Forms.ComboBox dateComboBox;
        private System.Windows.Forms.ToolStripMenuItem менеджерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePeopleList;
        private System.Windows.Forms.ToolStripButton closeFinPeriodBtn;
        private System.Windows.Forms.ComboBox docTypeComboBox;
        private System.Windows.Forms.ComboBox managerComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton highlighetBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel selectPanel;
        private System.Windows.Forms.ToolStripButton exportRealizationBtn;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem заливкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem безЗаливкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ComboBox saleFilter;
        
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.highlighetBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportRealizationBtn = new System.Windows.Forms.ToolStripButton();
            this.totalPanel = new System.Windows.Forms.Panel();
            this.accountingSignFilterBox = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.безЗаливкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заливкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.менеджерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePeopleList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.подборШиринывсеКолонкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerCodeFilterBox = new System.Windows.Forms.TextBox();
            this.customerNameFilterBox = new System.Windows.Forms.TextBox();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.managerComboBox = new System.Windows.Forms.ComboBox();
            this.saleFilter = new System.Windows.Forms.ComboBox();
            this.docNameFilter = new System.Windows.Forms.TextBox();
            this.selectPanel = new System.Windows.Forms.Panel();
            this.mainListView = new AccountingModule.AccountListView();
            this.bottomPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainListView)).BeginInit();
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
            this.bottomPanel.Location = new System.Drawing.Point(0, 511);
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
            this.docTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docTypeComboBox.FormattingEnabled = true;
            this.docTypeComboBox.Location = new System.Drawing.Point(590, 0);
            this.docTypeComboBox.Name = "docTypeComboBox";
            this.docTypeComboBox.Size = new System.Drawing.Size(93, 21);
            this.docTypeComboBox.TabIndex = 3;
            this.docTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.DocTypeComboBoxSelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsLoadBtn,
            this.closeFinPeriodBtn,
            this.toolStripSeparator1,
            this.highlighetBtn,
            this.toolStripSeparator2,
            this.exportRealizationBtn});
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // highlighetBtn
            // 
            this.highlighetBtn.Image = ((System.Drawing.Image)(resources.GetObject("highlighetBtn.Image")));
            this.highlighetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.highlighetBtn.Name = "highlighetBtn";
            this.highlighetBtn.Size = new System.Drawing.Size(84, 32);
            this.highlighetBtn.Text = "Заливка";
            this.highlighetBtn.Click += new System.EventHandler(this.HighlighetBtnClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // exportRealizationBtn
            // 
            this.exportRealizationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportRealizationBtn.Image = ((System.Drawing.Image)(resources.GetObject("exportRealizationBtn.Image")));
            this.exportRealizationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportRealizationBtn.Name = "exportRealizationBtn";
            this.exportRealizationBtn.Size = new System.Drawing.Size(166, 32);
            this.exportRealizationBtn.Text = "Сформировать реализацию";
            this.exportRealizationBtn.Click += new System.EventHandler(this.ExportRealizationBtnClick);
            // 
            // totalPanel
            // 
            this.totalPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalPanel.Location = new System.Drawing.Point(0, 479);
            this.totalPanel.Name = "totalPanel";
            this.totalPanel.Size = new System.Drawing.Size(956, 32);
            this.totalPanel.TabIndex = 4;
            // 
            // accountingSignFilterBox
            // 
            this.accountingSignFilterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountingSignFilterBox.FormattingEnabled = true;
            this.accountingSignFilterBox.Location = new System.Drawing.Point(421, 0);
            this.accountingSignFilterBox.Name = "accountingSignFilterBox";
            this.accountingSignFilterBox.Size = new System.Drawing.Size(64, 21);
            this.accountingSignFilterBox.TabIndex = 8;
            this.accountingSignFilterBox.SelectedIndexChanged += new System.EventHandler(this.AccountingSignFilterBoxSelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripMenuItem3,
            this.безЗаливкиToolStripMenuItem,
            this.заливкаToolStripMenuItem,
            this.toolStripMenuItem4,
            this.менеджерToolStripMenuItem,
            this.toolStripMenuItem2,
            this.подборШиринывсеКолонкиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(248, 132);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.ОткрытьToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(244, 6);
            // 
            // безЗаливкиToolStripMenuItem
            // 
            this.безЗаливкиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("безЗаливкиToolStripMenuItem.Image")));
            this.безЗаливкиToolStripMenuItem.Name = "безЗаливкиToolStripMenuItem";
            this.безЗаливкиToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.безЗаливкиToolStripMenuItem.Text = "Без заливки";
            this.безЗаливкиToolStripMenuItem.Click += new System.EventHandler(this.БезЗаливкиToolStripMenuItemClick);
            // 
            // заливкаToolStripMenuItem
            // 
            this.заливкаToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("заливкаToolStripMenuItem.Image")));
            this.заливкаToolStripMenuItem.Name = "заливкаToolStripMenuItem";
            this.заливкаToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.заливкаToolStripMenuItem.Text = "Заливка";
            this.заливкаToolStripMenuItem.Click += new System.EventHandler(this.ЗаливкаToolStripMenuItemClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(244, 6);
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(244, 6);
            // 
            // подборШиринывсеКолонкиToolStripMenuItem
            // 
            this.подборШиринывсеКолонкиToolStripMenuItem.Name = "подборШиринывсеКолонкиToolStripMenuItem";
            this.подборШиринывсеКолонкиToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.подборШиринывсеКолонкиToolStripMenuItem.Text = "Подбор ширины (все колонки)";
            this.подборШиринывсеКолонкиToolStripMenuItem.Click += new System.EventHandler(this.ПодборШиринывсеКолонкиToolStripMenuItemClick);
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
            this.dateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.filterPanel.Controls.Add(this.saleFilter);
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
            this.managerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.managerComboBox.FormattingEnabled = true;
            this.managerComboBox.Location = new System.Drawing.Point(294, 1);
            this.managerComboBox.Name = "managerComboBox";
            this.managerComboBox.Size = new System.Drawing.Size(121, 21);
            this.managerComboBox.TabIndex = 17;
            this.managerComboBox.SelectedIndexChanged += new System.EventHandler(this.ManagerComboBoxSelectedIndexChanged);
            this.managerComboBox.TextUpdate += new System.EventHandler(this.ManagerComboBoxTextUpdate);
            // 
            // saleFilter
            // 
            this.saleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saleFilter.FormattingEnabled = true;
            this.saleFilter.Location = new System.Drawing.Point(491, 1);
            this.saleFilter.Name = "saleFilter";
            this.saleFilter.Size = new System.Drawing.Size(93, 21);
            this.saleFilter.TabIndex = 3;
            this.saleFilter.SelectedIndexChanged += new System.EventHandler(this.SaleFilterSelectedIndexChanged);
            // 
            // docNameFilter
            // 
            this.docNameFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.docNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.docNameFilter.Location = new System.Drawing.Point(706, 3);
            this.docNameFilter.Name = "docNameFilter";
            this.docNameFilter.Size = new System.Drawing.Size(100, 21);
            this.docNameFilter.TabIndex = 13;
            this.docNameFilter.TextChanged += new System.EventHandler(this.DocNameFilterTextChanged);
            // 
            // selectPanel
            // 
            this.selectPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectPanel.Location = new System.Drawing.Point(0, 447);
            this.selectPanel.Name = "selectPanel";
            this.selectPanel.Size = new System.Drawing.Size(956, 32);
            this.selectPanel.TabIndex = 8;
            // 
            // mainListView
            // 
            this.mainListView.AccountingSignFilterBox = this.accountingSignFilterBox;
            this.mainListView.AlternateRowBackColor = System.Drawing.Color.AliceBlue;
            this.mainListView.AutoGenerateColumns = false;
            this.mainListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.mainListView.CellEditEnterChangesRows = true;
            this.mainListView.CellEditUseWholeCell = false;
            this.mainListView.ContextMenuStrip = this.contextMenuStrip1;
            this.mainListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainListView.CustomerCodeFilterBox = this.customerCodeFilterBox;
            this.mainListView.CustomerNameFilterBox = this.customerNameFilterBox;
            this.mainListView.DataSource = null;
            this.mainListView.DateFilter = this.dateComboBox;
            this.mainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListView.DocTypeFilter = this.docTypeComboBox;
            this.mainListView.FilterPanel = this.filterPanel;
            this.mainListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainListView.FullRowSelect = true;
            this.mainListView.GridLines = true;
            this.mainListView.HeaderWordWrap = true;
            this.mainListView.IsSearchOnSortColumn = false;
            this.mainListView.Location = new System.Drawing.Point(0, 65);
            this.mainListView.ManagerFilterBox = this.managerComboBox;
            this.mainListView.Name = "mainListView";
            this.mainListView.NameDocFilterBox = this.docNameFilter;
            this.mainListView.OwnerDrawnHeader = true;
            this.mainListView.RenderNonEditableCheckboxesAsDisabled = true;
            this.mainListView.SaleFilterBox = this.saleFilter;
            this.mainListView.SelectPanel = this.selectPanel;
            this.mainListView.ShowFilterMenuOnRightClick = false;
            this.mainListView.ShowGroups = false;
            this.mainListView.Size = new System.Drawing.Size(956, 382);
            this.mainListView.TabIndex = 9;
            this.mainListView.TotalPanel = this.totalPanel;
            this.mainListView.TotalSelectLabel = null;
            this.mainListView.UseAlternatingBackColors = true;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.UseFilterIndicator = true;
            this.mainListView.UseFiltering = true;
            this.mainListView.View = System.Windows.Forms.View.Details;
            this.mainListView.VirtualMode = true;
            this.mainListView.SelectionChanged += new System.EventHandler(this.AccountingListViewSelectionChanged);
            this.mainListView.DoubleClick += new System.EventHandler(this.AccountingListViewDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainListView);
            this.Controls.Add(this.selectPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.totalPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.bottomPanel);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(956, 557);
            this.Text = "Финансовый учет";
            this.FormClosing += new Atechnology.Components.FormClosing(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.bottomPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}