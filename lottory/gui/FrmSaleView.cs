using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmSaleView : Form
    {
        LottoryControl lc;
        DataTable dt;
        int colCnt = 5;
        int colRow = 0, colName = 2, colRemark = 3, colId = 4, colCode = 1;
        
        public FrmSaleView()
        {
            InitializeComponent();
            initConfig();
            setControl();
        }
        private void initConfig()
        {
            lc = new LottoryControl();
            //dt = lc.selectStaffAll();

        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;

            groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        public void setControl()
        {
            DataTable dt = new DataTable();
            dt = lc.selectSaleAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colName].Width = 150;
            dgvView.Columns[colRemark].Width = 120;
            dgvView.Columns[colId].Width = 80;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colCode].HeaderText = "code";
            dgvView.Columns[colName].HeaderText = "ชื่อ";
            dgvView.Columns[colRemark].HeaderText = "หมายเหตุ";
            dgvView.Columns[colId].HeaderText = "id";

            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colCode, i].Value = dt.Rows[i][lc.saledb.sale.Code].ToString();
                    dgvView[colName, i].Value = dt.Rows[i][lc.saledb.sale.Name].ToString();
                    dgvView[colRemark, i].Value = dt.Rows[i][lc.saledb.sale.Remark].ToString();
                    dgvView[colId, i].Value = dt.Rows[i][lc.saledb.sale.Id].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }

        private void btnSaleAdd_Click(object sender, EventArgs e)
        {
            FrmSaleAdd frm = new FrmSaleAdd("");
            frm.setControl("");
            frm.ShowDialog(this);
            setControl();
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgvView[colId, e.RowIndex].Value == null)
            {
                return;
            }
            FrmSaleAdd frm = new FrmSaleAdd(dgvView[colId, e.RowIndex].Value.ToString());
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setControl();
        }

        private void FrmSaleView_Load(object sender, EventArgs e)
        {

        }

    }
}
