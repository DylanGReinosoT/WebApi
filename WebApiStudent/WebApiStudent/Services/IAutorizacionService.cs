using WebApiLibrary.Models.Custom;

namespace WebApiLibrary.Services
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);
    }
}
