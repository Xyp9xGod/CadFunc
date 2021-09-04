using CadFunc.Domain.Entities;
using CadFunc.Domain.Interfaces;
using CadFunc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadFunc.Infra.Data.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        ApplicationDbContext _phoneContext;
        public PhoneRepository(ApplicationDbContext context)
        {
            _phoneContext = context;
        }
        public async Task<Phone> CreateAsync(Phone phone)
        {
            _phoneContext.Add(phone);
            await _phoneContext.SaveChangesAsync();
            return phone;
        }

        public async Task<Phone> GetByIdAsync(int? id)
        {
            var phone = await _phoneContext.Phones.FindAsync(id);
            if (phone != null)
            {
                _phoneContext.Entry(phone).State = EntityState.Detached;//evita erro por tracking.
            }
            return phone;
        }

        public async Task<IEnumerable<Phone>> GetPhonesAsync()
        {
            return await _phoneContext.Phones.ToListAsync();
        }

        public async Task<Phone> RemoveAsync(Phone phone)
        {
            _phoneContext.Remove(phone);
            await _phoneContext.SaveChangesAsync();
            return phone;
        }

        public async Task<Phone> UpdateAsync(Phone phone)
        {
            _phoneContext.Update(phone);
            await _phoneContext.SaveChangesAsync();
            return phone;
        }
    }
}
