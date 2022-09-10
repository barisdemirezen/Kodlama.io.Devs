using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Framework : Entity
    {
        public string Name { get; set; }
        public int CodingLanguageId { get; set; }
        public virtual CodingLanguage? CodingLanguage { get; set; }
    }
}
