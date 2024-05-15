using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.DataGrid.Renderers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using mshtml;
using Syncfusion.Windows.Forms.HTMLUI;
using mshtml;

namespace ConsolidatedEmailAlerts
{
    public partial class ConsolidatedEmailAlerts1 : Form
    {
        public static IniFile.ini iniObj = new IniFile.ini(AppDomain.CurrentDomain.BaseDirectory + "//SPCWB.ini");
        char[] c = { '\r', '\n' };
        ResourceManager rm;
        bool selectFlag = false;
        public string FilePath = "";
        public string FileName = "";
        ArrayList fileNames = new ArrayList();
       // public string htmltextfromDatabase = "";
        string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        bool state = false;
        public int EmailAlertCount;
        OleDbCommand cmd;
        OleDbConnection connection;
        OleDbDataReader reader;
        ListViewItem lstviewItem = new ListViewItem();
        DataTable dtFillDatagridWithFiles = new DataTable();
        //GridCheckBoxColumn checkBoxColumn = new GridCheckBoxColumn();
        public string checkcol = "";
        string colName = "File Name";
        string colName1 = "File Path";
        string colName2 = "Modified Date";
        string colName3 = "Check Status For Alert";
        public string filepath = "";
        public int currentCellRowIndex;
        public int previousRowIndex;
        public int previousvalue;
       // string NoAlertFoundMessage = "<span style ='color:blue;font-size:1.6em;' ><b> " + " </b ></ span ><br/>" + "(No alert found in this File.)</p>";
        // public static string cellValue = "";
        // ArrayList arrFileName = new ArrayList();
        List<KeyValuePair<string, string>> arrFileName = new List<KeyValuePair<string, string>>();
        // public string cssstyleforheadertag;
        public string htmltextfromDatabase = "";
        public  static string mainbodyTagUpper = "<html>" + "<body>";
        public static string mainBodyTagLower = "</body>" + "</html>";
        //public string cssStyleForHr="";
       public string  cssStyleForHr ="<hr style=height:10px;border-width:10px;color:black;background-color:black>";


        public ConsolidatedEmailAlerts1()
        {
            InitializeComponent();
         
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            #region step-1 Create OpenFileDialog to Fill CheckListBox With selected Files in OpenFileDialog
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "//SPCWB.ini") == false)//If file SPCWB.ini not present then it creates that file and path,version and startup option are added to that file 
            {
                iniObj.IniWriteValue("VersionInfo", "Version", "6");
                iniObj.IniWriteValue("Settings", "DataPath", AppDomain.CurrentDomain.BaseDirectory + @"Data");//default path
                iniObj.IniWriteValue("StartUpOption", "ShowAtStartUp", "Yes");
            }

            string DataPath = iniObj.IniReadValue("Settings", "DataPath");

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = DataPath;
            openFileDialog.Filter = "SPC WorkBench Files (*.spcx) | *.spcx";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var filename in openFileDialog.FileNames)
                {
                    FilePath = openFileDialog.FileName;
                    FileName = filename.Remove(0, FilePath.LastIndexOf('\\') + 1);
                    filepath = Path.GetDirectoryName(FilePath);

                    fileNames.Add(FileName);
                    var lastModified = System.IO.File.GetLastWriteTime(filename);

                    System.Data.DataRow dr1 = dtFillDatagridWithFiles.NewRow();
                    dr1[colName] = FileName;
                    dr1[colName1] =filename;
                    dr1[colName2] = lastModified.ToString();
                    string EmailAlert = "EmailAlert";
                    connection = new OleDbConnection(conString + filename);
                    connection.Open();

                    cmd = new OleDbCommand("Select *from AttributeSetting where AttributeName='" + EmailAlert + "' ", connection);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        dr1[colName3] = "Yes";
                    }
                    else
                    {
                        dr1[colName3] = "No";
                    }
                        
                    #region check if FileName already exists in Datatable or not
                    System.Data.DataRow[] foundRows = dtFillDatagridWithFiles.Select("[File Name] = '" + FileName + "' ");
                    if (foundRows.Length != 0)
                    {
                        MessageBox.Show("File Name already exists");
                    }
                   else
                    {
                        dtFillDatagridWithFiles.Rows.Add(dr1.ItemArray);
                        sfdgFileSelect.DataSource = dtFillDatagridWithFiles;
                    }
                    #endregion check if FileName already exists in Datatable or not
                    connection.Close();
                }
            }
        }
            #endregion Create OpenFileDialog to Fill CheckListBox With selected Files in OpenFileDialog
        

      private string ConcatehtmltextwithheadertagUsingFileName(List<KeyValuePair<string, string>> lstFilenames)
        {
            foreach (KeyValuePair<string, string> ele in lstFilenames)
            {
                string NoAlertFoundMessage = "";
                string selectedFile = ele.Key;
                string filepath = ele.Value;

                string fileheader = "";
                fileheader = "<h2>" + ele.Key + "</h2>";

                int filecharcount = filepath.Length;

                string EmailAlert = "EmailAlert";
                connection = new OleDbConnection(conString + filepath);
                connection.Open();

                cmd = new OleDbCommand("Select *from AttributeSetting where AttributeName='" + EmailAlert + "' ", connection);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    NoAlertFoundMessage = "";
                    //string readMailContent = "<div style =\"display: block;\\" + reader["AttributeValue"].ToString();
                    string readMailContent = reader["AttributeValue"].ToString();
                    htmltextfromDatabase = htmltextfromDatabase + fileheader + cssStyleForHr + readMailContent;
                }
                else
                {
                    NoAlertFoundMessage = "";
                    NoAlertFoundMessage = "<html><body><p style ='color:blue;font-size:30px;' ><b> " + " </b ></ span ><br/>" + "(No alert found in this File.)</p></body></html>";
                    string removeNoAlertFoundMessage =Regex.Replace(htmltextfromDatabase, @"" + NoAlertFoundMessage + "", "");
                    htmltextfromDatabase = removeNoAlertFoundMessage + fileheader + NoAlertFoundMessage+cssStyleForHr;
                
                }
                connection.Close();
                connection.Dispose();
            }
            htmltextfromDatabase= "<!DOCTYPE html>" + htmltextfromDatabase;
            return htmltextfromDatabase;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
           webBrowser1.Navigate("about:blank");
           // webBrowser1.ClearHistory();
            // webBrowser1.Refresh();
            //webBrowser1.Document.OpenNew(true);
             htmltextfromDatabase = "";
            // htmluiControlEmailAlerts.Navigate.ToString() 
            #region Step1 FillList with SelectedItems in Sfdatagrid
            if (sfdgFileSelect.SelectedItems.Count > 0)
            {
                foreach (var item in sfdgFileSelect.SelectedItems)
                {
                    var datarow = (item as DataRowView).Row;
                    //var datacolumn = (item as DataColumn).ColumnName;
                    arrFileName.Add(new KeyValuePair<string, string>(datarow["File Name"].ToString(), datarow["File Path"].ToString()));
                    // arrFileName.Add(datarow["File Path"].ToString());
                }

            }
            #endregion Step1 FillList with SelectedItems in Sfdatagrid

            #region Step 2 Iterate through List and add html tag for header and wide line
            string Emailtext= ConcatehtmltextwithheadertagUsingFileName(arrFileName);

            arrFileName.Clear();
            #region Iterate through List and add html tag for header and wide line

            #region step 3 send emailtext to htmluicontrol
            webBrowser1.DocumentText = Emailtext;
            //webBrowser1.Document.Write(Emailtext);
            //htmluicontrolEmailAlerts.LoadFromString(Emailtext);
            #endregion send emailtext to htmluicontrol

        }
    
       private void sfDataGrid1_CurrentCellActivating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatingEventArgs e)
        {

        }

        private void sfDataGrid1_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            // foreach (var record in sfDataGrid1.View.Records)
            // {
            //     bool isChecked = false;
            //     var checkBoxColumn = sfDataGrid1.Columns.FirstOrDefault(col => col.MappingName == "Column2");
            //     int checkBoxColumnIndex = -1;
            //     if (checkBoxColumn != null)
            //     {
            //         //for (int i = 0; i < sfDataGrid1.Columns.Count; i++)
            //         //{
            //         //    if (sfDataGrid1.Columns[i].MappingName == checkBoxColumn.MappingName)
            //         //    {
            //         //        checkBoxColumnIndex = i;
            //         //        break;
            //         //    }
            //         //}
            //         isChecked = (bool)record.Get(checkBoxColumn.MappingName);
            //     }
            //     // perform the necessary actions with the checkbox checked value
            //     // ...
            // }
            //// In this code snippet, we first check if the CheckBoxColumnName column exists in the SfDataGrid.Col

            //int rowIndex = e.RowIndex;
            //int columnIndex = e.ColumnIndex;
            //var dataSource = sfDataGrid1.DataSource;
            //if (dataSource is DataTable dtFillDatagridWithFiles && dtFillDatagridWithFiles != null && rowIndex <= dtFillDatagridWithFiles.Rows.Count)
            //{
            //    object value =(dtFillDatagridWithFiles.Rows[rowIndex-1].ItemArray[columnIndex]);
            //    bool isChecked = Convert.ToBoolean(value);


            //    if (isChecked)
            //    {
            //        // Checkbox is checked
            //        // Do something
            //    }
            //    else
            //    {
            //        // Checkbox is unchecked
            //        // Do something else
            //    }
            //}
            //var dataTable = sfDataGrid1.GridTable;
            //bool isChecked = (bool)dataTable.Rows[rowIndex].ItemArray[columnIndex];
            //if (isChecked)
            //{
            //    // Checkbox is checked
            //    // Do something
            //}
            //else
            //{
            //    // Checkbox is unchecked
            //    // Do something else
            //}
            ////int rowIndex = e.RowIndex;
            //int columnIndex = e.ColumnIndex;
            //bool isChecked = (bool)sfDataGrid1.GetCurrent(rowIndex, columnIndex);

            //if (isChecked)
            //{
            //    // Checkbox is checked
            //    // Do something
            //}
            //else
            //{
            //    // Checkbox is unchecked
            //    // Do something else
            //}
            ////  int columnIndex = this.sfDataGrid1.Columns.IndexOf("Column1");
            //int rowIndex = e.RowIndex;

            ////// Get the "IsChecked" cell value of the clicked row
            //bool isChecked = (bool)sfDataGrid1.View.Records[rowIndex].Cells["IsChecked"].CellValue;

            //// Do something with the cell value
            //foreach (var record in sfDataGrid1.View.Records)
            //{
            //    bool isChecked = false;
            //    var checkBoxColumn = sfDataGrid1.Columns.FirstOrDefault(col => col.MappingName == "Column2");
            //    if (checkBoxColumn != null)
            //    {
            //        isChecked = (bool)record[checkBoxColumn.Index];
            //    }
            //    // perform the necessary actions with the checkbox checked value
            //    // ...
            //}

            //var records = sfdgFileSelect.View.Records;
            //foreach (var record in records)
            //{

            //    var dataRowView = record.Data as DataRowView;
            //    if (dataRowView != null)
            //    {

            //        var selectedValue = dataRowView.Row["File Name"];
            //        if (FilePath.Contains(selectedValue.ToString()))
            //        {
            //            // var selected = dataRowView.Row["checkBoxColumn"] ;
            //            if ((selectedValue) != null)
            //            {
            //                //if (selected.GetType() != typeof(DBNull) && (bool)selected)
            //                //{

            //                string EmailAlert = "EmailAlert";
            //                connection = new OleDbConnection(conString + selectedValue);
            //                connection.Open();
            //                cmd = new OleDbCommand("Select *from AttributeSetting where AttributeName='" + EmailAlert + "' ", connection);
            //                reader = cmd.ExecuteReader();
            //                if (reader.Read())
            //                {
            //                    htmltextfromDatabase = (reader["AttributeValue"].ToString());
            //                }
            //                // mailText = result;
            //                htmluiControl1.Text = htmltextfromDatabase;
            //                connection.Close();
            //                connection.Dispose();
            //            }
            //        }
            //    }
            //}


        }




        private void ConsolidatedEmailAlerts1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("about:blank");
            dtFillDatagridWithFiles.Columns.Add(colName, typeof(string));
            dtFillDatagridWithFiles.Columns.Add(colName1, typeof(string));
            dtFillDatagridWithFiles.Columns.Add(colName2, typeof(string));
            dtFillDatagridWithFiles.Columns.Add(colName3,typeof(string));


            this.sfdgFileSelect.Columns.Add(new GridCheckBoxSelectorColumn()
            {
                MappingName = "fldSelect",
                HeaderText = string.Empty,
                TrueValue = "True",
                FalseValue = "False",
                AllowCheckBoxOnHeader = true,
                Width = 34,
                CheckBoxSize = new Size(14, 14),
                AllowSorting = true

            }) ;
        }

        private void View_RecordPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            

        }

        private void sfDataGrid1_CellCheckBoxClicked(object sender, GridCellCheckBoxClickEventArgs e)
        {
            //// Get the checkbox column


            //if (checkBoxColumn != null)
            //{
            //    // Get the cell value
            //    var cellValue = e.Record.Equals(checkBoxColumn.MappingName);

            //    // Handle the checkbox click event based on the cell value
            //    if (cellValue != null && (bool)cellValue)
            //    {
            //        // Checkbox is checked
            //    }
            //    else
            //    {
            //        // Checkbox is unchecked
            //    }
            //}
        }

        private void sfdgFileSelect_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            //    string mailtext = htmltextfromDatabase;
            //    var records = sfdgFileSelect.View.Records;
            //    foreach (var record in records)
            //    {
            //        var dataRowView = record.Data as DataRowView;
            //        if (dataRowView != null)
            //        {
            //            // object selected = record.GetValue("CheckBoxColumnName");
            //            var selectedValue = dataRowView.Row["File Name"];
            //            //if (FilePath.Contains(selectedValue.ToString()))
            //            //{
            //                // var selected = dataRowView.Row["checkBoxColumn"] ;
            //                if ((selectedValue) != null)
            //                {
            //                    //if (selected.GetType() != typeof(DBNull) && (bool)selected)
            //                    //{

            //                    string EmailAlert = "EmailAlert";
            //                    connection = new OleDbConnection(conString + selectedValue);
            //                    connection.Open();
            //                    cmd = new OleDbCommand("Select *from AttributeSetting where AttributeName='" + EmailAlert + "' ", connection);
            //                    reader = cmd.ExecuteReader();
            //                    if (reader.Read())
            //                    {
            //                        htmltextfromDatabase = (reader["AttributeValue"].ToString());
            //                    }
            //                    htmltextfromDatabase = htmltextfromDatabase + mailtext;
            //                    // mailText = result;
            //                    htmluiControl1.Text = htmltextfromDatabase;
            //                    connection.Close();
            //                    connection.Dispose();
            //                }
            //          // }
            //        }
            //    }

            //}
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           // this.sfdgFileSelect.SearchController.Search(txtSearch.Text);
        }

        private void sfdgFileSelect_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            //var selectedItem = this.sfdgFileSelect.CurrentItem as DataRowView;
            //var dataRow = (selectedItem as DataRowView).Row;
            //var cellValue = ataRow["File Name"].ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void htmluiControl2_LoadFinished(object sender, EventArgs e)
        {

        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAsPdf_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void txtEmailAlertSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchForEmailAlert_Click(object sender, EventArgs e)
        {
            webBrowser1.Focus();
            SendKeys.Send("^f");

        }
        //FindNext(txtEmailAlertSearch.Text, webBrowser1);
    

        //public bool FindNext(string text, WebBrowser webBrowser1)
        //{

        //    IHTMLDocument2 doc = webBrowser1.Document.DomDocument as IHTMLDocument2;
        //    IHTMLSelectionObject sel = doc.selection;// (IHTMLSelectionObject)doc.selection;
        //    IHTMLTxtRange rng = sel.createRange() as IHTMLTxtRange;

        //    rng.collapse(false); // collapse the current selection so we start from the end of the previous range
        //    if (rng.findText(text, 1000000, 0))
        //    {
        //        rng.select();
        //        return true;
        //    }
        //    else
        //        // FindFirst(text, webBrowser1);
        //        return false;
        //}

        private void btnSaveAsHtml_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
          //  saveFileDialog.Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // If the user selects a file location and clicks OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path from the dialog
                string filePath = saveFileDialog.FileName;

                // Write the HTML string to the file
                System.IO.File.WriteAllText(filePath, htmltextfromDatabase);
            }
           // System.Diagnostics.Process.Start("notepad.exe", htmltextfromDatabase);
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            dtFillDatagridWithFiles.Clear();
            sfdgFileSelect.Refresh();
        }
    }
}

#endregion
#endregion