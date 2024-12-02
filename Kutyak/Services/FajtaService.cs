using Kutyak.Models;

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
                    return context.Fajta.ToList();
                }
                catch
                {
                    return new List<Fajtum>();
                }
            }
        }
    }
}
