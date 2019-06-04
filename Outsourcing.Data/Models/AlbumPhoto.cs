using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    class AlbumPhoto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ControlType { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPublic { get; set; }
        public bool Deleted { get; set; }
    }
}
