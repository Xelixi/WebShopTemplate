using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class ProductModels : Controller
    {
        // GET: ProductModels
        public ActionResult Index()
        {
            return View();
        }
    }
}
public class ProductModel
{
    private MySqlConnection conn;
    private String id;
    private String name;
    private String price;
    private String color;
    private String brand;
    private String size;
    private String type;
    private String description;
    private ArrayList data = new ArrayList();

    public ProductModel(String _id)
    {
        id = _id;
        if (Check(id))
        {
            conn = Connection.Initialize();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE pId=@pId;", conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@pId", Int32.Parse(id));
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    data.Add(rdr[0]);
                    data.Add(rdr[1]);
                    data.Add(rdr[2]);
                    data.Add(rdr[3]);
                    data.Add(rdr[4]);
                    data.Add(rdr[5]);
                    data.Add(rdr[6]);
                    data.Add(rdr[7]);
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
            id = _id[0];
            return (IsClean(id));
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
        size = data[1].ToString();
        name = data[2].ToString();
        type = data[3].ToString();
        description = data[4].ToString();
        price = data[5].ToString();
        brand = data[6].ToString();
        color = data[7].ToString();
    }

    public String Id
    {
        get { return id; }
    }
    public String Description
    {
        get { return description; }
    }
    public String Name
    {
        get { return name; }
        set { name = value; }
    }
    public String Price
    {
        get { return price; }
        set { price = value; }
    }
    public String Color
    {
        get { return color; }
    }
    public String Brand
    {
        get { return brand; }
    }
    public String Size
    {
        get { return size; }
    }
    public String Type
    {
        get { return type; }
    }
}