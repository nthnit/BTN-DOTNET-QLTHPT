using System;
using System.Windows.Forms;

namespace QLTHPT.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // TODO: Khởi tạo form chính của ứng dụng
            // Application.Run(new MainForm());
            
            MessageBox.Show("Hệ thống Quản lý Trường THPT\nCấu trúc project đã được tạo thành công!",
                           "QLTHPT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
