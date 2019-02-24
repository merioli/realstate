using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace realstate
{
    class lisener
    {
        public queryModel queryModel { get; set; }
        public bool workercontinu { get; set; }
        public string loginDB { get; set; }
        public login loginmodel { get; set; }
        public Socket newsocket { get; set; }
        public byte[] b { get; set; }
        public int   RecievedByteCount { get; set; }
        public string  message { get; set; }
        public string  id { get; set; }
        public Datum datumselected { get; set; }
        public byte[] imagenum  { get; set; }

        public int imageNumberSent { get; set; }
        public string  imageurlForDownload { get; set; }
        public int counter { get; set; }

    }
    class queryModel
    {
        public string cat { get; set; }
        public string kind { get; set; }
        public string area { get; set; }
        public string metrajfrom    { get; set; }
        public string metrajto   { get; set; }
        public string ejarefrom { get; set; }
        public string ejareto { get; set; }
        public string vadiefrom { get; set; }
        public string vadieto { get; set; }
        public string room { get; set; }
       
    }
    class login 
    {
        public string  name { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string  password { get; set; }
    }
    class loginback
    {
        public string status { get; set; }
        public string token { get; set; }
        public CatsAndAreasObject autocompleteObject { get; set; }
     
    }
}
