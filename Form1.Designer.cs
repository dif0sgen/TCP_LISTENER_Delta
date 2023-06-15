namespace TCP_LISTENER_Delta
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label cameraLabel;
            System.Windows.Forms.Label timeLabel;
            this.hOPEDataSet = new TCP_LISTENER_Delta.HOPEDataSet();
            this.hOPETableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hOPETableTableAdapter = new TCP_LISTENER_Delta.HOPEDataSetTableAdapters.HOPETableTableAdapter();
            this.tableAdapterManager = new TCP_LISTENER_Delta.HOPEDataSetTableAdapters.TableAdapterManager();
            this.hOPETableBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hOPETableBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.hOPETableDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.cameraTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            idLabel = new System.Windows.Forms.Label();
            cameraLabel = new System.Windows.Forms.Label();
            timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hOPEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOPETableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOPETableBindingNavigator)).BeginInit();
            this.hOPETableBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hOPETableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // hOPEDataSet
            // 
            this.hOPEDataSet.DataSetName = "HOPEDataSet";
            this.hOPEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hOPETableBindingSource
            // 
            this.hOPETableBindingSource.DataMember = "HOPETable";
            this.hOPETableBindingSource.DataSource = this.hOPEDataSet;
            // 
            // hOPETableTableAdapter
            // 
            this.hOPETableTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.HOPETableTableAdapter = this.hOPETableTableAdapter;
            this.tableAdapterManager.UpdateOrder = TCP_LISTENER_Delta.HOPEDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // hOPETableBindingNavigator
            // 
            this.hOPETableBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.hOPETableBindingNavigator.BindingSource = this.hOPETableBindingSource;
            this.hOPETableBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.hOPETableBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.hOPETableBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.hOPETableBindingNavigatorSaveItem});
            this.hOPETableBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.hOPETableBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.hOPETableBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.hOPETableBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.hOPETableBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.hOPETableBindingNavigator.Name = "hOPETableBindingNavigator";
            this.hOPETableBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.hOPETableBindingNavigator.Size = new System.Drawing.Size(800, 25);
            this.hOPETableBindingNavigator.TabIndex = 0;
            this.hOPETableBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // hOPETableBindingNavigatorSaveItem
            // 
            this.hOPETableBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.hOPETableBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("hOPETableBindingNavigatorSaveItem.Image")));
            this.hOPETableBindingNavigatorSaveItem.Name = "hOPETableBindingNavigatorSaveItem";
            this.hOPETableBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.hOPETableBindingNavigatorSaveItem.Text = "Save Data";
            this.hOPETableBindingNavigatorSaveItem.Click += new System.EventHandler(this.hOPETableBindingNavigatorSaveItem_Click);
            // 
            // hOPETableDataGridView
            // 
            this.hOPETableDataGridView.AutoGenerateColumns = false;
            this.hOPETableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hOPETableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.hOPETableDataGridView.DataSource = this.hOPETableBindingSource;
            this.hOPETableDataGridView.Location = new System.Drawing.Point(76, 81);
            this.hOPETableDataGridView.Name = "hOPETableDataGridView";
            this.hOPETableDataGridView.Size = new System.Drawing.Size(300, 220);
            this.hOPETableDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Camera";
            this.dataGridViewTextBoxColumn2.HeaderText = "Camera";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn3.HeaderText = "Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(456, 102);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 2;
            idLabel.Text = "Id:";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hOPETableBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(508, 99);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 3;
            // 
            // cameraLabel
            // 
            cameraLabel.AutoSize = true;
            cameraLabel.Location = new System.Drawing.Point(456, 128);
            cameraLabel.Name = "cameraLabel";
            cameraLabel.Size = new System.Drawing.Size(46, 13);
            cameraLabel.TabIndex = 4;
            cameraLabel.Text = "Camera:";
            // 
            // cameraTextBox
            // 
            this.cameraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hOPETableBindingSource, "Camera", true));
            this.cameraTextBox.Location = new System.Drawing.Point(508, 125);
            this.cameraTextBox.Name = "cameraTextBox";
            this.cameraTextBox.Size = new System.Drawing.Size(100, 20);
            this.cameraTextBox.TabIndex = 5;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new System.Drawing.Point(456, 154);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(33, 13);
            timeLabel.TabIndex = 6;
            timeLabel.Text = "Time:";
            // 
            // timeTextBox
            // 
            this.timeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hOPETableBindingSource, "Time", true));
            this.timeTextBox.Location = new System.Drawing.Point(508, 151);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeTextBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(cameraLabel);
            this.Controls.Add(this.cameraTextBox);
            this.Controls.Add(timeLabel);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.hOPETableDataGridView);
            this.Controls.Add(this.hOPETableBindingNavigator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hOPEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOPETableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOPETableBindingNavigator)).EndInit();
            this.hOPETableBindingNavigator.ResumeLayout(false);
            this.hOPETableBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hOPETableDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HOPEDataSet hOPEDataSet;
        private System.Windows.Forms.BindingSource hOPETableBindingSource;
        private HOPEDataSetTableAdapters.HOPETableTableAdapter hOPETableTableAdapter;
        private HOPEDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator hOPETableBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton hOPETableBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView hOPETableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox cameraTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
    }
}