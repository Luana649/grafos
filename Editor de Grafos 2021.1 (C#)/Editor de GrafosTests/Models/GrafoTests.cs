using Microsoft.VisualStudio.TestTools.UnitTesting;
using Editor_de_Grafos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor_de_Grafos.Models.Tests
{
    [TestClass()]
    public class GrafoTests
    {
        Grafo euleriano;
        Grafo unicursal;
        Grafo incompleto;
        Grafo grafo;

        [TestMethod()]
        public void isEulerianoTest()
        {

            euleriano = GerarEuleriano();
            Assert.IsTrue(euleriano.isEuleriano());
        }

        [TestMethod()]
        public void isUnicursalTest()
        {
            unicursal = GerarUnicursal();
            Assert.IsTrue(unicursal.isUnicursal());
        }

        [TestMethod()]
        public void paresOrdenadosTest()
        {
            euleriano = GerarEuleriano();
            var pares = euleriano.paresOrdenados();
        }

        [TestMethod()]
        public void completarGrafoTest()
        {
            incompleto = GerarIncompleto();
            incompleto.completarGrafo();
        }

        [TestMethod()]
        public void profundidadeTest()
        {
            grafo = GerarGrafo();
            grafo.profundidade(0);
        }


        [TestMethod()]
        public void larguraTest()
        {
            grafo = GerarGrafo();
            grafo.largura(0);
        }

        [TestMethod()]
        public void AGMTest()
        {
            grafo = GerarGrafo();
            Assert.AreEqual(17, grafo.AGM());
        }

        [TestMethod()]
        public void caminhoMinimoTest()
        {
            grafo = GerarGrafo();
            grafo.caminhoMinimo(0, 5);
        }

        [TestMethod()]
        public void isArvoreTest()
        {
            incompleto = GerarIncompleto();
            incompleto.completarGrafo();
            Assert.IsFalse(incompleto.isArvore());
        }

        [TestMethod()]
        public void numeroCromaticoTest()
        {
            var grafo = GerarGrafo();
            grafo.numeroCromatico();
        }
        private Grafo GerarGrafo()
        {
            var grafo = new Grafo();
            var vertice1 = new Vertice(0);
            var vertice2 = new Vertice(1);
            var vertice3 = new Vertice(2);
            var vertice4 = new Vertice(3);
            var vertice5 = new Vertice(4);
            var vertice6 = new Vertice(5);

            new Aresta(vertice1, vertice2, grafo, 2);
            new Aresta(vertice1, vertice5, grafo, 4);
            new Aresta(vertice1, vertice4, grafo, 1);

            new Aresta(vertice2, vertice4, grafo, 3);
            new Aresta(vertice2, vertice3, grafo, 3);
            new Aresta(vertice2, vertice6, grafo, 7);

            new Aresta(vertice3, vertice6, grafo, 8);
            new Aresta(vertice3, vertice4, grafo, 5);

            new Aresta(vertice4, vertice5, grafo, 9);


            grafo.vertices.AddRange(new List<Vertice> { vertice1, vertice2, vertice3, vertice4, vertice5, vertice6 });

            return grafo;
        }
        private Grafo GerarEuleriano()
        {
            var grafo = new Grafo();
            var vertice1 = new Vertice(0);
            var vertice2 = new Vertice(1);
            var vertice3 = new Vertice(2);
            var vertice4 = new Vertice(3);
            var vertice5 = new Vertice(4);
            var vertice6 = new Vertice(5);
            var vertice7 = new Vertice(6);

            new Aresta(vertice1, vertice2, grafo);
            new Aresta(vertice1, vertice3, grafo);

            new Aresta(vertice2, vertice3, grafo);
            new Aresta(vertice2, vertice4, grafo);
            new Aresta(vertice2, vertice5, grafo);

            new Aresta(vertice3, vertice6, grafo);

            new Aresta(vertice4, vertice3, grafo);
            new Aresta(vertice4, vertice6, grafo);
            new Aresta(vertice4, vertice5, grafo);

            new Aresta(vertice5, vertice6, grafo);
            new Aresta(vertice5, vertice7, grafo);

            new Aresta(vertice6, vertice7, grafo);

            grafo.vertices.AddRange(new List<Vertice> { vertice1, vertice2, vertice3, vertice4, vertice5, vertice6, vertice7 });

            return grafo;
        }
        private Grafo GerarUnicursal()
        {
            var grafo = new Grafo();
            var vertice1 = new Vertice(0);
            var vertice2 = new Vertice(1);
            var vertice3 = new Vertice(2);
            var vertice4 = new Vertice(3);
            var vertice5 = new Vertice(4);
            var vertice6 = new Vertice(5);

            new Aresta(vertice1, vertice2, grafo);
            new Aresta(vertice1, vertice3, grafo);

            new Aresta(vertice2, vertice3, grafo);
            new Aresta(vertice2, vertice4, grafo);
            new Aresta(vertice2, vertice5, grafo);

            new Aresta(vertice3, vertice6, grafo);

            new Aresta(vertice4, vertice3, grafo);
            new Aresta(vertice4, vertice6, grafo);
            new Aresta(vertice4, vertice5, grafo);

            new Aresta(vertice5, vertice6, grafo);

            grafo.vertices.AddRange(new List<Vertice> { vertice1, vertice2, vertice3, vertice4, vertice5, vertice6 });

            return grafo;
        }
        private Grafo GerarIncompleto()
        {
            var grafo = new Grafo();
            var vertice1 = new Vertice(0);
            var vertice2 = new Vertice(1);
            var vertice3 = new Vertice(2);
            var vertice4 = new Vertice(3);
            var vertice5 = new Vertice(4);
            var vertice6 = new Vertice(5);

            grafo.vertices.AddRange(new List<Vertice> { vertice1, vertice2, vertice3, vertice4, vertice5, vertice6 });

            return grafo;
        }
    }
}