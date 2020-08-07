using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vjsdn.Tech.KeyboardHook;


namespace DotaSkillScreenshot
{
    public partial class Form1 : Form
    {
        //获取窗口句柄
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll ")]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass, string FrmText);

        // 获得窗口矩形(包含边框)
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);
        // 获得客户区矩形(不含边框)
        [DllImport("user32.dll")]
        public static extern int GetClientRect(IntPtr hWnd, out RECT lpRect);
        public struct RECT
        {

            public int Left; //最左坐标

            public int Top; //最上坐标

            public int Right; //最右坐标

            public int Bottom; //最下坐标 
        }

        //控制鼠标移动
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        //触发鼠标事件
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        //键盘钩子
        private KeyboardHookLib _keyboardHook = null;

        //窗口矩形(包含边框)
        private RECT windowRect = new RECT();

        //客户区矩形(不含边框)
        //private RECT clientRect = new RECT();

        //DOTA2句柄
        private IntPtr hwnd;

        //timer tick
        int tick = 0;

        Bitmap image = null;

        public Form1()
        {
            InitializeComponent();
            this.Font = new Font("Microsoft YaHei UI", 9, FontStyle.Regular);
            if (_keyboardHook == null)
            {
                _keyboardHook = new KeyboardHookLib();
                _keyboardHook.InstallHook(this.OnKeyPress);
            }
            CheckDotaStatusTimer.Start();
        }

        private void GetCurrentScreenImage(ref Bitmap image)
        {
            int width = windowRect.Right - windowRect.Left; //窗口的宽度
            int height = windowRect.Bottom - windowRect.Top; //窗口的高度
            Graphics g = Graphics.FromImage(image);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;//高质量
            g.CopyFromScreen(0, 0, 0, 0, new Size(width, height));//截屏
        }

        private Boolean IsGameAlready()
        {
            if (hwnd.ToString() == "0")
            {
                MessageBox.Show("Dota2未开启.");
                return false;
            }
            if (Resolution.Text != "1920*1080" && Resolution.Text != "2560*1440")
            {
                MessageBox.Show("游戏分辨率不支持,请联系作者.(Q群:518615024)");
                return false;
            }
            if (windowRect.Left != 0 || windowRect.Top != 0)
            {
                MessageBox.Show("请使用全屏或者无边框窗口全屏模式.");
                return false;
            }
            return true;
        }

        public void OnKeyPress(KeyboardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false; //预设不拦截任何键
            Keys key = (Keys)hookStruct.vkCode;

            string keyStr = key.ToString();
            switch (keyStr)
            {
                case "F5":
                    if (IsGameAlready())
                    {
                        GetCurrentScreenImage(ref image);
                        Clipboard.Clear();
                        Clipboard.SetImage(image);//保存到Clipboard中
                    }
                    break;
                case "F6":
                    break;
                case "F7":
                    break;
                case "F8":

                    break;

                default:
                    break;

            }
            return;
        }

        //英雄头像坐标
        private int[,] heroIconCoordinate1920x1080 = {
            { 580, 20 },
            { 642, 20 },
            { 704, 20 },
            { 766, 20 },
            { 828, 20 },

            { 1098, 20 },
            { 1160, 20 },
            { 1222, 20 },
            { 1284, 20 },
            { 1346, 20 } };

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            transparency.Text = trackBar1.Value.ToString() + "%";
        }

        private void UpdateDotaStatus()
        {
            hwnd = FindWindow(null, "Dota 2");
            if (hwnd.ToString() != "0")
            {
                System.Diagnostics.Debug.WriteLine(hwnd.ToString());
                GetWindowRect(hwnd, out windowRect);
                int width = windowRect.Right - windowRect.Left; //窗口的宽度
                int height = windowRect.Bottom - windowRect.Top; //窗口的高度
                int x = windowRect.Left;
                int y = windowRect.Top;
                String resStr = "" + width + "*" + height;
                DotaStatus.Text = "打开";
                DotaStatus.ForeColor = Color.Blue;
                Resolution.Text = resStr;
                if (image == null)
                {
                    image = new Bitmap(width, height);
                }
            }
            else
            {
                DotaStatus.Text = "关闭";
                DotaStatus.ForeColor = Color.Red;
                Resolution.Text = "0*0";
                if (image != null)
                {
                    image.Dispose();
                }
            }
        }

        private void CheckDotaStatusTimer_Tick(object sender, EventArgs e)
        {
            tick++;
            if (tick % 10 == 0)
            {
                UpdateDotaStatus();
            }
        }
    }
}
