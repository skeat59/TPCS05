using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TPCS05
{
    public partial class Form1 : Form
    {
#if PONY
        private static Dictionary<PonyColor, string[]> colors = new Dictionary<PonyColor, string[]>();

        Arena arena;
        public Form1(Arena arena)
        {
            this.arena = arena;
            // Theses are the colors of ponies:                     hair1      hair2      body1      body2      body3      eyes1      eyes2      eyes3      eyes4      cuti1      cuti2
            colors.Add(PonyColor.Applejack, new string[]        { "#EDE27B", "#FFFFBD", "#EA7642", "#FAC479", "#F2B56A", "#74D65E", "#3D9828", "#D6F8CD", "#98F177", "#E43C53", "#75D75C" });
            colors.Add(PonyColor.PinkiePie, new string[]        { "#B90B85", "#E43B96", "#E580BB", "#F5BAD9", "#E99DCB", "#97E0F7", "#2A82A2", "#E8FDFF", "#B2E8FA", "#95DFF6", "#FFFEBC" });
            colors.Add(PonyColor.Rarity, new string[]           { "#521371", "#6B57A9", "#C9CDCE", "#F1F6F6", "#E8EDEB", "#4DBBBF", "#2F597B", "#8DBCEC", "#6BA2D6", "#32ADD4", "#93E2F9" });
            colors.Add(PonyColor.Fluttershy, new string[]       { "#E181BA", "#F0B9D7", "#ECE17A", "#FDFFBA", "#F7F09C", "#17CBAF", "#096C5A", "#9DE3DD", "#58D1C1", "#F3BAD7", "#85DEC8" });
            colors.Add(PonyColor.TwilightSparkle, new string[]  { "#1F2B55", "#33437D", "#AD70C4", "#D7A3E7", "#BC90CC", "#70308F", "#270A4A", "#D4BADC", "#9761AF", "#E33C96", "#FFFFFF" });
            // If you want to add a new pony colorscheme you may use this afer add the color in the enum.
            //colors.Add(PonyColor.YourColor, new string[]        { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" });
            InitializeComponent();
        }

        public void DoAttack(int n)
        {
            // Let's fight ! Call AttackWith method
            arena.AttackWith(n);
            // Update PV of ponies on the windows Form.
            this.rightLife.Value = arena.Right.Pv;
            this.rightPV.Text = arena.Right.Pv + " / " + arena.Right.PvMax;
            this.leftLife.Value = arena.Left.Pv;
            this.leftPV.Text = arena.Left.Pv + " / " + arena.Left.PvMax;
            // We switch attaking and defensive pony in the Arena object.
            arena.ChangeAttacker();
        }

        private Image getPonyImage(PonyColor ponyColor)
        {
            // Because Fuck you that's why !
            if (ponyColor == PonyColor.RainbowDash)
                return new Bitmap(@"../../rainbow.png");
            Bitmap bmp = new Bitmap(@"../../pony.png");
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (c.A == 0)
                        continue;
                    switch (c.B)
                    {
                        case 123: // hair1
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][0]));
                            break;
                        case 189: // hair2
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][1]));
                            break;
                        case 66: // body1
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][2]));
                            break;
                        case 121: // body2
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][3]));
                            break;
                        case 106: // body3
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][4]));
                            break;
                        case 94: // eye1
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][5]));
                            break;
                        case 40: // eye2
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][6]));
                            break;
                        case 205: // eye3
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][7]));
                            break;
                        case 119: // eye4
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][8]));
                            break;
                        case 83: // cuti1
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][9]));
                            break;
                        case 92: // cuti2
                            bmp.SetPixel(x, y, ColorTranslator.FromHtml(colors[ponyColor][10]));
                            break;
                        default:
                            break;
                    }
                }
            }
            return bmp;
        }
#else
        public Form1()
        {
            InitializeComponent();
        }
#endif

        // Init function
        private void Form1_Load(object sender, EventArgs e)
        {
            // right Pony
#if PONY
            this.rightPony.Image = getPonyImage(arena.Right.Color);
            this.rightName.Text = arena.Right.Name;
            this.rightPV.Text = arena.Right.Pv + " / " + arena.Right.PvMax;
            this.rightLife.Minimum = 0;
            this.rightLife.Maximum = arena.Right.PvMax;
            this.rightLife.Value = arena.Right.Pv;
            this.rightAttack.Items.Add(arena.Right.GetAttack(0).Name);
            this.rightAttack.Items.Add(arena.Right.GetAttack(1).Name);
            this.rightAttack.SelectedIndex = 0;
#endif
            this.rightAttack.Enabled = false;
            this.rightButton.Enabled = false;
            this.rightLife.ForeColor = Color.Green;
            this.rightLife.Style = ProgressBarStyle.Blocks;

            // left Pony
#if PONY
            this.leftPony.Image = getPonyImage(arena.Left.Color);
            this.leftPony.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            this.leftName.Text = arena.Left.Name;
            this.leftPV.Text = arena.Left.Pv + " / " + arena.Left.PvMax;
            this.leftLife.Minimum = 0;
            this.leftLife.Maximum = arena.Left.PvMax;
            this.leftLife.Value = arena.Left.Pv;
            this.leftAttack.Items.Add(arena.Left.GetAttack(0).Name);
            this.leftAttack.Items.Add(arena.Left.GetAttack(1).Name);
            this.leftAttack.SelectedIndex = 0;
#endif
            this.leftAttack.Enabled = true;
            this.leftButton.Enabled = true;
            this.leftLife.ForeColor = Color.Green;
            this.leftLife.Style = ProgressBarStyle.Blocks;
        }

        private void Button_Click(object sender, EventArgs e)
        {
#if PONY
            if (arena.IsFinished())
                return;
            if (this.leftAttack.Enabled)
                DoAttack(this.leftAttack.SelectedIndex);
            else
                DoAttack(this.rightAttack.SelectedIndex);
#endif
            this.rightAttack.Enabled = !this.rightAttack.Enabled;
            this.rightButton.Enabled = !this.rightButton.Enabled;
            this.leftAttack.Enabled = !this.leftAttack.Enabled;
            this.leftButton.Enabled = !this.leftButton.Enabled;
        }
    }
}