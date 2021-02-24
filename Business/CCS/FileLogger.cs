using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()//yapılan operasyonun bir yerde kaydının tutmaya loglama denir.
        {
            Console.WriteLine("Dosyaya loglandı");
        }
    }
}
