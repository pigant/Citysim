using System;

namespace Citysim
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Setting.load();
            using (var game = new Citysim())
                game.Run();
        }
    }
#endif
}
