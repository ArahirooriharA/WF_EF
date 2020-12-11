using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_EF.Models;

namespace WF_EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExibirAlunos();
        }

        public void ExibirAlunos()
        {
            List<Aluno> alunos;
            lbAlunos.Items.Clear();

            using (var ctx = new ApplicationDBContext())
            {
                alunos = ctx.Alunos.ToList();
            }
            foreach (var aluno in alunos)
                lbAlunos.Items.Add(aluno);
        }

        private void lbAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var alunoSelecionado = (Aluno)lbAlunos.SelectedItem;

            txtCodigo.Text = alunoSelecionado.AlunoId.ToString();
            txtNome.Text = alunoSelecionado.Nome;
            txtEmail.Text = alunoSelecionado.Email;
        }

        private bool ValidaAcao()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                return false;
            else
                return true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidaAcao())
            {
                var aluno = (Aluno)lbAlunos.SelectedItem;
                Form2 frm = new Form2(aluno, Acao.Operacao.edit);
                frm.ShowDialog();
                ExibirAlunos();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                var aluno = new Aluno();
                Form2 frm = new Form2(aluno, Acao.Operacao.add);
                frm.ShowDialog();
                ExibirAlunos();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (ValidaAcao())
            {
                var aluno = (Aluno)lbAlunos.SelectedItem;
                Form2 frm = new Form2(aluno, Acao.Operacao.del);
                frm.ShowDialog();
                ExibirAlunos();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Encerrar?", "Encerrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
