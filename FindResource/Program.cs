using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindResource
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenImage oi = new OpenImage("dude_animation_set.png", "dude.animation_set_index");
            oi.open();
        }
    }
}
