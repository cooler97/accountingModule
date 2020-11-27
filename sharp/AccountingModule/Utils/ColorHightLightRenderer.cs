using System;
using System.Collections.Generic;
using System.Drawing;
using BrightIdeasSoftware;

namespace AccountingModule
{
    public class ColorHightLightRenderer : HighlightTextRenderer
    {
        Dictionary<int, Color> selectedIndexes = new Dictionary<int, Color>();
        
        public void AddBackgroundColorToRow(int index, Color color)
        {
            if(selectedIndexes.ContainsKey(index))
            {
                selectedIndexes[index] = color;
            }
            else
            {
                selectedIndexes.Add(index, color);
            }
        }
        
        public void RemoveRowBackgroundColor(int index)
        {
            selectedIndexes.Remove(index);
        }
        
        public void ClearBackgroundColorList()
        {
            selectedIndexes.Clear();
        }
        
        public override Color GetBackgroundColor()
        {
            if(selectedIndexes.ContainsKey(ListItem.Index))
            {
                return selectedIndexes[ListItem.Index];
            }

            return base.GetBackgroundColor();
        }
    }
}
