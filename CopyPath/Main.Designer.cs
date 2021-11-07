
namespace CopyPath
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.copyBtn = new System.Windows.Forms.Button();
            this.browseBtnFrom = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.moveBtn = new System.Windows.Forms.Button();
            this.fromColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(872, 339);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(103, 38);
            this.copyBtn.TabIndex = 5;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // browseBtnFrom
            // 
            this.browseBtnFrom.Location = new System.Drawing.Point(186, 338);
            this.browseBtnFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseBtnFrom.Name = "browseBtnFrom";
            this.browseBtnFrom.Size = new System.Drawing.Size(82, 38);
            this.browseBtnFrom.TabIndex = 7;
            this.browseBtnFrom.Text = "Browse";
            this.browseBtnFrom.UseVisualStyleBackColor = true;
            this.browseBtnFrom.Click += new System.EventHandler(this.browseBtnFrom_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(10, 339);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(82, 37);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(98, 339);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(82, 37);
            this.loadBtn.TabIndex = 19;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fromColumn,
            this.toPath,
            this.extensionsColumn});
            this.dataGridView1.Location = new System.Drawing.Point(10, 9);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(965, 326);
            this.dataGridView1.TabIndex = 20;
            // 
            // moveBtn
            // 
            this.moveBtn.Location = new System.Drawing.Point(764, 339);
            this.moveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(103, 38);
            this.moveBtn.TabIndex = 21;
            this.moveBtn.Text = "Move";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // fromColumn
            // 
            this.fromColumn.HeaderText = "From Path";
            this.fromColumn.MinimumWidth = 6;
            this.fromColumn.Name = "fromColumn";
            // 
            // toPath
            // 
            this.toPath.HeaderText = "To Path";
            this.toPath.MinimumWidth = 6;
            this.toPath.Name = "toPath";
            // 
            // extensionsColumn
            // 
            this.extensionsColumn.HeaderText = "Extension list";
            this.extensionsColumn.MinimumWidth = 6;
            this.extensionsColumn.Name = "extensionsColumn";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 385);
            this.Controls.Add(this.moveBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.browseBtnFrom);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button browseBtnFrom;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionsColumn;
    }
}

