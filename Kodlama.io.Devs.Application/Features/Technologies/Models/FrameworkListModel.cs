﻿using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Technologies.Models
{
    public class FrameworkListModel : BasePageableModel
    {
        public List<FrameworkListDto> Items { get; set; }
    }
}
