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
        public string server_id { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public int isWished { get; set; }
        public List<string> images { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string area { get; set; }
        public string areaID { get; set; }
        public string build_year { get; set; }
        public bool canbeAgent { get; set; }
        public bool isAgent { get; set; }
        public bool countryside { get; set; }
        public string room { get; set; }
        public string metraj { get; set; }
        public string kind { get; set; }
        public string cat { get; set; }
        public string vadie { get; set; }
        public string ejare { get; set; }
        public string tabdil { get; set; }
        public string total { get; set; }
        public string phone { get; set; }
        public string phone_hidden { get; set; }
        public string email { get; set; }
        public string source { get; set; }
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
        public bool forceRemoveAll { get; set; }
        public bool forceLogout { get; set; }
        public List<Datum> data { get; set; }
        public int data_count { get; set; }
        public int today_files { get; set; }
        public object remove { get; set; }
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


    public class Cats2
    {
        public string ID { get; set; }
        public string title { get; set; }
    }

    public class Areas2
    {
        public string ID { get; set; }
        public string title { get; set; }
    }


    public class Category
    {
        public string ID { get; set; }
        public string title { get; set; }
    }

    public class Result2
    {
        public List<Cats2> cats2 { get; set; }
        public List<Areas2> areas2 { get; set; }
        public List<Category> category { get; set; }
    }
    public class CatsAndAreasObject
    {
        public Result2 result2 { get; set; }
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
