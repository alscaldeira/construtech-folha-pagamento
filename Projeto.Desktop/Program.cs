﻿using Projeto.Desktop.Funcionario;
using System;
using System.Windows.Forms;

namespace Projeto.Desktop
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmIncluirFuncionario());
        }
    }
}
