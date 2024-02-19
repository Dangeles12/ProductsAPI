using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseDto
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
