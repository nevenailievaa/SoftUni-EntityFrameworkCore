using System;

namespace SoftUni
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Install-Package Microsoft.EntityFrameworkCore.Tools –v 6.0.1
            //Install-Package Microsoft.EntityFrameworkCore.SqlServer –v 6.0.1
            //Install-Package Microsoft.EntityFrameworkCore.Design -v 6.0.1

            //Scaffold-DbContext -Connection "Server=DESKTOP-140PNU1\SQLEXPRESS;Database=SoftuniEF;Integrated Security=True; TrustServerCertificate=True" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        }
    }
}