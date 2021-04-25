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
                var grau = vertice.grauVertice();
                if (grau % 2 != 0)
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
                paresOrdenados += $"{aresta}\n";
            }
            return paresOrdenados;
        }
        public void completarGrafo()
        {
            foreach (var vertice in vertices)
            {
                foreach (var verticeAdjacente in vertices)
                {
                    if (!vertice.isAdjcente(verticeAdjacente) && vertice.id != verticeAdjacente.id)
                    {
                        new Aresta(vertice, verticeAdjacente, this);
                    }
                }
            }
        }
        public void profundidade(int idVerticeInicial)
        {
            var vertice = vertices.Find(v => v.id == idVerticeInicial);
            buscaProfundidade(vertice);
        }
        public void buscaProfundidade(Vertice vertice)
        {
            if (vertice.temAdjacentesNaoVisitados())
            {
                foreach (var verticeAjacente in vertice.adjacentes)
                {
                    if (!verticeAjacente.visitado) {

                        verticeAjacente.visitado = true;
                        buscaProfundidade(verticeAjacente);
                    }
                }
            }

        }
        public void largura(int IdVerticeInicial)
        {
            Vertice.limparVertices(vertices);
            var vertice = vertices.Find(v => v.id == IdVerticeInicial);
            buscaLargura(0, vertice);
        }
        public void buscaLargura(int largura, Vertice vertice)
        {
            vertice.visitaAjacentes();
            foreach (var verticeAjacente in vertice.adjacentes)
            {
                if (!verticeAjacente.visitado)
                {
                    buscaLargura(largura, verticeAjacente);
                }
            }
        }
        public void AGM(int IdVerticeInicial)
        {
            var custo = AGM();
        }
        public int AGM()
        {
            int custo = 0;
            foreach (var vertice in vertices)
            {
                var aresta = vertice.arestaComMenorPeso();
                if (aresta != null)
                {
                    custo += aresta.custo;
                }

            }
            return custo;
        }
        public int caminhoMinimo(int IdVerticeInicial, int IdVerticeFinal)
        {
            var verticeInicial = vertices.Find(vertice => vertice.id == IdVerticeInicial);
            var verticeFinal = vertices.Find(vertice => vertice.id == IdVerticeFinal);
            return caminhoMinimo(verticeInicial, verticeFinal);
        }
        public int caminhoMinimo(Vertice verticeInicial, Vertice verticeFinal)
        {
            int[] custos = new int[vertices.Count];
            Vertice.limparVertices(vertices, verticeInicial, custos);
            int custo = 0;
            while (podeContinuar())
            {
                var vertice = menorCusto();
                custo = vertice.custo;
                if (vertice.adjacentes != null)
                {
                    foreach (var verticeAdjacete in vertice.adjacentes)
                    {
                        var custoCaminho = getCusto(vertice, verticeAdjacete) + custo;
                        if (custos[verticeAdjacete.id] > custoCaminho)
                        {
                            verticeAdjacete.setCustoEPredecessor(vertice, custoCaminho);
                            custos[verticeAdjacete.id] = custoCaminho;
                        }
                    }
                }
            }
            verticeInicial.predecessor = null;
            return custos[verticeFinal.id];
        }
        public int getCusto(Vertice vertice, Vertice verticeAdjacete)
        {
            int custo = 0;
            foreach (var aresta in arestas)
            {
                if (aresta.vertices.Contains(vertice) && aresta.vertices.Contains(verticeAdjacete))
                {
                    custo = aresta.custo;
                }
            }
            return custo;
        }
        private Vertice menorCusto()
        {
            var menorCusto = int.MaxValue;
            Vertice verticeComMenorCusto = null;
            foreach (var vertice in vertices)
            {
                if (vertice.custo < menorCusto && !vertice.visitado)
                {
                    verticeComMenorCusto = vertice;
                    menorCusto = vertice.custo;
                }
            }
            verticeComMenorCusto.visitado = true;
            return verticeComMenorCusto;
        }
        private bool podeContinuar()
        {
            foreach (var vertice in vertices)
            {
                if (!vertice.visitado)
                {
                    return true;
                }
            }
            return false;
        }
        public void numeroCromatico()
        {
            var cores = new List<Color>();
            foreach (var vertice in vertices)
            {
                var verticesAColorir = new List<Vertice>();
                if (!coloriuTodos())
                {
                    cores.Add(gerarCorAleatoria());
                    foreach (var cor in cores)
                    {
                        verticesAColorir = vertice.getNaoAdjacentes(vertices);
                        colorirVertices(verticesAColorir, cor);
                    }
                }

            }
            var numCromatico = cores.Count;
        }
        private bool coloriuTodos()
        {
            foreach (var vertice in vertices)
            {
                if (vertice.cor.IsEmpty)
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
                if (vertice.cor.IsEmpty)
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
        public bool isArvore()
        {
            var vertice = vertices.Find(v => v.id == 0);
            return isArvore(vertice, true);
        }
        public bool isArvore(Vertice vertice, bool eArvore)
        {
            if (!vertice.visitado && vertice.adjacentes.Count > 0)
            {
                vertice.visitado = true;
                foreach (var verticeAjacente in vertice.adjacentes)
                {
                    eArvore = isArvore(verticeAjacente, eArvore);
                }
            }
            else
            {
                eArvore = false;
            }
            return eArvore;
        }
    }
}
