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
    const int ScreenWidth = 80;
    const int ScreenHeight = 25;
    
    const int LeftPanelWidth = 40;
    const int RightPanelWidth = 40;
    
    const int RightPanelX = LeftPanelWidth;

    //Координаты панелей
    const int PanelTop = 1;//"═" координата по y сверху
    const int PanelHeight = 21;//"═" координата по y снизу

    //Строки внутри панели
    const int HeaderRow = 2;
    const int FilesTopRow = 4; //"-" внутри панели
    const int PanelBottomLine = 19;//"-" внутри панели
    const int PanelInfoRow = 20;//►КАТАЛОГ◄ снизу

    const int LeftColumnWidth = 13;//ширина одной колонки в левой панели
    const int LeftNameMaxLength = 11;//max длина имени файла слева

    const int RightNameMaxLength = 12;//max длина имени файла справа
    const int SizeColumnX = 15;//ширина колонки размера правой панели
    const int DateColumnX = 24;//ширина колонки даты правой панели
    const int TimeColumnX = 33;//ширина колонки времени правой панели

    const int StatusRow = 22;//под снимим окном вывод C:\NC<
    const int FunctionKeyRow = 23;//нижние доп кнопки под окном

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
        Console.BackgroundColor = ConsoleColor.Blue;//цвет фона
        Console.ForegroundColor = ConsoleColor.White;//цвет текста

        for (int y = 0; y < ScreenHeight; y++)//заливка экрана синим
        {
            Write(0, y, new string(' ', ScreenWidth));//ScreenWidth контсанта =80
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
        Console.ForegroundColor = ConsoleColor.White;

        Write(1, 0, "Левая");
        Write(10, 0, "Файл");
        Write(18, 0, "Диск");
        Write(26, 0, "Команды");
        Write(38, 0, "Правая");

        Console.ForegroundColor = ConsoleColor.Black;


        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Write(70, 0, "8  30");
    }

    static void DrawLeftPanel(List<FileItem> files)
    {
        int x = 0;
        //(0, 1, 40, 21)
        DrawBox(x, PanelTop, LeftPanelWidth, PanelHeight);

        Write(x + 16, PanelTop, "C:\\NC");

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;

        Write(x + 1, HeaderRow, "C:\\");
        Write(x + 16, HeaderRow, "Имя");
        Write(x + 29, HeaderRow, "Имя");

        Write(//- горизонтальная одинарная
            x + 1,
            FilesTopRow - 1,//FilesTopRow=40
            new string('\u2500', LeftPanelWidth - 2)
        );

        //(4, 19)
        for (int y = FilesTopRow; y < PanelBottomLine; y++)// - вертикальаная раздел колонки
        {
            Write(x + 13, y, "\u2502");
            Write(x + 26, y, "\u2502");
        }

        List<FileItem> sorted = files
            .OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase)//игнорируеv регистр 
            .ToList();//результат сортировки превращаем обратно в List<FileItem>

        int rowsPerColumn = PanelBottomLine - FilesTopRow;//19-4

        for (int i = 0; i < sorted.Count && i < rowsPerColumn * 3; i++)//*3 т.к три колонки в каждой 15 строк
        {
            int column = i / rowsPerColumn;
            int row = i % rowsPerColumn;//без оcтсттка деления выходит ровно 3 колонки 

            int positionX = x + 1 + column * 13;//вычиялем X файла
            int positionY = FilesTopRow + row;//вычиялем Y файла

            string name = Shorten(//обрезание длины файла до max 11 символов
                sorted[i].Name,
                LeftNameMaxLength//константа = 11
            );

            if (sorted[i].IsDirectory)//проверка каталог или файл
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Write(positionX, positionY, name.PadRight(LeftNameMaxLength));//выводим имя
        }

        Write(//нижняя вертикальная линия над каталог
            x + 1,
            PanelBottomLine,
            new string('\u2500', LeftPanelWidth - 2)
        );

        Console.ForegroundColor = ConsoleColor.White;

        string catalog = "►КАТАЛОГ◄ 11.10.02 19:48";

        int catalogX =//для центирования 
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

        Write(//одинарная горизонтальная
            x + 1,
            FilesTopRow - 1,
            new string('\u2500', RightPanelWidth - 2)
        );

        for (int y = FilesTopRow; y < PanelBottomLine; y++)
        {
            Write(x + 14, y, "\u2502");//одинарная вертикальная
            Write(x + 23, y, "\u2502");
            Write(x + 32, y, "\u2502");
        }

        List<FileItem> sorted = files
            .OrderBy(f => f.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        int rowsPerPanel = PanelBottomLine - FilesTopRow;

        for (int i = 0; i < sorted.Count && i < rowsPerPanel; i++)//цикл для вывода файла
        {
            FileItem file = sorted[i];

            int positionY = FilesTopRow + i;//вычиялем строку вывода файла

            if (file.IsDirectory)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Write(//вывод файла
                x + 1,
                positionY,
                Shorten(file.Name, RightNameMaxLength)
                    .PadRight(RightNameMaxLength)//определяем макс длину файла
            );

            Write(//вывод размера файла
                x + SizeColumnX,
                positionY,
                file.Size.PadLeft(7)
            );

            Write(//вывод даты 
                x + DateColumnX,
                positionY,
                file.Date
            );

            Write(//вывод времени
                x + TimeColumnX,
                positionY,
                file.Time.PadLeft(5)
            );
        }

        Write(//нижняя горизонтальная линия
            x + 1,
            PanelBottomLine,
            new string('\u2500', RightPanelWidth - 2)
        );

        Console.ForegroundColor = ConsoleColor.White;

        string catalog = "►КАТАЛОГ◄ 11.10.02 19:48";

        int catalogX =//вычиляем позицию строки 
            x + (RightPanelWidth - catalog.Length) / 2;

        Write(catalogX, PanelInfoRow, catalog);//вывод строки каталог
    }

    static void DrawBox(int x, int y, int width, int height)// '=' двойная рамка
    {
        Write(
            x,
            y,
            "\u2554" + new string('\u2550', width - 2) + "\u2557"//левый угол + горизонт + правый угол
        );

        for (int i = 1; i < height - 1; i++)
        {
            Write(x, y + i, "\u2551");//вертикальная
            Write(x + width - 1, y + i, "\u2551");
        }

        Write(
            x,
            y + height - 1,
            "\u255A" + new string('\u2550', width - 2) + "\u255D"//левый угол + правый угол
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

            if (key.StartsWith("10"))//двузрначное число или нет
            {
                numberLength = 2;
            }
            else
            {
                numberLength = 1;
            }

            string number = key.Substring(0, numberLength);//с 0 индекса берем numberLength
            string command = key.Substring(numberLength);//с позиции numberLength берем все до конца

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

            x += key.Length + 1;//один пробел между кнопками 
        }

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    static string Shorten(string name, int maxLength)
    {
        if (name.Length <= maxLength)//если меньше чем MaxLength=11
        {
            return name;
        }

        int dot = name.LastIndexOf('.');//ищем позицию точки в имени 

        if (dot > 0 && dot < name.Length - 1)//>0 и после точки хотя бы 1 символ
        {
            string extension = name.Substring(dot);//берем строку с позиции dot и до конца

            int available =
                maxLength - extension.Length - 1;//считаем сколько места осталось

            if (available < 1)//осталось ли место для основной части имени
            {
                return name.Substring(0, maxLength - 1) + "~";//в начало имени ставим ~
            }

            return name.Substring(0, available)//если расширение нормально и место есть
                   + "-"
                   + extension;
        }

        return name.Substring(0, maxLength - 1) + "-";
    }

    static void Write(int x, int y, string text)
    {
        if (y < 0 || y >= ScreenHeight || x >= ScreenWidth)//проверка на корректность координат
        {
            return;
        }

        if (x < 0)//прорверка корректности координаты x
        {
            text = text.Substring(-x);//отбрасываются символы если левее экрана
            x = 0;
        }

        if (x + text.Length > ScreenWidth)//проверка правой границы
        {
            text = text.Substring(0, ScreenWidth - x);//также отбрастываются символы если правее экрана
        }

        Console.SetCursorPosition(x, y);//перемещаем курсор по координатам
        Console.Write(text);
    }
}