using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FFX2SaveEditor
{
    /// <summary>
    /// Interaction logic for CreatureCreator.xaml
    /// </summary>
    public partial class CreatureCreator : Window
    {
        private Ffx2Save save;

        public byte StandardCupWins { get { return ParseRoundedByte(tbxStandardCupWins.Text); } set { tbxStandardCupWins.Text = value.ToString(); } }
        public byte StandardCupHardWins { get { return ParseRoundedByte(tbxStandardCupHardWins.Text); } set { tbxStandardCupHardWins.Text = value.ToString(); } }
        public byte GrandCupWins { get { return ParseRoundedByte(tbxGrandCupWins.Text); } set { tbxGrandCupWins.Text = value.ToString(); } }
        public byte GrandCupHardWins { get { return ParseRoundedByte(tbxGrandCupHardWins.Text); } set { tbxGrandCupHardWins.Text = value.ToString(); } }
        public byte ChocoboCupWins { get { return ParseRoundedByte(tbxChocoboCupWins.Text); } set { tbxChocoboCupWins.Text = value.ToString(); } }
        public byte CactuarCupWins { get { return ParseRoundedByte(tbxCactuarCupWins.Text); } set { tbxCactuarCupWins.Text = value.ToString(); } }
        public byte YouthLeagueCupWins { get { return ParseRoundedByte(tbxYouthLeagueCupWins.Text); } set { tbxYouthLeagueCupWins.Text = value.ToString(); } }
        public byte AeonCupWins { get { return ParseRoundedByte(tbxAeonCupWins.Text); } set { tbxAeonCupWins.Text = value.ToString(); } }
        public byte FiendWorldCupWins { get { return ParseRoundedByte(tbxFiendWorldCupWins.Text); } set { tbxFiendWorldCupWins.Text = value.ToString(); } }
        public byte FarplaneCupWins { get { return ParseRoundedByte(tbxFarplaneCupWins.Text); } set { tbxFarplaneCupWins.Text = value.ToString(); } }
        public bool ArenaFightsUnlocked { get { return chkArenaFightsUnlocked.IsChecked.HasValue ? (bool)chkArenaFightsUnlocked.IsChecked : false; } set { chkArenaFightsUnlocked.IsChecked = value; } }

        public CreatureCreator(Ffx2Save save)
        {
            this.save = save;
            InitializeComponent();
            StandardCupWins = save.StandardCupWins;
            StandardCupHardWins = save.StandardCupHardWins;
            GrandCupWins = save.GrandCupWins;
            GrandCupHardWins = save.GrandCupHardWins;
            ChocoboCupWins = save.ChocoboCupWins;
            CactuarCupWins = save.CactuarCupWins;
            YouthLeagueCupWins = save.YouthLeagueCupWins;
            AeonCupWins = save.AeonCupWins;
            FiendWorldCupWins = save.FiendWorldCupWins;
            FarplaneCupWins = save.FarplaneCupWins;
        }

        private void textbox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var tbx = (TextBox)sender;
            if (string.IsNullOrEmpty(tbx.Text)) return;

            var qty = int.Parse(tbx.Text);
            if (e.Delta < 0 && qty > 0)
                qty--;
            else if (e.Delta > 0 && qty < 30)
                qty++;

            tbx.Text = qty.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            save.StandardCupWins = StandardCupWins;
            save.StandardCupHardWins = StandardCupHardWins;
            save.GrandCupWins = GrandCupWins;
            save.GrandCupHardWins = GrandCupHardWins;
            save.ChocoboCupWins = ChocoboCupWins;
            save.CactuarCupWins = CactuarCupWins;
            save.YouthLeagueCupWins = YouthLeagueCupWins;
            save.AeonCupWins = AeonCupWins;
            save.FiendWorldCupWins = FiendWorldCupWins;
            save.FarplaneCupWins = FarplaneCupWins;
            save.AllArenaFightsUnlocked = ArenaFightsUnlocked;
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            bool oversized = false;

            if (!string.IsNullOrWhiteSpace(e.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
                oversized = textBox.Text.Length + e.Text.Length - textBox.SelectionLength > 9;

            e.Handled = oversized || Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private byte ParseRoundedByte(String text)
        {
            int value = int.Parse(text);
            if(value > 255)
            {
                return 255;
            } else
            {
                return (byte) value;
            }
        }
    }
}
