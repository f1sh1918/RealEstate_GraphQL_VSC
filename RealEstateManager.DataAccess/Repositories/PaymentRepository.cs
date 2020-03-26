using System.Collections.Generic;
using System.Linq;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories
{
public class PaymentRepository : IPaymentRepository
{
    private readonly RealEstateContext _dbContext;
   public PaymentRepository(RealEstateContext dbContext)
   {
       _dbContext = dbContext;
   } 
   public IEnumerable<Payment> GetAllForProperty(int properyId)
   {
       return _dbContext.Payments.Where(x=>x.PropertyId == properyId);
   }

        public IEnumerable<Payment> GetAllForProperty(int properyId, int lastAmount)
        {
            return _dbContext.Payments.Where(x=>x.PropertyId==properyId)
            .OrderByDescending(x => x.DateCreated)
            .Take(lastAmount);
        }
    }
}