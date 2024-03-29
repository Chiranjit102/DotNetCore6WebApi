using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.DTOs.Character
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = "Chiro";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defencse { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; }  = RPGClass.Knight;
    }
}