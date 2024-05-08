﻿using ProdavnicaObuce.DTOs;

namespace ProdavnicaObuce.Interface
{
    public interface IZaposleniServis
    {
        Task<List<ProizvodDTO>> GetProizvode();
        Task KreirajProizvod(KreirajProizvodDTO kreirajProizvodDTO);
    }
}