using System;
using System.Collections.Generic;
using System.Linq;

class FileItem
{
    public string Name;
    public string Size;
    public string Date;
    public string Time;
    public bool IsDirectory;

    public FileItem(
        string name,
        string size,
        string date,
        string time,
        bool isDirectory = false)
    {
        Name = name;
        Size = size;
        Date = date;
        Time = time;
        IsDirectory = isDirectory;
    }
}

class Program
{
    // Размер всего экрана
    const int ScreenWidth = 80;
    const int ScreenHeight = 25;

    // Левая и правая панели
    const int LeftPanelWidth = 40;
    const int RightPanelWidth = 40;

    // Координата начала правой панели
    const int RightPanelX = LeftPanelWidth;

    // Координаты панелей
    const int PanelTop = 1;
    const int PanelHeight = 21;

    // Строки внутри панели
    const int HeaderRow = 2;
    const int FilesTopRow = 4;
    const int PanelBottomLine = 19;
    const int PanelInfoRow = 20;

    // Колонки левой панели
    const int LeftColumnWidth = 13;
    const int LeftNameMaxLength = 11;

    // Колонки правой панели
    const int RightNameMaxLength = 12;
    const int SizeColumnX = 15;
    const int DateColumnX = 24;
    const int TimeColumnX = 33;

    // Нижняя часть экрана
    const int StatusRow = 22;
    const int FunctionKeyRow = 23;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;//для рамок и киррилицы
        Console.CursorVisible = false;

        List<FileItem> files = CreateFiles();//список файлов

        DrawAll(files);

        Console.ReadKey(true);

        Console.ResetColor();
        Console.CursorVisible = true;
    }

    static List<FileItem> CreateFiles()
    {
        return new List<FileItem>
        {
            new FileItem("..", "", "11.10.02", "19:48", true),

            new FileItem("123view.exe", "128380", "25.05.02", "5:00"),
            new FileItem("4372ansi.set", "255", "25.05.95", "5:00"),
            new FileItem("8502ansi.set", "255", "25.05.95", "5:00"),
            new FileItem("8632ansi.set", "255", "25.05.95", "5:00"),
            new FileItem("8652ansi.set", "255", "25.05.95", "5:00"),
            new FileItem("8662ansi.set", "255", "25.05.95", "5:00"),
            new FileItem("Ajaccgdo...", "417392", "10.12.10", "9:02"),
            new FileItem("ansi12437.set", "255", "25.05.95", "5:00"),
            new FileItem("ansi12850.set", "255", "25.05.95", "5:00"),
            new FileItem("ansi12863.set", "255", "25.05.95", "5:00"),
            new FileItem("ansi12865.set", "255", "25.05.95", "5:00"),
            new FileItem("ansi12866.set", "255", "25.05.95", "5:00"),
            new FileItem("arcview.exe", "81738", "25.05.95", "5:00"),
            new FileItem("bitmap.exe", "54805", "25.05.95", "5:00"),
            new FileItem("bug.nss", "16133", "25.05.95", "5:00"),
            new FileItem("bungee.nss", "41914", "25.05.95", "5:00"),
            new FileItem("clp2dib.exe", "", "25.05.95", "5:00"),
            new FileItem("dbview.exe", "", "25.05.95", "5:00"),
            new FileItem("draw2wmf.exe", "", "25.05.95", "5:00"),
            new FileItem("drw2wmf.exe", "", "25.05.95", "5:00"),
            new FileItem("ico2dib.exe", "", "25.05.95", "5:00"),
            new FileItem("msp2dib.exe", "", "25.05.95", "5:00"),
            new FileItem("MyLongFileNameExample.txt", "45231", "15.08.01", "16:20"),
            new FileItem("nc.cfg", "", "25.05.95", "5:00"),
            new FileItem("nc.exe", "", "25.05.95", "5:00"),
            new FileItem("nc.ext", "", "25.05.95", "5:00"),
            new FileItem("nc.fil", "", "25.05.95", "5:00"),
            new FileItem("nc.hlp", "", "25.05.95", "5:00"),
            new FileItem("nc.ico", "", "25.05.95", "5:00"),
            new FileItem("nc.ini", "", "25.05.95", "5:00"),
            new FileItem("ncclean.exe", "", "25.05.95", "5:00"),
            new FileItem("ncclean.ini", "", "25.05.95", "5:00"),
            new FileItem("ncdd.exe", "", "25.05.95", "5:00"),
            new FileItem("ncedit.exe", "", "25.05.95", "5:00"),
            new FileItem("ncff.exe", "", "25.05.95", "5:00"),
            new FileItem("ncff.hlp", "", "25.05.95", "5:00"),
            new FileItem("nclabel.exe", "", "25.05.95", "5:00"),
            new FileItem("ncmain.exe", "", "25.05.95", "5:00"),
            new FileItem("ncnet.exe", "", "25.05.95", "5:00"),
            new FileItem("ncpscrip.hdr", "", "25.05.95", "5:00"),
            new FileItem("ncsi.exe", "", "25.05.95", "5:00"),
            new FileItem("nczip.exe", "", "25.05.95", "5:00"),
            new FileItem("nc_exit.com", "", "25.05.95", "5:00"),
            new FileItem("nc_exit.doc", "", "25.05.95", "5:00"),
            new FileItem("norton.ini", "", "25.05.95", "5:00"),
            new FileItem("packer.exe", "", "25.05.95", "5:00"),
            new FileItem("paraview.exe", "", "25.05.95", "5:00"),
            new FileItem("pct2dib.exe", "", "25.05.95", "5:00"),
            new FileItem("playwave.exe", "", "25.05.95", "5:00"),

            new FileItem("Program Files", "", "11.10.02", "19:48", true),

            new FileItem("q&aview.exe", "", "25.05.95", "5:00"),
            new FileItem("rbview.exe", "", "25.05.95", "5:00"),
            new FileItem("refview.exe", "", "25.05.95", "5:00"),
            new FileItem("saver.exe", "", "25.05.95", "5:00"),
            new FileItem("telemax.dat", "", "25.05.95", "5:00"),
            new FileItem("telemax.exe", "", "25.05.95", "5:00"),
            new FileItem("telemax.hlp", "", "25.05.95", "5:00"),
            new FileItem("telemax.ini", "", "25.05.95", "5:00"),
            new FileItem("tif2dib.exe", "", "25.05.95", "5:00"),
            new FileItem("vector.exe", "", "25.05.95", "5:00"),
            new FileItem("wpb2dib.exe", "", "25.05.95", "5:00"),
            new FileItem("wpv2wmf.exe", "", "25.05.95", "5:00"),
            new FileItem("wpview.exe", "", "25.05.95", "5:00")
        };
    }

    static void DrawAll(List<FileItem> files)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        for (int y = 0; y < ScreenHeight; y++)//заливка экрана синим
        {
            Write(0, y, new string(' ', ScreenWidth));
        }

        DrawTopMenu();
        DrawLeftPanel(files);
        DrawRightPanel(files);
        DrawStatusLine();
        DrawFunctionKeys();
    }

    static void DrawTopMenu()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Yellow;

        Write(1, 0, "Левая");
        Write(10, 0, "Файл");
        Write(18, 0, "Диск");
        Write(26, 0, "Команды");
        Write(38, 0, "Правая");

        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;


        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Write(70, 0, "8  30");
    }

    static void DrawLeftPanel(List<FileItem> files)
    {
        int x = 0;

        DrawBox(x, PanelTop, LeftPanelWidth, PanelHeight);

        Write(x + 16, PanelTop, "C:\\NC");

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Write(x + 1, HeaderRow, "C:\\");
        Write(x + 16, HeaderRow, "Имя");
        Write(x + 29, HeaderRow, "Имя");

        Write(
            x + 1,
            FilesTopRow - 1,
            new string('─', LeftPanelWidth - 2)
        );

        for (int y = FilesTopRow; y < PanelBottomLine; y++)
        {
            Write(x + 13, y, "│");
            Write(x + 26, y, "│");
        }

        List<FileItem> sorted = files
            .OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        int rowsPerColumn = PanelBottomLine - FilesTopRow;

        for (int i = 0;
             i < sorted.Count && i < rowsPerColumn * 3;
             i++)
        {
            int column = i / rowsPerColumn;
            int row = i % rowsPerColumn;

            int positionX = x + 1 + column * 13;
            int positionY = FilesTopRow + row;

            string name = Shorten(
                sorted[i].Name,
                LeftNameMaxLength
            );

            if (sorted[i].IsDirectory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Write(positionX, positionY, name.PadRight(LeftNameMaxLength));
        }

        Write(
            x + 1,
            PanelBottomLine,
            new string('─', LeftPanelWidth - 2)
        );

        Console.ForegroundColor = ConsoleColor.White;

        string catalog = "►КАТАЛОГ◄ 11.10.02 19:48";

        int catalogX =
            x + (LeftPanelWidth - catalog.Length) / 2;

        Write(catalogX, PanelInfoRow, catalog);
    }

    static void DrawRightPanel(List<FileItem> files)
    {
        int x = RightPanelX;

        DrawBox(x, PanelTop, RightPanelWidth, PanelHeight);

        Write(x + 16, PanelTop, "C:\\NC");

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Write(x + 1, HeaderRow, " C:\\ Имя");
        Write(x + SizeColumnX, HeaderRow, "Размер");
        Write(x + DateColumnX, HeaderRow, "Дата");
        Write(x + TimeColumnX, HeaderRow, "Время");

        Write(
            x + 1,
            FilesTopRow - 1,
            new string('─', RightPanelWidth - 2)
        );

        for (int y = FilesTopRow; y < PanelBottomLine; y++)
        {
            Write(x + 14, y, "│");
            Write(x + 23, y, "│");
            Write(x + 32, y, "│");
        }

        List<FileItem> sorted = files
            .OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        int rowsPerPanel = PanelBottomLine - FilesTopRow;

        for (int i = 0; i < sorted.Count && i < rowsPerPanel; i++)
        {
            FileItem file = sorted[i];

            int positionY = FilesTopRow + i;

            if (file.IsDirectory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Write(
                x + 1,
                positionY,
                Shorten(file.Name, RightNameMaxLength)
                    .PadRight(RightNameMaxLength)
            );

            Write(
                x + SizeColumnX,
                positionY,
                file.Size.PadLeft(7)
            );

            Write(
                x + DateColumnX,
                positionY,
                file.Date
            );

            Write(
                x + TimeColumnX,
                positionY,
                file.Time.PadLeft(5)
            );
        }

        Write(
            x + 1,
            PanelBottomLine,
            new string('─', RightPanelWidth - 2)
        );

        Console.ForegroundColor = ConsoleColor.White;

        string catalog = "►КАТАЛОГ◄ 11.10.02 19:48";

        int catalogX =
            x + (RightPanelWidth - catalog.Length) / 2;

        Write(catalogX, PanelInfoRow, catalog);
    }

    static void DrawBox(int x, int y, int width, int height)
    {
        Write(
            x,
            y,
            "╔" + new string('═', width - 2) + "╗"
        );

        for (int i = 1; i < height - 1; i++)
        {
            Write(x, y + i, "║");
            Write(x + width - 1, y + i, "║");
        }

        Write(
            x,
            y + height - 1,
            "╚" + new string('═', width - 2) + "╝"
        );
    }

    static void DrawStatusLine()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Write(0, StatusRow, new string(' ', ScreenWidth));
        Write(0, StatusRow, "C:\\NC>");
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

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Write(0, FunctionKeyRow, new string(' ', ScreenWidth));
        Write(0, FunctionKeyRow + 1, new string(' ', ScreenWidth));

        int x = 0;

        foreach (string key in keys)
        {
            int numberLength;

            if (key.StartsWith("10"))
            {
                numberLength = 2;
            }
            else
            {
                numberLength = 1;
            }

            string number = key.Substring(0, numberLength);
            string command = key.Substring(numberLength);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Write(x, FunctionKeyRow, number);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            Write(
                x + numberLength,
                FunctionKeyRow,
                command
            );

            x += key.Length + 1;
        }

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    static string Shorten(string name, int maxLength)
    {
        if (name.Length <= maxLength)
        {
            return name;
        }

        int dot = name.LastIndexOf('.');

        if (dot > 0 && dot < name.Length - 1)
        {
            string extension = name.Substring(dot);

            int available =
                maxLength - extension.Length - 1;

            if (available < 1)
            {
                return name.Substring(0, maxLength - 1) + "~";
            }

            return name.Substring(0, available)
                   + "-"
                   + extension;
        }

        return name.Substring(0, maxLength - 1) + "-";
    }

    static void Write(int x, int y, string text)
    {
        if (y < 0 || y >= ScreenHeight || x >= ScreenWidth)
        {
            return;
        }

        if (x < 0)
        {
            text = text.Substring(-x);
            x = 0;
        }

        if (x + text.Length > ScreenWidth)
        {
            text = text.Substring(0, ScreenWidth - x);
        }

        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }
}
