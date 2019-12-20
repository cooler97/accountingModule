using System;
using System.Windows.Forms;
using Atechnology.Components;
using Atechnology.Components.AtLogWatcher;
using Atechnology.DBConnections2;

namespace AccountingModule
{
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
