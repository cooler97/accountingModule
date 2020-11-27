using System;
using System.Collections;
using System.Collections.Generic;

namespace AccountingModule
{
    [Serializable]
    public class AccountSettings
    {
        public AccountColumnList columnList = new AccountColumnList();
        
        public AccountSettings()
        {
        }
    }
    
    [Serializable]
    public class AccountColumnList : List<AccountColumnSetting> {
        
        public AccountColumnList() {}
        
        public void Add(string name, int width)
        {
            AccountColumnSetting acc = new AccountColumnSetting();
            acc.name = name;
            acc.width = width;
            this.Add(acc);
        }
    }
    
    [Serializable]
    public class AccountColumnSetting {
        
        public string name;
        public int width;
        
        public AccountColumnSetting() {}
    }
}
