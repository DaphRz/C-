using InovaWeek_WPF.Control;
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

namespace InovaWeek_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IdeiaControle objIdeiaControle = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxArea.Text) &&
                !string.IsNullOrEmpty(TextBoxIdeia.Text))
            {
                if (objIdeiaControle.ControleCadastrar(TextBoxArea.Text,
                                               TextBoxIdeia.Text,
                                               float.Parse(TextBoxCusto.Text)))
                {
                    MessageBox.Show("Cadastrado com Sucesso!");
                }
            }
            else
            {
               MessageBox.Show("Preencha todos os campos!");
            }
        }
    }
}