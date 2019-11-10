using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp.Model
{
    public class Compare : BaseVM
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime ChangeData { get; set; }
        public string State { get; set; }

    }
}
