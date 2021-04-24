using System;
using System.Collections.Generic;
using System.Text;

namespace Editor_de_Grafos
{
    public class Aresta
    {
        public int peso { get; set; }
        public bool selecionada { get; set; }
        public List<Vertice> vertices { get; }

        private Aresta()
        {
            vertices = new List<Vertice>();
        }
        public Aresta(Vertice vertice, Vertice verticeAdjacente)
        {
            var aresta = new Aresta();
            addVerticesTerminais(aresta, vertice, verticeAdjacente);
            addAresta(aresta, vertice, verticeAdjacente);
        }

        private void addVerticesTerminais(Aresta aresta, Vertice vertice, Vertice verticeAdjacente)
        {
            aresta.vertices.Add(vertice);
            aresta.vertices.Add(verticeAdjacente);
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
                extremidades = $"{vertices.IndexOf(vertice)} {vertice} "
                ;
            }
            return extremidades;
        }
    }
}
