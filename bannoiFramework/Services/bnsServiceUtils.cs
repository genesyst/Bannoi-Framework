using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Services
{
    public enum WorkRound {wrDay,wrNight }

    public partial class bnsServiceUtils
    {
        public Regex isEng;
        public Regex isThi;

        public bnsServiceUtils()
        {
            isEng = new Regex("^[a-zA-Z]*$");
            isThi = new Regex("^[ก-๙]*$");
        }

        public static bool IsValidEmailPattern(string emailaddress)
        {
            try
            {
                if (String.IsNullOrEmpty(emailaddress)) return false;
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }

        public static bool IsWinXPOrHigher()
        {
            OperatingSystem OS = Environment.OSVersion;
            return (OS.Platform == PlatformID.Win32NT) && ((OS.Version.Major > 5) || ((OS.Version.Major == 5) && (OS.Version.Minor >= 1)));
        }

        public static bool IsWinVistaOrHigher()
        {
            OperatingSystem OS = Environment.OSVersion;
            return (OS.Platform == PlatformID.Win32NT) && (OS.Version.Major >= 6);
        }

        public static string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                MessageBox.Show("Error");
                return source;
            }
        }

        public static string IntToStringDigitPos(int Value, int digitCount)
        {
            string Res = Value.ToString();
            string dig = "";
            for (int i = Res.Length; i < digitCount; i++)
            {
                dig += "  ";
            }
            Res = dig + Res;
            return Res;
        }

        public static string IntToStringDigit(int Value, int digitCount)
        {
            string Res = Value.ToString();
            string dig = "";
            for (int i = Res.Length; i < digitCount; i++)
            {
                dig += "0";
            }
            Res = dig + Res;
            return Res;
        }

        public static bool isNumber(string value)
        {
            int i = 0;
            bool isINT = int.TryParse(value, out i);
            return isINT;
        }

        public static bool isDateTime(string value)
        {
            DateTime dt = DateTime.Now;
            bool isDateTime = DateTime.TryParse(value, out dt);
            return isDateTime;
        }

        public static Color HexToColor(String hexString)
        // Translates a html hexadecimal definition of a color into a .NET Framework Color.
        // The input string must start with a '#' character and be followed by 6 hexadecimal
        // digits. The digits A-F are not case sensitive. If the conversion was not successfull
        // the color white will be returned.
        {
            Color actColor;
            int r, g, b;
            r = 0;
            g = 0;
            b = 0;
            if ((hexString.StartsWith("#")) && (hexString.Length == 7))
            {
                r = Convert.ToInt32(hexString.Substring(1, 2), 16);
                g = Convert.ToInt32(hexString.Substring(3, 2), 16);
                b = Convert.ToInt32(hexString.Substring(5, 2), 16);
                actColor = Color.FromArgb(r, g, b);
            }
            else
            {
                actColor = Color.White;
            }
            return actColor;
        }

        public static int DiffDay(DateTime dt1, DateTime dt2)
        {
            int Res = 0;
            DateTime d1 = new DateTime(dt1.Year, dt1.Month, dt1.Day);
            DateTime d2 = new DateTime(dt2.Year, dt2.Month, dt2.Day);
            if (d1 == d2)
            {
                Res = 1;
            }
            else
            {
                TimeSpan diffTime = d2 - d1;
                Res = diffTime.Days;
            }
            return Res;
        }

        public static double DiffTime_resHourAndMinute(TimeSpan ts1, TimeSpan ts2)
        {
            double Res = 0;
            TimeSpan res = new TimeSpan();
            res = ts2.Subtract(ts1);

            double mintoH = (res.Minutes / 60.00);
            Res = res.Hours + mintoH;
            return Res;
        }

        public static char disableKeyChar(char inputChar, char[] disableChar)
        {
            char Res = inputChar;
            foreach (char disChar in disableChar)
            {
                if (disChar == inputChar) Res = (char)0;
            }
            return Res;
        }

        public static void setMCHTime(string connStr)
        {
            try
            {
                if (bnsServiceUtils.IsWinVistaOrHigher())
                {
                    if (String.IsNullOrEmpty(connStr))
                    {
                        connStr = Properties.Settings.Default.defaultConnectionString;
                    }

                    DateTime sysTime = new DateTime();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand cmd = new SqlCommand("SELECT GETDATE() AS SERVERTIME", conn);
                    try
                    {
                        conn.Open();
                        sysTime = (DateTime)cmd.ExecuteScalar();
                        new setLocalTime().setTime(sysTime);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
            catch { throw; }
        }
    }

    #region system class

    public partial class serviceInputlang
    {
        /// <summary>
        /// Changing Current Input Language to a next installed language
        /// </summary>
        public static void ChangeInputLanguage()
        {
            // Nothing to do if there is only one Input Language supported:
            if (InputLanguage.InstalledInputLanguages.Count == 1)
                return;
            // Get index of current Input Language
            int currentLang = InputLanguage.InstalledInputLanguages.IndexOf(InputLanguage.CurrentInputLanguage);
            // Calculate next Input Language
            InputLanguage nextLang = ++currentLang == InputLanguage.InstalledInputLanguages.Count ?
               InputLanguage.InstalledInputLanguages[0] : InputLanguage.InstalledInputLanguages[currentLang];
            // Change current Language to the calculated:
            ChangeInputLanguage(nextLang);
        }
        /// <summary>
        /// Changing current Input Language to a new one passed in the param
        /// </summary>
        /// <param name="ISOLang">ISO Culture name string code e.g. "en" for English</param>
        public static void ChangeInputLanguage(string ISOLang)
        {
            // Convert ISO Culture name to InputLanguage object. Be aware: if ISO is not supported
            // ArgumentException will be invoked here
            InputLanguage nextLang = InputLanguage.FromCulture(new System.Globalization.CultureInfo(ISOLang));
            ChangeInputLanguage(nextLang);
        }
        /// <summary>
        /// Changing current Input Language to a new one passed in the param
        /// </summary>
        /// <param name="LangID">Integer Culture code e.g. 1033 for English</param>
        public static void ChangeInputLanguage(int LangID)
        {
            // Convert Integer Culture code to InputLanguage object. Be aware: if Culture code is not supported
            // ArgumentException will be invoked here
            InputLanguage nextLang = InputLanguage.FromCulture(new System.Globalization.CultureInfo(LangID));
            ChangeInputLanguage(nextLang);
        }
        /// <summary>
        /// Changing current Input Language to a new one passed in the param
        /// </summary>
        /// <param name="InputLang">New Input Language as InputLanguage object</param>
        public static void ChangeInputLanguage(InputLanguage InputLang)
        {
            // Check is this Language really installed. Raise exception to warn if it is not:
            if (InputLanguage.InstalledInputLanguages.IndexOf(InputLang) == -1)
                throw new ArgumentOutOfRangeException();
            // InputLAnguage changes here:
            InputLanguage.CurrentInputLanguage = InputLang;
        }
    }

    public partial class ProcessChecker
    {
        /// <summary>
        /// Stores a required string that must be present in the window title for it
        /// to be detected.
        /// </summary>
        static string _requiredString;

        /// <summary>
        /// Contains signatures for C++ DLLs using interop.
        /// </summary>
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern bool EnumWindows(EnumWindowsProcDel lpEnumFunc,
                Int32 lParam);

            [DllImport("user32.dll")]
            public static extern int GetWindowThreadProcessId(IntPtr hWnd,
                ref Int32 lpdwProcessId);

            [DllImport("user32.dll")]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString,
                Int32 nMaxCount);

            public const int SW_SHOWNORMAL = 1;
        }

        public delegate bool EnumWindowsProcDel(IntPtr hWnd, Int32 lParam);

        /// <summary>
        /// Perform finding and showing of running window.
        /// </summary>
        /// <returns>Bool, which is important and must be kept to match up
        /// with system call.</returns>
        static private bool EnumWindowsProc(IntPtr hWnd, Int32 lParam)
        {
            int processId = 0;
            NativeMethods.GetWindowThreadProcessId(hWnd, ref processId);

            StringBuilder caption = new StringBuilder(1024);
            NativeMethods.GetWindowText(hWnd, caption, 1024);

            // Use IndexOf to make sure our required string is in the title.
            if (processId == lParam && (caption.ToString().IndexOf(_requiredString,
                StringComparison.OrdinalIgnoreCase) != -1))
            {
                // Restore the window.
                NativeMethods.ShowWindowAsync(hWnd, NativeMethods.SW_SHOWNORMAL);
                NativeMethods.SetForegroundWindow(hWnd);
            }
            return true; // Keep this.
        }

        /// <summary>
        /// Find out if we need to continue to load the current process. If we
        /// don't focus the old process that is equivalent to this one.
        /// </summary>
        /// <param name="forceTitle">This string must be contained in the window
        /// to restore. Use a string that contains the most
        /// unique sequence possible. If the program has windows with the string
        /// "Journal", pass that word.</param>
        /// <returns>False if no previous process was activated. True if we did
        /// focus a previous process and should simply exit the current one.</returns>
        static public bool IsOnlyProcess(string forceTitle)
        {
            _requiredString = forceTitle;
            foreach (Process proc in Process.GetProcessesByName(Application.ProductName))
            {
                if (proc.Id != Process.GetCurrentProcess().Id)
                {
                    NativeMethods.EnumWindows(new EnumWindowsProcDel(EnumWindowsProc),
                        proc.Id);
                    return false;
                }
            }
            return true;
        }
    }

    #endregion

    public partial class setLocalTime
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool SetLocalTime(ref SYSTEMTIME lpSystemTime);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;    // ignored for the SetLocalTime function
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        public void setTime(DateTime timeValue)
        {
            SYSTEMTIME time = new SYSTEMTIME();
            time.wDay = (ushort)timeValue.Day;
            time.wMonth = (ushort)timeValue.Month;
            time.wYear = (ushort)timeValue.Year;
            time.wHour = (ushort)timeValue.Hour;
            time.wMinute = (ushort)timeValue.Minute;
            time.wSecond = (ushort)timeValue.Second;

            if (!SetLocalTime(ref time))
            {
                // The native function call failed, so throw an exception
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }

    public class SortableBindingList<T> : BindingList<T> where T : class
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public SortableBindingList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="list">An <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
        public SortableBindingList(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }

        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirection; }
        }

        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }

        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented
        /// </summary>
        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
            _isSorted = false; //thanks Luca
        }

        /// <summary>
        /// Sorts the items if overridden in a derived class
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;

            List<T> list = Items as List<T>;
            if (list == null) return;

            list.Sort(Compare);

            _isSorted = true;
            //fire an event that the list has been changed.
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }


        private int Compare(T lhs, T rhs)
        {
            var result = OnComparison(lhs, rhs);
            //invert if descending
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;
            return result;
        }

        private int OnComparison(T lhs, T rhs)
        {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            if (lhsValue == null)
            {
                return (rhsValue == null) ? 0 : -1; //nulls are equal
            }
            if (rhsValue == null)
            {
                return 1; //first has value, second doesn't
            }
            if (lhsValue is IComparable)
            {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }
            if (lhsValue.Equals(rhsValue))
            {
                return 0; //both are the same
            }
            //not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }
    }

    public class AssemblyInfo
    {
        public AssemblyInfo(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            this.assembly = assembly;
        }

        private readonly Assembly assembly;

        /// <summary>
        /// Gets the title property
        /// </summary>
        public string ProductTitle
        {
            get
            {
                return GetAttributeValue<AssemblyTitleAttribute>(a => a.Title,
                       Path.GetFileNameWithoutExtension(assembly.CodeBase));
            }
        }

        /// <summary>
        /// Gets the application's version
        /// </summary>
        public string Version
        {
            get
            {
                string result = string.Empty;
                Version version = assembly.GetName().Version;
                if (version != null)
                    return version.ToString();
                else
                    return "1.0.0.0";
            }
        }

        /// <summary>
        /// Gets the description about the application.
        /// </summary>
        public string Description
        {
            get { return GetAttributeValue<AssemblyDescriptionAttribute>(a => a.Description); }
        }


        /// <summary>
        ///  Gets the product's full name.
        /// </summary>
        public string Product
        {
            get { return GetAttributeValue<AssemblyProductAttribute>(a => a.Product); }
        }

        /// <summary>
        /// Gets the copyright information for the product.
        /// </summary>
        public string Copyright
        {
            get { return GetAttributeValue<AssemblyCopyrightAttribute>(a => a.Copyright); }
        }

        /// <summary>
        /// Gets the company information for the product.
        /// </summary>
        public string Company
        {
            get { return GetAttributeValue<AssemblyCompanyAttribute>(a => a.Company); }
        }

        protected string GetAttributeValue<TAttr>(Func<TAttr,
          string> resolveFunc, string defaultResult = null) where TAttr : Attribute
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(TAttr), false);
            if (attributes.Length > 0)
                return resolveFunc((TAttr)attributes[0]);
            else
                return defaultResult;
        }
    }
}
