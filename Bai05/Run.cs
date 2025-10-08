using System;
class Bai05
{
    public void Run()
    {
        Console.WriteLine("Nhap vao ngay - thang - nam, cach nhau boi dau cach");
        Console.WriteLine();
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Khong nhap gi ca.");
            return;
        }
        string[] s = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (s.Length != 3 || !int.TryParse(s[0], out int d) || !int.TryParse(s[1], out int m) || !int.TryParse(s[2], out int y))
        {
            Console.WriteLine("Dinh dang dau vao khong hop le.");
            return;
        }

        if (!IsValidDate(d, m, y))
        {
            Console.WriteLine("Ngay thang nam khong hop le.");
            return;
        }

        int N = d + 2 * m + (3 * (m + 1) / 5) + y + (y / 4) - (y / 100) + (y / 400) + 2;
        N %= 7;

        string thu;
        switch (N)
        {
            case 0:
                thu = "Thu Bay";
                break;
            case 1:
                thu = "Chu Nhat";
                break;
            case 2:
                thu = "Thu Hai";
                break;
            case 3:
                thu = "Thu Ba";
                break;
            case 4:
                thu = "Thu Tu";
                break;
            case 5:
                thu = "Thu Nam";
                break;
            case 6:
                thu = "Thu Sau";
                break;
            default:
                thu = "Khong xac dinh";
                break;
        }

        Console.WriteLine(thu);
    }
    private bool IsValidDate(int day, int month, int year)
    {
        if (year < 0 || month < 1 || month > 12) return false;

        int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (month == 2 && IsLeapYear(year))
            daysInMonth[2] = 29;

        return day >= 1 && day <= daysInMonth[month];
    }
    private bool IsLeapYear(int year) =>
        (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}
