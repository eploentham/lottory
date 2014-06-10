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
    public partial class FrmPassword : Form
    {
        LottoryControl lc;
        Staff s;
        public FrmPassword(String sfId)
        {
            InitializeComponent();
            initConfig(sfId);
        }
        private void initConfig(String sfId)
        {
            lc = new LottoryControl();
            s = new Staff();
            s = lc.selectStaffbyPk(sfId);
            setControl(s.Id);
        }
        private void setControl(String sfId)
        {
            txtNewPassword.Text = s.Password;
            txtConfirmPassword.Text = s.Password;
        }
        private Staff getControl()
        {
            s.Password = txtNewPassword.Text;
            s.Password = txtConfirmPassword.Text;
            return s;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show("รหัสผ่าน ไม่เหมือนกัน", "ป้อนข้อมูลไม่ถูกต้อง");
                return;
            }
            //s = getControl();
            if (lc.sfdb.updatePassword(s.Id, txtNewPassword.Text).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            txtNewPassword.BackColor = Color.LightYellow;
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            txtNewPassword.BackColor = Color.White;
        }

        private void txtNewPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
            }
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtConfirmPassword.BackColor = Color.LightYellow;
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            txtConfirmPassword.BackColor = Color.White;
        }

        private void txtConfirmPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
    }
}
