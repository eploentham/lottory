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
    public partial class FrmStaffView : Form
    {
        LottoryControl lc;
        DataTable dt;
        int colCnt = 7;
        int colRow = 0, colName = 2, colRemark = 3, colId=4, colCode=1, colPassword=6, colPriority=5;
        
        public FrmStaffView()
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
            dt = lc.selectStaffAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colName].Width = 150;
            dgvView.Columns[colRemark].Width = 120;
            dgvView.Columns[colId].Width = 80;
            dgvView.Columns[colPassword].Width = 80;
            dgvView.Columns[colPriority].Width = 180;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colCode].HeaderText = "code";
            dgvView.Columns[colName].HeaderText = "ชื่อ";
            dgvView.Columns[colRemark].HeaderText = "หมายเหตุ";
            dgvView.Columns[colId].HeaderText = "id";
            dgvView.Columns[colPriority].HeaderText = "สิทธิใช้งาน";
            dgvView.Columns[colPassword].HeaderText = "  ";

            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colCode, i].Value = dt.Rows[i][lc.sfdb.sf.Code].ToString();
                    dgvView[colName, i].Value = dt.Rows[i][lc.sfdb.sf.Name].ToString();
                    dgvView[colRemark, i].Value = dt.Rows[i][lc.sfdb.sf.Remark].ToString();
                    dgvView[colId, i].Value = dt.Rows[i][lc.sfdb.sf.Id].ToString();
                    if (dt.Rows[i][lc.sfdb.sf.Priority].ToString().Equals("1"))
                    {
                        dgvView[colPriority, i].Value = "ป้อนรางวัลอย่างเดียว";
                    }
                    else if (dt.Rows[i][lc.sfdb.sf.Priority].ToString().Equals("2"))
                    {
                        dgvView[colPriority, i].Value = "ตรวจสอบข้อมูลอย่างเดียว";
                    }
                    else if (dt.Rows[i][lc.sfdb.sf.Priority].ToString().Equals("3"))
                    {
                        dgvView[colPriority, i].Value = "ทุกหน้าจอ";
                    }
                    dgvView[colPassword, i].Value = "รหัสผ่าน";
                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void FrmStaffView_Load(object sender, EventArgs e)
        {

        }

        private void btnSfAdd_Click(object sender, EventArgs e)
        {
            FrmStaffAdd frm = new FrmStaffAdd("");
            //frm.setControl("");
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
            if (e.ColumnIndex == colPassword)
            {
                FrmPassword frm = new FrmPassword(dgvView[colId, e.RowIndex].Value.ToString());
                frm.ShowDialog(this);
            }
            else
            {
                FrmStaffAdd frm = new FrmStaffAdd(dgvView[colId, e.RowIndex].Value.ToString());
                //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
                frm.ShowDialog(this);
                setControl();
            }
        }
    }
}
