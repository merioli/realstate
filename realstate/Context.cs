using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace realstate
{
    class Context
    {
    }
    public class Dialog
    {
        public bool showDialog { get; set; }
        public string dialogTitle { get; set; }
        public string dialogMessage { get; set; }
        public string positiveBtn { get; set; }
        public string positiveBtnUrl { get; set; }
        public string negativeBtn { get; set; }
    }

    public class Datum
    {
        [Key]
        public string server_id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public List<string> images { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string area { get; set; }
        public int build_year { get; set; }
        public bool canbeAgent { get; set; }
        public bool isAgent { get; set; }
        public bool countryside { get; set; }
        public int room { get; set; }
        public int metraj { get; set; }
        public string cat { get; set; }
        public int vadie { get; set; }
        public int ejare { get; set; }
        public int tabdil { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string source { get; set; }
    }

    public class Remove
    {
        public string server_id { get; set; }
    }

    public class Cat
    {
        public string title { get; set; }
    }

    public class RemoveCat
    {
        public string title { get; set; }
    }

    public class Result
    {
        public bool forceLogout { get; set; }
        public List<Datum> data { get; set; }
        public List<Remove> remove { get; set; }
        public List<Cat> cats { get; set; }
        public List<RemoveCat> remove_cats { get; set; }
        public bool hastNextPage { get; set; }
    }

    public class RootObject
    {
        public Dialog dialog { get; set; }
        public Result result { get; set; }
    }

    public class image
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string name { get; set; }

    }

    public class MyContext : DbContext
    {
        //public MyContext(string connectionstring)
        //    : base("Data Source= " + connectionstring + ";Initial Catalog=realstate;Trusted_Connection=Yes;App=EntityFramework")
        //{

        //}
        public MyContext()
            //: base(@"Data Source=(localDB)\v11.0;Initial Catalog=myrealstate;Integrated Security=True; AttachDBFilename=|DataDirectory|myrealstatedes.mdf ")
            : base("MyConnection3")
        {

        }
        public DbSet<Datum> Data { get; set; }
        public DbSet<image> images { get; set; }
    }
}
