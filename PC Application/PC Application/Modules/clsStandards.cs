using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Management;
using System.Management.Instrumentation;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

/// <summary>
/// Purpose : Class is created to declare standard function.
/// Created On : 31 July, 2012.
/// Created By : Chandrakant Shindkar.
/// Modified On : 
/// Modified By : 
/// Comment :
/// </summary>
public class clsStandards
{
    

    /// <summary>
    /// Purpose : Filling datatable contents into combobox.
    /// </summary>
    /// <param name="objCombo">Combobox field reference.</param>
    /// <param name="dt">Datatable reference.</param>
    /// <param name="strColumn">Column name reference to fill.</param>
    public static void fillCombobox(ComboBox objCombo, DataTable dt)
    {
        //Clearing combobox.
        objCombo.Items.Clear();
        objCombo.Text = string.Empty;
        //if (objCombo.ID == "cboDepartment_Code" || objCombo.ID == "cboAsset_Name" || objCombo.ID == "cboUT_Code" || objCombo.ID == "cboPurchase_Order" || objCombo.ID == "cboCategories" || objCombo.ID == "cboCompany_Code")
        //{
            objCombo.Items.Add("Select");
        //}
            DataView dv = new DataView(dt);
            if (dt.Rows.Count != 0)
            {
                dv.Sort = dt.Columns[0].ColumnName + " ASC";
            }
            try
            {
                for (int i = 0; i <= dv.Table.Rows.Count - 1; i++)
                {
                    objCombo.Items.Add(dv.Table.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                dv = null;
            }
    }

    /// <summary>
    /// Purpose : Filling datatable contents into combobox.
    /// </summary>
    /// <param name="objCombo">Combobox field reference.</param>
    /// <param name="dt">Datatable reference.</param>
    /// <param name="strColumn">Column name reference to fill.</param>
    public static void fillComboboxForReports(ComboBox objCombo, DataTable dt, string strColumn, string FirstRow)
    {
        //Clearing combobox.
        objCombo.Items.Clear();
        objCombo.Text = string.Empty;
        objCombo.Items.Add(FirstRow);
        try
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                objCombo.Items.Add(dt.Rows[i][strColumn].ToString());
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public static void FillListView(ListView objlst, DataTable dt)
    {
        try
        {
            objlst.Items.Clear();
            objlst.Columns.Clear();

            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                objlst.Columns.Add(dt.Columns[i].ToString());
                objlst.Columns[i].Width = 150;
            }
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ListViewItem lst = new ListViewItem(dt.Rows[i][0].ToString());
                for (int j = 1; j <= dt.Columns.Count -1; j++)
                {
                    lst.SubItems.Add(dt.Rows[i][j].ToString());
                }
                objlst.Items.Add(lst);
            }
            if (objlst.Items.Count > 0)
            {
                objlst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                objlst.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public static void FillListView(ref ListView objlst, DataTable dt)
    {
        try
        {
            objlst.Items.Clear();
            objlst.Columns.Clear();

            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                objlst.Columns.Add(dt.Columns[i].ToString());
                objlst.Columns[i].Width = 150;
            }
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                ListViewItem lst = new ListViewItem(dt.Rows[i][0].ToString());
                for (int j = 1; j <= dt.Columns.Count - 1; j++)
                {
                    lst.SubItems.Add(dt.Rows[i][j].ToString());
                }
                objlst.Items.Add(lst);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}