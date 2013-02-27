using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EnjoyConsole
{
    class Program
    {
        private static async void Test()
        {
            Task<int> t = new Task<int>(() => { Thread.Sleep(3000); return 1; });
            t.Start();
            int tr = await t;
            Console.WriteLine(tr);
        }

        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Main");
            Console.ReadKey();
        }
    }
}
