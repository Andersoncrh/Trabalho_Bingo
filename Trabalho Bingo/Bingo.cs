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
    class Bingo
    {
        //constructor da classe!
        public Bingo(Form f)
        {
            tab = new Tabela(f);
            car = new Cartela(f);
        }
        public Tabela tab;//variável tab do tipo tabela
        public Cartela car;//variável car do tipo cartela
        int[] sorteados = new int[60];//guarda numeros sorteados para verificação
        int[] encontrados = new int[25];//guarda numeros pintados na cartela para controle
        int ultnro=-1;//ultimo numero sorteado
        int ultpos = -1;//ultima posicao pintada na cartela
        public int[] Encontrados
        {
            get { return encontrados; }
            set { encontrados = value; }
        }
        //#################METODOS DO BINGO#####################
        //sorteia numero válido pinta botao da tabela se o numero existir na cartela pinta botao da cartela guarda o numero sorteado e a posicao do ultimo botao pintado na cartela
        public void ProximaRodada(Form f)
        {
            
            int nro=0;
            
            do
            {
                nro = car.SortearNumero();
            }while (car.ValidarNumero(sorteados, nro, 60) == false);
            tab.btn[nro-1].BackColor = Color.Yellow;
            if (ultnro!=-1)
                tab.btn[ultnro-1].BackColor = Color.CornflowerBlue;
            sorteados[nro-1] = nro;
            
            int posicao = car.MarcarNumero(nro, f);
            Encontrados[car.pintados] = posicao;
            
            if (ultpos!=-1)
                if (car.Quin !=-1)
                    car.Btn[ultpos].BackColor = Color.CornflowerBlue;
            ultnro = nro;
            ultpos = posicao;
            
            
            
        }
        //zerar vetor que guarda numeros sorteados
        public void LimparSorteados(Form f)
        {
            ultnro = -1;
            ultpos = -1;
            for (int j = 0; j < 60; j++)
            {

                sorteados[j] = 0;
                
                
            }
        }
        //pintar botoes randomicamente quando der bingo
        public void Bingow(Form f,Button b)
        {
            int n;
            Random rdn = new Random();
            for (int i = 1; i < 60; i++)
            {
                n = rdn.Next(0, 9);
                if (n == 0)
                    tab.btn[i].BackColor = Color.CornflowerBlue;
                if (n == 1)
                    tab.btn[i].BackColor = Color.Green;
                if (n == 2)
                    tab.btn[i].BackColor = Color.Red;
                if (n == 3)
                    tab.btn[i].BackColor = Color.Yellow;
                if (n == 4)
                    tab.btn[i].BackColor = Color.LightBlue;
                if (n == 5)
                    tab.btn[i].BackColor = Color.Blue;
                if (n == 6)
                    tab.btn[i].BackColor = Color.Azure;
                if (n == 7)
                    tab.btn[i].BackColor = Color.Brown;
                if (n == 8)
                    tab.btn[i].BackColor = Color.White;
            }
            for (int i = 0; i < 25; i++)
            {
                n = rdn.Next(0, 9);
                if (n == 0)
                    car.Btn[i].BackColor = Color.CornflowerBlue;
                if (n == 1)
                    car.Btn[i].BackColor = Color.Green;
                if (n == 2)
                    car.Btn[i].BackColor = Color.Red;
                if (n == 3)
                    car.Btn[i].BackColor = Color.Yellow;
                if (n == 4)
                    car.Btn[i].BackColor = Color.LightBlue;
                if (n == 5)
                    car.Btn[i].BackColor = Color.Blue;
                if (n == 6)
                    car.Btn[i].BackColor = Color.Azure;
                if (n == 7)
                    car.Btn[i].BackColor = Color.Brown;
                if (n == 8)
                    car.Btn[i].BackColor = Color.White;
            }
            
        }
        //############################################################
        
        
    }
}
