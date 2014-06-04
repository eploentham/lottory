using lottory.gui;
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

namespace lottory
{
    public partial class FrmInputAdd1 : Form
    {
        int col1Number = 0, col1Up=1, col1Down=2, col1Remark=3;
        int col1Cnt = 4;

        int col2Number = 0, col2Up=1, col2Down=2, col2Remark=3;
        int col2Cnt = 4;
        
        int col3Number = 0, col3Up = 1, col3Down = 2, col3Remark=3;
        int col3Cnt = 4;

        Config1 cf;

        public FrmInputAdd1()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            cf = new Config1();
            setGrid1();
            setGrid2();
            setGrid3();
            cboMonth = cf.setCboMonth(cboMonth);
            cboPeriod = cf.setCboPeriod(cboPeriod);
        }
        private void ExitApplication()
        {
            Application.Exit();
        }
        private void setGrid1()
        {
            Font font = new Font("Microsoft Sans Serif", 10);
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dgv1.ColumnCount = col1Cnt;
            dgv1.RowCount = 1;
            dgv1.Columns[col1Number].Width = 80;
            dgv1.Columns[col1Up].Width = 60;
            dgv1.Columns[col1Down].Width=60;
            dgv1.Columns[col1Remark].Width = 60;
            dgv1.Columns[col1Number].HeaderText = "ตัวเลข";
            dgv1.Columns[col1Up].HeaderText = "บน";
            dgv1.Columns[col1Down].HeaderText = "ล่าง";

            dgv1.Font=font;
            //dgv1[col1Number, 0].Value = "0";
            //dgv1[col1Number, 1].Value = "1";
            //dgv1[col1Number, 2].Value = "2";
            //dgv1[col1Number, 3].Value = "3";
            //dgv1[col1Number, 4].Value = "4";
            //dgv1[col1Number, 5].Value = "5";
            //dgv1[col1Number, 6].Value = "6";
            //dgv1[col1Number, 7].Value = "7";
            //dgv1[col1Number, 8].Value = "8";
            //dgv1[col1Number, 9].Value = "9";
        }
        private void setDataGrid1(String number, String numUp, String numDown)
        {
            dgv1.Rows.Insert(0, 1);
            dgv1[col1Number, 0].Value = number;
            dgv1[col1Up, 0].Value = numUp;
            dgv1[col1Down, 0].Value = numDown;
        }
        private void setDataGrid2(String number, String numUp, String numDown)
        {
            dgv2.Rows.Insert(0, 1);
            dgv2[col2Number, 0].Value = number;
            dgv2[col2Up, 0].Value = numUp;
            dgv2[col2Down, 0].Value = numDown;
        }
        private void setDataGrid3(String number, String numUp, String numDown)
        {
            dgv3.Rows.Insert(0, 1);
            dgv3[col3Number, 0].Value = number;
            dgv3[col3Up, 0].Value = numUp;
            dgv3[col3Down, 0].Value = numDown;
        }
        private void setGrid2()
        {
            String txt = "";
            Font font = new Font("Microsoft Sans Serif", 10);
            dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv2.ColumnCount = col2Cnt;
            dgv2.RowCount = 1;
            dgv2.Columns[col2Number].Width = 65;
            dgv2.Columns[col2Up].Width = 60;
            dgv2.Columns[col2Down].Width = 60;
            dgv2.Columns[col2Number].HeaderText = "ตัวเลข";
            dgv2.Columns[col2Up].HeaderText = "บน";
            dgv2.Columns[col2Down].HeaderText = "ล่าง";

            dgv2.Font = font;

            //for (int i = 0; i < 100; i++)
            //{
            //    txt = "00"+i.ToString();
            //    dgv2[col2Number, i].Value = txt.Substring(txt.Length-2);
            //}
        }
        private void setGrid3()
        {
            String txt = "";
            Font font = new Font("Microsoft Sans Serif", 10);
            dgv3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv3.ColumnCount = col3Cnt;
            dgv3.RowCount = 1;
            dgv3.Columns[col3Number].Width = 65;
            dgv3.Columns[col3Up].Width = 60;
            dgv3.Columns[col3Down].Width = 60;
            dgv3.Columns[col3Number].HeaderText = "ตัวเลข";
            dgv3.Columns[col3Up].HeaderText = "บน";
            dgv3.Columns[col3Down].HeaderText = "ล่าง";

            dgv3.Font = font;
            //for (int i = 0; i < 1000; i++)
            //{
            //    txt = "000" + i.ToString();
            //    dgv3[col3Number, i].Value = txt.Substring(txt.Length - 3);
            //}
        }
        private void txtInputFocus()
        {
            txtInput.SelectAll();
            txtInput.Focus();
        }
        private void txtDownFocus()
        {
            txtDown.SelectAll();
            txtDown.Focus();
        }
        private void txtUpFocus()
        {
            txtUp.SelectAll();
            txtUp.Focus();
        }
        private void txtTodFocus()
        {
            txtTod.SelectAll();
            txtTod.Focus();
        }
        private void setDgv1Up()
        {
            if (txtInput.Text.Equals("0"))
            {
                dgv1[col1Up, 0].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 0].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("1"))
            {
                dgv1[col1Up, 1].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 1].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("2"))
            {
                dgv1[col1Up, 2].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 2].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("3"))
            {
                dgv1[col1Up, 3].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 3].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("4"))
            {
                dgv1[col1Up, 4].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 4].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("5"))
            {
                dgv1[col1Up, 5].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 5].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("6"))
            {
                dgv1[col1Up, 6].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 6].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("7"))
            {
                dgv1[col1Up, 7].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 7].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("8"))
            {
                dgv1[col1Up, 8].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 8].Value)) + int.Parse(txtUp.Text);
            }
            else if (txtInput.Text.Equals("9"))
            {
                dgv1[col1Up, 9].Value = int.Parse(cf.NumberNull(dgv1[col1Up, 9].Value)) + int.Parse(txtUp.Text);
            }
        }
        private void setDgv1Down()
        {
            if (txtInput.Text.Equals("0"))
            {
                dgv1[col1Down, 0].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 0].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("1"))
            {
                dgv1[col1Down, 1].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 1].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("2"))
            {
                dgv1[col1Down, 2].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 2].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("3"))
            {
                dgv1[col1Down, 3].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 3].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("4"))
            {
                dgv1[col1Down, 4].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 4].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("5"))
            {
                dgv1[col1Down, 5].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 5].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("6"))
            {
                dgv1[col1Down, 6].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 6].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("7"))
            {
                dgv1[col1Down, 7].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 7].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("8"))
            {
                dgv1[col1Down, 8].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 8].Value)) + int.Parse(txtDown.Text);
            }
            else if (txtInput.Text.Equals("9"))
            {
                dgv1[col1Down, 9].Value = int.Parse(cf.NumberNull(dgv1[col1Down, 9].Value)) + int.Parse(txtDown.Text);
            }
        }


        private void FrmInput_Load(object sender, EventArgs e)
        {
            txtInputFocus();
        }

        private void FrmInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApplication();
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUpFocus();
            }
        }

        private void txtUp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtInput.Text.Length == 1)
                {
                    //setDgv1Up();
                    txtTodFocus();
                }
                else if (txtInput.Text.Length == 2)
                {

                    txtTodFocus();
                }
                else if (txtInput.Text.Length == 3)
                {

                    txtTodFocus();
                }
            }
        }

        private void txtDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtInput.Text.Length == 1)
                {
                    //setDgv1Down();
                    setDataGrid1(txtInput.Text, txtUp.Text, txtDown.Text);
                    //txtInputFocus();
                }
                else if (txtInput.Text.Length == 2)
                {
                    setDataGrid2(txtInput.Text, txtUp.Text, txtDown.Text);
                    //txtInputFocus();
                }
                else if (txtInput.Text.Length == 3)
                {
                    setDataGrid3(txtInput.Text, txtUp.Text, txtDown.Text);
                    //txtInputFocus();
                }
                txtInputFocus();
            }
        }

        private void FrmInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                FrmMain frm = new FrmMain(this, "", null);
                frm.Show();
                this.Hide();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain(this, "", null);
            frm.Show();
            this.Hide();
        }

        private void txtTod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDownFocus();
            }
        }
    }
}
