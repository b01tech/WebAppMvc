using WebAppMvc.Data;
using WebAppMvc.Models;

namespace WebAppMvc.Services;

public class SellerService
{
    private readonly AppDbContext _context;

    public SellerService(AppDbContext context)
    {
        _context = context;
    }


    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller seller)
    {
        if (seller is null)
        {
            return;
        }
        seller.Department = _context.Department.First();
        _context.Seller.Add(seller);
        _context.SaveChanges();

    }
}
