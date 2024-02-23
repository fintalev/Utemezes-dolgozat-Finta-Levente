using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0223
{
    internal class utemezesbeolv
    {
        public int kezdho { get; set; }
        public int kezdnap { get; set; }
        public int vegho { get; set; }
        public int vegnap { get; set; }
        public string gyerekek { get; set; }
        public string tabornev { get; set; }

        public utemezesbeolv(string sor)
        {
            var v=sor.Split('\t');

            kezdho = int.Parse(v[0]);
            kezdnap = int.Parse(v[1]);
            vegho = int.Parse(v[2]);
            vegnap = int.Parse(v[3]);
            gyerekek = v[4];
            tabornev = v[5];
        }
    }
}
