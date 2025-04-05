using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net;

namespace ProdavnicaObuce.Services
{
    public class AutorizacijaServis : IAutorizacijaServis
    {
        private IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AutorizacijaServis(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<Korisinik>(registerDTO);
            await _unitOfWork.Korisnici.Insert(user);
            await _unitOfWork.Save();
        }

        private string GetToken(Korisinik korisnik)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, korisnik.KorisnickoIme!),
                new Claim(ClaimTypes.Role, korisnik.Tip.ToString()),
                new Claim("Id", korisnik.Id.ToString()),
                new Claim("Email", korisnik.Email!),
            };
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponseDto> Login(LoginDTO loginDTO)
        {
            var korisnici = await _unitOfWork.Korisnici.GetAll();
            var korisnik = korisnici
                .Where(u => u.Email.Equals(loginDTO.Email))
                .FirstOrDefault();
            if (korisnik == null)
                throw new Exception($"Incorrect email. Try again.");

            if (!BC.BCrypt.Verify(loginDTO.Sifra, korisnik.Sifra))
                throw new Exception("Invalid password");
            var token = GetToken(korisnik);
            return new LoginResponseDto
            {
                Token = token
            };
        }
    }
}
