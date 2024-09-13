using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace resolution
{
    class ScreenSize
    {
        //// VGA画面をQVGAに変換する
        ////
        ////    CALL方法：各FormのLoad処理に以下のステートを追加する
        ////
        ////    if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width == 240)
        ////    {
        ////        resolution.ScreenSize.VGAtoQVGA(this);
        ////    }
        public static void VGAtoQVGA(Control top)
        {
            //// フォーム内の部品のサイズ調整
            foreach (Control item in top.Controls)
            {
                //// 縦横座標、幅＆高さ
                item.Left = (int)(item.Left * 0.5);
                item.Top = (int)(item.Top * 0.5);
                item.Width = (int)(item.Width * 0.5);
                item.Height = (int)(item.Height * 0.5);

                //// フォントサイズ
                try
                {
                    item.Font = new Font(item.Font.Name, (float)(item.Font.Size * 0.5), item.Font.Style);
                }
                catch (NotSupportedException)
                {
                    /* Font not implemented */
                }

            }

            //// フォーム自体のサイズ調整
            top.Left = (int)(top.Left * 0.5);
            top.Top = (int)(top.Top * 0.5);
            top.Width = (int)(top.Width * 0.5);
            top.Height = (int)(top.Height * 0.5);

            top.Font = new Font(top.Font.Name, (float)(top.Font.Size * 0.5), top.Font.Style);
        }

        //// QVGA画面をVGAに変換する
        ////
        ////    CALL方法：各FormのLoad処理に以下のステートを追加する
        ////
        ////    if (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width == 480)
        ////    {
        ////        resolution.ScreenSize.VGAtoQVGA(this);
        ////    }
        public static void QVGAtoVGA(Control top)
        {
            //// フォーム内の部品のサイズ調整
            foreach (Control item in top.Controls)
            {
                //// 縦横座標、幅＆高さ
                item.Left = item.Left * 2;
                item.Top = item.Top * 2;
                item.Width = item.Width * 2;
                item.Height = item.Height * 2;

                //// フォントサイズ
                try
                {
                    item.Font = new Font(item.Font.Name, item.Font.Size * 2, item.Font.Style);
                }
                catch (NotSupportedException)
                {
                    /* Font not implemented */
                }

            }

            //// フォーム自体のサイズ調整
            top.Left = top.Left * 2;
            top.Top = top.Top * 2;
            top.Width = top.Width * 2;
            top.Height = top.Height * 2;

            top.Font = new Font(top.Font.Name, top.Font.Size * 2, top.Font.Style);
        }
    }

}
