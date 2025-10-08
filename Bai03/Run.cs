using System;

class Bai03
{
    delegate int GetMax(int month, int year);

    private GetMax DayMax = (month, year) =>
    {
        switch (month)
        {
            case 1: case 3: case 5: case 7: case 8: case 10: case 12: return 31;
            case 4: case 6: case 9: case 11: return 30;
            case 2:
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) return 29;
                return 28;
            default: return 0;
        }
    };

    public bool Validation(int day, int month, int year)
    {
        
        if (month < 1 || month > 12 || year < 0) return false;
        int maxDay = DayMax(month, year);
        return day >= 1 && day <= maxDay;
    }

    public void Run()
    {
        Console.WriteLine("Nhap ngay, thang, nam, cach nhau bang khoang trang");
        Console.WriteLine();
        string[] parts = new string[10000]; 
        parts = Console.ReadLine().Split(); 
        int day = int.Parse(parts[0]);
        int month = int.Parse(parts[1]);
        int year = int.Parse(parts[2]);
        bool isValid = Validation(day, month, year);
        Console.WriteLine(isValid ? "Hop Le" : "Khong hop le"); 
    }
}