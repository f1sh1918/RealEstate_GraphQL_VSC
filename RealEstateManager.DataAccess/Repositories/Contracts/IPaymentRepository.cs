using System.Collections.Generic;
using RealEstateManager.Database.Models;
namespace RealEstateManager.DataAccess.Repositories.Contracts
{
public interface IPaymentRepository
{
   IEnumerable<Payment> GetAllForProperty(int properyId);
   IEnumerable<Payment> GetAllForProperty(int properyId, int lastAmount);

}
}