using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takerman.Marketplace.Services.Enums;

namespace Takerman.Marketplace.Services.Dtos
{
    public class PostDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> Platforms { get; set; }

        public IEnumerable<string> Pictures { get; set; }
    }
}
