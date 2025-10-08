using System;
using System.Collections.Generic;
using System.Linq;

class Bai06
{
    private List<List<long>> a = new List<List<long>>();
    private int n, m;
    private Random r = new Random();

    public void Input()
    {
        Console.WriteLine(); 
        Console.Write("Nhap so dong (n): ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Nhap so cot (m): ");
        m = int.Parse(Console.ReadLine());
        a.Clear();
        for (int i = 0; i < n; ++i)
        {
            List<long> row = new List<long>();
            for (int j = 0; j < m; ++j)
            {
                long val = r.Next(1, 1900);
                row.Add(val);
            }
            a.Add(row);
        }

        Console.WriteLine("Ma tran da tao ngau nhien:");
        DisplayMatrix();
    }

    public void DisplayMatrix()
    {
        foreach (var row in a)
        {
            foreach (var x in row)
                Console.Write($"{x,6}");
            Console.WriteLine();
        }
    }

    public long FindMax(Func<long, long, long> maximize)
    {
        long res = a[0][0];
        foreach (var row in a)
            foreach (var x in row)
                res = maximize(res, x);
        return res;
    }

    public long FindMin(Func<long, long, long> minimize)
    {
        long res = a[0][0];
        foreach (var row in a)
            foreach (var x in row)
                res = minimize(res, x);
        return res;
    }

    public int RowWithMaxSum()
    {
        int pos = 0;
        long maxSum = a[0].Sum();
        for (int i = 1; i < n; ++i)
        {
            long sum = a[i].Sum();
            if (sum > maxSum)
            {
                maxSum = sum;
                pos = i;
            }
        }
        return pos;
    }

    public bool IsPrime(long x)
    {
        if (x < 2) return false;
        for (long i = 2; i * i <= x; ++i)
            if (x % i == 0)
                return false;
        return true;
    }

    public long SumNonPrime()
    {
        long sum = 0;
        foreach (var row in a)
            foreach (var x in row)
                if (!IsPrime(x))
                    sum += x;
        return sum;
    }

    public void DeleteKthRow()
    {
        Console.Write("Nhap chi so dong muon xoa (bat dau tu 0): ");
        int k = int.Parse(Console.ReadLine());
        if (k < 0 || k >= n)
        {
            Console.WriteLine("Chi so khong hop le.");
            return;
        }
        a.RemoveAt(k);
        n--;
        Console.WriteLine("Da xoa dong.");
    }

    public void DeleteColumnWithMaxElement()
    {
        long max = FindMax((a, b) => a > b ? a : b);
        HashSet<int> colsToDelete = new HashSet<int>();

        for (int i = 0; i < n; ++i)
            for (int j = 0; j < m; ++j)
                if (a[i][j] == max)
                    colsToDelete.Add(j);

        List<List<long>> newMatrix = new List<List<long>>();
        foreach (var row in a)
        {
            List<long> newRow = new List<long>();
            for (int j = 0; j < m; ++j)
            {
                if (!colsToDelete.Contains(j))
                    newRow.Add(row[j]);
            }
            newMatrix.Add(newRow);
        }

        a = newMatrix;
        m = a[0].Count;
        Console.WriteLine("Da xoa cac cot co chua phan tu lon nhat.");
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Nhap ma tran ngau nhien");
            Console.WriteLine("2. Tim phan tu lon nhat");
            Console.WriteLine("3. Tim phan tu nho nhat");
            Console.WriteLine("4. Dong co tong lon nhat");
            Console.WriteLine("5. Tong cac so khong la so nguyen to");
            Console.WriteLine("6. Xoa dong k");
            Console.WriteLine("7. Xoa cac cot chua phan tu lon nhat");
            Console.WriteLine("8. Hien thi ma tran");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Input();
                    break;
                case "2":
                    Console.WriteLine("Max = " + FindMax((a, b) => a > b ? a : b));
                    break;
                case "3":
                    Console.WriteLine("Min = " + FindMin((a, b) => a < b ? a : b));
                    break;
                case "4":
                    Console.WriteLine("Dong co tong lon nhat: " + RowWithMaxSum());
                    break;
                case "5":
                    Console.WriteLine("Tong cac so khong la so nguyen to: " + SumNonPrime());
                    break;
                case "6":
                    DeleteKthRow();
                    break;
                case "7":
                    DeleteColumnWithMaxElement();
                    break;
                case "8":
                    DisplayMatrix();
                    break;
                case "0":
                    Console.WriteLine("Thoat chuong trinh.");
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
    }
}
