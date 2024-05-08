using ProdavnicaObuce.DTOs;

namespace ProdavnicaObuce.Interface
{
    public interface IAutorizacijaServis
    {
        public Task Register(RegisterDTO registerDTO);

        public Task<string> Login(LoginDTO loginDTO);
    }
}
