using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_Bingo
{
    public partial class Form1 : Form
    {
        int cont = 0;//contador utilizado no label6 para mostrar quantidade de rodadas
        Bingo bin;//variável bin do tipo bingo
        Timer bingow = new Timer();//timer utilizado para pitnar botoes randomicamente quando der bingo
        
        
        
        
        public Form1()
        {
            InitializeComponent();
            bin = new Bingo(this);//stancia um novo bingo
            bingow.Interval = 1000;//intervalo do timer bingow
            bingow.Tick += new EventHandler(bingow_Tick);//tick do timer bingow
            
        }
        private void bingow_Tick(object sender, EventArgs e)
        {
            bin.Bingow(this, button2);//tick do timer chama o metodo bingow quando o jogo acaba
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //botao proxima rodada, chama metodo ProximaRodada da classe Bingo, enquanto não der quina chama as funções de quina da classe Cartela, se a cartela estiver cheia chama o metodo CartelaCheia da classe cartela e ativa o timer bingow
        private void button2_Click(object sender, EventArgs e)
        {
            cont++;
            label6.Text = cont + "ª RODADA".ToString();
            bin.ProximaRodada(this);
            if (bin.car.Quin == -1)
                bin.car.Quin = -2;
            if (bin.car.Quin != -1 && bin.car.Quin != -2)
            {
                if (((bin.car.QuinaTrans1(this) || bin.car.QuinaTrans2(this) || (bin.car.QuinaVert(this)) || (bin.car.QuinaHori(this)) == true )))
                {
                    MessageBox.Show("Quina encontrada");
                    bin.car.Quin=-1;
                }
            }

            if (bin.car.CartelaCheia(this, button2) == true)
            {
                bingow.Enabled = true;
            }
            
        }

        

        

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void novoJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //mostra informações dos desenvolvedores
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Desenvolvido por:\n Anderson Hipocreme RA: 1418/12\n Leandro Zatin RA: 0731/12");
        }
        //mostra ajuda
        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Legenda:\n  Cor Amarela = Ultimo Número Sorteado\n  Cor Azul = Números já Sorteados \n  Cor Verde = Quina Encontrada \n  Cor Vermelha = Cartela Cheia\n\nTeclas de Atalho: \n  F1 = Ajuda \n  F2 = Sobre \n  F5 = Novo Jogo \n  Ctrl+Del = Sair");
        }
        //reinicia o jogo
        private void novoJogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bingow.Enabled = false;
            bin.LimparSorteados(this);
            bin.car.ReiniciarCartela(this);
            bin.car.pintados = 0;
            bin.tab.ReiniciarTabela(this);
            button2.Enabled = true;
            bin.car.Quin = 0;
            cont = 0;
            label6.Text = " ";
        }
        //fexa o jogo
        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
