using System;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;

using Gma.System.MouseKeyHook;

namespace MouseMovementScanner
{
    public partial class Form1 : Form
    {
        // --| =============================================================================================== |--
        // --| Start of DLL Imports to make programming easy                                                   |--
        // --| =============================================================================================== |--



        // --| Invoke flashwindow from Windows to use it for our Warning Form
        // --| It will flash on taskbar with orange
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        // --| Importing function from windows to allow us to easily lock the windows
        // --| without hardcoding CMD.exe file 
        [DllImport("user32")]
        public static extern void LockWorkStation();

        // --| Importing function from windows to allow us to detect if the system is in IDLE state so we can use it in our code
        // --| This function checks if there is any input received into the system. This way we can check if the system is idling or not
        [DllImport("user32.dll")]
        public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);

        public struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public Int32 dwTime;
        }

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

        // --| Global Mouse and keyboard Hook from GITHUB OPEN SOURCE PROJECT:
        // --| I DID NOT MODIFY IT! IT COMES IN SOURCE CODE SO I JUST COMPILED IT! https://github.com/gmamaladze/globalmousekeyhook/tree/vNext/MouseKeyHook
        // --| https://globalmousekeyhook.codeplex.com/
        // --| https://github.com/gmamaladze/globalmousekeyhook/tree/vNext/Demo
        // --| All the documentation is there + open source hook
        private IKeyboardMouseEvents m_GlobalHook;



        // --| ============================================================================================= |--
        // --| End of DLL Imports to make programming easy                                                   |--
        // --| ============================================================================================= |--


        // --| Get cursor current and old position on X and Y axis
        int CursorPositionX = 0, CursorPositionY = 0;
        int NewCursorPositionX = 0, NewCursorPositionY = 0;

        // --| Default timer 2 interval to 0
        int TimerInterval = 0;

        // --| Default IDLE setting interval to 0
        int IdleInterval = 0;

        // --| Hardcode travel difference to calculate difference between mouse x and y positions to 75
        int TravelDifference = 75;

        // --| Create a boolean variable to check if the warning was already displayed, so we avoid duplication of the same form in case
        // --| MOUSE AND KEYBOARD WAS MOVED/PRESSED in the same time
        // --| NON ORTHODOX WAY BUT I NEED IT. Since the compiler thinks i haven't used the boolean in the code and is defined but never used,
        // --| we disable the warning because (glitch on compiler). It is just a warning and i know it does not affect my program anyway
        // --| "Warning	CS0414	The field 'Form1.isScannerDetected' is assigned but its value is never used"
        #pragma warning disable 414, 0414
            bool isScannerDetected = false;
        #pragma warning restore 0414

        // --| Create timer2 because we need to add some functionalities in code
        Timer timer2 = new Timer();

        public Form1()
        {
            InitializeComponent();

            // --| Disable form border and draw round corners/borders
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 17, 17));

            // --| We have to manually bind the ballontip clicked event in order to work
            notifyIcon1.BalloonTipClicked += new EventHandler(notifyIcon1_BalloonTipClicked);

            // --| If the program was opened for the first time, we load combobox values by default
            comboBox_StartSelection.SelectedIndex = 4;
            comboBox_IdleTime.SelectedIndex = 1;
            chckBox_Mouse.Checked = true;

            // --| Subscribe our global hook
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }

        // --| Subscribe the global hook event
        public void Subscribe(IKeyboardMouseEvents events)
        {
            // --| Note: for the application hook, use the Hook.AppEvents() instead
            // --| According to source -->  The KeyPress event is not raised by non-character keys; however, the non-character keys do raise the KeyDown and KeyUp events.
            // --| We hook keydown to also check if user pressed arrow, print screen, esc etc
            m_GlobalHook = events;
            m_GlobalHook.KeyDown += HookKeyDown;
        }

        // --| Event for key press from Global Mouse and Keyboard hook
        public void HookKeyDown(object sender, KeyEventArgs e)
        {
            // --| If user presses End KEY while one of the scanners are running, in this way we detect that he knows what key to press
            // --| and we know is the computer admin/owner so we stop the scanners
            if (e.KeyCode == Keys.End)
            {
                if(ScannerTimer.Enabled == true || timer2.Enabled == true)
                {
                    // --| We stop all our timers and scanners since user pressed F2 key so we know he is the owned or the computer
                    ScannerTimer.Stop();
                    ScannerTimer.Enabled = false;

                    timer2.Stop();
                    timer2.Enabled = false;

                    // --| Play a feedback soun so owner knows that program has detected his End shortcut and disabled scanners
                    // --| SOUND TAKEN FOR FREE FROM http://soundjax.com/alarm-1.html
                    SoundPlayer StoppedSound = new SoundPlayer(Properties.Resources.stopped);
                    StoppedSound.Play();
                }

                else if(IdleChekTimer.Enabled == true || chkBox_Idle.Checked == true)
                {
                    // --| Disable idle scanner
                    IdleChekTimer.Stop();
                    IdleChekTimer.Enabled = false;

                    // --| Uncheck "Auto-Start if system is idle" checkbox
                    chkBox_Idle.Checked = false;

                    // --| Re-enable our start scanner button and dropdown list
                    btn_StartScanner.Enabled = true;
                    comboBox_StartSelection.Enabled = true;

                    // --| Play a feedback soun so owner knows that program has detected his End shortcut and disabled scanners
                    // --| SOUND TAKEN FOR FREE FROM http://soundjax.com/alarm-1.html
                    SoundPlayer StoppedSound = new SoundPlayer(Properties.Resources.stopped);
                    StoppedSound.Play();
                }

                // --| Disable radar.GIF animation
                pictureBox2_Scanner.Enabled = false;

                // --| Disable value for scanner detection
                isScannerDetected = false;

                return;
            }

            // --| If "Keyboard" checkbox is checked then our scanner will detect keypress
            if (chkBox_Keyboard.Checked == true)
            {
                if (ScannerTimer.Enabled == true && timer2.Enabled == false)
                {
                    // --| Our scanner has detected something so we turn it to true value
                    isScannerDetected = true;

                    // --| Do what user selected in settings
                    AlertAndProtect();
                }
            }
        }

        // --| When timer1 "scanner" is active, we check old and new cursor positions and then do the following things according to user checkbox settings:
        // --| If checkbox "Play a sound on detection" is checked, we play a custom sound on mouse movement detection
        // --| If checkbox "lock windows on movement detection" is checked, we lock the workstation
        // --| We display a warning window to the user where we specify detection date and time and information
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(chckBox_Mouse.Checked == true)
            {
                NewCursorPositionX = Cursor.Position.X;
                NewCursorPositionY = Cursor.Position.Y;

                // --| Now we need so math, not rocket science but math. We need to detect if mouse was moved by a person and not accidentaly by the mouse itself
                // --| Sometimes the mouse moves by itself because sensor causes tracking issues. 
                // --| We hardcoded a travel difference integer and we calculate the difference between point X and Y and if the difference is more than travel difference then we are good
                int deltaX = (NewCursorPositionX - CursorPositionX);
                int deltaY = (NewCursorPositionY - CursorPositionY);

                // --| Calculate the difference
                int CalculateDifference = (deltaX * deltaX) + (deltaY * deltaY);

                if (CalculateDifference > TravelDifference)
                {
                    isScannerDetected = true;

                    // --| Do what user selected in settings
                    AlertAndProtect();
                }
            }
        }

        // --| User clicked Start Scanner button
        // --| If the user is clicking the button again, we display him a warning that a process of starting the scanner already exists
        // --| Set timings in miliseconds for dropdown list items
        private void button1_Click(object sender, EventArgs e)
        {
            // --| If there is no keyboard or mouse device checked in the "Device Detection", we throw an error displaying the following message
            if (chkBox_Keyboard.Checked == false && chckBox_Mouse.Checked == false)
            {
                MessageBox.Show("Can't start the Scanner...\n\nTry to select at least one device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (timer2.Enabled == true)
            {
                string strMessage = "";

                // --| A simple conversion. if the timer is less or equal to one minute we display timing in seconds
                if(TimerInterval <= 60000)
                {
                    double TimerMilisecondsToSeconds = TimeSpan.FromMilliseconds(TimerInterval).TotalSeconds;

                    strMessage = "Scanner is about to start in " + TimerMilisecondsToSeconds + " seconds!";
                }

                // --| If the timer is more or equal to one minute we display timing in minutes
                else
                {
                    double TimerMilisecondsToMinutes = TimeSpan.FromMilliseconds(TimerInterval).TotalMinutes;

                    strMessage = "Scanner is about to start in " + TimerMilisecondsToMinutes + " minutes!";
                }

                MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // --| Get Scanner Start Delay value from dropdown list
            StartSelectionDropDownlistCheck();

            // --| Enable radar.GIF animation
            pictureBox2_Scanner.Enabled = true;

            // --| We create the delay before starting the scanner, so we can allow user to use the mouse for a small/large amount of time
            timer2.Interval = (TimerInterval);
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();     
            timer2.Enabled = true;
        }

        // --| User clicked on the mouse picture box, now we display the about page
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 AboutForm = new Form2();
            AboutForm.Show();
        }

        // --| User clicked "_" minimise custom button, so we minimise the application to task tray and hide the form
        // --| Also we display a popup ballon tip with application name and informing user that the application is running on background
        // --| Also a small tip that if the icon is double-clicked the application will maximise again
        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

            if(FormWindowState.Minimized == WindowState)
            {
                Hide();

                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1500, "Mouse Movement Scanner", "Your program is running on background now!\nDouble-click this icon to display it again or click this balloon!", ToolTipIcon.Info);
            }
        }

        // --| When program starts, we disable every scanning timer and set the default value for combobox Scanner Start Delay to 4 (1 Minute)
        // --| And set the default value for combobox IDLE Control to 1 (5 minutes)
        // --| We also disable the notification icon, since our program is maximised and we do some more settings
        private void Form1_Load(object sender, EventArgs e)
        {
            // --| If program was reopened and user made settings on the program, we load saved settings
            // --| Load saved values for checkbox setting made by the user
            chkBox_Startup.Checked = Properties.Settings.Default.RunonStartup_Setting;
            chkBox_StartMin.Checked = Properties.Settings.Default.Startminimized_Setting;
            chkBox_Alert.Checked = Properties.Settings.Default.Playsound_Setting;
            chkBox_Lock.Checked = Properties.Settings.Default.Lockmachine_Setting;
            chkBox_Idle.Checked = Properties.Settings.Default.AutoStartonIdle_Setting;
            chkBox_Keyboard.Checked = Properties.Settings.Default.DeviceKeyboard_Settings;
            chckBox_Mouse.Checked = Properties.Settings.Default.DeviceMouse_Settings;

            // --| Load dropdown lists settings made by the user
            comboBox_StartSelection.SelectedIndex = Properties.Settings.Default.StartDelay_Setting;
            comboBox_IdleTime.SelectedIndex = Properties.Settings.Default.IdleControl_Settings;

            // --| Disable radar.GIF animation
            pictureBox2_Scanner.Enabled = false;

            // --| If checkbox "Auto-Start if system is idle is checked" we start our idle check timer
            if (chkBox_Idle.Checked == true)
            {
                IdleChekTimer.Start();
                IdleChekTimer.Enabled = true;

                // --| Enable radar.GIF animation
                pictureBox2_Scanner.Enabled = true;

                // --| We also disable "Start Scanner" button and "Scanner Delay" dropdown list
                comboBox_StartSelection.Enabled = false;
                btn_StartScanner.Enabled = false;
            }

            // --| Reset our scanners
            ScannerTimer.Enabled = false;
            timer2.Enabled = false;
            IdleChekTimer.Enabled = false;

            isScannerDetected = false;
            notifyIcon1.Visible = false;


            // --| We start our program minimised to system tray
            if (chkBox_StartMin.Checked == true)
            {
                WindowState = FormWindowState.Minimized;

                if (FormWindowState.Minimized == WindowState)
                {
                    Hide();

                    notifyIcon1.Visible = true;
                    this.ShowInTaskbar = false;
                }
            }

            // --| If the program is already opened, we disable multiple instances of the same program to be opened in the same time
            // --| Only one instance can be opened
            // --| We find our program process and if it is already running, we throw an information error and exit application


            // --| But what if user renames the exe file in something else? No problem, we get the current executable name and we dont allow it to run on
            // --| Multiple instances :p
            // --| Also it does work if you change the executable name 
            string ApplicationCurrentName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            Process[] pResult = Process.GetProcessesByName(ApplicationCurrentName);

            if(pResult.Length > 1)
            {
                MessageBox.Show("There is already a instance running!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                System.Environment.Exit(0);
            }
        }

        // --| Disable form double clicking so we can avoid bugs with maximise and custom layout design
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            return;
        }

        // --| Timer2 think
        // --| If ScannerTimer is not enabled, we enable it, we stop timer2 aswell
        // --| We get the current position of the cursor in X and Y axis
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ScannerTimer.Enabled != true)
            {
                CursorPositionX = Cursor.Position.X;
                CursorPositionY = Cursor.Position.Y;

                ScannerTimer.Start();
                ScannerTimer.Enabled = true;

                timer2.Stop();
                timer2.Enabled = false;
            }
        }

        // --| User clicked the "Stop Scanner" button
        // --| Now if the scanner is not running at all we throw an error message
        // --| If the scanner has been working but process was stopped by the button, we throw an info message
        // --| We also stop all scanners
        private void button1_Click_1(object sender, EventArgs e)
        {
            // --| If the "Auto-Start if system is idle" is checked, first we stop that
            if (chkBox_Idle.Checked == true)
            {
                chkBox_Idle.Checked = false;

                IdleChekTimer.Stop();
                IdleChekTimer.Enabled = false;

                isScannerDetected = false;

                // --| Disable radar.GIF animation
                pictureBox2_Scanner.Enabled = false;

                MessageBox.Show("Scanner Stopped", "Scanner has ben stopped.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            // --| If there is no scanner running, we throw an information
            if (timer2.Enabled == false)
            {
                MessageBox.Show("Scanner not running", "Scanner is not running!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            // --| We stop the scanners
            ScannerTimer.Stop();
            ScannerTimer.Enabled = false;

            timer2.Stop();
            timer2.Enabled = false;

            isScannerDetected = false;

            // --| Disable radar.GIF animation
            pictureBox2_Scanner.Enabled = false;

            MessageBox.Show("Scanner Stopped", "Scanner has ben stopped.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --| Idle timer scanner
        // --| We check if the computer is in idle state
        private void IdleChekTimer_Tick(object sender, EventArgs e)
        {
            // --| If there is no scanner started and checkbox "Auto-Start if system is idle" is ENABLED then we start our scanning time
            if (chkBox_Idle.Checked == true && ScannerTimer.Enabled == false && timer2.Enabled == false)
            {
                // --| Useful stuff to be able to get if system is idling
                tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();

                Int32 IdleTime;
                double IdleTimeInMinutes;

                LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
                LastInput.dwTime = 0;

                if (GetLastInputInfo(ref LastInput))
                {
                    // --| Get idle time in milliseconds and convert them to minutes
                    IdleTime = System.Environment.TickCount - LastInput.dwTime;
                    IdleTimeInMinutes = TimeSpan.FromMilliseconds(IdleTime).TotalMinutes;

                    // --| If system is idle is equal or more minutes that our specified time from combobox "IDLE Control" we enable the scanner
                    // --| We also disable Start Scanner button.
                    if (IdleTimeInMinutes >= IdleInterval)
                    {
                        if (ScannerTimer.Enabled != true)
                        {
                            // --| Get the current cursor position again and start the scanner
                            CursorPositionX = Cursor.Position.X;
                            CursorPositionY = Cursor.Position.Y;

                            ScannerTimer.Start();
                            ScannerTimer.Enabled = true;
                        }
                    }
                }
            }
        }

        private void chkBox_Idle_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBox_Idle.Checked == true)
            {
                // --| Check if the scanner is running or in process to start and throw a warning message to the user, while automatically unchecking the checkbox since we 
                // --| don't want two scanning processes to start at the same time
                if (ScannerTimer.Enabled == true || timer2.Enabled == true)
                {
                    chkBox_Idle.Checked = false;
                    MessageBox.Show("You need to turn off the Scanner first in order to use this setting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // --| Enable radar.GIF animation
                    pictureBox2_Scanner.Enabled = true;

                    return;
                }

                // --| If there is no device checked, throw an error
                if(chckBox_Mouse.Checked == false && chkBox_Keyboard.Checked == false)
                {
                    // --| Uncheck our "Auto-Start if system is idle" checkbox
                    chkBox_Idle.Checked = false;

                    MessageBox.Show("Try to select at least one device!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // --| Disable radar.GIF animation
                    pictureBox2_Scanner.Enabled = false;

                    return;
                }

                // --| If scanner is not running or not in process to start then we start it
                else
                {
                    // --| Get value from "Idle Control" Dropdown list
                    IdleIntervalDropdownListCheck();

                    // --| Enable radar.GIF animation
                    pictureBox2_Scanner.Enabled = true;

                    // --| Start searching if system is IDLE
                    IdleChekTimer.Start();
                    IdleChekTimer.Enabled = true;

                    // --| Since we don't want two timers to run at a time, when "Auto-Start if system is idle" is checked
                    // --| we disable "Start Scanner" button and we disable the "Scanner Start Delay" dropdown list
                    btn_StartScanner.Enabled = false;
                    comboBox_StartSelection.Enabled = false;
                }
            }

            // --| If checkbox is unchecked then we enable "Start Scanner" button and "Scanner Start Delay" dropdown list again
            // --| Also we disable the timer where it checks for system being idle or not
            if(chkBox_Idle.Checked == false)
            {
                btn_StartScanner.Enabled = true;
                comboBox_StartSelection.Enabled = true;

                // --| Disable radar.GIF animation
                pictureBox2_Scanner.Enabled = false;

                IdleChekTimer.Stop();
                IdleChekTimer.Enabled = false;
            }
        }

        // --| If the user double clicks on the notification icon, we display the program and remove the icon from taskbar
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;

            notifyIcon1.Visible = false;
            FlashWindow(this.Handle, true);
        }

        // --| If user clicks the ballon tooltip we show this form again and flash the window form
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;

            notifyIcon1.Visible = false;
            FlashWindow(this.Handle, true);
        }

        // --| User pressed "X" custom button, so we terminate the program
        private void button3_Click(object sender, EventArgs e)
        {
            // --| We save checkbox settings made by the user so when the programs reopens, we load saved values 
            Properties.Settings.Default.RunonStartup_Setting = chkBox_Startup.Checked;
            Properties.Settings.Default.Startminimized_Setting = chkBox_StartMin.Checked;
            Properties.Settings.Default.Playsound_Setting = chkBox_Alert.Checked;
            Properties.Settings.Default.Lockmachine_Setting = chkBox_Lock.Checked;
            Properties.Settings.Default.AutoStartonIdle_Setting = chkBox_Idle.Checked;
            Properties.Settings.Default.DeviceKeyboard_Settings = chkBox_Keyboard.Checked;
            Properties.Settings.Default.DeviceMouse_Settings = chckBox_Mouse.Checked;

            // --| We save dropdown list settings made by user so when the programs reopens, we load saved values 
            Properties.Settings.Default.StartDelay_Setting = comboBox_StartSelection.SelectedIndex;
            Properties.Settings.Default.IdleControl_Settings = comboBox_IdleTime.SelectedIndex;

            // --| Now we save the user settings
            Properties.Settings.Default.Save();

            // --| Unsubsrcibe the hook
            Unsubscribe();

            // --| Close program
            this.Close();
        }

        // --| Check if the checkbox for "Run on Windows Startup" is checked/unchecked and we do the following things:
        // --| Checked: Add the executable path to windows registry keys for run on startup
        // --| Unchecked: Remove the exectuable path from windows registry for run on startup
        private void chkBox_Startup_CheckedChanged(object sender, EventArgs e)
        {
            // --| Get Run path in "CURRENT_USER" registry in "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            // --| If checkbox "Run on Windows Startup" is:
            // --| Checked: We get the current program/executable path from user drive and set it to autostart in windows registry
            if (chkBox_Startup.Checked == true)
            {
                string exePath = Application.ExecutablePath;
                key.SetValue("Mouse Movement Scanner", exePath);
            }

            // --| Unchecked: We remove the program registry
            else if (chkBox_Startup.Checked == false)
            {
                key.DeleteValue("Mouse Movement Scanner", false);
            }
        }

        // --| Alert and do things according to user settings
        // --| I created this function to avoid code duplication since i am going to use it twice in keyboard press event hook and mouse movement
        public void AlertAndProtect()
        {
            // "Play a sound on detection" is checked so we play our alarm sound file on loop until he clicks "Okay." button on the other warning form
            if (chkBox_Alert.Checked)
            {
                SoundPlayer CustomSound = new SoundPlayer(Properties.Resources.alarm);
                CustomSound.PlayLooping();
            }

            // --| "lock windows on movement detection" is checked so we lock windows
            if (chkBox_Lock.Checked)
            {
                LockWorkStation();
            }

            // --| We stop all our timers and scanners since detection has been made
            ScannerTimer.Stop();
            ScannerTimer.Enabled = false;

            IdleChekTimer.Stop();
            IdleChekTimer.Enabled = false;

            // --| Display our warning form
            Form3 WarningForm = new Form3();
            WarningForm.Show();
        }

        // --| Get "Scanner Start Delay" value from dropdwon list
        // --| I created this function to avoid code duplication since i am going to use it on "Start Scanner" button click and on "Dropdownlist changed" event
        private void StartSelectionDropDownlistCheck()
        {
            // --| Set timers in milliseconds according to our dropdown list and convert it
            switch (comboBox_StartSelection.SelectedIndex)
            {
                case 0:
                    {
                        TimerInterval = 100;    // 100 miliseconds
                        break;
                    }

                case 1:
                    {
                        TimerInterval = 5000;   // 5 seconds
                        break;
                    }

                case 2:
                    {
                        TimerInterval = 15000;  // 15 seconds
                        break;
                    }

                case 3:
                    {
                        TimerInterval = 30000;  // 30 seconds
                        break;
                    }

                case 4:
                    {
                        TimerInterval = 60000;  // 1 minute
                        break;
                    }

                case 5:
                    {
                        TimerInterval = 300000; // 5 minutes
                        break;
                    }

                case 6:
                    {
                        TimerInterval = 600000; // 10 minutes
                        break;
                    }

                case 7:
                    {
                        TimerInterval = 1200000;    // 20 minutes
                        break;
                    }
            }

            // --| In case if user chose another value from "Scanner Start Delay" while pressed "Start Scanner" button and running, we
            // --| refresh the interval.
            timer2.Interval = (TimerInterval);
        }

        // --| Get "Idle Control" value from dropdwon list
        // --| I created this function to avoid code duplication since i am going to use it on "Dropdownlist changed" event and on checked/unchecked "Auto-Start if system is idle" checkbox
        // --| Also the interval is automatically converted to minutes so we have to convert 2 hours in minutes for example
        private void IdleIntervalDropdownListCheck()
        {
            switch (comboBox_IdleTime.SelectedIndex)
            {
                case 0:
                    {
                        IdleInterval = 1;   // 1 Minute
                        break;
                    }

                case 1:
                    {
                        IdleInterval = 5;   // 5 Minutes
                        break;
                    }

                case 2:
                    {
                        IdleInterval = 10;  // 10 Minutes
                        break;
                    }

                case 3:
                    {
                        IdleInterval = 15;  // 15 Minutes
                        break;
                    }

                case 4:
                    {
                        IdleInterval = 20;  // 20 Minutes
                        break;
                    }

                case 5:
                    {
                        IdleInterval = 30;  // 30 Minutes
                        break;
                    }

                case 6:
                    {
                        IdleInterval = 60; // 1 Hour
                        break;
                    }

                case 7:
                    {
                        IdleInterval = 120; // 2 Hours
                        break;
                    }

                case 8:
                    {
                        IdleInterval = 300; // 5 Hours
                        break;
                    }
            }
        }

        // --| If the user somehow wants to change the "Scanner Start Delay" value while the scanner is in process to start,
        // --| we update the value on selection to set the time according to the changes dinamically
        private void comboBox_StartSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // --| Get Scanner Start Delay value from dropdown list
            StartSelectionDropDownlistCheck();
        }

        // --| If the user somehow wants to change the "Idle Control" value while the scanner is in process to start,
        // --| we update the value on selection to set the time according to the changes dinamically
        private void comboBox_IdleTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // --| Get Idle Control value from dropdown list
            IdleIntervalDropdownListCheck();
        }

        // --| User unchecked device "Mouse"
        // --| If the Scanner or Auto-start on IDLE scanner is active, we disable them since we cannot run a scanner without having what to detect"
        private void chckBox_Mouse_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBox_Mouse.Enabled == false || chkBox_Keyboard.Checked == false)
            {
                if (ScannerTimer.Enabled == true || timer2.Enabled == true)
                {
                    // --| We stop all our timers and scanners since detection has been made
                    ScannerTimer.Stop();
                    ScannerTimer.Enabled = false;

                    timer2.Stop();
                    timer2.Enabled = false;

                    // --| Disable radar.GIF animation
                    pictureBox2_Scanner.Enabled = false;

                    MessageBox.Show("Scanner stopped, please select at least one device!", "Scanner Stopped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if(IdleChekTimer.Enabled == true)
                {
                    // --| Uncheck our "Auto-Start if system is idle" checkbox
                    chkBox_Idle.Checked = false;

                    // --| Disable radar.GIF animation
                    pictureBox2_Scanner.Enabled = false;

                    IdleChekTimer.Stop();
                    IdleChekTimer.Enabled = false;

                    MessageBox.Show("Scanner stopped, please select at least one device!", "Scanner Stopped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        // --| User unchecked device "Keyboard"
        // --| If the Scanner or Auto-start on IDLE scanner is active, we disable them since we cannot run a scanner without having what to detect"
        private void chkBox_Keyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_Keyboard.Enabled == false || chckBox_Mouse.Checked == false)
            {
                if (ScannerTimer.Enabled == true || timer2.Enabled == true)
                {
                    // --| We stop all our timers and scanners since detection has been made
                    ScannerTimer.Stop();
                    ScannerTimer.Enabled = false;

                    timer2.Stop();
                    timer2.Enabled = false;

                    // --| Disable radar.GIF animation
                    pictureBox2_Scanner.Enabled = false;

                    MessageBox.Show("Scanner stopped, please select at least one device!", "Scanner Stopped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (IdleChekTimer.Enabled == true)
                {
                    // --| Uncheck our "Auto-Start if system is idle" checkbox
                    chkBox_Idle.Checked = false;

                    // --| Disable radar.GIF animation
                    pictureBox2_Scanner.Enabled = false;

                    IdleChekTimer.Stop();
                    IdleChekTimer.Enabled = false;

                    MessageBox.Show("Scanner stopped, please select at least one device!", "Scanner Stopped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        // --| Event for moving the form around while having custom design applied to it
        // --| http://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)(HT_CAPTION);
            }
        }

        // --| We unsubscribe the global hook
        public void Unsubscribe()
        {
            if (m_GlobalHook == null)
            {
                return;
            }

            // --| Unsubscribe keypress event
            m_GlobalHook.KeyDown -= HookKeyDown;

            // --| It is recommened to dispose it
            m_GlobalHook.Dispose();
            m_GlobalHook = null;
        }
    }
}
