using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Editor_de_Grafos.Models
{
    public class Grafo : iGrafo
    {
        public List<Vertice> vertices { get; set; }
        public List<Aresta> arestas { get; set; }
        public bool[,] matrizAdjacencia { get; set; }
        public Grafo()
        {
            vertices = new List<Vertice>();
            arestas = new List<Aresta>();
        }

        private void gerarMatrizAdjacencia()
        {
            matrizAdjacencia = new bool[vertices.Count, vertices.Count];
            foreach (var vertice in vertices)
            {
                foreach (var verticeAdjacente in vertice.adjacentes)
                {
                    matrizAdjacencia[vertice.id, verticeAdjacente.id] = true;
                }
            }
        }
        public bool isEuleriano()
        {
            foreach (var vertice in vertices)
            {
                if (vertice.grauVertice() % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool isUnicursal()
        {
            var qtdImpar = 0;
            foreach (var vertice in vertices)
            {
                if (vertice.grauVertice() % 2 != 0)
                {
                    qtdImpar++;
                }
            }
            return qtdImpar == 2;
        }
        public string paresOrdenados()
        {
            var paresOrdenados = string.Empty;
            foreach (var aresta in arestas)
            {
                paresOrdenados += $"{aresta}+ \n";
            }
            return paresOrdenados;
        }
        public void completarGrafo()
        {
            foreach (var vertice in vertices)
            {
                foreach (var verticeAdjacente in vertices)
                {
                    if (!vertice.isAdjcente(verticeAdjacente))
                    {
                        new Aresta(vertice, verticeAdjacente);
                    }
                }
            }
        }
        public void profundidade(int idVerticeInicial)
        {
            var vertice = vertices.Find(v => v.id == idVerticeInicial);
            var profundidade = calcularProfundidade(0, vertice);
        }
        public int calcularProfundidade(int profundidade, Vertice vertice)
        {
            if (vertice.grauVertice() > 1)
            {
                foreach (var verticeAjacente in vertice.adjacentes)
                {
                    calcularProfundidade(profundidade, verticeAjacente);
                }
            }
            return profundidade++;
        }
        public void largura(int IdVerticeInicial)
        {
            Vertice.limparVertices(vertices);
            var vertice = vertices.Find(v => v.id == IdVerticeInicial);
            calcularLargura(0, vertice);
            var largura = vertices.FindAll(v => v.visitado).Count;
        }
        public void calcularLargura(int largura, Vertice vertice)
        {
            vertice.visitaAjacentes();
            foreach (var verticeAjacente in vertice.adjacentes)
            {
                if (!verticeAjacente.visitado)
                {
                    calcularLargura(largura, verticeAjacente);
                }
            }
        }
        public void AGM(int IdVerticeInicial)
        {
            Vertice.limparVertices(vertices);
            var vertice = vertices.Find(v => v.id == IdVerticeInicial);
            AGM(vertice);
        }
        public void AGM(Vertice vertice)
        {
            var proxVertice = vertice.arestaComMenorPeso(vertice);
            foreach (var verticeAjacente in proxVertice.adjacentes)
            {
                if (!verticeAjacente.visitado)
                {
                    AGM(verticeAjacente);
                }
            }
        }
        public void caminhoMinimo(int IdVerticeInicial, int IdVerticeFinal)
        {
            var verticeInicial = vertices.Find(vertice => vertice.id == IdVerticeInicial);
            var verticeFinal = vertices.Find(vertice => vertice.id == IdVerticeFinal);
            foreach (var vertice in verticeInicial.adjacentes)
            {
                encontrarVertice(verticeInicial, verticeFinal);
            }
        }
        public bool encontrarVertice(Vertice verticeAtual, Vertice verticeProcurado)
        {
            if (continuarProcurando(verticeAtual, verticeProcurado))
            {
                foreach (var vertice in verticeAtual.adjacentes)
                {
                    vertice.visitado = true;
                    return encontrarVertice(vertice, verticeProcurado);
                }
            }
            return false;
        }
        private bool continuarProcurando(Vertice verticeAtual, Vertice verticeProcurado)
        {
            bool continuarProcurando;
            if (verticeAtual.Equals(verticeProcurado))
            {
                continuarProcurando = false;
            }
            else
            {
                continuarProcurando = verticeAtual.temAdjacentesNaoVisitados();
            }

            return continuarProcurando;
        }
        public void numeroCromatico()
        {
            List<Color> cores = new List<Color>();
            foreach (var vertice in vertices)
            {
                if (!coloriuTodos())
                {
                    cores.Add(gerarCorAleatoria());
                    foreach (var cor in cores)
                    {
                        vertice.cor = cor;
                        colorirVertices(vertice.getNaoAdjacentes(vertices), cor);
                    }
                }

            }
            var numCromatico = cores.Count;
        }
        private bool coloriuTodos()
        {
            foreach (var vertice in vertices)
            {
                if (vertice.cor == null)
                {
                    return false;
                }
            }
            return true;
        }
        private void colorirVertices(List<Vertice> vertices, Color cor)
        {
            foreach (var vertice in vertices)
            {
                if (vertice.cor == null)
                {
                    vertice.cor = cor;
                }
            }
        }
        private Color gerarCorAleatoria()
        {
            var seletor = new Random();
            var argb = seletor.Next();
            return Color.FromArgb(argb);
        }
    }
}
