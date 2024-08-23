namespace WebAppMvc.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string? Name { get; set; }
    public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

    public Department()
    {
        
    }

    public Department(int departmentId, string? name)
    {
        DepartmentId = departmentId;
        Name = name;
    }

    public void AddSeller(Seller seller)
    {
        Sellers.Add(seller);
    }

    public double TotalSales(DateTime initialDate, DateTime finalDate)
    {
        return Sellers.Sum(s => s.TotalSales(initialDate, finalDate));
    }
}
