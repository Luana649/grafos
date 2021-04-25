﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Editor_de_Grafos
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();            
        }

        #region Botoes de Algoritmo do Menu
        private void BtParesOrd_Click(object sender, EventArgs e)
        {
            grafoPanel.grafo.paresOrdenados();
        }

        private void BtGrafoEuleriano_Click(object sender, EventArgs e)
        {
            if(grafoPanel.grafo.isEuleriano())
                MessageBox.Show("O grafo e Euleriano!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("O grafo não e Euleriano!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtGrafoUnicursal_Click(object sender, EventArgs e)
        {
            if (grafoPanel.grafo.isUnicursal())
                MessageBox.Show("O grafo e Unicursal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("O grafo não e Unicursal!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtBuscaProfundidade_Click(object sender, EventArgs e)
        {
        }

        #endregion --------------------------------------------------------------------------------------------------

        #region botoes restantes do menu

        //private void BtNovo_Click(object sender, EventArgs e)
        //{
        //    g.Limpar();
        //}

        //private void BtAbrir_Click(object sender, EventArgs e)
        //{
        //    if(OPFile.ShowDialog() == DialogResult.OK)
        //    {
        //        g.abrirArquivo(OPFile.FileName);
        //        g.Refresh();
        //    }
        //}

        //private void BtSalvar_Click(object sender, EventArgs e)
        //{
        //    if(SVFile.ShowDialog() == DialogResult.OK)
        //    {
        //        g.SalvarArquivo(SVFile.FileName);
        //    }
        //}

        //private void BtSair_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void BtPeso_Click(object sender, EventArgs e)
        //{
        //    if(BtPeso.Checked)
        //    {
        //        BtPeso.Checked = false;
        //        g.setExibirPesos(false);

        //    }
        //    else
        //    {
        //        BtPeso.Checked = true;
        //        g.setExibirPesos(true);
        //    }
        //    g.Refresh();
        //}

        //private void BtPesoAleatorio_Click(object sender, EventArgs e)
        //{
        //    if(BtPesoAleatorio.Checked)
        //    {
        //        BtPesoAleatorio.Checked = false;
        //        g.setPesosAleatorios(false);
        //    }
        //    else
        //    {
        //        BtPesoAleatorio.Checked = true;
        //        g.setPesosAleatorios(true);
        //    }
        //}

        private void BtSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show(".", "Sobre o Editor de Grafos...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion --------------------------------------------------------------------------------------------------

        private void completarGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafoPanel.grafo.completarGrafo();
        }

        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //g.Limpar();
        }
    }
}
