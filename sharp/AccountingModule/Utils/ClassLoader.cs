using System;
using Atechnology.Components;
using Atechnology.Components.AtLogWatcher;

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
                    
                    try
                    {
                    form = new MainForm();
                    MdiManager.Add((AtUserControl)form);
                    }
                    catch(Exception e)
                    {
                        AtLog.AddMessage(e.ToString());
                    }

                }
            finally
                {
                    MdiManager.tabs.Remove(form);
                }
        }
        
    }
}
