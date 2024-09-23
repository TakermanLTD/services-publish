using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takerman.Publishing.Services.Dtos
{
    public class ProjectSecretDto
    {
        public int ProjectId { get; set; }

        public int PlatformId { get; set; }

        public IEnumerable<KeyValuePair<int, string>> Secrets { get; set; } = [];
    }
}
