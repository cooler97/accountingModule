/*
 * Created by SharpDevelop.
 * User: At
 * Date: 30.10.2019
 * Time: 14:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AccountingModule
{
    partial class FilterForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox findElementTextBox;
        private System.Windows.Forms.TreeView filterCollection;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Button cancelBtn;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.findElementTextBox = new System.Windows.Forms.TextBox();
            this.filterCollection = new System.Windows.Forms.TreeView();
            this.okBtn = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findElementTextBox
            // 
            this.findElementTextBox.Location = new System.Drawing.Point(12, 12);
            this.findElementTextBox.Name = "findElementTextBox";
            this.findElementTextBox.Size = new System.Drawing.Size(167, 20);
            this.findElementTextBox.TabIndex = 0;
            this.findElementTextBox.Text = "Поиск элементов";
            this.findElementTextBox.Click += new System.EventHandler(this.FindElementTextBoxClick);
            this.findElementTextBox.TextChanged += new System.EventHandler(this.FindElementTextBoxTextChanged);
            this.findElementTextBox.Leave += new System.EventHandler(this.FindElementTextBoxLeave);
            // 
            // filterCollection
            // 
            this.filterCollection.CheckBoxes = true;
            this.filterCollection.Location = new System.Drawing.Point(12, 38);
            this.filterCollection.Name = "filterCollection";
            this.filterCollection.Size = new System.Drawing.Size(167, 153);
            this.filterCollection.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 227);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ок";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // checkAll
            // 
            this.checkAll.Location = new System.Drawing.Point(12, 197);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(167, 24);
            this.checkAll.TabIndex = 3;
            this.checkAll.Text = "Выбрать все";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.CheckAllCheckedChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(104, 227);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 262);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.filterCollection);
            this.Controls.Add(this.findElementTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
