using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bases
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? DeletedDate { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string? CreatedBy { get; set; }
        string? UpdatedBy { get; set; }
        string? DeletedBy { get; set; }
    }
    public class BaseEntity : Base, IBase
    {
        public virtual DateTimeOffset? DeletedDate { get; set; }
        public virtual DateTimeOffset CreatedDate { get; set; }
        public virtual DateTimeOffset? UpdatedDate { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual string ?UpdatedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
    }
}
