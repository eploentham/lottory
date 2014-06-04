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
    public partial class FrmThooDefault : Form
    {
        LottoryControl lc;
        Thoo tho;
        Staff sf;
        public FrmThooDefault(String sfCode)
        {
            InitializeComponent();
            initConfig(sfCode);
        }
        private void initConfig(String sfCode)
        {
            lc = new LottoryControl();
            tho = lc.thodb.selectByDefault();
            sf = lc.sfdb.selectByCode(sfCode);
            cboThoo = lc.thodb.getCboThooAll(cboThoo);
            //ComboBoxItem cbo = new ComboBoxItem();
            //cbo.Value = tho.Id;
            //cbo.Text = tho.Name;
            cboThoo.Text = tho.Name;
        }

        private void FrmThooDefault_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboThoo.Text.Equals(""))
            {
                MessageBox.Show("ไม่ได้เลือกรายการ", "ป้อนข้อมูลไม่ครบ");
                return;
            }
            if (lc.thodb.UpdateThooDefault(lc.cf.getValueCboItem(cboThoo), sf.Id).Length == 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
