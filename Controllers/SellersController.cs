using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMvc.Data;
using WebAppMvc.Models;
using WebAppMvc.Services;

namespace WebAppMvc.Controllers;

public class SellersController : Controller
{
    private readonly AppDbContext _context;
    private  readonly SellerService _sellerService;

    public SellersController(AppDbContext context, SellerService sellerService)
    {
        _context = context;
        _sellerService = sellerService; 
    }

    // GET: Sellers
    public async Task<IActionResult> Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }

    // GET: Sellers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seller = await _context.Seller
            .FirstOrDefaultAsync(m => m.SellerId == id);
        if (seller == null)
        {
            return NotFound();
        }

        return View(seller);
    }

    // GET: Sellers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Sellers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }

    // GET: Sellers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seller = await _context.Seller.FindAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        return View(seller);
    }

    // POST: Sellers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("SellerId,Name,Email,BirthDate,BaseSalary")] Seller seller)
    {
        if (id != seller.SellerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(seller.SellerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(seller);
    }

    // GET: Sellers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seller = await _context.Seller
            .FirstOrDefaultAsync(m => m.SellerId == id);
        if (seller == null)
        {
            return NotFound();
        }

        return View(seller);
    }

    // POST: Sellers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var seller = await _context.Seller.FindAsync(id);
        if (seller != null)
        {
            _context.Seller.Remove(seller);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SellerExists(int id)
    {
        return _context.Seller.Any(e => e.SellerId == id);
    }
}
