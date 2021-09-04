using AutoMapper;
using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using CadFunc.Domain.Entities;
using CadFunc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Application.Services
{
    public class PhoneService : IPhoneService
    {
        private IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;

        public PhoneService(IMapper mapper, IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository ??
                 throw new ArgumentNullException(nameof(phoneRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<PhoneDTO>> GetPhones()
        {
            var phonesEntity = await _phoneRepository.GetPhonesAsync();
            return _mapper.Map<IEnumerable<PhoneDTO>>(phonesEntity);
        }

        public async Task<PhoneDTO> GetById(int? id)
        {
            var phonesEntity = await _phoneRepository.GetByIdAsync(id);
            return _mapper.Map<PhoneDTO>(phonesEntity);
        }

        public async Task Add(PhoneDTO phoneDTO)
        {
            var phoneEntity = _mapper.Map<Phone>(phoneDTO);
            await _phoneRepository.CreateAsync(phoneEntity);
        }

        public async Task Update(PhoneDTO phoneDTO)
        {
            var phoneEntity = _mapper.Map<Phone>(phoneDTO);
            await _phoneRepository.UpdateAsync(phoneEntity);
        }

        public async Task Remove(int? id)
        {
            var phoneEntity = _phoneRepository.GetByIdAsync(id).Result;
            await _phoneRepository.RemoveAsync(phoneEntity);
        }

        
    }
}
