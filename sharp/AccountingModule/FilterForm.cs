using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingModule
{

    public partial class FilterForm : Form
    {
        
        private readonly string FIND_ELEMENT_CAPTION = "Поиск элементов";
        
        private TreeView _filterCollectionCache;
        
        private List<string> _rowFilterCollection = new List<string>();
        
        public TreeView filterCollectionCache {
            
            get {return _filterCollectionCache; }
            
        }
        
        public FilterForm(List<string> rowFilterCollection)
        {
            InitializeComponent();
            
            _filterCollectionCache = new TreeView();
            
            foreach(string s in rowFilterCollection){
                _filterCollectionCache.Nodes.Add(s);
            }
            
            updateFilterTreeView();
        }
        
        void CancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
        
        void FindElementTextBoxClick(object sender, EventArgs e)
        {
            if (findElementTextBox.Text == FIND_ELEMENT_CAPTION)
            {
                findElementTextBox.Text = string.Empty;
            }
        }
        
        void FindElementTextBoxLeave(object sender, EventArgs e)
        {
            if (findElementTextBox.Text == string.Empty)
            {
                findElementTextBox.Text = FIND_ELEMENT_CAPTION;
            }
        }
        
        void FindElementTextBoxTextChanged(object sender, EventArgs e)
        {
            updateFilterTreeView();
        }
        
        private void updateFilterTreeView() {
            this.filterCollection.BeginUpdate();
            this.filterCollection.Nodes.Clear();
            if (this.findElementTextBox.Text != string.Empty && this.findElementTextBox.Text != FIND_ELEMENT_CAPTION)
            {
                foreach (TreeNode _parentNode in _filterCollectionCache.Nodes)
                {
                    
                    if (_parentNode.Text.StartsWith(this.findElementTextBox.Text))
                    {
                        this.filterCollection.Nodes.Add((TreeNode)_parentNode.Clone());
                    }
                    
                    foreach (TreeNode _childNode in _parentNode.Nodes)
                    {
                        if (_childNode.Text.StartsWith(this.findElementTextBox.Text))
                        {
                            this.filterCollection.Nodes.Add((TreeNode)_childNode.Clone());
                        }
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in this._filterCollectionCache.Nodes)
                {
                    filterCollection.Nodes.Add((TreeNode)_node.Clone());
                }
            }
            //enables redrawing tree after all objects have been added
            this.filterCollection.EndUpdate();
        }
        
        void CheckAllCheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckedState((sender as CheckBox).Checked);
        }
        
        private void ChangeCheckedState(bool state)
        {
            foreach (TreeNode _parentNode in filterCollection.Nodes)
            {
                _parentNode.Checked = state;
                foreach (TreeNode _childNode in _parentNode.Nodes)
                {
                    _childNode.Checked = state;
                }
            }
        }
    }
}
