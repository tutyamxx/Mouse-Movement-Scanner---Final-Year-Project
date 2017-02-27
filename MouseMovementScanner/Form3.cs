using System;
using System.Runtime.InteropServices;
using System.Media;
using System.Windows.Forms;

namespace MouseMovementScanner
{
    public partial class Form3 : Form
    {
        // --| Invoke flashwindow from Windows to use it for our Warning Form
        // --| It will flash on taskbar with orange
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        public Form3()
        {
            InitializeComponent();
        }

        // --| User clicked "Okay." button
        // --| Disable flashing and close the application form
        // --| Stop the alarm sound since user has been informed already and he clicked okay. button
        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer CustomSound = new SoundPlayer(Properties.Resources.alarm);
            CustomSound.Stop();

            this.TopMost = false;
            this.Close();
        }

        // --| When application form loads, we do the following:
        // --| + Make it "always on top" of other window applications
        // --| + Make it flash for notification
        // --| + Display log: Current Day, Date, Time when mouse was moved
        // --| + Since the sound is looping all over, user needs to click the "Okay." button in order to stop it
        private void Form3_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            FlashWindow(this.Handle, true);

            string strDay = DateTime.Now.DayOfWeek.ToString();
            string strDate = System.DateTime.Today.ToShortDateString();
            string strTime = DateTime.Now.ToString("hh:mm:ss tt");

            string strLogDetails = Environment.NewLine + "Day: " + strDay + Environment.NewLine + "Date: " + strDate + Environment.NewLine + "Time: " + strTime;
            txtbox_Log.Text = strLogDetails;
        }
    }
}
