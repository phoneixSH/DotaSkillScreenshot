using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Vjsdn.Tech.KeyboardHook;


namespace DotaSkillScreenshot
{
    public partial class DotaSkillScreenshot : Form
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

        private ArrayList heroIconList = new ArrayList();

        private ArrayList heroSkillList = new ArrayList();

        private int[,] heroIconCoordinate;
        private int[] heroIconRect;
        private int[,] heroSkillIconRect;

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

        private int[,] heroIconCoordinate2560x1440 = {
            { 773, 30 },
            { 856, 30 },
            { 939, 30 },
            { 1022, 30 },
            { 1105, 30 },

            { 1454, 30 },
            { 1537, 30 },
            { 1620, 30 },
            { 1703, 30 },
            { 1786, 30 } };

        //英雄头像矩形框
        private int[] heroIconRect1920x1080 = {
            -26,    //头像坐标x距离
            -15,    //头像坐标y距离
            52,     //宽
            30      //高
        };
        //75*44
        private int[] heroIconRect2560x1440 = {
            -37,    //头像坐标x距离
            -24,    //头像坐标y距离
            75,     //宽
            44      //高
        };

        //技能图标矩形框
        private int[,] heroSkillIconRect1920x1080 = {
            {                             //技能1
                -117 + 60*0,      //头像坐标x距离
                52,                     //头像坐标y距离
                48,                     //宽
                47                      //高
            },
            {                             //技能2
                -117 + 60,          //头像坐标x距离
                52,                     //头像坐标y距离
                48,                     //宽
                47                      //高
            },
            {                            //技能3
                -117 + 60*2,      //头像坐标x距离
                52,                     //头像坐标y距离
                48,                     //宽
                47                      //高
            },
            {                           //技能4
                -117 + 60*3,      //头像坐标x距离
                52,                     //头像坐标y距离
                48,                     //宽
                47                      //高
            }
        };
        //773,30 => 618,95
        private int[,] heroSkillIconRect2560x1440 = {
            {                             //技能1
                -155 + 80*0,      //头像坐标x距离
                65,                     //头像坐标y距离
                64,                     //宽
                64                      //高
            },
            {                             //技能2
                -155 + 80,          //头像坐标x距离
                65,                     //头像坐标y距离
                64,                     //宽
                64                      //高
            },
            {                            //技能3
                -155 + 80*2,      //头像坐标x距离
                65,                     //头像坐标y距离
                64,                     //宽
                64                      //高
            },
            {                           //技能4
                -155 + 80*3,      //头像坐标x距离
                65,                     //头像坐标y距离
                64,                     //宽
                64                      //高
            }
        };

        private int[,] mergeCoordinate;

        private int[,] mergeCoordinate1920x1080 = {
            {
                0 ,   //左侧x
                140         //左侧y
            },
            {
                1920 ,   //右侧x
                140    //右侧y
            },
         };

        private int[,] mergeCoordinate2560x1440 = {
            {
                0 ,   //左侧x
                190         //左侧y
            },
            {
                2560 ,   //右侧x
                190    //右侧y
            },
         };

        public DotaSkillScreenshot()
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

        private void getSnapHeroCoordinate(int index)
        {
            int x = heroIconCoordinate[index, 0] + heroIconRect[0];
            int y = heroIconCoordinate[index, 1] + heroIconRect[1];
            int width = heroIconRect[2];
            int height = heroIconRect[3];
            Bitmap heroIcon = GetCurrentScreenImageWithRect(x, y, width, height);
            heroIconList.Add(heroIcon);
        }

        private void getHeroSkill(int index)
        {
            ArrayList tmpList = new ArrayList();
            int x = heroIconCoordinate[index, 0];
            int y = heroIconCoordinate[index, 1];
            SetCursorPos(x, y);
            for (int i = 0; i < 4; i++)
            {
                x = heroIconCoordinate[index, 0] + heroSkillIconRect[i, 0];
                y = heroIconCoordinate[index, 1] + heroSkillIconRect[i, 1];
                int width = heroSkillIconRect[i, 2];
                int height = heroSkillIconRect[i, 3];
                if (index == 0 || index == 5)
                {
                    Thread.Sleep(150);
                }
                else
                {
                    Thread.Sleep(70);
                }
                Bitmap screenshot = GetCurrentScreenImageWithRect(x, y, width, height);
                tmpList.Add(screenshot);
            }
            heroSkillList.Add(tmpList);
        }

        //获取英雄头像及其技能
        private void GetAllHeroIcon()
        {
            for (int i = 0; i < 10; i++)
            {
                getSnapHeroCoordinate(i);
                getHeroSkill(i);
            }
        }

        private Bitmap DrawImageToImage(Bitmap image, Bitmap waterImg, int x, int y, float alpha)
        {
            Graphics g = Graphics.FromImage(image);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;//高质量
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//设置高质量插值法  
            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                                        new float[] {0, 1, 0, 0, 0},
                                        new float[] {0, 0, 1, 0, 0},
                                        new float[] {0, 0, 0, alpha, 0}, //0.5f 就是转换矩阵中调整透明度的值。0.5就是50%透明。
                                        new float[] {0, 0, 0, 0, 1}
                                      };
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(waterImg, new Rectangle(x, y, waterImg.Width, waterImg.Height), 0, 0, waterImg.Width, waterImg.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();
            return image;
        }

        private Bitmap MergePicture(Bitmap resultImg)
        {
            float alpha = Convert.ToSingle(trackBar1.Value.ToString()) / 100f;
            for (int i = 0; i < 10; i++)
            {
                //52*30
                Bitmap heroIconImg = (Bitmap)heroIconList[i];
                ArrayList currentHeroSkillList = (ArrayList)heroSkillList[i];
                if (i < 5)
                {
                    int baseX = mergeCoordinate[0, 0];
                    int baseY = mergeCoordinate[0, 1];
                    resultImg = DrawImageToImage(resultImg, heroIconImg, baseX, baseY + i * heroSkillIconRect[0, 3], alpha);
                    for (int j = 0; j < 4; j++)
                    {
                        Bitmap heroSkillImg = (Bitmap)currentHeroSkillList[j];
                        resultImg = DrawImageToImage(resultImg, heroSkillImg, baseX + heroIconRect[2] + j * heroSkillIconRect[0, 2], baseY - ((heroSkillIconRect[0, 3] - heroIconRect[3]) / 2) + heroSkillIconRect[0, 3] * i,
                                alpha);
                    }
                }
                else
                {
                    int baseX = mergeCoordinate[1, 0];
                    int baseY = mergeCoordinate[1, 1];
                    resultImg = DrawImageToImage(resultImg, heroIconImg, baseX - heroIconRect[2], baseY + (i - 5) * heroSkillIconRect[0, 3], alpha);
                    for (int j = 0; j < 4; j++)
                    {
                        Bitmap heroSkillImg = (Bitmap)currentHeroSkillList[j];
                        resultImg = DrawImageToImage(resultImg, heroSkillImg, baseX - heroIconRect[2] - (4 - j) * heroSkillIconRect[0, 2],
                                baseY - ((heroSkillIconRect[0, 3] - heroIconRect[3]) / 2) + heroSkillIconRect[0, 3] * (i - 5), alpha);
                    }
                }
            }
            heroIconList.Clear();
            heroSkillList.Clear();
            return resultImg;
        }

        private Bitmap GetCurrentScreenImageWithRect(int x, int y, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;//高质量
            g.CopyFromScreen(x, y, 0, 0, new Size(width, height));//截屏
            g.Dispose();
            return bitmap;
        }

        private void GetCurrentScreenImage(ref Bitmap image)
        {
            int width = windowRect.Right - windowRect.Left; //窗口的宽度
            int height = windowRect.Bottom - windowRect.Top; //窗口的高度
            Graphics g = Graphics.FromImage(image);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;//高质量
            g.CopyFromScreen(0, 0, 0, 0, new Size(width, height));//截屏
            g.Dispose();
        }

        private Boolean IsGameAlready()
        {
            if (hwnd.ToString() == "0")
            {
                MessageBox.Show("Dota2未开启.");
                return false;
            }
            if (Resolution.Text == "1920*1080")
            {
                this.heroIconCoordinate = heroIconCoordinate1920x1080;
                this.heroIconRect = heroIconRect1920x1080;
                this.heroSkillIconRect = heroSkillIconRect1920x1080;
                this.mergeCoordinate = mergeCoordinate1920x1080;
            }
            else if (Resolution.Text == "2560*1440")
            {
                this.heroIconCoordinate = heroIconCoordinate2560x1440;
                this.heroIconRect = heroIconRect2560x1440;
                this.heroSkillIconRect = heroSkillIconRect2560x1440;
                this.mergeCoordinate = mergeCoordinate2560x1440;
            }
            else
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

        private Bitmap DrawBlankImage()
        {
            int width = windowRect.Right - windowRect.Left; //窗口的宽度
            int height = windowRect.Bottom - windowRect.Top; //窗口的高度
            Bitmap blankImage = new Bitmap(width, height);
            blankImage.MakeTransparent(Color.Transparent);
            return blankImage;
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
                        Bitmap blankImage = DrawBlankImage();
                        GetAllHeroIcon();
                        Bitmap bitmap = MergePicture(blankImage);
                        String fileStr = System.DateTime.Now.Ticks.ToString() + ".png";
                        bitmap.Save(@fileStr);
                        System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                        String path = System.AppDomain.CurrentDomain.BaseDirectory;
                        files.Add(@path + fileStr);
                        Clipboard.SetFileDropList(files);
                        files.Clear();
                        bitmap.Dispose();
                    }
                    break;
                case "F6":
                    if (IsGameAlready())
                    {
                        GetCurrentScreenImage(ref image);
                        GetAllHeroIcon();
                        Bitmap bitmap = MergePicture(image);
                        Clipboard.SetImage(bitmap);//保存到Clipboard中
                    }
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
