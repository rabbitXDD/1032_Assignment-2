using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
namespace myMines
{
    class Square : Button
    {
        private int _row;
        private int _col;
        private bool _dismantled = false;
        private bool _minded = false;
        private bool _opened = false;

        public int status = 0;

        StackPanel sp;
        Image img;
        Label lbl;

        public int ROW
        {
            get { return _row; }
            set { _row = value; }
        }

        public int COL
        {
            get { return _col; }
            set { _col = value; }
        }

        public bool Dismantled
        {
            get { return _dismantled; }
            set { _dismantled = value; }
        }

        public bool Minded
        {
            get { return _minded; }
            set { _minded = value; }
        }

        public bool Opened
        {
            get { return _opened; }
            set { _opened = value; }
        }

        public Square()
            : base()
        {
            this.Background = System.Windows.Media.Brushes.LightGray;
            sp = new StackPanel();
            img = new Image();
            lbl = new Label();
            this.AddChild(sp);
            this.FontSize = 12;
            sp.Children.Add(img);
            sp.Children.Add(lbl);
            sp.IsEnabled = false;
            this.Focusable = false;

            //this.Background = new System.Windows.Media.SolidColorBrush(
            //    System.Windows.Media.Colors.Green);

            //this.Background = SystemColors.ControlBrush;

            //byte red = 0; byte green = 255; byte blue = 0;
            //this.Background = new System.Windows.Media.SolidColorBrush(
            //    System.Windows.Media.Color.FromRgb(red, green, blue));
        }

        public void LeftClick()
        {
            this.IsEnabled = false;
            this.BorderBrush = System.Windows.Media.Brushes.Black;
        }

        public void DismantleClick()
        {
            if (!_opened)
            {
                if (_dismantled)
                {
                    _dismantled = false;
                    //this.Content = "?";
                    status = 2;
                    setContent("question");

                }
                else if (status == 2)
                {
                    _dismantled = false;
                    img.Visibility = Visibility.Hidden;
                    status = 0;
                }
                else
                {
                    _dismantled = true;
                    this.Foreground = System.Windows.Media.Brushes.Green;
                    //this.Content = "★";
                    status = 1;
                    setContent("flag");
                }
            }
        }

        public void setContent(String s)
        {
            string path = "";
            if (s == "flag")
                path = "Resources\\flag.png";
            else if (s == "bomb")
                path = "Resources\\2015-04-20_025246.png";
            else if (s == "question")
                path = "Resources\\0143.png";
            img.Visibility = Visibility.Visible;
            lbl.Visibility = Visibility.Hidden;
            img.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }
        public void setContent(int i)
        {
            img.Visibility = Visibility.Hidden;
            lbl.Visibility = Visibility.Visible;
            sp = null;
            lbl.Content = i.ToString();
            this.Content = i.ToString();
        }
        public void setFontSize(int v)
        {
            this.FontSize = v;
        }
    }
}
