using System;

class Bai04
{
    private int[] DayMax = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public void Run()
    {
        Console.WriteLine("Nhap vao mot thang va nam, cach nhau bang khoang trang");
        Console.WriteLine(); 
        string? input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Khong nhap gi ca.");
            return;
        }
        string[] s = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (s.Length != 2 || !int.TryParse(s[0], out int m) || !int.TryParse(s[1], out int y))
        {
            Console.WriteLine("Dinh dang dau vao khong hop le.");
            return;
        }

        if (m < 1 || m > 12 || y < 0)
        {
            Console.WriteLine("Thang hoac nam khong hop le.");
            return;
        }
        int days = (m == 2 && IsLeapYear(y)) ? 29 : DayMax[m];
        Console.WriteLine($"Thang {m} nam {y} co {days} ngay.");
    }
    private bool IsLeapYear(int year) =>
        (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}