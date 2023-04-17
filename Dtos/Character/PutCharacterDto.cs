using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Character
{
    public class PutCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int HitPoints { get; set; } = 1;
        public int Strength { get; set; } = 1;
        public int Defense { get; set; } = 1;
        public int Intelligence { get; set; } = 1;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}