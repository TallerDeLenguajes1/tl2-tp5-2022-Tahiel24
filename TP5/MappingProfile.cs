using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TP5.Models;
using TP5.ViewModels;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CadetesViewModels, Cadete>();
        CreateMap<Cadete, CadetesViewModels>();
    }
}
