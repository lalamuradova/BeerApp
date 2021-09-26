using BeerApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeerApp
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : Window
    {
        public EditView()
        {
            InitializeComponent();
            ShowHistory();
        }

        public void ShowHistory()
        {
            List<string> texts = new List<string>();

            try
            {
                Json.JsonDeserialize(texts);
                foreach (var item in texts)
                {
                    Listbox1.Text += "\n" + item;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File not found");
            }
               
           
        }
    }
}
