/*
 * Created by SharpDevelop.
 * User: At
 * Date: 30.10.2019
 * Time: 14:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace AccountingModule
{
    /// <summary>
    /// Description of TextBoxWithBtn.
    /// </summary>
    public class TextBoxWithBtn : TextBox
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        
        Button button = new Button();
        
        public TextBoxWithBtn()
        {
            ResourceManager resources = new ResourceManager("AccountingModule.icons", Assembly.GetExecutingAssembly());
            Bitmap bitmap = (Bitmap)resources.GetObject("filterIcon"); //image without extension

            button.Size = new Size(25, this.ClientSize.Height + 2);
            button.Location = new Point(this.ClientSize.Width - button.Width, -1);
            button.Cursor = Cursors.Default;
            button.Image = bitmap;
            button.Click += OnClick;
//            this.Controls.Add(button);
            
            SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(button.Width << 16));
        }
        
        void OnClick(object sender, System.EventArgs e)
        {
            FilterForm form = new FilterForm(null);
            Point location = this.PointToScreen(Point.Empty);
            int locY = location.Y - form.Height - 5;
            locY = (locY < 0) ? location.Y + this.Height : locY;
            form.Location = new Point(location.X, locY);
            form.ShowDialog();
      
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            button.Size = new Size(25, this.ClientSize.Height + 2);
            button.Location = new Point(this.ClientSize.Width - button.Width, -1);
        }
    }
}
