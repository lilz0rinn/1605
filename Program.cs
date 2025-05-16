using System;
using System.Windows.Forms;
using TaskManager.View;
using TaskManager.Presenter;

namespace TaskManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new TaskForm();
            var presenter = new TaskPresenter(form);
            Application.Run(form);
        }
    }
}