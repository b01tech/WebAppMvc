namespace WebAppMvc.Models;

public class Seller
{
    public int SellerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

    public Seller()
    {
        
    }

    public Seller(int sellerId, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        SellerId = sellerId;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }


    public void AddSales(SalesRecord sr)
    {
        Sales.Add(sr);
    }

    public void RemoveSale(SalesRecord sr)
    {
        Sales.Remove(sr);   
    }

    public double TotalSales(DateTime initialDate, DateTime finalDate)
    {
        double totalSales = 0;
        foreach(SalesRecord sr in Sales.Where(s => s.Date >= initialDate && s.Date <= finalDate))
        {
            totalSales += sr.Amount;
        }

        return totalSales;
    }
}
