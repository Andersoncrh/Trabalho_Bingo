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
    class Tabela
    {
        public Tabela(Form f)
        {
            CriarTabela(f);
        }
        public Button[] btn = new Button[60];//vetor de botoes da classe
        int x = 22, y = 50;//posicionamento inicial da tabela
        int contab = 0;//contador da classe
        //################Variáveis Refatoradas######################
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
        public int Contab
        {
            get { return contab; }
            set { contab = value; }
        }
        //############################################################
        //#################METODOS DA TABELA#####################
        //Instancia o vetor de botoes btn criando 60 botoes
        private void CriarTabela(Form f)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int l = 0; l < 10; l++)
                {
                    
                    btn[Contab] = new Button();
                    btn[Contab].Size = new System.Drawing.Size(40, 40);
                    btn[Contab].Text = (Contab+1).ToString();
                    btn[Contab].Name = Contab.ToString();
                    btn[Contab].BackColor = Color.LightGray;
                    btn[Contab].Location = new System.Drawing.Point(X, Y);
                    btn[Contab].Enabled = false;
                    f.Controls.Add(btn[Contab]);
                    X = X + 45;
                    Contab++;
                }
                Y = Y + 45;
                X = 22;
            }
        }
        //reinicia tabela com as caracteristicas padrões
        public void ReiniciarTabela(Form f)
        {
            int contador = 0;
            Y = 50;
            X = 22;
            for (int j = 0; j < 6; j++)
            {
                for (int l = 0; l < 10; l++)
                {
                    
                    btn[contador].BackColor = Color.LightGray;
                    X = X + 45;
                    contador++;
                }
                Y = Y + 45;
                X = 22;
            }
        }
        //###########################################################################
    }
}
