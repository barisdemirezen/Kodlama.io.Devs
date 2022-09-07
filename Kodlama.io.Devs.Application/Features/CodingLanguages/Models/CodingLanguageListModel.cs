using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.CodingLanguages.Models
{
    public class CodingLanguageListModel : BasePageableModel
    {
        public List<CodingLanguageListDto> Items { get; set; }
    }
}
