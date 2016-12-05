﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Collections;
using WebApplication3.Data;

namespace WebApplication3.Models
{
    public class ProductModel{
        private MySqlConnection conn;
        private String product_id;
        private String name;
        private String catagory;
        private String price;
        private String manufactorer;
        private ArrayList data = new ArrayList();

        public ProductModel(String _id)
        {
            product_id = _id;
            if (Check(product_id))
            {
                conn = Connection.Initialize();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM product WHERE product_id=@product_id;", conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@pProduct_id", Int32.Parse(product_id));
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        data.Add(rdr[0]);
                        data.Add(rdr[1]);
                        data.Add(rdr[2]);
                        data.Add(rdr[3]);
                    }
                }
                FillValues();
                //conn.Close();
            }
            else
            {
                // return standard product not found page
            }
        }

        public bool Check(String nonParsedId)
        {
            if (nonParsedId != null)
            {
                char[] s = { '?', '&' };
                String[] _id = nonParsedId.Split(s);
                product_id = _id[0];
                return (IsClean(product_id));
            }
            else
            {
                return false;
            }
        }
        private bool IsClean(String str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private void FillValues()
        {
            name = data[2].ToString();
            catagory = data[3].ToString();
            price = data[5].ToString();
            manufactorer = data[6].ToString();
        }

        public String Product_id
        {
            get { return product_id; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Catagory
        {
            get { return catagory; }
            set { catagory = value; }
        }
        public String Price
        {
            get { return price; }
            set { price = value; }
        }
        public String Manufactorer
        {
            get { return manufactorer; }
        }
    }
}