using System;

class Bai01
{
    private long[] a;
    private long n; // So luong phan tu 
    private static long M = 1;
    private static long LIM = 100;

    public long SumOdd()
    {
        long res = 0;
        foreach (var x in a)
            if (x % 2 != 0)
                res += x;
        return res;
    }

    public long PrimeCounting(Func<long, bool> IsPrime)
    {
        long cnt = 0;
        foreach (var x in a)
            if (IsPrime(x))
                cnt++;
        return cnt;
    }

    public long MinSquare(Func<long, bool> Square)
    {
        long ans = long.MaxValue;
        foreach (var x in a)
        {
            if (Square(x))
                ans = Math.Min(ans, x);
        }

        return ans == long.MaxValue ? -1 : ans;
    }

    private bool IsPrime(long x)
    {
        if (x < 2) return false;
        for (long i = 2; i * i <= x; ++i)
            if (x % i == 0)
                return false;
        return true;
    }

    public void InputArray()
    {
        Console.Write("Nhap so phan tu cua mang: ");
        Console.Out.Flush();
        n = long.Parse(Console.ReadLine());
        a = new long[n];

        Random r = new Random();
        for (long i = 0; i < n; ++i)
            a[i] = r.Next(1, 10000);
        Console.WriteLine("Mang da duoc khoi tao ngau nhien...");
        for (long i = 0; i < n; ++i) Console.Write(a[i] + " "); 
        Console.WriteLine();
    }

    public void DisplayArray()
    {
        if (a == null)
        {
            Console.WriteLine("Mang chua duoc khoi tao.");
            return;
        }

        Console.Write("Cac phan tu trong mang la: ");
        foreach (var x in a)
            Console.Write(x + " ");
        Console.WriteLine();
    }

    public void Run()
    {
        long choice;
        do
        {
            Console.WriteLine("\n==== MENU CHUONG TRINH ====");
            Console.WriteLine("1. Nhap va khoi tao mang ngau nhien");
            Console.WriteLine("2. Hien thi mang");
            Console.WriteLine("3. Tinh tong phan tu le");
            Console.WriteLine("4. Dem so luong so nguyen to");
            Console.WriteLine("5. Tim so chinh phuong nho nhat");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
            choice = long.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    InputArray();
                    break;
                case 2:
                    DisplayArray();
                    break;
                case 3:
                    Console.WriteLine("Tong cac phan tu le la: " + SumOdd());
                    break;
                case 4:
                    Console.WriteLine("So luong so nguyen to la: " + PrimeCounting(IsPrime));
                    break;
                case 5:
                    Func<long, bool> IsSquare = x => (long)Math.Sqrt(x) * (long)Math.Sqrt(x) == x;
                    long minSquare = MinSquare(IsSquare);
                    if (minSquare == -1)
                        Console.WriteLine("Khong co so chinh phuong.");
                    else
                        Console.WriteLine("So chinh phuong nho nhat la: " + minSquare);
                    break;
                case 0:
                    Console.WriteLine("Thoat chuong trinh.");
                    break;
                default:
                    Console.WriteLine("Khong hop le. Vui long chon lai");
                    break;
            }
        } while (choice != 0);
    }
}