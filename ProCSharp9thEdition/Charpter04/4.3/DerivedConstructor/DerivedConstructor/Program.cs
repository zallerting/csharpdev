using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedConstructor
{
    abstract class GenericCustomer
    {
        private string name;
        public GenericCustomer(string name)
        {
            this.name = name;
        }
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
    }
    class Nevermore60Customer : GenericCustomer
    {
        private uint highCostMinutesUsed;
        private string referenceName;
        public Nevermore60Customer(string name, string referenceName)
            : base(name)
        {
            this.referenceName = referenceName;
        }
        public Nevermore60Customer(string name)
            : this(name,"<no name>")
        {

        }
        static void Main(String[] args)
        {
            GenericCustomer customer = new Nevermore60Customer("Zaller Ting");
            Console.WriteLine("referenceName is " + new Nevermore60Customer("").referenceName);
            Console.Read();
        }
    }
}
