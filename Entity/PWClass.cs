using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PWClass
    {
        private string name;
        private string pw;

        public PWClass(string name,string pw)
        {
            this.name = name;
            this.pw = pw;
        }

        public PWClass() { }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Pw
        {
            get
            {
                return pw;
            }

            set
            {
                pw = value;
            }
        }

        public override string ToString()
        {
            return this.Name + "";
        }
    }
}
