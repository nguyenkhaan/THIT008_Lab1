using System;
class Bai02
{
    public bool IsPrime(long n)
    {
        if (n < 2) return false; 
        for (long i = 2; i * i <= n; ++i)
            if (n % i == 0)
                return false;
        return true; 
    }
    public void Run()
    {
        Console.WriteLine(); 
        Console.WriteLine("Nhap so nguyen duong n: ");
        Console.WriteLine(); 
        long n = long.Parse(Console.ReadLine()); 
        
        // Console.Write("Cac so nguyen to nho hon n la: ");
        long s = 0; 
        for (long i = 0; i <= n; ++i)
        {
            if (IsPrime(i) == true)
            {
                // Console.Write(i + " ");
                s += i; 
            }
        }
        Console.WriteLine($"\nTong cac so nguyen to la: {s}"); 
    }
}