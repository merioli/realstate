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
}
