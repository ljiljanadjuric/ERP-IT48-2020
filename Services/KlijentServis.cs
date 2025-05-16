using AutoMapper;
using ProdavnicaObuce.DTOs;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Models;
using ProdavnicaObuce.UnitOfWorkConfig;
using Stripe.Checkout;
using System.Drawing;

namespace ProdavnicaObuce.Services
{
    public class KlijentServis : IKlijentServis
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KlijentServis(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<KlijentProizvodDTO>> GetProizvode()
        {
            var proizvodi = await _unitOfWork.Proizvodi.GetAll();
            return _mapper.Map<List<KlijentProizvodDTO>>(proizvodi);
        }

        public async Task KupiProizvodeKes(KupiProizvodDTO kupiProizvodDTO, int idKupca)
        {
            Prodaja prodaja = _mapper.Map<Prodaja>(kupiProizvodDTO);
            prodaja.IdKupca = idKupca;
            prodaja.VremeProdaje = DateTime.Now;
            double cena = 0;
            foreach (var p in kupiProizvodDTO.StavkeProdaje)
            {
                var proizvod = await _unitOfWork.Proizvodi.GetById(p.IdProizvoda);
                if (proizvod == null)
                {
                    throw new Exception("Proizvod ne postoji!");
                }
                if (p.Kolicina > proizvod.Kolicina)
                {
                    throw new Exception("Proizvoda nema dovoljno na stanju!");
                }
                proizvod.Kolicina -= p.Kolicina;
                cena += proizvod.ProdajnaCena;
            }
            await _unitOfWork.Proizvodi.Save();
            prodaja.CenaProdaje = cena;
            prodaja.StavkeProdaje.ForEach(s => s.IdProdaje = prodaja.Id);

            await _unitOfWork.Prodaje.Insert(prodaja);

            await _unitOfWork.Save();
        }

        public async Task<string?> KupiProizvodeKartica(KupiProizvodDTO kupiProizvodDTO, int idKupca)
        {
            Prodaja prodaja = _mapper.Map<Prodaja>(kupiProizvodDTO);
            prodaja.IdKupca = idKupca;
            prodaja.VremeProdaje = DateTime.Now;
            double cena = 0;

            var dict = new Dictionary<int, Proizvod>();
            foreach (var p in kupiProizvodDTO.StavkeProdaje)
            {
                var proizvod = await _unitOfWork.Proizvodi.GetById(p.IdProizvoda);
                if (proizvod == null)
                {
                    throw new Exception("Proizvod ne postoji!");
                }
                if (p.Kolicina > proizvod.Kolicina)
                {
                    throw new Exception("Proizvoda nema dovoljno na stanju!");
                }
                proizvod.Kolicina -= p.Kolicina;
                cena += proizvod.ProdajnaCena;
                dict.Add(proizvod.Id, proizvod);
            }
            await _unitOfWork.Proizvodi.Save();
            prodaja.CenaProdaje = cena;
            prodaja.StavkeProdaje.ForEach(s => s.IdProdaje = prodaja.Id);

            await _unitOfWork.Prodaje.Insert(prodaja);

            await _unitOfWork.Save();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = kupiProizvodDTO.StavkeProdaje.Select(x =>
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "rsd",
                            UnitAmount = (long)dict[x.IdProizvoda].ProdajnaCena * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = dict[x.IdProizvoda].Ime
                            }
                        },
                        Quantity = x.Kolicina
                    }
                ).ToList(),
                Mode = "payment",
                SuccessUrl = "http://localhost:4200/payment-successful",
                CancelUrl = "http://localhost:4200/",
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", prodaja.Id.ToString() }
                }
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session.Id;
        }

        public async Task<List<KlijentProizvodDTO>> FiltrirajProizvode(double? cena, string? boja, string? brend)
        {
            var proizvodi = await _unitOfWork.Proizvodi.GetAll();
            var filrtriraniProizvodi = proizvodi.Where(p =>
                (cena == null || p.ProdajnaCena < cena) &&
                (boja == null || p.Boja == boja) &&
                (brend == null || p.Brend == brend));
            return _mapper.Map<List<KlijentProizvodDTO>>(filrtriraniProizvodi);

        }

    }
}
