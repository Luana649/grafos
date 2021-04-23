using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Editor_de_Grafos
{
    public class Grafo : GrafoBase, iGrafo
    {
        private bool[] visitado;

        public void AGM(int v)
        {

        }

        public void caminhoMinimo(int i, int j)
        {

        }

        public void completarGrafo()
        {

        }

        public bool isEuleriano()
        {
            int i;
            for (i = 0; i < getN(); i++)
            {
                if (grau(i) % 2 != 0)
                    return false;

            }
            if (getN() != 0)
                return true;
            else
                return false;

        }

        public bool isUnicursal()
        {
            int grauImpar = 0;
            for (int i = 0; i < getN(); i++)
            {
                if (grau(i) % 2 != 0)
                    grauImpar++;
            }
            return (grauImpar == 2);
        }

        public void largura(int v)
        {
            Fila f = new Fila(matAdj.GetLength(0));
            f.enfileirar(v);
            visitado[v] = false; // marca V como visitado
            while (!f.vazia())
            {
                v = f.desenfileirar(); // retira o próximo vértice da fila
                for (int i = 0; i < matAdj.GetLength(0); i++)
                {
                    // se I é adjacente a V e I ainda não foi visitado
                    if (matAdj[v, i] != 0 && !visitado[i])
                    {
                        visitado[i] = true; // marca i como visitado
                        f.enfileirar(i); // enfileira i
                    }
                }
            }
        }

        public void numeroCromatico()
        {
        }

        public String paresOrdenados()
        {
            getAresta(0, 1).setCor(Color.Yellow);
            getAresta(1, 2).setCor(Color.Green);
            return "";
        }
        public void profundidade(int v)
        {
           // visitado[v] = true; // marca V como visitado 

           // for (int i = 0; i < getN(); i++) { // se I é adjacente a V e I ainda não foi visitado 
            //if (getAresta[v, i] != 0 && !visitado[i])
             //   {
                    // chamada recursiva (vá para o vértice I) 
                  //  profundidade(i);
              //  }
          //  }
        }

    public void Limpar()
        {
            Console.Clear();
        }
    }
}
