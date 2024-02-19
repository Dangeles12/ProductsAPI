using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntityDto : BaseDto
    {
        public virtual DateTimeOffset? DeletedDate { get; set; }
        public virtual DateTimeOffset CreatedDate { get; set; }
        public virtual DateTimeOffset? UpdatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual string DeletedBy { get; set; }
    }
}
