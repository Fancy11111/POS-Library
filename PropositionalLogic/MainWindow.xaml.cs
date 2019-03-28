using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropositionalLogic
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TableEntry> tableEntries = new ObservableCollection<TableEntry>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public Dictionary<char, bool> getBooleanFromInt(List<char> variables, int value)
        {
            string binary = Convert.ToString(value, 2).PadLeft(variables.Count, '0');
            Console.WriteLine(binary);
            if (variables.Count != binary.Length)
                throw new ArgumentException("Not enough variables");
            Dictionary<char, bool> res = new Dictionary<char, bool>();
            for (int i = 0; i < variables.Count ; i++)
            {
                res.Add(variables[i], binary[i] == '0' ? false : true);
            }
            return res;
        }

        public ObservableCollection<TableEntry> TableEntries { get => tableEntries; set => tableEntries = value; }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            AbstractExpression parser = new TermExpression(); //mit konkreter Klasse anlegen

            //Variablenliste zurücksetzen
            AbstractExpression.variables.Clear();

            //Formel parsen
            parser.ParseFormel(new List<char>(inputTextBox.Text.ToCharArray()));

            kv.VariableList = new ObservableCollection<char>(AbstractExpression.variables);
            kv.VariableCount = AbstractExpression.variables.Count;
            kv.Visibility = Visibility.Visible;
            wahrheitstabelleDataGrid.Visibility = Visibility.Visible;

            TableEntries.Clear();
            for (int i=0; i< Math.Pow(2, AbstractExpression.variables.Count); i++)
            {
                Console.WriteLine(i);
                TableEntry entry = new TableEntry(getBooleanFromInt(AbstractExpression.variables, i), parser);
                TableEntries.Add(entry);
                kv[i] = entry.Result;

            }

            //Auswerten für Feld 0001
            //bool result = parser.Interpret();

            //Console.WriteLine(result);
        }
    }
}
