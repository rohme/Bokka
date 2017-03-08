using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bokka
{
    static class Bokka
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            System.Environment.Exit(0); //プログラム終了
        }
    }
}
