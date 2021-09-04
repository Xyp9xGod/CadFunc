using CadFunc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Application.Interfaces
{
    public interface IPhoneService
    {
        Task<IEnumerable<PhoneDTO>> GetPhones();
        Task<PhoneDTO> GetById(int? id);
        Task Add(PhoneDTO phoneDTO);
        Task Update(PhoneDTO phoneDTO);
        Task Remove(int? id);
    }
}
