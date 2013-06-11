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
    class Cartela
    {
        //constructor da classe
        public Cartela(Form f)
        {
            CriarCartela(f);
        }
        Button[] btn = new Button[25];//vetor de botoes da cartela
        int x = 680, y = 50;//posicionamento inicial da cartela
        static int contcar = 0;//contador utilizado para criar botoes da cartela
        int[] cartela = new int[25];//ao criar a catela os números apresentados no btn[].Text são guardados neste vetor
        public int Quin;//contador para verificar quina, enquanto for diferente de -1ou-2 chama os metodos de quina, quando for  igual a cinco anuncia quina e recebe -1
        public int pintados = 0;//contador para verificar a quantidade de numeros pintados na cartela, sempre que for igual a 24 é anunciado o fim do jogo
        //################Variáveis Refatoradas######################
        public Button[] Btn
        {
            get { return btn; }
            set { btn = value; }
        }             
        public int[] Cartela1
        {
            get { return cartela; }
            set { cartela = value; }
        }        
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Contcar
        {
            get { return contcar; }
            set { contcar = value; }
        }
        //###################################################
        //#################METODOS DA CARTELA#####################  
        //Instancia o vetor de botoes btn criando 25 botoes e mostrando apenas 24(1 coringa)
        public void CriarCartela(Form f)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int l = 0; l < 5; l++)
                {                  
                    int nro;              
                    if (Contcar == 12)
                    {
                        X = X + 45;
                        PictureBox pic = new PictureBox();
                        pic.Image = Properties.Resources.coringa;
                        Btn[Contcar] = new Button();
                        Btn[Contcar].BackColor = Color.CornflowerBlue;
                        pic.Size = new System.Drawing.Size(50, 50);
                        pic.Location = new System.Drawing.Point(765, 135);
                        Btn[Contcar].Enabled = false;
                        f.Controls.Add(pic);
                        
                    }
                    else
                    {
                        do
                        {
                            nro = SortearNumero();
                        } while (ValidarNumero(Cartela1, nro, 24) == false);
                        Cartela1[Contcar] = nro;
                        Btn[Contcar] = new Button();
                        Btn[Contcar].Size = new System.Drawing.Size(40, 40);
                        Btn[Contcar].Name = Contcar.ToString();                        
                        Btn[Contcar].Text = nro.ToString();
                        Btn[Contcar].BackColor = Color.LightGray;
                        Btn[Contcar].Location = new System.Drawing.Point(X, Y);
                        Btn[Contcar].Enabled = false;
                        f.Controls.Add(Btn[Contcar]);
                        X = X + 45;
                    }
                    Contcar++;
                }                
                Y = Y + 45;
                X = 680;
            }            
        }
        //Sorteia numero Randomico
        public int SortearNumero()
        {
            Random rdn = new Random();
            int nro;
            nro = rdn.Next(1, 61);
            return (nro);
        }
        //Verifica se numero já foi sorteado
        public bool ValidarNumero(int[] vetor, int nro, int qnt)
        {


            for (int i = 0; i < qnt; i++)
            {
                if (nro == vetor[i])
                {
                    return false;
                }

            }
            return true;
        }
        //marca numero sorteado e validado na cartela
        public int MarcarNumero(int nro,Form f)
        {
            for (int i = 0; i < 25; i++)
            {
                
                if (nro == Cartela1[i])
                {
                    pintados++;
                    Btn[i].BackColor = Color.Yellow;
                    
                    return i;
                    
                }
            }
            return -1;
        }
        //reinicia cartela com as caracteristicas padrões
        public void ReiniciarCartela(Form f)
        {
            X = 680; Y = 50;
            int contador = 0;
            int teste = 0;
            Btn[12].BackColor = Color.CornflowerBlue;


            for (int j = 0; j < 5; j++)
            {

                for (int l = 0; l < 5; l++)
                {
                    contador++;
                    //if (contador == 25)
                    //    contador--;
                    int nro;





                    if (contador == teste + 13)
                    {
                        X = X + 45;
                        teste += 13;
                    }
                    else
                    {
                        do
                        {
                            nro = SortearNumero();
                        } while (ValidarNumero(Cartela1, nro, 24) == false);
                        Cartela1[contador - 1] = nro;
                        Btn[contador - 1].Size = new System.Drawing.Size(40, 40);
                        Btn[contador - 1].Name = Contcar.ToString();
                        Btn[contador - 1].Text = nro.ToString();
                        Btn[contador - 1].BackColor = Color.LightGray;
                        Btn[contador - 1].Location = new System.Drawing.Point(X, Y);
                        Btn[contador - 1].Enabled = false;
                        f.Controls.Add(Btn[contador - 1]);
                        X = X + 45;
                    }


                }

                Y = Y + 45;
                X = 680;
            }


        }
        //###########################################################################
        //#################METODOS DE VERIFICACAO DE QUINA#####################  
        public bool QuinaHori(Form f)
        {
            
            for (int j = 0; j < 5; j++)
            {
                Quin = 0;
                int[] colorir = new int[5];
                for (int i = 0; i < 5; i++)
                    if (Btn[i + (j * 5)].BackColor != Color.LightGray)
                    {
                        colorir[i] = i + (j * 5);
                        Quin++;
                    }
                if (Quin == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Btn[colorir[i]].BackColor = Color.Green;
                    }
                    return true;
                }
            }
            return false;
        }
        public bool QuinaVert(Form f)
        {
            for (int j = 0; j < 5; j++)
            {
                int[] colorir = new int[5];
                Quin = 0;
                for (int i = 0; i < 5; i++)
                    if (Btn[j + (i * 5)].BackColor != Color.LightGray)
                    {
                        colorir[i] = j + (i * 5);
                        Quin++;
                    }
                if (Quin == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Btn[colorir[i]].BackColor = Color.Green;
                    }
                    return true;
                }
            }
            return false;
        }
        public bool QuinaTrans1(Form f)
        {

            if ((Btn[0].BackColor != Color.LightGray) && (Btn[6].BackColor != Color.LightGray) && (Btn[18].BackColor != Color.LightGray) && (Btn[24].BackColor != Color.LightGray))
            {
                Btn[0].BackColor = Color.Green;
                Btn[6].BackColor = Color.Green;                
                Btn[18].BackColor = Color.Green;
                Btn[24].BackColor = Color.Green;
                return true;
            }


            return false;
        }
        public bool QuinaTrans2(Form f)
        {

            if ((Btn[4].BackColor != Color.LightGray) && (Btn[8].BackColor != Color.LightGray) && (Btn[16].BackColor != Color.LightGray) && (Btn[20].BackColor != Color.LightGray))
            {
                Btn[4].BackColor = Color.Green;
                Btn[8].BackColor = Color.Green;                
                Btn[16].BackColor = Color.Green;
                Btn[20].BackColor = Color.Green;
                return true;
            }


            return false;
        }        
        //###########################################################################
        public bool CartelaCheia(Form f, Button botao)
        {
            

            if (pintados == 24)
            {
                botao.Enabled = false;
                for (int i = 0; i < 25; i++)
                {
                    btn[i].BackColor = Color.Red;
                }
                MessageBox.Show("                                                  Bingo!!!\n                                  Você completou a cartela!!\n              Clique em Novo Jogo(F5) para jogar novamente!!\n                    ou em Sair(Ctrl+del) para fexar o programa!!");

                return (true);
            }
            return (false);
        }
        //###########################################################################
        
        
    }
}
