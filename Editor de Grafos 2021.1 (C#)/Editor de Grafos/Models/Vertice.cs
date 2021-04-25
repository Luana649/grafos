using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Editor_de_Grafos.Models
{
    public class Vertice
    {
        public int id { get; }
        public List<Vertice> adjacentes { get; }
        public List<Aresta> arestas { get; }
        public Color cor { get; set; }
        public bool visitado { get; set; }
        public Vertice predecessor { get; set; }
        public int custo { get; set; }

        public Vertice(int id)
        {
            this.id = id;
            adjacentes = new List<Vertice>();
            arestas = new List<Aresta>();
            cor = Color.Empty;
        }

        public void addAdjacente(Vertice verticeAdjacente)
        {
            adjacentes.Add(verticeAdjacente);
        }
        public void addAresta(Aresta aresta)
        {
            arestas.Add(aresta);
            addAdjacente(aresta.vertices.Find(v => v.id != id));
        }
        public int grauVertice()
        {
            return arestas.Count;
        }
        public bool isAdjcente(Vertice verticeAdjacente)
        {
            return adjacentes.Contains(verticeAdjacente);
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
        public Aresta arestaComMenorPeso()
        {
            var menor = int.MaxValue;
            Aresta arestaSelecionado = null;
            var temArestaSeleciona = arestas.Find(a => a.selecionada) != null;
            if (!temArestaSeleciona)
            {
                foreach (var aresta in arestas)
                {
                    if (aresta.custo < menor)
                    {
                        arestaSelecionado = aresta;
                        menor = aresta.custo;
                    }
                }
                arestaSelecionado.selecionada = true;
            }

            return arestaSelecionado;
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
        public List<Vertice> getNaoAdjacentes(List<Vertice> vertices)
        {
            List<Vertice> verticesNaoAdjacentes = new List<Vertice>();
            foreach (var vertice in vertices)
            {
                if (!adjacentes.Contains(vertice))
                {
                    verticesNaoAdjacentes.Add(vertice);
                }
            }
            return verticesNaoAdjacentes;
        }
        public void setCustoEPredecessor(Vertice predecessor, int custo)
        {
            this.predecessor = predecessor;
            this.custo = custo;
        }
        public static void limparVertices(List<Vertice> vertices, Vertice verticeInical, int[] custos)
        {
            foreach (var vertice in vertices)
            {
                vertice.visitado = false;
                vertice.predecessor = null;
                vertice.custo =  vertice.Equals(verticeInical)? 0 : vertice.custo = int.MaxValue;
                custos[vertice.id] = int.MaxValue;
            }
        }
        public static void limparVertices(List<Vertice> vertices)
        {
            foreach (var vertice in vertices)
            {
                vertice.visitado = false;
            }
        }
        public override string ToString()
        {
            return id.ToString();
        }

    }
}
