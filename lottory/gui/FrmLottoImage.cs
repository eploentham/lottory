using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmLottoImage : Form
    {
        Staff sf;
        Thoo tho;
        LottoryControl lc;
        Boolean pageLoad = false, clearGrd1 = false;
        ImageList iL;
        FolderBrowserDialog fbd;
        List<String> name;
        List<String> name1;
        public FrmLottoImage(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode, l);
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            pageLoad = true;
            pB1.Visible = false;
            String monthId = "", periodId = "";
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);

            fbd = new FolderBrowserDialog();
            fbd.SelectedPath = lc.initC.pathImageBefore;
            iL = new ImageList();
            name = new List<String>();
            name1 = new List<String>();
            
            monthId = System.DateTime.Now.Month.ToString("00");

            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            //cboStaff = lc.sfdb.getCboStaff(cboStaff);

            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            getImage();
            //pageLoad = false;
        }
        private void getImageNew()
        {
            //DialogResult result = fbd.ShowDialog();
            //txtPath.Text = fbd.SelectedPath;
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            name.Clear();
            //pageLoad = true;
            pB1.Visible = true;
            lVNew.Clear();
            DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
            iL.Images.Clear();
            int cnt = 0;
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
                    iL.Images.Add(Image.FromFile(file.FullName));
                    name.Add(file.FullName);

                    //Image image = Image.FromFile(file.FullName);
                    //Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                    //thumb.Save(Path.ChangeExtension(file.FullName, "thumb"));
                    pB1.Value = cnt;
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
            lVNew.View = View.LargeIcon;
            iL.ImageSize = new Size(64, 64);
            lVNew.LargeImageList = iL;
            lVNew.CheckBoxes = true;
            //or
            //this.listView1.View = View.SmallIcon;
            //this.listView1.SmallImageList = this.imageList1;

            for (int j = 0; j < iL.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                item.Checked = true;
                lVNew.Items.Add(item);                
            }

            pB1.Visible = false;
            //pageLoad = false;
            Cursor.Current = cursor;
        }
        private bool compareImage(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }
        private void getImage()
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            name1.Clear();
            String pahtFile = lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString();
            String fileName = "", file1="";
            pageLoad = true;
            pB1.Visible = true;
            lV1.Clear();
            DirectoryInfo dir = new DirectoryInfo(pahtFile);
            iL.Images.Clear();
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
                        file1 = file.FullName.Replace(file.Extension,"");
                        iL.Images.Add(Image.FromFile(file.FullName));
                        name1.Add(file.FullName);
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
                file1 = name1[j];
                file1 = file1.Replace(".thumb", "");
                if (file1.Substring(file1.Length - 2).Equals("_1"))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
                lV1.Items.Add(item);
            }
            pB1.Visible = false;
            pageLoad = false;
            Cursor.Current = cursor;
        }
        private void saveImage()
        {
            String pahtFile = lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString();
            String fileName = "";
            pB1.Visible = true;
            pB1.Minimum = 0;
            pB1.Maximum = name.Count;
            int cnt = 0;
            bool isExists = System.IO.Directory.Exists(pahtFile);
            if (!isExists)
                System.IO.Directory.CreateDirectory(pahtFile);

            DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    cnt++;
                    //iL.Images.Add(Image.FromFile(file.FullName));
                    //name.Add(file.FullName);
                    Image1 img = new Image1();
                    img.Active = "1";
                    img.custId = "";
                    img.Id = "";
                    img.pathFilename = file.FullName;
                    img.saleId = "";
                    img.staffId = sf.Id;
                    img.yearId = cboYear.Text;
                    img.monthId = cboMonth.SelectedValue.ToString();
                    img.periodId = cboPeriod.SelectedValue.ToString();
                    img.statusInput = "0";
                    img.FLock = "0";
                    String id = lc.imgdb.insertImage(img);

                    Image image = Image.FromFile(file.FullName);
                    //fileName = pahtFile + "\\" + file.Name.Replace(file.Extension, "") + ".lotto";
                    fileName = pahtFile + "\\" + id + "_" + img.statusInput + ".lotto";

                    if (!System.IO.File.Exists(fileName))
                    {

                        image.Save(fileName);
                    }
                    else
                    {
                        //Image img = Image.FromFile(fileName);
                        //if (compareImage((Bitmap)image, (Bitmap)img))
                        //{
                        //MessageBox.Show("error " , "asdfsdf");
                        continue;
                        //}
                    }
                    Image thumb = image.GetThumbnailImage(128, 128, () => false, IntPtr.Zero);
                    fileName = pahtFile + "\\" + id + "_" + img.statusInput + ".thumb";
                    if (!System.IO.File.Exists(fileName))
                    {
                        thumb.Save(fileName);
                    }
                    //thumb.Save(pahtFile + "\\" + file.Name.Replace(file.Extension, "") + ".thumb");

                    image.Dispose();
                    thumb.Dispose();
                    if (lc.initC.delImage.Equals("yes"))
                    {
                        //file.Delete();
                    }

                    pB1.Value = cnt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.Message, "");
                    Console.WriteLine("This is not an image file");
                }
            }
            pB1.Visible = false;
        }
        private void viewImage(String filename)
        {
            //if (!pageLoad)
            //{
                //if (e.Item.Checked)
                //{
            String file = filename.Replace(".thumb",".lotto");

            if (System.IO.File.Exists(file))
            {
                pic1.Image = Image.FromFile(file);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                picRotate.Visible = true;
                //picZoomM.Visible = true;
                //picZoomP.Visible = true;
                //picHand.Visible = true;
            }
                //}
                //else
                //{
                //    //pic1.Image = new Image(new Size(1,1));
                //}

            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getImageNew();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveImage();
            getImage();
        }

        private void lV1_MouseClick(object sender, MouseEventArgs e)
        {
            //ListViewItem aa = lV1.SelectedItems[0].Index;
            viewImage(name1[lV1.SelectedItems[0].Index]);
        }

        private void lVNew_MouseClick(object sender, MouseEventArgs e)
        {
            viewImage(name[lVNew.SelectedItems[0].Index]);
        }

        private void btnBrowe_Click(object sender, EventArgs e)
        {
            fbd.ShowDialog();
            getImageNew();
        }

        private void FrmLottoImage_Load(object sender, EventArgs e)
        {

        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                getImage();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                getImage();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                getImage();
            }
        }
    }
}
