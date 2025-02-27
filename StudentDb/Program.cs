// Date         Name            Description
// 2/13/25      harmansb        Created student object, DbApp object, and a MainTestDriver method


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDb
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // using singlton pattern - db app will be a single object
            DbApp app = new DbApp();


        }        
    }
}
