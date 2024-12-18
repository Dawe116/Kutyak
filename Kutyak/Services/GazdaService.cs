﻿using Kutyak.Models;

namespace Kutyak.Services
{
    public class GazdaService
    {

        public static List<Gazdum> GetGazdak()
        {
            using (var context = new KutyakContext())
            {
                try
                {
                    return context.Gazdas.ToList();
                }
                catch
                {
                    return new List<Gazdum>();
                }
            }
        }
    }
}
