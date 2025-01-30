using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF___projekt
{
    class InfoList
    {
        public ObservableCollection<Chuze>Chuzes {  get; set; } //Funguje podbně jako list, akorát hned při změně řekne xamlu že došlo ke změně
        public InfoList()
        {
            Chuzes = new ObservableCollection<Chuze>();
        }
        public void PridatChuze(string name, int den, int mesic, int rok, string voleni ,int howMuch)
        {
            Chuzes.Add(new Chuze(name, den, mesic, rok, voleni, howMuch)); //Přidat chůzy do info listu
        }

        public void OdebratChuze(Chuze chuze)
        {
            if (Chuzes.Contains(chuze))
            {
                Chuzes.Remove(chuze);
            }
        }
    }
    
}
