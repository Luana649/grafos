using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Editor_de_Grafos.Models;

namespace Editor_de_Grafos.Controllers
{
    public class GrafoController : Control, iGrafo
    {
        private Grafo grafo;
        public GrafoController() {
            grafo = new Grafo();
        }

        public void AGM(int v)
        {
            grafo.AGM(v);
        }

        public void caminhoMinimo(int i, int j)
        {
            grafo.caminhoMinimo(i,j);
        }

        public void completarGrafo()
        {
            grafo.completarGrafo();
        }

        public bool isArvore()
        {
            return grafo.isArvore();
        }

        public bool isEuleriano()
        {
            return grafo.isEuleriano();
        }

        public bool isUnicursal()
        {
            return grafo.isUnicursal();
        }

        public void largura(int v)
        {
            grafo.largura(v); 
        }

        public void numeroCromatico()
        {
            grafo.numeroCromatico();
        }

        public string paresOrdenados()
        {
            return grafo.paresOrdenados();
        }

        public void profundidade(int v)
        {
            grafo.profundidade(v);
        }

        int iGrafo.caminhoMinimo(int i, int j)
        {
            return grafo.caminhoMinimo(i, j);
        }
    }
}
