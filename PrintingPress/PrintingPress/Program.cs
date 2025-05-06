namespace PrintingPress
{

    /*
     * NEXT:
     * TESTS. DONE for service
     * Think about making settings better looking. Adding the ability to have some settings like
     * showing notifications and to preserve those settings.
     * Add another option in icon tray to show current look of the text in memory. DONE
     */
    internal static class Program
    {
        private static CustomAppContext? customAppContext;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            customAppContext = new();
            Application.Run(customAppContext);
        }
    }
}