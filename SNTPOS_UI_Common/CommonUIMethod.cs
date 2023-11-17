using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace SNTPOS_UI_Common
{
   public static  class CommonUIMethod
    {
        public static void setDataColName(this ComboBox comboBox,ref DataTable dt)
        {
                 for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        comboBox.Items.Add(dt.Columns[i].ColumnName);
  
                    }
                    if (comboBox.Items.Count >= 2)
                        comboBox.SelectedIndex = 1;
                    else
                        comboBox.SelectedIndex = 0;
                }

        public static void changeImageLayout(this DataGridView dgv,DataGridViewImageCellLayout layout)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column is DataGridViewImageColumn)
                {
                    DataGridViewImageColumn imgCol = (DataGridViewImageColumn)column;
                    imgCol.ImageLayout = layout;
                }
            }
        }


       
        
    }
    
}
