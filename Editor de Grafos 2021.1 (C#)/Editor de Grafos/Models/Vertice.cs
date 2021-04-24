using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Editor_de_Grafos
{
    public class Vertice
    {
        public int id { get; }
        public List<Vertice> adjacentes { get; }
        private List<Aresta> arestas;
        public Color cor { get; set; }
        public bool visitado { get; set; }

        public Vertice(int id)
        {
            this.id = id;
            adjacentes = new List<Vertice>();
            arestas = new List<Aresta>();
        }

        public void addAdjacente(Vertice verticeAdjacente)
        {
            adjacentes.Add(verticeAdjacente);
        }
        public void addAresta(Aresta aresta)
        {
            arestas.Add(aresta);
        }
        public int grauVertice()
        {
            return arestas.Count;
        }
        public bool isAdjcente(Vertice verticeAdjacente)
        {
            return adjacentes.Contains(verticeAdjacente);
        }
        public static void limparVertices(List<Vertice> vertices)
        {
            foreach (var vertice in vertices)
            {
                vertice.visitado = false;
            }
        }
        public void visitaAjacentes()
        {
            foreach (var vertice in adjacentes)
            {
                if (!vertice.visitado)
                {

                    vertice.visitado = true;
                    var aresta = arestas.Find(a => a.vertices.Contains(vertice));
                    aresta.selecionada = true;
                }
            }

        }
        public Vertice arestaComMenorPeso(Vertice vertice)
        {
            var menor = 0;
            Vertice verticeSelecionado = null;
            foreach (var aresta in arestas)
            {
                if (aresta.peso < menor)
                {
                    verticeSelecionado = aresta.vertices.Find(verticeAdjacente => !verticeAdjacente.Equals(vertice));
                    verticeSelecionado.visitado = true;
                }

            }
            return verticeSelecionado;
        }
        public bool temAdjacentesNaoVisitados()
        {
            foreach (var vertice in adjacentes)
            {
                if (!vertice.visitado)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Vertice> getNaoAdjacentes(List<Vertice> vertices) {
            List<Vertice> verticesNaoAdjacentes = new List<Vertice>();
            foreach (var vertice in vertices)
            {
                if (!adjacentes.Contains(vertice)) {
                    verticesNaoAdjacentes.Add(vertice);
                }
            }
            return verticesNaoAdjacentes;
        }
        public override string ToString()
        {
            return id.ToString();
        }

      
    }
}
