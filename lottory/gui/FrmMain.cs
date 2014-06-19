using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmMain : Form
    {
        LottoryControl lc;
        Form frm;
        Staff sf;

        public FrmMain(Form f, String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(f, sfCode,l);
        }
        private void initConfig(Form f, String sfCode, LottoryControl l)
        {
            //lc = new LottoryControl();
            lc = l;
            frm = f;
            sf = lc.sfdb.selectByCode(sfCode);
            tvMain();
        }
        private void showFrame(Form f)
        {
            this.Hide();
            f.ShowDialog(this);
            this.Show();
        }
        private void tvMain()
        {
            tv1.Nodes.Clear();
            if (sf.Priority.Equals("1") || sf.Priority.Equals("3"))
            {
                tv1.Nodes.Add("nInputAdd", "ป้อนข้อมูล");
                tv1.Nodes.Add("nInputImage", "ป้อนข้อมูลจากรูป");
                tv1.Nodes.Add("nInputView", "ดูข้อมูลเก่า");
                tv1.Nodes.Add("nRewardAdd", "ป้อนรางวัล");
            }
            if (sf.Priority.Equals("2") || sf.Priority.Equals("3"))
            {
                tv1.Nodes.Add("nLottoImage", "นำรูปเข้าระบบ");
                tv1.Nodes.Add("nLottoApprove", "ยืนยันตัวเลข");
                tv1.Nodes.Add("nLottoResult", "ตรวจรางวัลประจำงวด");
                tv1.Nodes.Add("nLottoSummary", "สรุปข้อมูลประจำงวด");
            }
            if (sf.Priority.Equals("3"))
            {
                tv1.Nodes.Add("nInitConfig", "กำหนดค่าโปรแกรม");
                tv1.Nodes["nInitConfig"].Nodes.Add("nThooView", "สร้างเจ้ามือ");
                tv1.Nodes["nInitConfig"].Nodes.Add("nSaleView", "สร้างคนเก็บโพย");
                //tv1.Nodes["nInitConfig"].Nodes.Add("nSaleDiscount", "สร้างส่วนลดคนเก็บโพย");
                tv1.Nodes["nInitConfig"].Nodes.Add("nStaffView", "สร้างคนป้อนข้อมูล");
                tv1.Nodes["nInitConfig"].Nodes.Add("nRateView", "สร้างอัตรา");
                tv1.Nodes["nInitConfig"].Nodes.Add("nPassword", "เปลี่ยนรหัสผ่าน");
                tv1.Nodes["nInitConfig"].Nodes.Add("nThooDefault", "กำหนดเจ้ามือ (เจ้าของโปรแกรม)");
                tv1.Nodes["nInitConfig"].Nodes.Add("nInitConfig1", "กำหนดค่าโปรแกรม");
            }
            
            tv1.ExpandAll();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Last Update " + System.IO.File.GetLastWriteTime(System.Environment.CurrentDirectory + "\\" + Process.GetCurrentProcess().ProcessName + ".exe");
        }

        private void tv1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name.ToString() == "nThooView")
            {
                FrmThooView frm = new FrmThooView();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nStaffView")
            {
                FrmStaffView frm = new FrmStaffView();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nSaleView")
            {
                FrmSaleView frm = new FrmSaleView();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nRateView")
            {
                FrmRateView frm = new FrmRateView();
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nPassword")
            {
                FrmPassword frm = new FrmPassword(sf.Id);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nInputView")
            {
                FrmInputView frm = new FrmInputView(sf.Code);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nInputAdd")
            {
                FrmInputAdd frm = new FrmInputAdd(sf.Code, lc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nRewardAdd")
            {
                FrmRewardAdd frm = new FrmRewardAdd(sf.Code);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nLottoResult")
            {
                FrmLottoResult frm = new FrmLottoResult(sf.Code, lc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nLottoApprove")
            {
                FrmLottoApprove frm = new FrmLottoApprove(sf.Code,lc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nLottoSummary")
            {
                FrmLottoSummary frm = new FrmLottoSummary(sf.Code, lc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nThooDefault")
            {
                FrmThooDefault frm = new FrmThooDefault(sf.Code);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nInitConfig1")
            {
                FrmInitConfig frm = new FrmInitConfig(sf.Code, lc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nInputImage")
            {
                FrmInputImage frm = new FrmInputImage(sf.Code, lc);
                showFrame(frm);
            }
            else if (e.Node.Name.ToString() == "nLottoImage")
            {
                FrmLottoImage frm = new FrmLottoImage(sf.Code, lc);
                showFrame(frm);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frm != null)
            {
                frm.Show();
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            //frm.Show();
        }
    }
}
