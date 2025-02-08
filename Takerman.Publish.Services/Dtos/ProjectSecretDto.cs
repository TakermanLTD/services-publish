using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takerman.Publish.Data.Entities;

namespace Takerman.Publish.Services.Dtos
{
    public class ProjectSecretDto
    {
        public int ProjectId { get; set; }

        public int PlatformId { get; set; }

        public List<KeyValuePair<int, string>> Secrets { get; set; } = [];
    }
}
