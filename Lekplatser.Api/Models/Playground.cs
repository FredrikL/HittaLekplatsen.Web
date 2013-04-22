using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lekplatser.Api.Models
{
    public class Playground
    {
        public Playground()
        {
            
        }

        public string PlaygroundId { get; set; }

        public float Lat { get; set; }
        public float Long { get; set; }

        public float Rating { get; set; }

        public bool HasSwing { get; set; }
        public bool HasSlide { get; set; }
        public bool HasSandbox { get; set; }

    }
}