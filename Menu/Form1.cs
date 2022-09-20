using Tetris;
using System.Windows;
namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 TelaRanking = new Form2();
            
            TelaRanking.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Sobre = new Form3();
            Sobre.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lOGININToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 login = new Form4();
            login.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow x = new MainWindow();
            x.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}