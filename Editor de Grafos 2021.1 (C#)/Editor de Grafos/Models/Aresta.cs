using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Grafos.Models
{
    public class Aresta
    {
        public int custo { get; set; }
        public bool selecionada { get; set; }
        public List<Vertice> vertices { get; set; }

        private Aresta()
        {
            vertices = new List<Vertice>();
        }
        public Aresta(Vertice vertice, Vertice verticeAdjacente, Grafo grafo, int custo = 0)
        {
            vertices = new List<Vertice> { vertice, verticeAdjacente};
            addAresta(this, vertice, verticeAdjacente);
            this.custo = custo;
            grafo.arestas.Add(this);
        }

        private void addAresta(Aresta aresta, Vertice vertice, Vertice verticeAdjacente)
        {
            vertice.addAresta(aresta);
            verticeAdjacente.addAresta(aresta);
        }
        
        public override string ToString()
        {
            var extremidades = string.Empty;
            foreach (var vertice in vertices)
            {
                extremidades += $"{vertice}, ";
            }
            return extremidades;
        }
    }
}
