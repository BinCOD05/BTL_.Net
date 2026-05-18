using BTL_QLSV.DAL;

namespace BTL_QLSV
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new GUI.fDangNhap());
        }
    }
}
