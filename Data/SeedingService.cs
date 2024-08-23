using WebAppMvc.Models;

namespace WebAppMvc.Data;

public class SeedingService
{
    private readonly AppDbContext _context;

    public SeedingService(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Department.Any() || _context.Seller.Any() || _context.Sales.Any())
        {
            return;
        }
        var d1 = new Department(1,name:"Eletronics");
        var d2 = new Department(2,name:"Fashion");
        var d3 = new Department(3,name:"Books");

        var s1 = new Seller(1, name: "John", email: "jonh@gmail.com", baseSalary: 2500.00, birthDate:new DateTime(1990, 02, 11),department:d1);
        var s2 = new Seller(2, name: "Mary", email: "mary@gmail.com", baseSalary: 1000.00, birthDate:new DateTime(1996, 06, 25),department:d1);
        var s3 = new Seller(3, name: "Robert", email: "robert@gmail.com", baseSalary: 2200.00, birthDate:new DateTime(1992, 07, 14),department:d2);
        var s4 = new Seller(4, name: "Anna", email: "anna@gmail.com", baseSalary: 3000.00, birthDate:new DateTime(1986, 12, 03),department:d2);
        var s5 = new Seller(5, name: "Sarah", email: "sarah@gmail.com", baseSalary: 1200.00, birthDate:new DateTime(1985, 01, 30),department:d3);

        var r1 = new SalesRecord(1, date: new DateTime(2020,11,02), amount:2000.00, seller:s1, status:Models.Enums.SaleStatus.Billed);
        var r2 = new SalesRecord(2, date: new DateTime(2020,11,02), amount:5700.50, seller:s1, status:Models.Enums.SaleStatus.Billed);
        var r3 = new SalesRecord(3, date: new DateTime(2020,11,03), amount:1000.99, seller:s4, status:Models.Enums.SaleStatus.Billed);
        var r4 = new SalesRecord(4, date: new DateTime(2020,11,17), amount:1400.30, seller:s2, status:Models.Enums.SaleStatus.Pending);
        var r5 = new SalesRecord(5, date: new DateTime(2020,12,20), amount:400.59, seller:s2, status:Models.Enums.SaleStatus.Billed);
        var r6 = new SalesRecord(6, date: new DateTime(2020,12,30), amount:326.99, seller:s3, status:Models.Enums.SaleStatus.Billed);
        var r7 = new SalesRecord(7, date: new DateTime(2020,12,02), amount:1000.20, seller:s2, status:Models.Enums.SaleStatus.Billed);
        var r8 = new SalesRecord(8, date: new DateTime(2021,01,07), amount:7500.00, seller:s1, status:Models.Enums.SaleStatus.Billed);

        _context.Department.AddRange(d1,d2,d3);
        _context.Seller.AddRange(s1, s2, s3, s4, s5);
        _context.Sales.AddRange(r1,r2,r3,r4,r5,r6,r7,r8);
        _context.SaveChanges();
    }
}
