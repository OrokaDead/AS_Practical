using _211787P_Practical_Assn.Model;
using _211787P_Practical_Assn.ViewModels;

namespace _211787P_Practical_Assn.Services
{
    public interface IRegistration
    {
        Task<RegistrationResponse> Registration(Registration request);
    }
}
