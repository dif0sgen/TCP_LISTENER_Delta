using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_LISTENER_Delta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hOPETableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hOPETableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hOPEDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hOPEDataSet.HOPETable' table. You can move, or remove it, as needed.
            this.hOPETableTableAdapter.Fill(this.hOPEDataSet.HOPETable);

        }
    }
}
