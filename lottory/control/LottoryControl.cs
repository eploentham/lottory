using lottory.objdb;
using lottory.object1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottory.control
{
    public class LottoryControl
    {
        public Config1 cf;
        public ConnectDB conn;//
        public RateDB ratedb;
        public SaleDB saledb;
        public StaffDB sfdb;
        public ThooDB thodb;
        public LottoDB lotdb;
        public RewardDB rwdb;
        public FlockDB fldb;
        public SaleRateDB srdb;
        public CustomerDB cudb;
        public ImageDB imgdb;

        public Rate rate;
        public Staff staff;
        public Sale sale;
        public Thoo tho;
        public Lotto lot;
        public Reward rw;
        public FLock fl;
        public SaleRate sr;
        public Customer cu;
        public Image1 img;

        public RegEdit regE;

        public Rate r2Down, r2Tod, r2Up, r3Down, r3Up, r3Tod, rUp, rDown;

        public String thooId = "";

        public ComboBox cboStaff, cboSale, cboThoo;
        public List<Thoo> lTho = new List<Thoo>();
        public List<Font1> thoColor = new List<Font1>();
        public List<SaleRate> lsr = new List<SaleRate>();
        public List<Sale> ls = new List<Sale>();

        private IniFile iniFile;
        public InitConfig initC;
        //public List<Reward1> lRew1 = new List<Reward1>();

        public LottoryControl()
        {
            initConfig();
        }
        private void initConfig()
        {
            iniFile = new IniFile(Environment.CurrentDirectory+"\\"+Application.ProductName+".ini");
            initC = new InitConfig();
            //regE = new RegEdit();
            GetConfig();
            cf = new Config1();
            conn = new ConnectDB(initC);
            ratedb = new RateDB(conn);
            saledb = new SaleDB(conn);
            sfdb = new StaffDB(conn);
            thodb = new ThooDB(conn);
            lotdb = new LottoDB(conn);
            rwdb = new RewardDB(conn);
            fldb = new FlockDB(conn);
            srdb = new SaleRateDB(conn);
            cudb = new CustomerDB(conn);
            imgdb = new ImageDB(conn);

            rate = new Rate();
            sale = new Sale();
            staff = new Staff();
            tho = new Thoo();
            lot = new Lotto();
            rw = new Reward();
            fl = new FLock();
            sr = new SaleRate();
            cu = new Customer();
            img = new Image1();

            r2Down = new Rate();
            r2Tod = new Rate();
            r2Up = new Rate();
            r3Up = new Rate();
            r3Tod = new Rate();
            r3Down = new Rate();
            rUp = new Rate();
            rDown = new Rate();            

            rUp = ratedb.selectByPk("up");
            rDown = ratedb.selectByPk("down");
            r3Up = ratedb.selectByPk("3up");
            r3Tod = ratedb.selectByPk("3tod");
            r3Down = ratedb.selectByPk("3down");
            r2Down = ratedb.selectByPk("2down");
            r2Up = ratedb.selectByPk("2up");
            lTho = thodb.setData();
            setThoColor();
            lsr = srdb.selectSRAll();
            ls = saledb.selectSAll();
            //cboThoo = new ComboBox();
            //cboStaff = new ComboBox();
            //cboSale = new ComboBox();
            //cboThoo = thodb.getCboThoo(cboThoo);
            //cboStaff = sfdb.getCboStaff(cboStaff);
            //cboSale = saledb.getCboSale(cboSale);
        }
        private void setThoColor()
        {
            Font1 f1 = new Font1();
            f1.id = "1";
            f1.BackColor = "#F37257";
            f1.foreColor = "";
            thoColor.Add(f1);
            Font1 f2 = new Font1();
            f2.id = "2";
            f2.BackColor = "#F68D5C";
            f2.foreColor = "";
            thoColor.Add(f2);
            Font1 f3 = new Font1();
            f3.id = "3";
            f3.BackColor = "#F4D27A";
            f3.foreColor = "";
            thoColor.Add(f3);
            Font1 f4 = new Font1();
            f4.id = "4";
            f4.BackColor = "#517281";
            f4.foreColor = "";
            thoColor.Add(f4);
            Font1 f5 = new Font1();
            f5.id = "5";
            f5.BackColor = "#7895A2";
            f5.foreColor = "#000000";
            thoColor.Add(f5);
            Font1 f6 = new Font1();
            f6.id = "6";
            f6.BackColor = "#AFC1CC";
            f6.foreColor = "#000000";
            thoColor.Add(f6);
            Font1 f7 = new Font1();
            f7.id = "7";
            f7.BackColor = "#E96D63";
            f7.foreColor = "#000000";
            thoColor.Add(f7);
            Font1 f8 = new Font1();
            f8.id = "8";
            f8.BackColor = "#7FCA9F";
            f8.foreColor = "#000000";
            thoColor.Add(f8);
            Font1 f9 = new Font1();
            f9.id = "9";
            f9.BackColor = "#F4BA70";
            f9.foreColor = "#000000";
            thoColor.Add(f9);
            Font1 f10 = new Font1();
            f10.id = "10";
            f10.BackColor = "#85C1F5";
            f10.foreColor = "#000000";
            thoColor.Add(f10);
            Font1 f11 = new Font1();
            f11.id = "11";
            f11.BackColor = "#4A789C";
            f11.foreColor = "#000000";
            thoColor.Add(f11);
        }
        public String getThooBackColor(String thoId)
        {
            String aa = "#FFFFFF";
            Font1 i = new Font1();
            foreach (Font1 t in thoColor)
            {
                if (t.id.Equals(thoId))
                {
                    aa = t.BackColor;
                }
            }
            return aa;
        }
        public String getThooBackColorByThoId(String thoId)
        {
            String aa = "#FFFFFF";
            //Font1 i = new Font1();
            foreach (Thoo t in lTho)
            {
                if (t.Id.Equals(thoId))
                {
                    aa = getThooBackColor(t.Color);
                }
            }
            return aa;
        }
        public Thoo getThoo(String thoId)
        {
            Thoo i = new Thoo();
            foreach (Thoo t in lTho)
            {
                if (t.Id.Equals(thoId))
                {
                    return t;
                }
            }
            return i;
        }
        public ComboBoxItem getCboItem(ComboBox c, String valueId)
        {
            ComboBoxItem r = new ComboBoxItem();
            r.Text = "";
            r.Value = "";
            foreach (ComboBoxItem cc in c.Items)
            {
                if (cc.Value.Equals(valueId))
                {
                    r = cc;
                }
            }
            return r;
        }

        public Staff selectStaffbyPk(String staffId)
        {
            staff = sfdb.selectByPk(staffId);
            return staff;
        }
        public DataTable selectStaffAll()
        {
            DataTable dt = sfdb.selectAll();
            return dt;
        }
        public String saveStaff(Staff p)
        {
            String chk = "";
            chk = sfdb.insertStaff(p);
            return chk;
        }

        public Sale selectSalebyPk(String staffId)
        {
            sale = saledb.selectByPk(staffId);
            return sale;
        }
        public DataTable selectSaleAll()
        {
            DataTable dt = saledb.selectAll();
            return dt;
        }
        public String saveSale(Sale p)
        {
            String chk = "";
            chk = saledb.insertSale(p);
            return chk;
        }

        public Thoo selectThoobyPk(String thoId)
        {
            tho = thodb.selectByPk(thoId);
            return tho;
        }
        public DataTable selectThooAll()
        {
            DataTable dt = thodb.selectAll();
            return dt;
        }

        public String saveThoo(Thoo p)
        {
            String chk = "";
            chk = thodb.insertThoo(p);
            return chk;
        }

        public Rate selectRatebyPk(String thoId)
        {
            rate = ratedb.selectByPk(thoId);
            return rate;
        }
        public DataTable selectRateAll()
        {
            DataTable dt = ratedb.selectAll();
            return dt;
        }
        public DataTable selectRateAlltoSaleRate()
        {
            DataTable dt = ratedb.selectAlltoSaleRate();
            return dt;
        }
        public String saveRate(Rate p)
        {
            String chk = "";
            chk = ratedb.insertRate(p);
            return chk;
        }

        public Lotto selectLottobyPk(String rowId)
        {
            lot = lotdb.selectByPk(rowId);
            return lot;
        }
        public DataTable selectLottoAll()
        {
            DataTable dt = lotdb.selectAll();
            return dt;
        }
        public String saveLotto(Lotto p)
        {
            String chk = "";
            chk = lotdb.insertLotto(p);
            return chk;
        }
        public Boolean getLoginByCode(String code, String password)
        {
            Boolean chk = false;
            staff = sfdb.selectByCode(code);
            if (staff != null)
            {
                if (staff.Password.Equals(password))
                {
                    chk = true;
                }
            }
            return chk;
        }
        public Reward selectRewardbyPk(String rwId)
        {
            rw = rwdb.selectByPk(rwId);
            return rw;
        }
        public Reward selectRewardByPeriod(String yearId, String monthId, String periodId)
        {
            rw = rwdb.selectByPeriod(yearId, monthId, periodId);
            return rw;
        }
        public DataTable selectRewardAll()
        {
            DataTable dt = rwdb.selectAll();
            return dt;
        }
        public String saveReward(Reward p)
        {
            String chk = "";
            chk = rwdb.insertReward(p);
            return chk;
        }
        public void setPeriodReward(String yearId, String monthId, String periodId)
        {

        }
        public String saveThoo(String rowId, String thooId)
        {
            String chk = "";
            if (thooId.Equals(""))
            {
                return "";
            }
            chk = lotdb.updateThoo(rowId, thooId);
            return chk;
        }
        public String saveThooTranfer(String rowId, String thooId)
        {
            String chk = "";
            if (thooId.Equals(""))
            {
                return "";
            }
            chk = lotdb.updateThooTranfer(rowId, thooId);
            return chk;
        }
        String alignPrint(String txt, int space)
        {
            if (txt.Length >= space)
            {
                return txt;
            }
            String prn = "";
            for (int i = 0; i < space; i++)
            {
                prn += " ";
            }
            prn = prn + txt;
            prn = prn.Substring(prn.Length - space);
            return prn;
        }
        public float alignR(float gapCol, float fixCol, int len, float fontSizeinPoint)
        {
            if (len == 1)
            {
                return ((gapCol) + ((fixCol - len) * fontSizeinPoint));
            }
            else if (len == 5)
            {
                return ((gapCol) + ((fixCol - len) * fontSizeinPoint) + ((float)len * (float)1.5));
            }
            else
            {
                return ((gapCol) + ((fixCol - len) * fontSizeinPoint) + ((float)len * (float)1.3333));
            }
        }
        public double chkRewardUp(Reward r, String num, double up)
        {
            if (r.reward1.Substring(r.reward1.Length - 3).IndexOf(num) >= 0)
            {
                return up * double.Parse(rUp.pay);
            }
            else
            {
                return 0;
            }
        }
        public double chkRewardDown(Reward r, String num, double down)
        {
            if (r.rewardDown2.Substring(r.rewardDown2.Length - 2).IndexOf(num) >= 0)
            {
                return down * double.Parse(rUp.pay);
            }
            else
            {
                return 0;
            }
        }
        public double chkReward2Up(Reward r, String num, double up)
        {
            if (r.reward1.Substring(r.reward1.Length - 2).Equals(num))
            {
                return up * double.Parse(r2Up.pay);
            }
            else
            {
                return 0;
            }
        }
        public double chkReward2Down(Reward r, String num, double down)
        {
            if (r.rewardDown2.Substring(r.rewardDown2.Length - 2).Equals(num))
            {
                return down * double.Parse(r2Down.pay);
            }
            else
            {
                return 0;
            }
        }
        public double chkReward3Up(Reward r, String num, double up)
        {
            if (r.reward1.Substring(r.reward1.Length - 3).Equals(num))
            {
                return up * double.Parse(r3Up.pay);
            }
            else
            {
                return 0;
            }
        }
        public double chkReward3Down(Reward r, String num, double down)
        {
            if (r.rewardDown31.Equals(num))
            {
                return down * double.Parse(r3Down.pay);
            }
            else if (r.rewardDown32.Equals(num))
            {
                return down * double.Parse(r3Down.pay);
            }
            else if (r.rewardDown33.Equals(num))
            {
                return down * double.Parse(r3Down.pay);
            }
            else if (r.rewardDown34.Equals(num))
            {
                return down * double.Parse(r3Down.pay);
            }
            else
            {
                return 0;
            }
        }
        public double chkReward3Tod(Reward r, String num, double up)
        {
            if (r.tod31.Equals(num))
            {
                return up * double.Parse(r3Tod.pay);
            }
            else if (r.tod32.Equals(num))
            {
                return up * double.Parse(r3Tod.pay);
            }
            else if (r.tod33.Equals(num))
            {
                return up * double.Parse(r3Tod.pay);
            }
            else if (r.tod34.Equals(num))
            {
                return up * double.Parse(r3Tod.pay);
            }
            else if (r.tod35.Equals(num))
            {
                return up * double.Parse(r3Tod.pay);
            }
            else if (r.tod36.Equals(num))
            {
                return up * double.Parse(r3Tod.pay);
            }
            else
            {
                return 0;
            }
        }
        public ComboBox setCboPeriodDefault(ComboBox c)
        {
            if (System.DateTime.Now.Day >= 2)
            {
                if (System.DateTime.Now.Day <= 17)
                {
                    c.SelectedValue = "01";
                }
                else
                {
                    c.SelectedValue = "02";
                }

            }
            else
            {
                c.SelectedValue = "01";
            }
            return c;
        }
        public List<Reward1> selectByReward(String yearId, String monthId, String periodId, String rateId)
        {
            List<Reward1> lRew1 = new List<Reward1>();
            DataTable dt = lotdb.selectByReward(yearId, monthId, periodId, rateId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Reward1 rew1 = new Reward1();
                rew1.number = dt.Rows[i][lotdb.lot.number].ToString();
                if (rateId.Equals("up"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.up].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.rUpRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.rUp].ToString());
                }
                else if (rateId.Equals("down"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.down].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.rDownRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.rDown].ToString());
                }
                else if (rateId.Equals("2down"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.down].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.r2DownRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.r2Down].ToString());
                }
                else if (rateId.Equals("2up"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.up].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.r2UpRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.r2Up].ToString());
                }
                else if (rateId.Equals("3down"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.down].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.r3DownRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.r3Down].ToString());
                }
                else if (rateId.Equals("3tod"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.tod].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.r3TodRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.r3Tod].ToString());
                }
                else if (rateId.Equals("3up"))
                {
                    rew1.Amt = Double.Parse(dt.Rows[i][lotdb.lot.up].ToString());
                    rew1.PayRate = Double.Parse(dt.Rows[i][lotdb.lot.r3UpRate].ToString());
                    rew1.Reward = Double.Parse(dt.Rows[i][lotdb.lot.r3Up].ToString());
                }
                lRew1.Add(rew1);
            }
            return lRew1;
        }
        public List<Reward1> selectByLenNumber(String yearId, String monthId, String periodId, String rateId)
        {
            List<Reward1> lRew1 = new List<Reward1>();
            DataTable dt = lotdb.selectByLenNumber(yearId, monthId, periodId, rateId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Reward1 rew1 = new Reward1();
                rew1.number = dt.Rows[i][lotdb.lot.number].ToString();
                if (rateId.Equals("up"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.up]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.rUpRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.rUp]));
                    //rew1.AmtReward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.rUp]));
                }
                else if (rateId.Equals("down"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.down]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.rDownRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.rDown]));
                }
                else if (rateId.Equals("2down"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.down]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r2DownRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r2Down]));
                }
                else if (rateId.Equals("2up"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.up]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r2UpRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r2Up]));
                }
                else if (rateId.Equals("3down"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.down]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r3DownRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r3Down]));
                }
                else if (rateId.Equals("3tod"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.tod]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r3TodRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r3Tod]));
                }
                else if (rateId.Equals("3up"))
                {
                    rew1.Amt = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.up]));
                    rew1.PayRate = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r3UpRate]));
                    rew1.Reward = Double.Parse(cf.NumberNull(dt.Rows[i][lotdb.lot.r3Up]));
                }
                lRew1.Add(rew1);
            }
            return lRew1;
        }
        
        public String GetConfigbyKey(String key)
        {
            AppSettingsReader _configReader = new AppSettingsReader();
            // Set connection string of the sqlconnection object
            return _configReader.GetValue(key, "".GetType()).ToString();
        }
        public void GetConfig()
        {
            initC.clearInput = iniFile.Read("clearinput");
            initC.connectServer = iniFile.Read("connectserver");
            initC.ServerIP = iniFile.Read("host");
            initC.User = iniFile.Read("username");
            initC.Password = iniFile.Read("password");

            initC.pathImage = iniFile.Read("pathimage");
            initC.pathImageBefore = iniFile.Read("pathimagebefore");
            initC.delImage = iniFile.Read("delimage");
            //initC.connectServer = regE.getConnectServer();
            //initC.ServerIP = regE.getServerIP();
            //initC.User = regE.getUsername();
            //initC.Password = regE.getPassword();
        }
        public void SetPathImage(String path)
        {
            iniFile.Write("pathimage", path);
        }
        public void SetPathImageBefore(String path)
        {
            iniFile.Write("pathimagebefore", path);
        }
        public void SetClearInput(Boolean value)
        {
            if (value)
            {
                iniFile.Write("clearinput", "yes");
            }
            else
            {
                iniFile.Write("clearinput", "no");
            }
        }
        public void SetDelImage(Boolean value)
        {
            if (value)
            {
                iniFile.Write("delimage", "yes");
            }
            else
            {
                iniFile.Write("delimage", "no");
            }
        }
        public void SetConnectServer(Boolean value, String host, String username, String password)
        {
            if (value)
            {
                iniFile.Write("connectserver", "yes");
                iniFile.Write("host", host.Trim());
                iniFile.Write("username", username.Trim());
                iniFile.Write("password", password.Trim());
            }
            else
            {
                iniFile.Write("connectserver", "no");
            }
        }
        public void renameFileImage(String fileName)
        {
            String file1 = fileName.Replace("_0","_1");
            System.IO.File.Move(fileName, file1);
        }
        public String getSalePercent(String yearId, String monthId, String periodId, String saleId)
        {
            String num="";
            DataTable dt1 = lotdb.selectBySale(yearId, monthId, periodId, saleId);
            Double up = 0, down = 0, tod = 0, amtUp=0, amtTod=0, amtDown=0, amt=0;
            Sale s = new Sale();
            
            if (dt1.Rows.Count > 0)
            {
                s = getSalebyListS(saleId);
                //DataTable dtRate = ratedb.selectAll();
                
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    SaleRate sr = new SaleRate();
                    //DataTable dtSR = srdb.selectBySale(dt.Rows[i][lotdb.lot.saleId].ToString());
                    num = dt1.Rows[i][lotdb.lot.number].ToString();
                    up = Double.Parse(cf.NumberNull(dt1.Rows[i][lotdb.lot.up]));
                    down = Double.Parse(cf.NumberNull(dt1.Rows[i][lotdb.lot.down]));
                    tod = Double.Parse(cf.NumberNull(dt1.Rows[i][lotdb.lot.tod]));
                    amtUp = 0;
                    amtDown = 0;
                    amtTod = 0;
                    if (s.statusDiscount.Equals("1"))
                    {
                        if (num.Length == 1)
                        {
                            sr = getSaleRatebyListSR(lsr, saleId, "up");
                            amtUp = (up * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                            sr = getSaleRatebyListSR(lsr, saleId, "down");
                            amtDown = (down * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                        }
                        else if (num.Length == 2)
                        {
                            sr = getSaleRatebyListSR(lsr, saleId, "2up");
                            amtUp = (up * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                            sr = getSaleRatebyListSR(lsr, saleId, "2down");
                            amtDown = (down * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                            sr = getSaleRatebyListSR(lsr, saleId, "2tod");
                            amtTod = (tod * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                        }
                        else if (num.Length == 3)
                        {
                            sr = getSaleRatebyListSR(lsr, saleId, "3up");
                            amtUp = (up * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                            sr = getSaleRatebyListSR(lsr, saleId, "3down");
                            amtDown = (down * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                            sr = getSaleRatebyListSR(lsr, saleId, "3tod");
                            amtTod = (tod * Double.Parse(cf.NumberNull(sr.discount))) / 100;
                        }
                    }
                    else
                    {

                    }
                    
                    amt += amtUp + amtDown + amtTod;
                }
            }
            return amt.ToString();
        }
        public SaleRate getSaleRatebyListSR(List<SaleRate> lsr, String saleId, String rateId)
        {
            SaleRate item = new SaleRate();
            for (int i = 0; i < lsr.Count; i++)
            {
                item = new SaleRate();
                item = lsr[i];
                if (item.SaleId.Equals(saleId))
                {
                    if (item.RateId.Equals(rateId))
                    {
                        return item;
                    }
                }
            }
            return item;
        }
        public Sale getSalebyListS(String saleId)
        {
            Sale item = new Sale();
            for (int i = 0; i < ls.Count; i++)
            {
                item = new Sale();
                item = ls[i];
                if (item.Id.Equals(saleId))
                {
                    return item;
                }
            }
            return item;
        }
    }
}
