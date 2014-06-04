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
    public partial class FrmInputView : Form
    {
        int row = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5;
        int col1Cnt = 7;
        LottoryControl lc;
        Staff sf;
        public FrmInputView(String sfCode)
        {
            InitializeComponent();
            initConfig(sfCode);
        }
        private void initConfig(String sfCode)
        {
            String monthId = "", periodId = "";
            lc = new LottoryControl();
            sf = lc.sfdb.selectByCode(sfCode);
            //lc.sfdb.sf = sf;
            monthId = System.DateTime.Now.Month.ToString("00");
            if ((System.DateTime.Now.Day >= 2) && (System.DateTime.Now.Day <= 17))
            {
                cboPeriod.SelectedValue = "02";
            }
            else
            {
                cboPeriod.SelectedValue = "01";
            }
            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboSale = lc.saledb.getCboSale(cboSale);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            ComboBoxItem cbo = new ComboBoxItem();
            cbo.Value = sf.Id;
            cbo.Text = sf.Name;
            cboStaff.Text = sf.Name; 
        }
        private void setGrid1()
        {
            dgv1.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgv1.ColumnCount = col1Cnt;
            dgv1.RowCount = 1;
            row = 0;
            dgv1.Columns[colNumber].Width = 80;
            dgv1.Columns[colUp].Width = 80;
            dgv1.Columns[colTod].Width = 80;
            dgv1.Columns[colDown].Width = 80;
            dgv1.Columns[colRemark].Width = 60;
            dgv1.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv1.Columns[colUp].HeaderText = "บน";
            dgv1.Columns[colTod].HeaderText = "โต๊ด";
            dgv1.Columns[colDown].HeaderText = "ล่าง";
            dgv1.Columns[colRowId].Visible = false;
            dgv1.Columns[colLottoId1].Visible = false;
            dgv1.Columns[colRemark].Visible = false;
            dgv1.Font = font;

        }
        private void setDataGrid1(String number, String numUp, String numTod, String numDown, String rowId, String lottoId)
        {
            //if (dgv1.Enabled == false)
            //{
            //    return;
            //}
            //dgv1.Rows.Insert(0, 1);
            //dgv1[col1Number, 0].Value = number;
            //dgv1[col1Up, 0].Value = numUp;
            //dgv1[col1Down, 0].Value = numDown;
            dgv1.Rows.Insert(dgv1.RowCount - 1, 1);
            //int r = 0;
            //r = row;
            dgv1[colNumber, row].Value = number;
            dgv1[colUp, row].Value = numUp;
            dgv1[colTod, row].Value = numTod;
            dgv1[colDown, row].Value = numDown;
            dgv1[colRowId, row].Value = rowId;
            dgv1[colLottoId1, row].Value = lottoId;

            row++;

            //dgv1.RowCount = dgv1.RowCount + 1;


            //DataRow dr = new DataRow();
            //dr[col1Number].Value = "";
        }
        private void setGrd1()
        {
            DataTable dt = lc.lotdb.selectByStaff(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), lc.cf.getValueCboItem(cboStaff));
            setGrid1();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrid1(dt.Rows[i][lc.lotdb.lot.number].ToString(), dt.Rows[i][lc.lotdb.lot.up].ToString(),
                        dt.Rows[i][lc.lotdb.lot.tod].ToString(), dt.Rows[i][lc.lotdb.lot.down].ToString(),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString());
                }
            }
            //dgv1.Enabled = false;
        }

        private void FrmInputView_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            setGrd1();
        }
    }
}
