using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmInputImage : Form
    {
        int row = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5;
        int col1Cnt = 7;
        Staff sf;
        Thoo tho;
        LottoryControl lc;
        ComboBox cboSale1;
        List<String> name = new List<String>();
        ImageList iL = new ImageList();
        Boolean pageLoad = false, clearGrd1=false;
        Boolean lotNew = false;
        String lotId1 = "";
        Color btnEditColor;
        public FrmInputImage(String sfCode, LottoryControl l)
        {
            pageLoad = true;
            InitializeComponent();
            initConfig(sfCode, l);
            pageLoad = false;
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            pB1.Visible = false;
            
            String monthId = "", periodId = "";
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            tho = lc.thodb.selectByDefault();
            monthId = System.DateTime.Now.Month.ToString("00");
            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboSale = lc.saledb.getCboSale(cboSale);
            cboSale1 = cboSale;
            cboThoo = lc.thodb.getCboThoo(cboThoo);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            ComboBoxItem cbo = new ComboBoxItem();
            cbo.Value = sf.Id;
            cbo.Text = sf.Name;
            cboStaff.Text = sf.Name;
            cboThoo.Text = tho.Name;
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            picRotate.Visible = false;
            picZoomM.Visible = false;
            picZoomP.Visible = false;
            picHand.Visible = false;
            lotNew = true;
            clearGrd1 = false;

            setGrid1();
            viewImage();
            btnEdit.Enabled = false;
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

            lotNew = true;
        }
        private void setGrid1(String lotoId)
        {
            DataTable dt = lc.lotdb.selectByImg(lotoId);
            setGrid1();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrid1(dt.Rows[i][lc.lotdb.lot.number].ToString(), dt.Rows[i][lc.lotdb.lot.up].ToString(),
                        dt.Rows[i][lc.lotdb.lot.tod].ToString(), dt.Rows[i][lc.lotdb.lot.down].ToString(),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString());
                    if ((i % 2) != 0)
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
                lotId1 = lotoId;
            }
            dgv1.Enabled = false;
        }

        private void FrmInputImage_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            viewImage();
        }
        private void nextImage(int index)
        {
            //viewImage(index);
            lV1.Items[index].Checked = true;
        }
        private void viewImage()
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            String pahtFile = lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString();
            String fileName = "";
            pageLoad = true;
            pB1.Visible = true;
            lV1.Clear();
            DirectoryInfo dir = new DirectoryInfo(pahtFile);
            iL.Images.Clear();
            name.Clear();
            int cnt = 0;
            if (!dir.Exists)
            {
                pageLoad = false;                
                pB1.Visible = false;
                Cursor.Current = cursor;
                return;
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                cnt++;
            }

            pB1.Minimum = 0;
            pB1.Maximum = cnt;
            cnt = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    cnt++;
                    if (file.Extension.Equals(".thumb"))
                    {
                        iL.Images.Add(Image.FromFile(file.FullName));
                        name.Add(file.Name.Replace(file.Extension, "") + ".lotto");
                    }
                    pB1.Value = cnt;
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            lV1.View = View.LargeIcon;
            iL.ImageSize = new Size(64, 64);
            lV1.LargeImageList = iL;
            lV1.CheckBoxes = true;
            //or
            //this.listView1.View = View.SmallIcon;
            //this.listView1.SmallImageList = this.imageList1;

            for (int j = 0; j < iL.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                lV1.Items.Add(item);
                if (name[j].IndexOf("_1.") > 0)
                {
                    lV1.Items[j].Checked = true;
                    lV1.Items[j].BackColor = Color.DarkCyan;
                }
            }
            pB1.Visible = false;
            pageLoad = false;
            Cursor.Current = cursor;
        }
        private void viewImage(int index)
        {
            Image1 img = new Image1();
            //txtImgId.Text = name[index];
            txtIndex.Text = index.ToString();
            img = lc.imgdb.selectByPk(txtImgId.Text);
            if (img.FLock.Equals("1"))
            {
                MessageBox.Show("viewImage img.FLock", "1111");
                return;
            }
            lc.imgdb.UpdateLock(txtImgId.Text);

            String pahtFile = lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString();
            //File.
            if (File.Exists(pahtFile + "\\" + name[index]))
            {
                //pic1.Image = Image.FromFile(pahtFile + "\\" + name[index]);
                Image im = GetCopyImage(pahtFile + "\\" + name[index]);
                pic1.Image = im;
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                picRotate.Visible = true;
                picZoomM.Visible = true;
                picZoomP.Visible = true;
                picHand.Visible = true;
            }
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        private void lV1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!pageLoad)
            {
                if (e.Item.Checked)
                {
                    //viewImage(e.Item.ImageIndex);
                }
                else
                {
                    //pic1.Image = new Image(new Size(1,1));
                }
            }
        }

        private void picRotate_Click(object sender, EventArgs e)
        {
            //Bitmap bitmap = (Bitmap)pic1.Image;
            //pic1.Image = null;
            pic1.Image = (RotateImageByAngle(pic1.Image, -90.0f));
            //pic1.SizeMode = PictureBoxSizeMode.Normal;
            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pic1.Image = p.Image;
        }

        private void picZoomP_Click(object sender, EventArgs e)
        {
            pic1.Image = (PictureBoxZoom(pic1.Image, new Size(2,2)));
        }

        private void picZoomM_Click(object sender, EventArgs e)
        {

        }
        private Bitmap RotateImageByAngle(Image oldBitmap, float angle)
        {
            var newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            newBitmap.SetResolution(oldBitmap.HorizontalResolution, oldBitmap.VerticalResolution);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)oldBitmap.Width / 2, (float)oldBitmap.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)oldBitmap.Width / 2, -(float)oldBitmap.Height / 2);
            graphics.DrawImage(oldBitmap, new Point(0, 0));
            return newBitmap;
        }
        public Image PictureBoxZoom(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));
            Graphics grap = Graphics.FromImage(bm);
            grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bm;
        }
        private void refresh()
        {
            setGrid1();
            //setGridLot();
            lotNew = true;
            lotId1 = "";
            btnEdit.Enabled = false;
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
        private void clearInput()
        {
            txtInput.Text = "";
            txtUp.Text = "";
            txtTod.Text = "";
            txtDown.Text = "";
        }
        private Lotto setLotto(int row)
        {
            Lotto lot = new Lotto();
            lot.rowNumber = row.ToString();
            lot.Active = "1";
            lot.dateCancel = "";
            lot.dateCreate = "";
            lot.dateModi = "";


            lot.lottoId = dgv1[colLottoId1, row].Value.ToString();
            lot.yearId = cboYear.Text;
            lot.monthId = cboMonth.SelectedValue.ToString();

            lot.periodId = cboPeriod.SelectedValue.ToString();
            lot.Remark = "";
            lot.rowId = dgv1[colRowId, row].Value.ToString();
            //lot.saleId = cboSale.SelectedValue.ToString();

            lot.saleId = lc.cf.getValueCboItem(cboSale);
            lot.staffId = lc.cf.getValueCboItem(cboStaff);
            lot.thooId = lc.cf.getValueCboItem(cboThoo);
            lot.thooTranferId = lot.thooId;

            lot.staffCancel = "";
            lot.staffCreate = "";

            lot.staffModi = "";

            lot.number = lc.cf.LottoNull(dgv1[colNumber, row].Value);
            lot.down = lc.cf.LottoNull(dgv1[colDown, row].Value);
            lot.tod = lc.cf.LottoNull(dgv1[colTod, row].Value);
            lot.up = lc.cf.LottoNull(dgv1[colUp, row].Value);
            lot.statusInput= "2";
            lot.imgId = txtImgId.Text;

            return lot;
        }
        private void saveLotto()
        {
            Lotto lot = new Lotto();
            String lotId = "", Cbdl = "";
            //if (lotNew)
            //{
            lotId = lot.getGenID();
            Cbdl = lc.lotdb.selectCDbl();
            //}
            for (int i = 0; i < dgv1.RowCount; i++)
            {
                if (dgv1[colNumber, i].Value == null)
                {
                    continue;
                }
                lot = setLotto(i);
                if (lot.lottoId.Equals(""))
                {
                    if (lotNew)
                    {
                        lot.lottoId = lotId;
                        lot.CDbl = Cbdl;
                    }
                    else
                    {
                        lot.lottoId = lotId1;
                    }
                }
                lc.saveLotto(lot);
                dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                //lV1.Items[txtIndex.Text].Checked = true;               
            }
            pic1.CancelAsync();
            pic1.Image.Dispose();
            lc.renameFileImage(lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString() + "\\" + txtImgId.Text);
            lc.renameFileImage(lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString() + "\\" + txtImgId.Text.Replace(".lotto", ".thumb"));
            lc.imgdb.UpdateStatusInput(txtImgId.Text.Replace(txtImgId.Text.Substring(txtImgId.Text.IndexOf("_0")),""), sf.Id, sf.Name);
            lc.imgdb.UpdateUnLock(txtImgId.Text);
            if (lV1.Items.Count < int.Parse(txtIndex.Text))
            {
                txtIndex.Text = String.Concat(int.Parse(txtIndex.Text) + 1);
                lV1.Items[int.Parse(txtIndex.Text)].Checked = true;
            }
            refresh();
        }
        private void setDataGrid1(String number, String numUp, String numTod, String numDown, String rowId, String lottoId)
        {
            dgv1.Rows.Insert(dgv1.RowCount - 1, 1);

            dgv1[colNumber, row].Value = number;
            if (numUp.Equals(""))
            {
                dgv1[colUp, row].Value = "0";
            }
            else
            {
                dgv1[colUp, row].Value = numUp;
            }
            if (numTod.Equals(""))
            {
                dgv1[colTod, row].Value = "0";
            }
            else
            {
                dgv1[colTod, row].Value = numTod;
            }
            if (numDown.Equals(""))
            {
                dgv1[colDown, row].Value = "0";
            }
            else
            {
                dgv1[colDown, row].Value = numDown;
            }
            dgv1[colDown, row].Value = numDown;
            dgv1[colRowId, row].Value = rowId;
            dgv1[colLottoId1, row].Value = lottoId;
            
            row++;
        }
        private void setGrdColor()
        {
            String numUp = "", numTod = "", numDown="";
            Double amt = 0;
            for (int i = 0; i < dgv1.RowCount-1; i++)
            {
                numUp = lc.cf.NumberNull(dgv1[colUp, i].Value);
                numTod = lc.cf.NumberNull(dgv1[colTod, i].Value);
                numDown = lc.cf.NumberNull(dgv1[colDown, i].Value);
                amt += (Double.Parse(numUp) + Double.Parse(numTod) + Double.Parse(numDown));
                if ((i % 2) != 0)
                {
                    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                }
            }
            lbAmt.Text = "รวม : " + amt.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            btnSave.Enabled = false;
            saveLotto();
            btnSave.Enabled = true;
            Cursor.Current = cursor;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.BackColor == btnEditColor)
            {
                btnEdit.BackColor = Color.FromArgb(171, 214, 121);
            }
            else
            {
                btnEdit.BackColor = btnEditColor;
                lotId1 = "";
            }
            dgv1.Enabled = true;
            lotNew = false;
            clearGrd1 = false;
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            txtInput.BackColor = Color.LightYellow;
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            txtInput.BackColor = Color.White;
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lc.chkNumberLimit(txtInput.Text))
                {
                    label18.Text = "เลขอั้น";
                    return;
                }
                else
                {
                    label18.Text = "";
                    txtUpFocus();
                }               
            }
        }

        private void txtUp_Enter(object sender, EventArgs e)
        {
            txtUp.BackColor = Color.LightYellow;
        }

        private void txtUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtUp_Leave(object sender, EventArgs e)
        {
            txtUp.BackColor = Color.White;
        }

        private void txtUp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTodFocus();
            }
        }

        private void txtTod_Enter(object sender, EventArgs e)
        {
            txtTod.BackColor = Color.LightYellow;
        }

        private void txtTod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDownFocus();
            }
        }

        private void txtTod_Leave(object sender, EventArgs e)
        {
            txtTod.BackColor = Color.White;
        }

        private void txtDown_Enter(object sender, EventArgs e)
        {
            txtDown.BackColor = Color.LightYellow;
        }

        private void txtDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (clearGrd1)
                {
                    setGrid1();
                    clearGrd1 = false;
                }
                //if (txtInput.Text.Length == 1)
                //{
                    //setDgv1Down();
                if (lc.chkNumberLimit(txtInput.Text))
                {
                    label18.Text = "เลขอั้น";
                    return;
                }
                else
                {
                    label18.Text = "";
                }
                if (txtInput.Text.Length <= 0)
                {
                    return;
                }
                else if (txtInput.Text.Length == 1)
                {
                    setDataGrid1(txtInput.Text, txtUp.Text, "0", txtDown.Text, "", "");
                }
                else if (txtInput.Text.Length == 2)
                {
                    setDataGrid1(txtInput.Text, txtUp.Text, "0", txtDown.Text, "", "");
                }
                else 
                {
                    setDataGrid1(txtInput.Text, txtUp.Text, txtTod.Text, txtDown.Text, "", "");
                }
                //setDataGrid1(txtInput.Text, txtUp.Text, txtTod.Text, txtDown.Text,"","");
                setGrdColor();
                txtInputFocus();
                clearInput();
            }
        }

        private void txtDown_Leave(object sender, EventArgs e)
        {
            txtDown.BackColor = Color.White;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {

        }

        private void lV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                Cursor cursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    ListViewItem i = lV1.SelectedItems[0];
                    txtImgId.Text = name[i.ImageIndex];
                    viewImage(i.ImageIndex);
                    if (txtImgId.Text.Length >= 10)
                    {
                        setGrid1(txtImgId.Text.Replace(txtImgId.Text.Substring(txtImgId.Text.IndexOf("_1")), ""));
                    }                    
                    txtInputFocus();
                }
                catch (Exception ex)
                {

                }
                Cursor.Current = cursor;
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.End:
                    // ... Process Shift+Ctrl+Alt+B ...
                    saveLotto();
                    return true; // signal that we've processed this key
                case Keys.Insert:
                    txtInputFocus();
                    return true;
            }
            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                viewImage();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                viewImage();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                viewImage();
            }
        }
    }
}
