using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class Rootobject
    {
        public Bear[] Property1 { get; set; }
    }

    public class Bear
    {
        public string name { get; set; }
        public string description { get; set; }
        public float[] location { get; set; }
    }

}