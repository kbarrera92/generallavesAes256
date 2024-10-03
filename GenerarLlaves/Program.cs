using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarLlaves
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "XSFu0BuSCe54F4ViMppMDPVmVfZIhchM2ElsX/eSlSI=";
            string iv = "/pRr62jWZ4blEjlNshBr3w==";

            //AESHelper.GenerarClaveYIV(out key, out iv);

            Console.WriteLine(key);
            Console.WriteLine(iv);

            Console.WriteLine();
            var cs = Console.ReadLine();

            Console.WriteLine(AESHelper.Encriptar(cs, key, iv));
            Console.ReadKey();
        }
    }
}
