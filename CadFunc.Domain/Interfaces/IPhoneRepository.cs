using CadFunc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Domain.Interfaces
{
    public interface IPhoneRepository
    {
        Task<IEnumerable<Phone>> GetPhonesAsync();
        Task<Phone> GetByIdAsync(int? id);
        Task<Phone> CreateAsync(Phone phone);
        Task<Phone> UpdateAsync(Phone phone);
        Task<Phone> RemoveAsync(Phone phone);
    }
}
