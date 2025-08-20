using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using Microsoft.EntityFrameworkCore;
namespace AKL_project_backend.Repository
{



   
        public class AtelierService
        {
            private readonly AppDbContext _context;

            public AtelierService(AppDbContext context)
            {
                _context = context;
            }

            // Ajouter un atelier
            public async Task<Atelier> AddAtelierAsync(Atelier atelier)
            {
                await _context.Atelier.AddAsync(atelier);
                await _context.SaveChangesAsync();
                return atelier;
            }

            // Récupérer tous les ateliers
            public async Task<List<Atelier>> GetAllAteliersAsync()
            {
                return await _context.Atelier.ToListAsync();
            }

            // Récupérer les 5 derniers ateliers triés par date
            public async Task<List<Atelier>> GetLastFiveAteliersAsync()
            {
                return await _context.Atelier
                    .OrderByDescending(a => a.DateOrganisation)
                    .Take(3)
                    .ToListAsync();
            }


        public async Task<bool> DeleteAtelierAsync(int id)
        {
            var atelier = await _context.Atelier.FindAsync(id);
            if (atelier == null)
            {
                return false; // Retourne faux si l'atelier n'existe pas
            }

            _context.Atelier.Remove(atelier);
            await _context.SaveChangesAsync();
            return true; // Retourne vrai si l'atelier est supprimé
        }




        public async Task Reserver(affectationIdForm   reserveForm)
        {
            if (string.IsNullOrWhiteSpace(reserveForm.condidatid))
            {
                throw new ArgumentException("L'ID du candidat ne peut pas être null ou vide.", nameof(reserveForm.condidatid));
            }

            var atelier = await _context.Atelier.FindAsync(reserveForm.offreId);

            if (atelier == null)
            {
                throw new InvalidOperationException($"Aucune offre trouvée avec l'ID {reserveForm.offreId}.");
            }

            if (!atelier.IdReservateur.Contains(reserveForm.condidatid))
            {
                atelier.IdReservateur.Add(reserveForm.condidatid);
                _context.Atelier.Update(atelier);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Le candidat avec l'ID {reserveForm.condidatid} est déjà lié à cette offre.");
            }
        }
    }
    }





