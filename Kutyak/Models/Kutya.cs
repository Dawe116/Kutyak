﻿using System;
using System.Collections.Generic;

namespace Kutyak.Models;

public partial class Kutya
{
    public int Id { get; set; }

    public int GazdaId { get; set; }

    public int FajtaId { get; set; }

    public int Eletkor { get; set; }

    public string ChipNumber { get; set; } = null!;

    public string Nev { get; set; } = null!;

    public byte[] IndexKep { get; set; } = null!;

    public byte[] Kep { get; set; } = null!;

    public virtual Fajtum Fajta { get; set; } = null!;

    public virtual Gazdum Gazda { get; set; } = null!;
}
