using Application.Common.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.Common.GenericHandler
{
    public class BaseCommand<TResponse> : IRequest<TResponse> where TResponse : class
    {
        [JsonIgnore]
        public virtual ActionTypes ActionType { get; set; }
        public int Id { get; set; }
    }
}
