﻿using DotNetAnnuaireApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetAnnuaireApi.Services
{
    public class SalarieService : ISalarieService
    {
        private readonly AnnuaireContext _context;

        public SalarieService(AnnuaireContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salarie>> GetAllSalariesAsync()
        {
            return await _context.Salaries.ToListAsync();
        }

        public async Task<Salarie> GetSalarieByIdAsync(int id)
        {
            return await _context.Salaries.FindAsync(id);
        }

        public async Task<Salarie> AddSalarieAsync(Salarie Salarie)
        {
            Salarie.MotDePasse = BCrypt.Net.BCrypt.HashPassword(Salarie.MotDePasse);
            _context.Salaries.Add(Salarie);
            await _context.SaveChangesAsync();
            return Salarie;
        }

        public async Task UpdateSalarieAsync(Salarie Salarie)
        {
            var elem = await _context.Salaries.FindAsync(Salarie.Id);
            if (elem != null)
            {
                if (Salarie.MotDePasse != elem.MotDePasse)
                {
                    Salarie.MotDePasse = BCrypt.Net.BCrypt.HashPassword(Salarie.MotDePasse);
                }
                elem.Nom = Salarie.Nom;
                elem.Prenom = Salarie.Prenom;
                elem.TelephoneFixe = Salarie.TelephoneFixe;
                elem.TelephonePortable = Salarie.TelephonePortable;
                elem.Email = Salarie.Email;
                elem.MotDePasse = Salarie.MotDePasse;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSalarieAsync(int id)
        {
            var salarie = await _context.Salaries.FindAsync(id);
            if (salarie != null)
            {
                _context.Salaries.Remove(salarie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Salarie>> GetSalarieByNomAsync(string nom)
        {
            return await _context.Salaries.Where(s => s.Nom.Contains(nom)).ToListAsync();
        }

        public async Task<IEnumerable<Salarie>> GetSalarieBySiteAsync(int siteId)
        {
            return await _context.Salaries.Where(s => s.SiteId == siteId).ToListAsync();
        }

        public async Task<IEnumerable<Salarie>> GetSalarieByServiceAsync(int serviceId)
        {
            return await _context.Salaries.Where(s => s.ServiceId == serviceId).ToListAsync();
        }
    }

}
