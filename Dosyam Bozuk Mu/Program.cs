using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosyam_Bozuk_Mu
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        ///
        /// The main entry point for the application.
        ///
        [STAThread]
        static void Main(string[] args)
        {
            string mode = args.Length > 0 ? args[0] : "gui";//Argüman boş ise mode gui yapılıyor.

            if (mode == "gui")
            {
                MessageBox.Show("Program GUI modunda çalışacak");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else if (mode == "console")
            {
                IntPtr ptr = GetForegroundWindow();
                int u;
                GetWindowThreadProcessId(ptr, out u);
                Process process = Process.GetProcessById(u);

                if (process.ProcessName == "cmd")    //console modunda uygulama cmd ekranında mı çalıştırıldı?
                {
                    AttachConsole(process.Id);

                    //cmd'den çalışıyor
                    Console.WriteLine("CMD Modu");
                    //Diğer Kodlar
                }
                else
                {
                    //Yeni console oluşturuluyor...
                    AllocConsole();

                    Console.WriteLine("Normal CONSOLE modu açıldı");
                    Console.WriteLine("Devam etmek için bir tuşa basın ...");
                    Console.ReadLine();
                    //Diğer Kodlar
                }
                FreeConsole();
            }
        }
    }
}
