namespace WFAFakePopupShit
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            dgvTasks = new DataGridView();
            clmTask = new DataGridViewTextBoxColumn();
            clmSheck = new DataGridViewCheckBoxColumn();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // dgvTasks
            // 
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AllowUserToDeleteRows = false;
            dgvTasks.AllowUserToResizeColumns = false;
            dgvTasks.AllowUserToResizeRows = false;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Columns.AddRange(new DataGridViewColumn[] { clmTask, clmSheck });
            dgvTasks.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTasks.Location = new Point(13, 64);
            dgvTasks.Margin = new Padding(4);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.Size = new Size(460, 305);
            dgvTasks.TabIndex = 0;
            // 
            // clmTask
            // 
            clmTask.FillWeight = 5F;
            clmTask.HeaderText = "Task";
            clmTask.Name = "clmTask";
            // 
            // clmSheck
            // 
            clmSheck.FillWeight = 1F;
            clmSheck.HeaderText = "CHB";
            clmSheck.Name = "clmSheck";
            // 
            // timer
            // 
            timer.Interval = 300;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 431);
            Controls.Add(dgvTasks);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "\"PopUp\" test shit";
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTasks;
        private DataGridViewTextBoxColumn clmTask;
        private DataGridViewCheckBoxColumn clmSheck;
        private System.Windows.Forms.Timer timer;
    }
}
