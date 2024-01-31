namespace WebLoader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string startDoc = "";
            if (args.Length > 0) { startDoc = args[0]; }
            if (startDoc == "") { Application.Run(new WebBroForm()); }
            else
                { Application.Run(new WebBroForm(startDoc)); }
        }
    }
}