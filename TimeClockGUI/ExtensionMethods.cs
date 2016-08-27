using System.Windows.Forms;

namespace TimeClock.GUI
{
    public static class ExtensionMethods
    {
        public static void ShowErrorMessage(this Form form, string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
