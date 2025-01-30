using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF___projekt
{
    class Chuze
    {
        public string Name { get; set; }
        public int Den {  get; set; }
        public int Mesic {  get; set; }
        public int Rok { get; set; }
        public int HowMuch { get; set; }
        public string Voleni { get; set; }
        public string Info => $"{Den}.{Mesic}. {Rok}, {Name} {Voleni} {HowMuch} Km.";
        public Chuze(string name, int den, int mesic, int rok, string voleni ,int howMuch)
        {
            Name = name;
            Den = den;
            Mesic = mesic;
            Rok = rok;
            Voleni = voleni;
            HowMuch = howMuch;
        }
    }
}
