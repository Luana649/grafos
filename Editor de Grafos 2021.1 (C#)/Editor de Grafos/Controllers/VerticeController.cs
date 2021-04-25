using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor_de_Grafos.Models;

namespace Editor_de_Grafos.Controllers
{
    public class VerticeController : Control
    {

        public VerticeController() {
        }

        public void AdicionarVertice(Grafo grafo, int idVertice) {
            Vertice vertice = new Vertice(idVertice);
            grafo.vertices.Add(vertice);
            
        }
    }
}
