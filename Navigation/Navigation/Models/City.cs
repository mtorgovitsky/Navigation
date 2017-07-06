using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Models
{
    public enum LayoutName
    {
        Stack,
        Absolute,
        Relative,
        Grid
    }
    public class City
    {
        public string Name { get; set; }
        public LayoutName CurrentLayout { get; set; }
    }
}
