using System;
using System.Windows.Forms;

namespace TinyScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            lstTokens.Items.Clear();

            string code = txtCode.Text;

            Scanner scanner = new Scanner();
            var tokens = scanner.Scan(code);

            foreach (var t in tokens)
            {
                lstTokens.Items.Add(t.ToString());
            }

            try
            {
                Parser parser = new Parser(tokens);
                parser.Parse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}