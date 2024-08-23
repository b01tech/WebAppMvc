using WebAppMvc.Models.Enums;

namespace WebAppMvc.Models;

public class SalesRecord
{
    public int SalesRecordId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public SaleStatus Status { get; set; }
    public Seller Seller { get; set; }

    public SalesRecord()
    {
        
    }

    public SalesRecord(int salesRecorId, DateTime date, double amount, SaleStatus status, Seller seller)
    {
        SalesRecordId = salesRecorId;
        Date = date;
        Amount = amount;
        Status = status;
        Seller = seller;
    }
}
