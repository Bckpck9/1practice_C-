using System;
using System.Collections.Generic;
using System.Linq;

namespace NortonCommanderImitation
{
    class FileItem
    {
        public string Name;
        public string Ext;
        public bool IsDirectory;
        public long Size;
        public string Date;
        public string Time;

        public FileItem(string name, string ext, bool isDir, long size, string date, string time)
        {
            Name = name;
            Ext = ext;
            IsDirectory = isDir;
            Size = size;
            Date = date;
            Time = time;
        }
    }

    class Program
    {
        const int ScreenWidth = 80;
        const int ScreenHeight = 25;

        const int LeftPanelWidth = 38;
        const int RightPanelWidth = 38;

        const int RightPanelX = LeftPanelWidth + 2;

        const int PanelTop = 1;
        const int HeaderRow = 2;
        const int FilesTopRow = 3;
        const int PanelBottomLine = 20;
        const int PanelInfoRow = 21;
        const int BottomBorderRow = 22;
        const int StatusRow = 23;
        const int FunctionKeyRow = 24;

        const int LeftColumnWidth = 12;
        const int LeftNameMaxLength = 8;

        const int RightNameMaxLength = 8;
        const int SizeColumnX = 13;
        const int DateColumnX = 22;
        const int TimeColumnX = 32;

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            PaintBackground(ConsoleColor.Blue);

            List<FileItem> leftFiles = CreateLeftFiles();
            List<FileItem> rightFiles = CreateRightFiles();

            DrawTopMenu();
            DrawTopPanelBorder();
            DrawColumnHeaders();
            DrawLeftPanel(leftFiles);
            DrawRightPanel(rightFiles);
            DrawMiddleBorder();
            DrawCatalogInfoRow();
            DrawBottomPanelBorder();
            DrawStatusLine();
            DrawFunctionKeys();

            Console.SetCursorPosition(0, ScreenHeight - 1);
            Console.ResetColor();
            Console.WriteLine();
        }

        static List<FileItem> CreateLeftFiles()
        {
            return new List<FileItem>
            {
                new FileItem("..", "", true, 0, "25.05.95", "5:00"),
                new FileItem("Ajaccgdo", "", true, 0, "25.05.95", "5:00"),
                new FileItem("nc", "cfg", false, 1024, "25.05.95", "5:00"),
                new FileItem("nc_exit", "com", false, 2048, "25.05.95", "5:00"),
                new FileItem("telemax", "dat", false, 4096, "25.05.95", "5:00"),
                new FileItem("nc_exit", "doc", false, 2200, "25.05.95", "5:00"),
                new FileItem("123view", "exe", false, 128380, "25.05.95", "5:00"),
                new FileItem("arcview", "exe", false, 81738, "25.05.95", "5:00"),
                new FileItem("bitmap", "exe", false, 54805, "25.05.95", "5:00"),
                new FileItem("clp2dib", "exe", false, 3200, "25.05.95", "5:00"),
                new FileItem("dbview", "exe", false, 4400, "25.05.95", "5:00"),
                new FileItem("draw2wmf", "exe", false, 5600, "25.05.95", "5:00"),
                new FileItem("drw2wmf", "exe", false, 6600, "25.05.95", "5:00"),
                new FileItem("ico2dib", "exe", false, 2900, "25.05.95", "5:00"),
                new FileItem("msp2dib", "exe", false, 3100, "25.05.95", "5:00"),
                new FileItem("nc", "exe", false, 1500, "25.05.95", "5:00"),
                new FileItem("ncclean", "exe", false, 1800, "25.05.95", "5:00"),

                new FileItem("ncdd", "exe", false, 15872, "25.05.95", "5:00"),
                new FileItem("ncedit", "exe", false, 71824, "25.05.95", "5:00"),
                new FileItem("ncff", "exe", false, 12345, "25.05.95", "5:00"),
                new FileItem("nclabel", "exe", false, 8320, "25.05.95", "5:00"),
                new FileItem("ncmain", "exe", false, 45678, "25.05.95", "5:00"),
                new FileItem("ncnet", "exe", false, 9821, "25.05.95", "5:00"),
                new FileItem("ncsf", "exe", false, 512, "25.05.95", "5:00"),
                new FileItem("ncsi", "exe", false, 3344, "25.05.95", "5:00"),
                new FileItem("nczip", "exe", false, 22110, "25.05.95", "5:00"),
                new FileItem("packer", "exe", false, 15900, "25.05.95", "5:00"),
                new FileItem("paraview", "exe", false, 43200, "25.05.95", "5:00"),
                new FileItem("pct2dib", "exe", false, 12800, "25.05.95", "5:00"),
                new FileItem("playwave", "exe", false, 9500, "25.05.95", "5:00"),
                new FileItem("q&aview", "exe", false, 5200, "25.05.95", "5:00"),
                new FileItem("rbview", "exe", false, 8800, "25.05.95", "5:00"),
                new FileItem("refview", "exe", false, 7600, "25.05.95", "5:00"),
                new FileItem("saver", "exe", false, 6100, "25.05.95", "5:00"),

                new FileItem("telemax", "exe", false, 128380, "25.05.95", "5:00"),
                new FileItem("tif2dib", "exe", false, 9900, "25.05.95", "5:00"),
                new FileItem("vector", "exe", false, 255, "25.05.95", "5:00"),
                new FileItem("wpb2dib", "exe", false, 255, "25.05.95", "5:00"),
                new FileItem("wpv2wmf", "exe", false, 255, "25.05.95", "5:00"),
                new FileItem("wpview", "exe", false, 255, "25.05.95", "5:00"),
                new FileItem("nc", "ext", false, 255, "25.05.95", "5:00"),
                new FileItem("nc", "fil", false, 255, "25.05.95", "5:00"),
                new FileItem("ncpscrip", "hdr", false, 255, "25.05.95", "5:00"),
                new FileItem("nc", "hlp", false, 255, "25.05.95", "5:00"),
                new FileItem("ncff", "hlp", false, 255, "25.05.95", "5:00"),
                new FileItem("telemax", "hlp", false, 255, "25.05.95", "5:00"),
                new FileItem("nc", "ico", false, 255, "25.05.95", "5:00"),
                new FileItem("nc", "ini", false, 255, "25.05.95", "5:00"),
                new FileItem("ncclean", "ini", false, 255, "25.05.95", "5:00"),
                new FileItem("norton", "ini", false, 255, "25.05.95", "5:00"),
                new FileItem("telemax", "ini", false, 255, "25.05.95", "5:00")
            };
        }

        static List<FileItem> CreateRightFiles()
        {
            return new List<FileItem>
            {
                new FileItem("..", "", true, 0, "11.10.02", "19:48"),
                new FileItem("123view", "exe", false, 128380, "25.05.95", "5:00"),
                new FileItem("4372ansi", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("8502ansi", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("8632ansi", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("8652ansi", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("8662ansi", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("Ajaccgdo", "", true, 0, "12.10.02", "9:02"),
                new FileItem("ansi2437", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("ansi2850", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("ansi2863", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("ansi2865", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("ansi2866", "set", false, 255, "25.05.95", "5:00"),
                new FileItem("arcview", "exe", false, 81738, "25.05.95", "5:00"),
                new FileItem("bitmap", "exe", false, 54805, "25.05.95", "5:00"),
                new FileItem("bug", "nss", false, 16133, "25.05.95", "5:00"),
                new FileItem("bungee", "nss", false, 41914, "25.05.95", "5:00")
            };
        }

        static void DrawTopMenu()
        {
            Write(0, 0,
                new string(' ', ScreenWidth),
                ConsoleColor.White,
                ConsoleColor.DarkCyan);

            var menuItems = new (string word, int x)[]
            {
                ("Левая", 2),
                ("Файл", 10),
                ("Диск", 17),
                ("Команды", 24),
                ("Правая", 34)
            };

            foreach (var item in menuItems)
            {
                Write(item.x, 0,
                    item.word.Substring(0, 1),
                    ConsoleColor.Yellow,
                    ConsoleColor.DarkCyan);

                Write(item.x + 1, 0,
                    item.word.Substring(1),
                    ConsoleColor.Black,
                    ConsoleColor.DarkCyan);
            }

            string time = " 8 30 ";
            int timePositionX = ScreenWidth - time.Length;

            Write(timePositionX, 0, time,
                ConsoleColor.Black,
                ConsoleColor.Cyan);

            SetColors(ConsoleColor.White, ConsoleColor.Blue);
        }

        static void DrawTopPanelBorder()
        {
            string line =
                "\u2554" + new string('\u2550', LeftPanelWidth) + "\u2557" +
                "\u2554" + new string('\u2550', RightPanelWidth) + "\u2557";

            Write(0, PanelTop, line,
                ConsoleColor.White,
                ConsoleColor.Blue);

            string label = " C:\\NC ";

            int leftTitleX =
                1 + (LeftPanelWidth - label.Length) / 2;

            int rightTitleX =
                RightPanelX + 1 +
                (RightPanelWidth - label.Length) / 2;

            Write(leftTitleX, PanelTop, label,
                ConsoleColor.Cyan,
                ConsoleColor.Blue);

            Write(rightTitleX, PanelTop, label,
                ConsoleColor.Cyan,
                ConsoleColor.Blue);
        }

        static void DrawColumnHeaders()
        {
            DrawPanelWalls(HeaderRow);

            int x = 1;

            string[] headerLabels =
            {
                " C:\u2193 Имя",
                "Имя",
                "Имя"
            };

            for (int i = 0; i < 3; i++)
            {
                Write(x, HeaderRow,
                    CenterInWidth(headerLabels[i], 12),
                    ConsoleColor.Yellow,
                    ConsoleColor.Blue);

                x += 12;

                if (i < 2)
                {
                    Write(x, HeaderRow, "\u2502",
                        ConsoleColor.White,
                        ConsoleColor.Blue);

                    x++;
                }
            }

            x = RightPanelX + 1;

            Write(x, HeaderRow,
                CenterInWidth(" C:\u2193 Имя", 12),
                ConsoleColor.Yellow,
                ConsoleColor.Blue);

            x += 12;

            Write(x, HeaderRow, "\u2502",
                ConsoleColor.White,
                ConsoleColor.Blue);

            x++;

            Write(x, HeaderRow,
                CenterInWidth("Размер", 8),
                ConsoleColor.Yellow,
                ConsoleColor.Blue);

            x += 8;

            Write(x, HeaderRow, "\u2502",
                ConsoleColor.White,
                ConsoleColor.Blue);

            x++;

            Write(x, HeaderRow,
                CenterInWidth("Дата", 9),
                ConsoleColor.Yellow,
                ConsoleColor.Blue);

            x += 9;

            Write(x, HeaderRow, "\u2502",
                ConsoleColor.White,
                ConsoleColor.Blue);

            x++;

            Write(x, HeaderRow,
                CenterInWidth("Время", 6),
                ConsoleColor.Yellow,
                ConsoleColor.Blue);
        }

        static void DrawLeftPanel(List<FileItem> files)
        {
            int columnWidth = LeftColumnWidth;
            int rowsPerColumn = PanelBottomLine - FilesTopRow;
            int maxVisibleFiles = rowsPerColumn * 3;

            List<FileItem> visibleFiles =
                files.Take(maxVisibleFiles).ToList();

            for (int row = 0; row < rowsPerColumn; row++)
            {
                int y = FilesTopRow + row;

                DrawPanelWalls(y);

                int x = 1;

                for (int col = 0; col < 3; col++)
                {
                    int index =
                        col * rowsPerColumn + row;

                    string cell;

                    if (index < visibleFiles.Count)
                    {
                        FileItem f = visibleFiles[index];

                        string name =
                            Shorten(f.Name, LeftNameMaxLength);

                        string ext = "";

                        if (!f.IsDirectory)
                        {
                            ext = f.Ext;
                        }

                        cell =
                            name.PadRight(8) +
                            " " +
                            ext.PadRight(3);
                    }
                    else
                    {
                        cell = new string(' ', columnWidth);
                    }

                    cell = PadOrTrim(cell, columnWidth);

                    Write(x, y, cell,
                        ConsoleColor.Cyan,
                        ConsoleColor.Blue);

                    x += columnWidth;

                    if (col < 2)
                    {
                        Write(x, y, "\u2502",
                            ConsoleColor.White,
                            ConsoleColor.Blue);

                        x++;
                    }
                }
            }
        }

        static void DrawRightPanel(List<FileItem> files)
        {
            int rowsPerColumn =
                PanelBottomLine - FilesTopRow;

            List<FileItem> visibleFiles =
                files.Take(rowsPerColumn).ToList();

            for (int row = 0; row < rowsPerColumn; row++)
            {
                int y = FilesTopRow + row;

                DrawPanelWalls(y);

                string name = "";
                string ext = "";
                string size = "";
                string date = "";
                string time = "";

                if (row < visibleFiles.Count)
                {
                    FileItem f = visibleFiles[row];

                    name =
                        Shorten(f.Name, RightNameMaxLength);

                    if (f.IsDirectory)
                    {
                        ext = "";
                        size = "417392";
                    }
                    else
                    {
                        ext = f.Ext;
                        size = f.Size.ToString();
                    }

                    date = f.Date;
                    time = f.Time;
                }

                ConsoleColor fg;
                ConsoleColor bg;

                if (row == 0)
                {
                    fg = ConsoleColor.Blue;
                    bg = ConsoleColor.Cyan;
                }
                else
                {
                    fg = ConsoleColor.Cyan;
                    bg = ConsoleColor.Blue;
                }

                int x = RightPanelX + 1;

                string nameColumn =
                    name.PadRight(8) +
                    " " +
                    ext.PadRight(3);

                Write(x, y,
                    PadOrTrim(nameColumn, 12),
                    fg,
                    bg);

                x += 12;

                Write(x, y, "\u2502",
                    ConsoleColor.White,
                    bg);

                x++;

                Write(x, y,
                    size.PadLeft(8),
                    fg,
                    bg);

                x += 8;

                Write(x, y, "\u2502",
                    ConsoleColor.White,
                    bg);

                x++;

                Write(x, y,
                    PadOrTrim(date, 9),
                    fg,
                    bg);

                x += 9;

                Write(x, y, "\u2502",
                    ConsoleColor.White,
                    bg);

                x++;

                Write(x, y,
                    time.PadLeft(6),
                    fg,
                    bg);
            }
        }

        static void DrawMiddleBorder()
        {
            string line =
                "\u2560" +
                new string('\u2500', LeftPanelWidth) +
                "\u2563" +
                "\u2560" +
                new string('\u2500', RightPanelWidth) +
                "\u2563";

            Write(0, PanelBottomLine, line,
                ConsoleColor.White,
                ConsoleColor.Blue);
        }

        static void DrawCatalogInfoRow()
        {
            DrawPanelWalls(PanelInfoRow);

            string left =
                PadOrTrim(
                    " ..        \u25B8КАТАЛОГ\u25C2  11.10.02  19:18",
                    LeftPanelWidth);

            Write(1, PanelInfoRow, left,
                ConsoleColor.Cyan,
                ConsoleColor.Blue);

            int x = RightPanelX + 1;

            Write(x, PanelInfoRow,
                PadOrTrim("..", 12),
                ConsoleColor.Yellow,
                ConsoleColor.Blue);

            x += 13;

            Write(x, PanelInfoRow,
                "\u25B8КАТАЛОГ\u25C2".PadLeft(8),
                ConsoleColor.Cyan,
                ConsoleColor.Blue);

            x += 9;

            Write(x, PanelInfoRow,
                PadOrTrim("11.10.02", 9),
                ConsoleColor.Cyan,
                ConsoleColor.Blue);

            x += 10;

            Write(x, PanelInfoRow,
                "19:48".PadLeft(6),
                ConsoleColor.Cyan,
                ConsoleColor.Blue);
        }

        static void DrawBottomPanelBorder()
        {
            string line =
                "\u255A" +
                new string('\u2550', LeftPanelWidth) +
                "\u255D" +
                "\u255A" +
                new string('\u2550', RightPanelWidth) +
                "\u255D";

            Write(0, BottomBorderRow, line,
                ConsoleColor.White,
                ConsoleColor.Blue);
        }

        static void DrawStatusLine()
        {
            Write(0, StatusRow,
                new string(' ', ScreenWidth),
                ConsoleColor.White,
                ConsoleColor.Black);

            Write(0, StatusRow,
                "C:\\NC>",
                ConsoleColor.White,
                ConsoleColor.Black);
        }

        static void DrawFunctionKeys()
        {
            string[] keys =
            {
                "1Помощь",
                "2Вызов",
                "3Чтение",
                "4Правка",
                "5Копия",
                "6НовИмя",
                "7НовКат",
                "8Удал-е",
                "9Меню",
                "10Выход"
            };

            Write(0, FunctionKeyRow,
                new string(' ', ScreenWidth),
                ConsoleColor.White,
                ConsoleColor.Black);

            int x = 0;

            foreach (string key in keys)
            {
                string number =
                    new string(
                        key.TakeWhile(char.IsDigit).ToArray()
                    );

                string text =
                    key.Substring(number.Length);

                Write(x, FunctionKeyRow,
                    number,
                    ConsoleColor.White,
                    ConsoleColor.Black);

                Write(x + number.Length, FunctionKeyRow,
                    text,
                    ConsoleColor.Black,
                    ConsoleColor.DarkCyan);

                x += number.Length +
                     text.Length +
                     1;
            }
        }

        static void SetColors(ConsoleColor fg, ConsoleColor bg)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }

        static void Write(
            int x,
            int y,
            string text,
            ConsoleColor fg,
            ConsoleColor bg)
        {
            Console.SetCursorPosition(x, y);

            SetColors(fg, bg);

            Console.Write(text);
        }

        static void PaintBackground(ConsoleColor bg)
        {
            SetColors(ConsoleColor.Gray, bg);

            string emptyLine =
                new string(' ', ScreenWidth);

            for (int y = 0; y < ScreenHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(emptyLine);
            }
        }

        static string Shorten(string name, int maxLen)
        {
            if (name.Length <= maxLen)
            {
                return name;
            }

            return name.Substring(0, maxLen - 1) + "~";
        }

        static string PadOrTrim(string s, int width)
        {
            if (s.Length > width)
            {
                return s.Substring(0, width);
            }

            return s.PadRight(width);
        }

        static string CenterInWidth(string s, int width)
        {
            if (s.Length >= width)
            {
                return s.Substring(0, width);
            }

            int paddingTotal =
                width - s.Length;

            int left =
                paddingTotal / 2;

            int right =
                paddingTotal - left;

            return new string(' ', left) +
                   s +
                   new string(' ', right);
        }

        static void DrawPanelWalls(int y)
        {
            Write(0, y, "\u2551",
                ConsoleColor.White,
                ConsoleColor.Blue);

            Write(LeftPanelWidth + 1, y, "\u2551",
                ConsoleColor.White,
                ConsoleColor.Blue);

            Write(RightPanelX, y, "\u2551",
                ConsoleColor.White,
                ConsoleColor.Blue);

            Write(ScreenWidth - 1, y, "\u2551",
                ConsoleColor.White,
                ConsoleColor.Blue);
        }
    }
}
