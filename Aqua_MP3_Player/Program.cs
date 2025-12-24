namespace Aqua_MP3_Player
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            }
            catch
            {

            }

            Application.SetCompatibleTextRenderingDefault(false);



            Application.Run(new Form1());
        }
    }
}