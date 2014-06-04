using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmLottoThooPrint : Form
    {
        LottoryControl lc;
        Staff sf;
        Thoo thoTranfer, thoD;
        int row = 0;
        int page = 0,j = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5;
        int col1Cnt = 7;

        int colLottoNumber = 0, colLottoUp = 1, colLottoTod = 2, colLottoDown = 3, colLottoRemark = 4, colLottoId = 5, colLPrint=6;
        int colLottoCnt = 7, pageN=0, cntNum=0, cntPage=0;

        String prn = "", prnPage="", prnNum="";
        DataTable dtPrn = new DataTable();
        DataTable dt = new DataTable();
        public FrmLottoThooPrint(String sfCode, String thooTranferId)
        {
            InitializeComponent();
            initConfig(sfCode, thooTranferId);
        }
        private void initConfig(String sfCode, String thooTranferId)
        {
            ComboBoxItem cbo = new ComboBoxItem();
            
            String monthId = "";
            lc = new LottoryControl();
            sf = lc.sfdb.selectByCode(sfCode);
            thoD = lc.thodb.selectByDefault();
            thoTranfer = lc.thodb.selectByPk(thooTranferId);
            cbo.Value = thoTranfer.Id;
            cbo.Text = thoTranfer.Name;
            cboThoo = lc.thodb.getCboThoo(cboThoo);
            cboThoo.SelectedItem = cboThoo;
            cboThoo.Text = thoTranfer.Name;
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
            //cboStaff = lc.sfdb.getCboStaff(cboStaff);

            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            setHGrdLotto();
            setDGrdLotto();
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
            dgv1.Columns[colLottoRemark].Visible = false;

            dgv1.Font = font;

        }
        private void setHGrdLotto()
        {
            dgvLotto.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            dgvLotto.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvLotto.ColumnCount = colLottoCnt;
            //dgvLotto.RowCount = row;
            //row = 0;
            dgvLotto.Columns[colLottoNumber].Width = 150;
            dgvLotto.Columns[colLottoTod].Width = 100;
            dgvLotto.Columns[colLottoUp].Width = 80;
            dgvLotto.Columns[colLottoDown].Width = 80;
            dgvLotto.Columns[colLottoRemark].Width = 60;
            dgvLotto.Columns[colLPrint].Width = 80;
            dgvLotto.Columns[colLottoNumber].HeaderText = "LOT";
            dgvLotto.Columns[colLottoUp].HeaderText = "รวมบน";
            dgvLotto.Columns[colLottoTod].HeaderText = "รวมโต๊ด";
            dgvLotto.Columns[colLottoDown].HeaderText = "รวมล่าง";
            dgvLotto.Columns[colLPrint].HeaderText = " ... ";

            dgvLotto.Columns[colLottoRemark].Visible = false;
            dgvLotto.Columns[colLottoId].Visible = false;
            dgvLotto.Columns[colLottoNumber].Visible = false;

            dgvLotto.Font = font;
        }
        private void setDGrdLotto()
        {
            ComboBoxItem iThoo = (ComboBoxItem)cboThoo.SelectedItem;
            DataTable dt = new DataTable();
            //dt = lc.lotdb.selectDistinctByThooTranfer(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), iThoo.Value);
            //if (dt.Rows.Count > 0)
            //{
            //    dgvLotto.RowCount = dt.Rows.Count;
            //    //setGridLotto(dt.Rows.Count);
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        dgvLotto[colLottoUp, i].Value = dt.Rows[i]["up11"].ToString();
            //        dgvLotto[colLottoDown, i].Value = dt.Rows[i]["down11"].ToString();
            //        dgvLotto[colLottoTod, i].Value = dt.Rows[i]["tod1"].ToString();
            //        dgvLotto[colLottoId, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
            //        dgvLotto[colLottoNumber, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
            //        dgvLotto[colLPrint, i].Value = " พิมพ์ ";
            //        if ((i % 2) != 0)
            //        {
            //            dgvLotto.Rows[i].DefaultCellStyle.BackColor = Color.Cornsilk;
            //        }
            //    }
            //}
            dt = lc.lotdb.selectByThooTranfer(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), iThoo.Value);
            if (dt.Rows.Count > 0)
            {
                dgvLotto.RowCount = dt.Rows.Count;
                //setGridLotto(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvLotto[colLottoUp, i].Value = dt.Rows[i][lc.lotdb.lot.up].ToString();
                    dgvLotto[colLottoDown, i].Value = dt.Rows[i][lc.lotdb.lot.down].ToString();
                    dgvLotto[colLottoTod, i].Value = dt.Rows[i][lc.lotdb.lot.tod].ToString();
                    dgvLotto[colLottoId, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
                    dgvLotto[colLottoNumber, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
                    dgvLotto[colLPrint, i].Value = " ";
                    if ((i % 2) != 0)
                    {
                        dgvLotto.Rows[i].DefaultCellStyle.BackColor = Color.Cornsilk;
                    }
                }
            }
        }
        private void setGrid1(String lotoId)
        {
            DataTable dt = lc.lotdb.selectByLot(lotoId);
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
            dgv1.Enabled = false;
        }
        private void setDataGrid1(String number, String numUp, String numTod, String numDown, String rowId, String lottoId)
        {
            dgv1.Rows.Insert(dgv1.RowCount - 1, 1);

            dgv1[colNumber, row].Value = number;
            dgv1[colUp, row].Value = numUp;
            dgv1[colTod, row].Value = numTod;
            dgv1[colDown, row].Value = numDown;
            dgv1[colRowId, row].Value = rowId;
            dgv1[colLottoId1, row].Value = lottoId;

            row++;
        }
        private void setGrdColor()
        {
            for (int i = 0; i < dgv1.RowCount - 1; i++)
            {
                if ((i % 2) != 0)
                {
                    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                }
            }
        }
        private void printLotto(String yearId, String monthId, String periodId, String thooId)
        {
            prn = "";
            //lottoId = dgv1[colLottoId1, row].Value.ToString();
            //DataTable dt = new DataTable();
            //dt = lc.lotdb.selectByLot(lottoId);
            dt = lc.lotdb.selectByThooTranfer(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), thooId);
            dtPrn = dt.Clone();
            if (dt.Rows.Count < 10)
            {
                pageN = 1;
                cntPage = 1;
                prnPage = " (หน้าที่ "+pageN+" ถึง "+ cntPage+")";
                prnNum = "รวมทั้งหมด " + dt.Rows.Count + " รายการ จำนวนหน้าทั้งหมด " + cntPage + prnPage;
                dtPrn = dt;
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }
            else
            {
                pageN++;
                int row = 0, aa=0, lineperPage=10;
                page = dt.Rows.Count % lineperPage;
                //page = dt.Rows.Count / 7;
                aa = dt.Rows.Count % lineperPage;
                if (page < 0)
                {
                    cntPage = page;
                }
                else
                {
                    cntPage = page + 1;
                }
                
                for (int i = 0; i < page; i++)
                {
                    prnPage = " (หน้าที่ " + pageN + " ถึง " + cntPage+")";
                    prnNum = "รวมทั้งหมด " + dt.Rows.Count + " รายการ จำนวนหน้าทั้งหมด " + cntPage + prnPage;
                    dtPrn.Clear();                    
                    for (int k = 0; k < dtPrn.Rows.Count; k++)
                    {
                        dtPrn.Rows.RemoveAt(k);
                    }
                    //dtPrn.Rows.Count = 10;
                    for (int j = 0; j < lineperPage; j++)
                    {
                        if (dt.Rows[row] != null)
                        {
                            DataRow drow = dt.Rows[row];
                            dtPrn.ImportRow(drow);
                        }
                        row++;
                    }
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    pd.Print();
                }
                System.Threading.Thread.Sleep(500);
                if (aa > 0)
                {
                    prnPage = "(หน้าที่ " + pageN + " ถึง " + cntPage+")";
                    prnNum = "รวมทั้งหมด " + dt.Rows.Count + " รายการ จำนวนหน้าทั้งหมด " + cntPage + prnPage;
                    dtPrn.Clear();
                    for (int j = 0; j < aa; j++)
                    {
                        if (dt.Rows[row] != null)
                        {
                            DataRow drow = dt.Rows[row];
                            dtPrn.ImportRow(drow);
                        }
                        row++;
                    }
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    pd.Print();
                }
            }

        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 8.5 x 11 paper:
            float linesPerPage = 0;
            float fontPerPage = 0;
            float fontPerPage1 = 0;
            float x0 = 25;
            float xEnd = 850 - x0;

            float y0 = 25;
            float yEnd = 1100 * 2 - y0; // bottom of 2ed page

            int page = dtPrn.Rows.Count % 7;
            int  page1 = page ;
            float gapCol = 0, fixCol=10, alignX=0, len=0;
            
            String doc = "", header1 = "", header2 = "", header3 = "", header = "", num="", up="", tod="", down="";
            header1 = "33333                       วันที่พิมพ์  " + lc.lotdb.selectDateDBtoShow() +" ";
            header2 = "ใบส่งต่อ                      จากเจ้ามือ " + thoD.Name + "  ถึงเจ้ามือ " + cboThoo.Text;
            header3 = "ประจำงวด                    ปี " + cboYear.Text + " เดือน " + cboMonth.Text + "     " + cboPeriod.Text;
            header = "ตัวเลข     บน      โต๊ด     ล่าง     ";
            doc = header1 + Environment.NewLine;
            doc += header2 + Environment.NewLine;
            doc += header3 + Environment.NewLine;
            Single yPos = 0;
            Single leftMargin = e.MarginBounds.Left + 100;
            Single topMargin = e.MarginBounds.Top + 100;
            Image img = Image.FromFile("images.jpg");
            Rectangle logo = new Rectangle(40, 40, 50, 50);
          
            using (Font printFont = new Font("Arial", 12.0f))
            {
                // Calculate the number of lines per page.
                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                fontPerPage = e.MarginBounds.Width / printFont.SizeInPoints;
                gapCol = fixCol * printFont.SizeInPoints;
                e.Graphics.DrawImage(img, logo);

                e.Graphics.DrawString(header1, printFont, Brushes.Black, leftMargin + 20, yPos + 30, new StringFormat());
                e.Graphics.DrawString(header2, printFont, Brushes.Black, leftMargin + 20, yPos + 60, new StringFormat());
                e.Graphics.DrawString(header3, printFont, Brushes.Black, leftMargin + 20, yPos + 90, new StringFormat());

                //e.Graphics.DrawString(header, printFont, Brushes.Black, leftMargin - 50, yPos + 150, new StringFormat());
                alignX = lc.alignR(gapCol, fixCol, 5, printFont.SizeInPoints);
                e.Graphics.DrawString("ตัวเลข", printFont, Brushes.Black, (leftMargin - 25), yPos + 150, new StringFormat());
                alignX = lc.alignR(gapCol, fixCol, 2, printFont.SizeInPoints);
                e.Graphics.DrawString("บน", printFont, Brushes.Black, ((leftMargin - 50) + alignX), yPos + 150, new StringFormat());
                alignX = lc.alignR(gapCol*2, fixCol, 3, printFont.SizeInPoints);
                e.Graphics.DrawString("โต๊ด", printFont, Brushes.Black, ((leftMargin - 50) + alignX), yPos + 150, new StringFormat());
                alignX = lc.alignR(gapCol*3, fixCol, 3, printFont.SizeInPoints);
                e.Graphics.DrawString("ล่าง", printFont, Brushes.Black, ((leftMargin - 50) + alignX), yPos + 150, new StringFormat());
                if (dtPrn.Rows.Count > 0)
                {
                    int gap = 150, i=0;
                    for (i = 0; i < dtPrn.Rows.Count; i++)
                    {
                        gap += 30;
                        num = dtPrn.Rows[i][lc.lotdb.lot.number].ToString();
                        e.Graphics.DrawString(num, printFont, Brushes.Black, (leftMargin - 25), yPos + gap, new StringFormat());
                        //num = lc.alignPrint(num, 10);
                        //e.Graphics.DrawString(num, printFont, Brushes.Black, ((leftMargin - 25) + (gapCol + ((fixCol - num.Length) * printFont.SizeInPoints))), yPos + gap, new StringFormat());
                        up = dtPrn.Rows[i][lc.lotdb.lot.up].ToString();

                        alignX = lc.alignR(gapCol, fixCol, up.Length, printFont.SizeInPoints);
                        e.Graphics.DrawString(up, printFont, Brushes.Black, ((leftMargin - 25) + alignX), yPos + gap, new StringFormat());

                        tod = dtPrn.Rows[i][lc.lotdb.lot.tod].ToString();
                        //alignX = ((gapCol * 2) + (fixCol - tod.Length) * printFont.SizeInPoints);
                        alignX = lc.alignR(gapCol*2, fixCol, tod.Length, printFont.SizeInPoints);
                        e.Graphics.DrawString(tod, printFont, Brushes.Black, ((leftMargin - 25) + alignX), yPos + gap, new StringFormat());

                        down = dtPrn.Rows[i][lc.lotdb.lot.down].ToString();
                        //alignX = ((gapCol * 3) + (fixCol - down.Length) * printFont.SizeInPoints);
                        alignX = lc.alignR(gapCol*3, fixCol, down.Length, printFont.SizeInPoints);
                        e.Graphics.DrawString(down, printFont, Brushes.Black, ((leftMargin - 25) + alignX), yPos + gap, new StringFormat());
                    }
                    e.Graphics.DrawString(prnNum, printFont, Brushes.Black, (leftMargin + 20), yPos + gap+30, new StringFormat());
                }

            }
        }

        private void FrmLottoThooPrint_Load(object sender, EventArgs e)
        {

        }

        private void dgvLotto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            setGrid1(dgvLotto[colLottoId, e.RowIndex].Value.ToString());
            setGrdColor();
        }

        private void dgvLotto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == colLPrint)
            //{
            //    String lottoId = "";
            //    lottoId = dgvLotto[colLottoId, e.RowIndex].Value.ToString();
            //    printLotto(lottoId);
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String lottoId = "";
            //for (int i = 0; i < dgvLotto.RowCount; i++)
            //{
            //    lottoId = dgvLotto[colLottoId, i].Value.ToString();
            printLotto(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), thoTranfer.Id);
            //    System.Threading.Thread.Sleep(1000);
            //}
        }
    }
}

