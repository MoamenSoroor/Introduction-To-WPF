﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlsAndAPIs
{
    public class ColorComboBoxItem : ComboBoxItem
    {
        public string ColorName { get; }

        public static readonly Dictionary<string, string> Colors = new Dictionary<string, string>()
        {
            ["INDIANRED"] = "#CD5C5C",
            ["LIGHTCORAL"] = "#F08080",
            ["SALMON"] = "#FA8072",
            ["DARKSALMON"] = "#E9967A",
            ["LIGHTSALMON"] = "#FFA07A",
            ["CRIMSON"] = "#DC143C",
            ["RED"] = "#FF0000",
            ["FIREBRICK"] = "#B22222",
            ["DARKRED"] = "#8B0000",
            ["PINK"] = "#FFC0CB",
            ["LIGHTPINK"] = "#FFB6C1",
            ["HOTPINK"] = "#FF69B4",
            ["DEEPPINK"] = "#FF1493",
            ["MEDIUMVIOLETRED"] = "#C71585",
            ["PALEVIOLETRED"] = "#DB7093",
            ["LIGHTSALMON"] = "#FFA07A",
            ["CORAL"] = "#FF7F50",
            ["TOMATO"] = "#FF6347",
            ["ORANGERED"] = "#FF4500",
            ["DARKORANGE"] = "#FF8C00",
            ["ORANGE"] = "#FFA500",
            ["GOLD"] = "#FFD700",
            ["YELLOW"] = "#FFFF00",
            ["LIGHTYELLOW"] = "#FFFFE0",
            ["LEMONCHIFFON"] = "#FFFACD",
            ["LIGHTGOLDENRODYELLOW"] = "#FAFAD2",
            ["PAPAYAWHIP"] = "#FFEFD5",
            ["MOCCASIN"] = "#FFE4B5",
            ["PEACHPUFF"] = "#FFDAB9",
            ["PALEGOLDENROD"] = "#EEE8AA",
            ["KHAKI"] = "#F0E68C",
            ["DARKKHAKI"] = "#BDB76B",
            ["LAVENDER"] = "#E6E6FA",
            ["THISTLE"] = "#D8BFD8",
            ["PLUM"] = "#DDA0DD",
            ["VIOLET"] = "#EE82EE",
            ["ORCHID"] = "#DA70D6",
            ["FUCHSIA"] = "#FF00FF",
            ["MAGENTA"] = "#FF00FF",
            ["MEDIUMORCHID"] = "#BA55D3",
            ["MEDIUMPURPLE"] = "#9370DB",
            ["REBECCAPURPLE"] = "#663399",
            ["BLUEVIOLET"] = "#8A2BE2",
            ["DARKVIOLET"] = "#9400D3",
            ["DARKORCHID"] = "#9932CC",
            ["DARKMAGENTA"] = "#8B008B",
            ["PURPLE"] = "#800080",
            ["INDIGO"] = "#4B0082",
            ["SLATEBLUE"] = "#6A5ACD",
            ["DARKSLATEBLUE"] = "#483D8B",
            ["MEDIUMSLATEBLUE"] = "#7B68EE",
            ["GREENYELLOW"] = "#ADFF2F",
            ["CHARTREUSE"] = "#7FFF00",
            ["LAWNGREEN"] = "#7CFC00",
            ["LIME"] = "#00FF00",
            ["LIMEGREEN"] = "#32CD32",
            ["PALEGREEN"] = "#98FB98",
            ["LIGHTGREEN"] = "#90EE90",
            ["MEDIUMSPRINGGREEN"] = "#00FA9A",
            ["SPRINGGREEN"] = "#00FF7F",
            ["MEDIUMSEAGREEN"] = "#3CB371",
            ["SEAGREEN"] = "#2E8B57",
            ["FORESTGREEN"] = "#228B22",
            ["GREEN"] = "#008000",
            ["DARKGREEN"] = "#006400",
            ["YELLOWGREEN"] = "#9ACD32",
            ["OLIVEDRAB"] = "#6B8E23",
            ["OLIVE"] = "#808000",
            ["DARKOLIVEGREEN"] = "#556B2F",
            ["MEDIUMAQUAMARINE"] = "#66CDAA",
            ["DARKSEAGREEN"] = "#8FBC8B",
            ["LIGHTSEAGREEN"] = "#20B2AA",
            ["DARKCYAN"] = "#008B8B",
            ["TEAL"] = "#008080",
            ["AQUA"] = "#00FFFF",
            ["CYAN"] = "#00FFFF",
            ["LIGHTCYAN"] = "#E0FFFF",
            ["PALETURQUOISE"] = "#AFEEEE",
            ["AQUAMARINE"] = "#7FFFD4",
            ["TURQUOISE"] = "#40E0D0",
            ["MEDIUMTURQUOISE"] = "#48D1CC",
            ["DARKTURQUOISE"] = "#00CED1",
            ["CADETBLUE"] = "#5F9EA0",
            ["STEELBLUE"] = "#4682B4",
            ["LIGHTSTEELBLUE"] = "#B0C4DE",
            ["POWDERBLUE"] = "#B0E0E6",
            ["LIGHTBLUE"] = "#ADD8E6",
            ["SKYBLUE"] = "#87CEEB",
            ["LIGHTSKYBLUE"] = "#87CEFA",
            ["DEEPSKYBLUE"] = "#00BFFF",
            ["DODGERBLUE"] = "#1E90FF",
            ["CORNFLOWERBLUE"] = "#6495ED",
            ["MEDIUMSLATEBLUE"] = "#7B68EE",
            ["ROYALBLUE"] = "#4169E1",
            ["BLUE"] = "#0000FF",
            ["MEDIUMBLUE"] = "#0000CD",
            ["DARKBLUE"] = "#00008B",
            ["NAVY"] = "#000080",
            ["MIDNIGHTBLUE"] = "#191970",
            ["CORNSILK"] = "#FFF8DC",
            ["BLANCHEDALMOND"] = "#FFEBCD",
            ["BISQUE"] = "#FFE4C4",
            ["NAVAJOWHITE"] = "#FFDEAD",
            ["WHEAT"] = "#F5DEB3",
            ["BURLYWOOD"] = "#DEB887",
            ["TAN"] = "#D2B48C",
            ["ROSYBROWN"] = "#BC8F8F",
            ["SANDYBROWN"] = "#F4A460",
            ["GOLDENROD"] = "#DAA520",
            ["DARKGOLDENROD"] = "#B8860B",
            ["PERU"] = "#CD853F",
            ["CHOCOLATE"] = "#D2691E",
            ["SADDLEBROWN"] = "#8B4513",
            ["SIENNA"] = "#A0522D",
            ["BROWN"] = "#A52A2A",
            ["MAROON"] = "#800000",
            ["WHITE"] = "#FFFFFF",
            ["SNOW"] = "#FFFAFA",
            ["HONEYDEW"] = "#F0FFF0",
            ["MINTCREAM"] = "#F5FFFA",
            ["AZURE"] = "#F0FFFF",
            ["ALICEBLUE"] = "#F0F8FF",
            ["GHOSTWHITE"] = "#F8F8FF",
            ["WHITESMOKE"] = "#F5F5F5",
            ["SEASHELL"] = "#FFF5EE",
            ["BEIGE"] = "#F5F5DC",
            ["OLDLACE"] = "#FDF5E6",
            ["FLORALWHITE"] = "#FFFAF0",
            ["IVORY"] = "#FFFFF0",
            ["ANTIQUEWHITE"] = "#FAEBD7",
            ["LINEN"] = "#FAF0E6",
            ["LAVENDERBLUSH"] = "#FFF0F5",
            ["MISTYROSE"] = "#FFE4E1",
            ["GAINSBORO"] = "#DCDCDC",
            ["LIGHTGRAY"] = "#D3D3D3",
            ["SILVER"] = "#C0C0C0",
            ["DARKGRAY"] = "#A9A9A9",
            ["GRAY"] = "#808080",
            ["DIMGRAY"] = "#696969",
            ["LIGHTSLATEGRAY"] = "#778899",
            ["SLATEGRAY"] = "#708090",
            ["DARKSLATEGRAY"] = "#2F4F4F",
            ["BLACK"] = "#000000"
        };

        public ColorComboBoxItem(string name)
        {
            ColorName = name;
            StackPanel stack = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Tag = name
            };
            Rectangle rect = new Rectangle()
            {
                Width = 50,
                Height = 25,
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Colors[ColorName]))
            };
            Label label = new Label()
            {
                Content = ColorName,
                Width = 120,
                Height = 25
            };

            stack.Children.Add(rect);
            stack.Children.Add(label);

            Content = stack;
            HorizontalContentAlignment = HorizontalAlignment.Center;
            VerticalContentAlignment = VerticalAlignment.Center;
            Margin = new Thickness(5, 5, 5, 5);
        }


        public ColorComboBoxItem() : this("BLACK")
        {

        }


        public Color ColorValue
        {
            get => (Color) ColorConverter.ConvertFromString(Colors[ColorName]);
        }

        public string ColorHex
        {
            get => Colors[ColorName];
        }

    }
}
