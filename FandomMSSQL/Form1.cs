using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FandomMSSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNames_Click(object sender, EventArgs e)
        {
            StringBuilder tmp = new StringBuilder();
            List<string> _lstNames = LinqToSqlClass.GetNames();

            // Используем StringBuilder для эффективной конкатенации
            foreach (var item in _lstNames)
            {
                tmp.AppendLine(item);
            }

            MessageBox.Show(tmp.ToString());

            // Для корректного отображения списка в DataGridView
            DataTable table = new DataTable();
            table.Columns.Add("Names", typeof(string));

            foreach (var name in _lstNames)
            {
                table.Rows.Add(name);
            }

            dgvTable.DataSource = table;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var _lstNames = LinqToSqlClass.GetNames(tbSearch.Text);
            dgvTable.DataSource = ConvertMetods.ListOfString2DataSet(_lstNames);            
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (LinqToSqlClass.ReplaceName(tbFind.Text, tbReplace.Text))
            {
                var _lstNames = LinqToSqlClass.GetNames(tbSearch.Text);
                dgvTable.DataSource = ConvertMetods.ListOfString2DataSet(_lstNames);
            }
        }
    }
}
