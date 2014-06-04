﻿using lottory.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.objdb
{
    public class SaleRateDB
    {
        ConnectDB conn;
        public SaleRate sr;
        public SaleRateDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            sr = new SaleRate();

            sr.Id = "sale_rate_id";
            sr.SaleId = "sale_id";
            sr.RateId = "rate_id";
            sr.Description = "sale_rate_description";
            sr.rec = "rec";
            sr.pay = "pay";
            sr.limit1 = "limit1";
            sr.discount = "discount";
            sr.Active = "sale_rate_active";
            sr.thooId = "thoo_id";
            sr.sited = "";
            sr.table = "b_sale_rate";
            sr.pkField = "sale_rate_id";
        }
        private SaleRate setData(SaleRate item, DataTable dt)
        {
            item.Id = dt.Rows[0][sr.Id].ToString();
            item.Description = dt.Rows[0][sr.Description].ToString();
            item.rec = dt.Rows[0][sr.rec].ToString();
            item.pay = dt.Rows[0][sr.pay].ToString();
            item.limit1 = dt.Rows[0][sr.limit1].ToString();
            item.discount = dt.Rows[0][sr.discount].ToString();
            item.Active = dt.Rows[0][sr.Active].ToString();
            item.thooId = dt.Rows[0][sr.thooId].ToString();
            item.SaleId = dt.Rows[0][sr.SaleId].ToString();
            item.RateId = dt.Rows[0][sr.RateId].ToString();
            return item;
        }
        public DataTable selectAll()
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sr.table + " Where " + sr.Active + "='1'";
            dt = conn.selectData(sql);

            return dt;
        }
        public SaleRate selectByPk(String saleId)
        {
            SaleRate item = new SaleRate();
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sr.table + " Where " + sr.pkField + "='" + saleId + "'";
            dt = conn.selectData(sql);
            if (dt.Rows.Count > 0)
            {
                item = setData(item, dt);
            }
            return item;
        }
        public DataTable selectBySale(String saleId)
        {
            String sql = "";
            DataTable dt = new DataTable();
            sql = "Select * From " + sr.table + " Where " + sr.Active + "='1' and "+sr.SaleId+"='"+saleId+"'";
            dt = conn.selectData(sql);

            return dt;
        }
        private String insert(SaleRate p)
        {
            String sql = "", chk = "";
            if (p.Id.Equals(""))
            {
                p.Id = p.getGenID();
            }
            p.Description = p.Description.Replace("''", "'");
            if (p.pay.Equals(""))
            {
                p.pay = "0";
            }
            if (p.limit1.Equals(""))
            {
                p.limit1 = "0";
            }
            if (p.discount.Equals(""))
            {
                p.discount = "0";
            }
            if (p.rec.Equals(""))
            {
                p.rec = "1";
            }
            //p.Remark = p.Remark.Replace("''", "'");
            sql = "Insert Into " + sr.table + " (" + sr.pkField + "," + sr.Description + "," + sr.rec + "," +
                sr.pay + "," + sr.limit1 + "," + sr.discount + "," +
                sr.thooId + "," + sr.Active+","+sr.RateId+","+sr.SaleId + ") " +
                "Values('" + p.Id + "','" + p.Description + "'," + p.rec + "," +
                p.pay + "," + p.limit1 + "," + p.discount + ",'" +
                p.thooId + "','" + p.Active+"','"+p.RateId+"','"+p.SaleId + "')";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
                chk = p.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "insert SaleRate");
            }
            finally
            {
            }
            return chk;
        }
        private String update(SaleRate p)
        {
            String sql = "", chk = "";

            p.Description = p.Description.Replace("''", "'");
            if (p.pay.Equals(""))
            {
                p.pay = "0";
            }
            if (p.limit1.Equals(""))
            {
                p.limit1 = "0";
            }
            if (p.discount.Equals(""))
            {
                p.discount = "0";
            }
            if (p.rec.Equals(""))
            {
                p.rec = "1";
            }
            sql = "Update " + sr.table + " Set " + sr.Description + "='" + p.Description + "', " +
                sr.rec + "=" + p.rec + ", " +
                sr.pay + "=" + p.pay + ", " +
                sr.limit1 + "=" + p.limit1 + ", " +
                sr.discount + "=" + p.discount + ", " +
                sr.thooId + "='" + p.thooId + "', " +
                sr.RateId + "='" + p.RateId + "', " +
                sr.SaleId + "='" + p.SaleId + "' " +
                "Where " + sr.pkField + "='" + p.Id + "'";
            try
            {
                chk = conn.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "update Rate");
            }
            finally
            {
            }
            return chk;
        }
        public String insertSaleRate(SaleRate p)
        {
            SaleRate item = new SaleRate();
            String chk = "";
            item = selectByPk(p.Id);
            if (item.Id == "")
            {
                chk = insert(p);
            }
            else
            {
                chk = update(p);
            }
            return chk;
        }
        public String deleteAll()
        {
            String sql = "", chk = "";
            sql = "Delete From " + sr.table;
            chk = conn.ExecuteNonQuery(sql);
            return chk;
        }
    }
}