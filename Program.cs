//using System;
//using System.Windows.Forms;

//namespace MusicDLP
//{
//    internal static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        private static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.ThreadException += Application_ThreadException;
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new MainForm());
//        }

//        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
//        {
//            MessageBox.Show("An unknown error has occurred: " + e.Exception.Message + "\n\nThe application will now exit to prevent further glitches/damages.", "Oopsies!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
//            Application.Exit();
//        }
//    }
//}