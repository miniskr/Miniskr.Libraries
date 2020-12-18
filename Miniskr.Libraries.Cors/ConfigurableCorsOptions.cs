using System;
using System.Collections.Generic;

namespace Miniskr.Libraries.Cors
{
    public class ConfigurableCorsOptions
    {
        public bool AnyOrigin { get; set; }
        public bool AnyHeader { get; set; }
        public bool AnyMethod { get; set; }

        public List<string> Origins { get; } = new List<string>();
        public List<string> Headers { get; } = new List<string>();
        public List<string> Methods { get; } = new List<string>();

        //public CorsPlolcy ToPolicy()
        //{

        //}
    }
}
