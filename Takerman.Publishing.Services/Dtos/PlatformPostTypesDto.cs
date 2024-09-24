using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takerman.Publishing.Services.Dtos
{
    public class PlatformPostTypesDto
    {
        public int PlatformId { get; set; }

        public List<int> PostTypes { get; set; } = [];
    }
}
