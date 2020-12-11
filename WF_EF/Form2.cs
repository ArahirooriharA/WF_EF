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
    public partial class Form2 : Form
    {
        Acao.Operacao _valor;
        public Form2(Aluno aluno, Acao.Operacao actionCode)
        {
            _valor = actionCode;
            InitializeComponent();
            ExibirAluno(aluno);
            if(actionCode == Acao.Operacao.add)
            {
                txtCodigo.Visible = false;
                label1.Visible = false;
            }

        }

        private void ExibirAluno(Aluno aluno)
        {
            txtCodigo.Text = aluno.AlunoId.ToString();
            txtNome.Text = aluno.Nome;
            txtEmail.Text = aluno.Email;
            txtNome.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var codigo = Convert.ToInt32(txtCodigo.Text);
            if (_valor == Acao.Operacao.edit)
            {
                using (var context = new ApplicationDBContext())
                {
                    var aluno = context.Alunos.First(a => a.AlunoId == codigo);
                    aluno.Nome = txtNome.Text;
                    aluno.Email = txtEmail.Text;
                    context.SaveChanges();
                }
            }
            else if (_valor == Acao.Operacao.del)
            {
                using (var context = new ApplicationDBContext())
                {
                    var aluno = context.Alunos.First(a => a.AlunoId == codigo);
                    context.Remove(aluno);
                    context.SaveChanges();
                }
            }
            else if (_valor == Acao.Operacao.add)
            {
                using (var context = new ApplicationDBContext())
                {
                    Aluno aluno = new Aluno();
                    aluno.Nome = txtNome.Text;
                    aluno.Email = txtEmail.Text;
                    context.Add(aluno);
                    context.SaveChanges();
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
