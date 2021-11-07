using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyPath
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            var rows = this.dataGridView1.SelectedRows;

            if (rows != null && rows.Count > 0)
            {
                this.dataGridView1.Rows.Remove(rows[0]);
            }
        }

        private void browseBtnFrom_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
                {
                    cell.Value = folderDlg.SelectedPath;
                }
            }
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (var file in GetFiles(row))
                {
                    File.Copy(file.FullName, Path.Combine(row.Cells[1].Value?.ToString(), file.Name));
                }
            }
        }

        private IEnumerable<FileInfo> GetFiles(DataGridViewRow row)
        {
            var sourcePath = row.Cells[0].Value?.ToString();
            var targetPath = row.Cells[1].Value?.ToString();
            var extensionsString = row.Cells[2].Value?.ToString().Trim();
            var extensionsArray = String.IsNullOrEmpty(extensionsString) 
                                 ? null
                                 : extensionsString.Split(';');

            return (!Directory.Exists(sourcePath) || !Directory.Exists(targetPath))
                  ? new FileInfo[0] 
                  : new DirectoryInfo(sourcePath).GetFilesByExtensions(extensionsArray);
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (var file in GetFiles(row))
                {
                    File.Move(file.FullName, Path.Combine(row.Cells[1].Value.ToString(), file.Name));
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            StringBuilder columnNames = new StringBuilder();
                            StringBuilder rowNames = new StringBuilder();
                            string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames.Append(dataGridView1.Columns[i].HeaderText.ToString());

                                if (i != (columnCount-1))
                                    columnNames.Append(',');
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    var rowValue = dataGridView1.Rows[i - 1].Cells[j].Value?.ToString();
                                    rowNames.Append(rowValue);

                                    if (j != (columnCount - 1))
                                        rowNames.Append(',');
                                }
                                outputCsv[i] += rowNames;
                                rowNames.Clear();
                            }
                            
                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadCSVOnDataGridView(openFileDialog1.FileName);
            }
        }

        private void LoadCSVOnDataGridView(string fileName)
        {
            try
            {
                ReadCSV csv = new ReadCSV(fileName);

                try
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = csv.readCSV;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
