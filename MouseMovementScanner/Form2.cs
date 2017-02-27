using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MouseMovementScanner
{
    public partial class Form2 : Form
    {
        // --| =============================================================================================== |--
        // --| Start of DLL Imports to make programming easy                                                   |--
        // --| =============================================================================================== |--

        // --| Importing this function from GDI we can create rounded corners/borders to our main form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect, // x-coordinate of upper-left corner
           int nTopRect, // y-coordinate of upper-left corner
           int nRightRect, // x-coordinate of lower-right corner
           int nBottomRect, // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );

        // --| Using this, since we have custom form design layout, and form border style set to none,
        // --| we can drag and drop/click and move the form wherever we want.
        // --| By default, form cannot be moved
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        // --| ============================================================================================= |--
        // --| End of DLL Imports to make programming easy                                                   |--
        // --| ============================================================================================= |--

        public Form2()
        {
            InitializeComponent();

            // --| Disable form border and draw round corners/borders
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 17, 17));
        }

        // --| Clicked Okay. button, we close the application form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --| Disable form double clicking so we can avoid bugs with maximise and custom layout design
        private void Form2_DoubleClick(object sender, EventArgs e)
        {
            return;
        }

        // --| Clicked university of huddersfield label, we redirect to university website
        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.hud.ac.uk/");
        }

        // --| Event for moving the form around
        // --| http://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)(HT_CAPTION);
            }
        }
    }
}
