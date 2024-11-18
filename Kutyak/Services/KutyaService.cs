using Kutyak.DTOs;
using Kutyak.Models;
using Microsoft.EntityFrameworkCore;

namespace Kutyak.Services
{
    public class KutyaService
    {
        public static List<Kutya> GetKutyak()
        {
            using (var context = new KutyakContext())
            {

                try
                {
                    var response = context.Kutyas.Include(f => f.Gazda.IrszamNavigation).Include(f => f.Fajta).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<Kutya> response = new List<Kutya>();
                    response.Add(new Kutya { Id = -1, Nev = ex.Message });
                    return response;
                }
            }
        }

        public static List<KutyakDTO> GetKutyakDTOs()
        {
            using (var context = new KutyakContext())
            {

                try
                {
                    var response = context.Kutyas.Include(f => f.Gazda.IrszamNavigation).Include(f => f.Fajta).Select(f => new KutyakDTO()
                    {
                        Id = f.Id,
                        GazdaNev = f.Gazda.Nev,
                        IrSzam = f.Gazda.Irszam,
                        Telepules = f.Gazda.IrszamNavigation.Nev,
                        Lakcim = f.Gazda.Lakcim,
                        FajtaNev = f.Fajta.Nev,
                        Eletkor = f.Eletkor,
                        ChipNumber = f.ChipNumber,
                        IndexKep = f.IndexKep
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<KutyakDTO> response = new List<KutyakDTO>();
                    response.Add(new KutyakDTO { Id = -1, Nev = ex.Message });
                    return response;
                }
            }
        }

        public static KutyaGumiDTO GetKutyaGumi(int id)
        {
            using (var context = new KutyakContext())
            {

                try
                {
                    var response = context.Kutyas.Where(f => f.Id == id).Select(f => new KutyaGumiDTO()
                    {
                        Kep = f.Kep
                    }).ToList();
                    return response[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static string KutyaTorol(int id)
        {
            using (var context = new KutyakContext())
            {

                try
                {
                    Kutya kutya = new Kutya { Id = id };
                    context.Kutyas.Remove(kutya);
                    context.SaveChanges();
                    return "Sikeresen törölve lett a kutya adatai.";
                }
                catch (Exception ex)
                {
                    return "Sikertelen volt a törlés";
                }
            }
        }


    }
}
