using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Rules
{
    public class FrameworkBusinessRules
    {
        private readonly IFrameworkRepository _frameworkRepository;
        private readonly ICodingLanguageRepository _codingLanguageRepository;
        public FrameworkBusinessRules(IFrameworkRepository frameworkRepository, ICodingLanguageRepository codingLanguageRepository)
        {
            _frameworkRepository = frameworkRepository;
            _codingLanguageRepository = codingLanguageRepository;
        }

        public async Task FrameworkNameCannotBeRepeatedWhenInsertedAsync(string name)
        {
            var framework = await _frameworkRepository.GetAsync(e => e.Name == name);
            if (framework != null)
                throw new BusinessException("Framework name already exists");
        }

        public async Task CodingLanguageMustExistForFrameworkOperationsAsync(int id)
        {
            var codingLanguage = await _codingLanguageRepository.GetAsync(e => e.Id == id);
            if (codingLanguage == null)
                throw new BusinessException("Coding Language does not exists");
        }
    }
}
