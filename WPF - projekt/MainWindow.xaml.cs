using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF___projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InfoList infolist;
        public MainWindow()
        {
            InitializeComponent();
            infolist = new InfoList();
            DataContext = infolist; //nastavení bindingu

        }

        private void Button_Click_Pridat(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;
            string voleni = volba.Text; // výběr akce 
            int den = 0;
            int mesic = 0;
            int rok = 0;
            int howMuch = 0;

            //Kontrola jestli je den číslo
            if (Int32.TryParse(DenInput.Text, out den ))
            {
                //Kontrola jestli je den větší než 1 a menší než 31
                if (den < 1 || den > 31)    // || - 2x AltGr + W
                {
                    MessageBox.Show("Den nemůže být menší než 1 a větší než 31");
                }
                else
                {
                    //Kontrola jestli je Měsíc číslo
                    if (Int32.TryParse(MesicInput.Text, out mesic))
                    {
                        //Kontrola jestli je měsíc v rozmezí 1 - 12
                        if (mesic < 1 || mesic > 12)
                        {
                            MessageBox.Show("Měsíc musí být v rozmezí 1 - 12");
                        }
                        else
                        {
                            //Kontrola jestli je rok číslo
                            if (Int32.TryParse(RokInput.Text, out rok))
                            {
                                if (rok < 2000 ||  rok > 2026)
                                {
                                    MessageBox.Show("Rok musí být v rozmezí 2000 - 2026");
                                }
                                else
                                {
                                    //Kontrola jestli je počet kroků číslo
                                    if (Int32.TryParse(HowMuchInput.Text, out howMuch))
                                    {
                                        //Kontrola jestli je počet kroků víc než 1
                                        if (howMuch < 1)
                                        {
                                            MessageBox.Show("Počet kroků musí být větší než 1");
                                        }
                                        else
                                        {
                                            //Kontola jestli je zvolena akce, a popřípadě jaká akce je zvolena
                                            if (voleni == "Chůze")
                                            {
                                                voleni = "ušel";
                                                infolist.PridatChuze(name, den, mesic, rok, voleni, howMuch);
                                                return;
                                            }
                                            else if (voleni == "Běh")
                                            {
                                                voleni = "uběhl";
                                                infolist.PridatChuze(name, den, mesic, rok, voleni, howMuch);
                                                return;
                                            }
                                            else if (voleni == "Jízda na kole")
                                            {
                                                voleni = "ujel na kole";
                                                infolist.PridatChuze(name, den, mesic, rok, voleni, howMuch);
                                                return;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Musíš zvoli akci");
                                            }  
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Počet musí být číslo");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rok musí být číslo");
                                return;
                            }
                        }  
                    }
                    else
                    {
                        MessageBox.Show("Mesic musí být číslo");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Den musí být číslo");
                return;
            }
             
        }

        //Button_Click_Zobrazit
        private void Button_Click_Zobrazit(object sender, EventArgs e)
        {
            if (ListHodnot.SelectedItem is Chuze selectedChuze)
            {
                MessageBox.Show($"Datum: {selectedChuze.Den}.{selectedChuze.Mesic}. {selectedChuze.Rok} \nJméno: {selectedChuze.Name} \nČinost: {selectedChuze.Voleni} {selectedChuze.HowMuch} Km");
            }
            else
            {
                MessageBox.Show("Musí být zvolena některá z položek");
            }
        }


        //Button_Click_Odebrat
        private void Button_Click_Odebrat(object sender, EventArgs e)
        {
            if (ListHodnot.SelectedItem is Chuze selectedChuze)
            {
                infolist.OdebratChuze(selectedChuze);
                MessageBox.Show("Úspěšně odstraněno");
            }
            else
            {
                MessageBox.Show("Musí být zvolena některá z položek");
            }
        }
    }
}