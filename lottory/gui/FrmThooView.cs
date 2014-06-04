using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmThooView : Form
    {
        LottoryControl lc;
        DataTable dt;
        int colCnt = 6;
        int colRow = 0, colName = 2, colRemark = 3, colId = 4, colCode = 1,colLimit=5;
        public FrmThooView()
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
            dt = lc.selectThooAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.MultiSelect = false;

            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colName].Width = 150;
            dgvView.Columns[colRemark].Width = 120;
            dgvView.Columns[colId].Width = 80;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colCode].HeaderText = "code";
            dgvView.Columns[colName].HeaderText = "ชื่อ";
            dgvView.Columns[colRemark].HeaderText = "หมายเหตุ";
            dgvView.Columns[colLimit].HeaderText = "อั้น";
            dgvView.Columns[colId].HeaderText = "id";

            dgvView.Columns[colId].HeaderText = "id";
            Font font = Font;

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dgvView[colRow, i].Value = (i + 1);
                        dgvView[colCode, i].Value = dt.Rows[i][lc.thodb.tho.Code].ToString();
                        dgvView[colName, i].Value = dt.Rows[i][lc.thodb.tho.Name].ToString();
                        dgvView[colRemark, i].Value = dt.Rows[i][lc.thodb.tho.Remark].ToString();
                        dgvView[colId, i].Value = dt.Rows[i][lc.thodb.tho.Id].ToString();
                        dgvView[colLimit, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i][lc.thodb.tho.Limit1]);
                        dgvView.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(lc.getThooBackColor(dt.Rows[i][lc.thodb.tho.Color].ToString()));
                    }
                    catch (Exception ex)
                    {
                    }
                }
                dgvView.Rows[dgvView.RowCount-1].Selected = true;
            }
        }

        private void FrmThooView_Load(object sender, EventArgs e)
        {

        }

        private void btnThooAdd_Click(object sender, EventArgs e)
        {
            FrmThooAdd frm = new FrmThooAdd();
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
            FrmThooAdd frm = new FrmThooAdd();
            frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            try
            {
                dgvView.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(frm.color);
            }
            catch (Exception ex)
            {
            }
            
            setControl();
        }
    }
}
