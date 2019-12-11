/*
 * Created by SharpDevelop.
 * User: At
 * Date: 24.09.2019
 * Time: 18:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.Components.AtLogWatcher;
using Atechnology.DBConnections2;

namespace AccountingModule
{
    /// <summary>
    /// Description of ClassLoader.
    /// </summary>
    public static class ClassLoader
    {
        public static void Load(bool log)
        {
            AtUserControl form = null;
            AtLogWatcher logWatcher = new AtLogWatcher();
            
            try
                {
                
                    if (log)
                        {
                            MdiManager.Add(logWatcher);
                            AtLog.LogWatcher = logWatcher;
                        }
                    
                    form = new MainForm();
                    MdiManager.Add((AtUserControl)form);

                }
            finally
                {
                    MdiManager.tabs.Remove(form);
                }
        }
        
    }
}
