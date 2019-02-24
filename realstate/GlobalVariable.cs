using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realstate
{
    class GlobalVariable
    {
        public static string  serverIP { get; set; }
        public static bool showimage { get; set; }
        public static String ConnectionString_IP= "Output.txt"; // Modifiable
        //public static readonly String CODE_PREFIX = "US-"; // Unmodifiable
        public static int port { get; set; }
        public static string  token { get; set; }
        public static  CatsAndAreasObject catsAndAreas { get; set; }
        public static string result { get; set; }
        public static int portlimit { get; set; }
    }

}
