using System.Threading.Tasks;
using MediatR;

namespace SampleAngular.Application.Common.Interfaces
{
    public interface IParentFiller<in TParent> where TParent : class, new()
    {
        Task FillParent(IMediator mediator, TParent product);
    }
}