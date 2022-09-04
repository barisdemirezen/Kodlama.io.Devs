using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Rules
{
    public class CodingLanguageBusinessRules
    {
        private readonly ICodingLanguageRepository _codingLanguageRepository;
        public CodingLanguageBusinessRules(ICodingLanguageRepository codingLanguageRepository)
        {
            _codingLanguageRepository = codingLanguageRepository;
        }
        public async Task CodingLanguageNameCannotBeRepeatedWhenInsertedAsync(string name)
        {
            CodingLanguage? codingLanguage = await _codingLanguageRepository.GetAsync(e => e.Name == name);
            if (codingLanguage != null)
                throw new BusinessException("Coding language already exists");
        }
    }
}
