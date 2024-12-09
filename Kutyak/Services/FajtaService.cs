using Kutyak.Controllers;
using Kutyak.DTOs;
using Kutyak.Models;
using Microsoft.EntityFrameworkCore;

namespace Kutyak.Services
{
    public class FajtaService
    {
        public static List<Fajtum> GetFajtak()
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    return context.Fajtas.ToList();
                }
                catch
                {
                    return new List<Fajtum>();
                }
            }
        }

        public static List<FajtaDTO> GetFajtaDTOs()
        {
            using (var context = new KutyakContext())
            {

                try
                {
                    var response = context.Fajtas.Include(f => f.Kutyas).Select(f => new FajtaDTO()
                    {
                        Id = f.Id,
                        Nev = f.Nev,
                        Leiras = f.Leiras,
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<FajtaDTO> response = new List<FajtaDTO>();
                    response.Add(new FajtaDTO { Id = -1, Nev = ex.Message });
                    return response;
                }
            }
        }

        public static string FajtaTorol(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    Fajtum fajta = new Fajtum { Id = id };
                    context.Fajtas.Remove(fajta);
                    //context.SaveChanges();
                    return "Sikeresen törölve a kutya adata.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public static Fajtum GetFajta(int id)
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    return context.Fajtas.FirstOrDefault(f => f.Id == id);
                }
                catch
                {
                    return new Fajtum { Id = 0 };
                }
            }
        }
    }
}
