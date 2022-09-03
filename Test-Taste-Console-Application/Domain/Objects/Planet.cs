using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get;
            set;
        }

        public Planet(PlanetDto planetDto)
        {
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            Moons = new Collection<Moon>();
            float averagemoongravity = 0;
            if(planetDto.Moons != null)
            {
                foreach (MoonDto moonDto in planetDto.Moons)
                {
                    averagemoongravity = averagemoongravity + moonDto.Gravity; // To get the sum of every moon's gravity for particular planet.
                    Moons.Add(new Moon(moonDto));
                }
                averagemoongravity = averagemoongravity / planetDto.Moons.Count; // Calculate the Average of the all moon gravity for single planet.
            }

            AverageMoonGravity = averagemoongravity;
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
