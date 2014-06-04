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
    public partial class FrmLottoThoo : Form
    {
        LottoryControl lc;
        Staff sf;
        Reward rw;
        Lotto lot;
        public String thooId = "";
        
        public FrmLottoThoo(String sfCode, String rowId, String thooid)
        {
            InitializeComponent();
            thooId = thooid;
            
            initConfig(sfCode, rowId);
            
            
        }
        private void initConfig(String sfCode, String rowId)
        {
            lot = new Lotto();
            lc = new LottoryControl();
            cboThoo = lc.thodb.getCboThoo(cboThoo);
            cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboSale = lc.saledb.getCboSale(cboSale);
            

            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboYear = lc.cf.setCboYear(cboYear);
            setControl(rowId);
        }
        private void setControl(String rowId)
        {
            //ComboBoxItem aa = new ComboBoxItem();
            lot = lc.selectLottobyPk(rowId);

            txtInput.Text = lot.number;
            txtUp.Text = lot.up;
            txtTod.Text = lot.tod;
            txtDown.Text = lot.down;
            txtRowId.Text = lot.rowId;

            txtLotId.Text = lot.lottoId;
            
            cboThoo.SelectedItem = lc.getCboItem(cboThoo, lot.thooId);
            cboStaff.SelectedItem = lc.getCboItem(cboStaff, lot.staffId);
            cboSale.SelectedItem = lc.getCboItem(cboSale, lot.saleId);
            //cboThoo.SelectedValue = lc.getCboItem(cboThoo, lot.thooId);
            cboYear.Text = lot.yearId;
            cboMonth.SelectedValue = lot.monthId;
            cboPeriod.SelectedValue = lot.periodId;
            //rw.dateReward;
        }
        private Lotto getControl()
        {
            lot.rowId = txtRowId.Text;
            lot.lottoId = txtLotId.Text;
            
            lot.up = txtUp.Text;
            lot.tod = txtTod.Text;
            lot.down = txtDown.Text;

            lot.saleId = lc.cf.getValueCboItem(cboSale);
            lot.staffId = lc.cf.getValueCboItem(cboStaff);
            lot.thooId = lc.cf.getValueCboItem(cboThoo);

            return lot;
        }
        private void FrmLottoThoo_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String chk = "";
            chk = saveThooTranfer();
            if (chk.Equals("1"))
            {
                //MessageBox.Show("aaaa", "aaaa");
                this.Dispose();
            }
        }
        private String  saveThooTranfer()
        {
            thooId = lc.cf.getValueCboItem(cboThoo);

            String chk = lc.saveThooTranfer(txtRowId.Text, thooId);
            return chk;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String doc = "", header1="", header2="", header3="";
            header1 = "          33333          ";
            header2 = "          ใบส่งต่อ         ";
            header3 = "          ประจำงวด ปี " + cboYear.Text + " เดือน " + cboMonth.Text + " งวด " + cboPeriod.Text;
            doc = header1+Environment.NewLine;
            doc += header2;
            doc += header3;
            saveThooTranfer();
            thooId = lc.cf.getValueCboItem(cboThoo);
            DataTable dt = new DataTable();
            dt = lc.lotdb.selectByThooTranfer(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(),thooId);
            if (dt.Rows.Count > 0)
            {

            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 8.5 x 11 paper:
            float linesPerPage = 0;
            float x0 = 25;
            float xEnd = 850 - x0;

            float y0 = 25;
            float yEnd = 1100 * 2 - y0; // bottom of 2ed page

            int page = 0;

            String doc = "", header1 = "", header2 = "", header3 = "", header="";
            header1 = "33333";
            header2 = "ใบส่งต่อ";
            header3 = "ประจำงวด ปี " + cboYear.Text + " เดือน " + cboMonth.Text + " งวด " + cboPeriod.Text;
            header = "ตัวเลข     บน      โต๊ด     ล่าง     ";
            doc = header1 + Environment.NewLine;
            doc += header2 + Environment.NewLine;
            doc += header3 + Environment.NewLine;
            Single yPos = 0;
            Single leftMargin = e.MarginBounds.Left+100;
            Single topMargin = e.MarginBounds.Top+100;
            Image img = Image.FromFile("images.jpg");
            Rectangle logo = new Rectangle(40, 40, 50, 50);
            using (Font printFont = new Font("Arial", 12.0f))
            {
                // Calculate the number of lines per page.
                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

                e.Graphics.DrawImage(img, logo);

                e.Graphics.DrawString(header1, printFont, Brushes.Black, leftMargin+50, yPos+30, new StringFormat());
                e.Graphics.DrawString(header2, printFont, Brushes.Black, leftMargin + 50, yPos + 60, new StringFormat());
                e.Graphics.DrawString(header3, printFont, Brushes.Black, leftMargin + 50, yPos + 90, new StringFormat());

                e.Graphics.DrawString(header, printFont, Brushes.Black, leftMargin + 10, yPos + 150, new StringFormat());
                //page++;
                //e.HasMorePages = (page <= 1);

                
                //e.Graphics.DrawString(
                //e.Graphics.dr
            }
        }
    }
}
