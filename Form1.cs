using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Desafio
{
    public partial class Form1 : Form
    {
        Time umTime = new Time();
        private bool isDarkMode = false;
        public Form1()
        {
            InitializeComponent();
            InitializetemaEscuro();
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            
            
            umTime.setCodigo(txtCodigo.Text);
            umTime.setTime(txtTime.Text);
            umTime.setDivisao(txtDivisao.Text);
            umTime.setLocalidade(txtLocal.Text);

            
            TimeBLL.validaDados(umTime, 'a');
            TimeDAL.atualizaUmTime(umTime);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados alterados com sucesso!");



        }


        private void InitializetemaEscuro()
        {
            Button temaEscuro = new Button();
            temaEscuro.Text = "Tema escuro";
            temaEscuro.AutoSize = true;
            temaEscuro.Location = new Point(10, 10);
            temaEscuro.Click += ToggleDarkMode;
            Controls.Add(temaEscuro);
        }
        private void ToggleDarkMode(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            if (isDarkMode)
            {
                BackColor = Color.Black;
                ForeColor = Color.White;
                btnAtualiza.BackColor = Color.Red;
                btnConsulta.BackColor = Color.Red;
                btnDeleta.BackColor = Color.Red;
                btnInseri.BackColor = Color.Red;
                btnLimpar.BackColor = Color.Red;
            }
            else
            {
                BackColor = SystemColors.Control;
                ForeColor = SystemColors.ControlText;
                btnAtualiza.BackColor = Color.White;
                btnConsulta.BackColor = Color.White;
                btnDeleta.BackColor = Color.White;
                btnInseri.BackColor = Color.White;
                btnLimpar.BackColor = Color.White;
            }
        }
            private void btnDeleta_Click(object sender, EventArgs e)
        {
            umTime.setCodigo(txtCodigo.Text);

            TimeBLL.validaCodigo(umTime, 'e');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("O clube foi Excluído!");
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            umTime.setCodigo(txtCodigo.Text);
            TimeBLL.validaCodigo(umTime,'c');
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                txtCodigo.Text = umTime.getCodigo();
                txtTime.Text = umTime.getTime();
                txtDivisao.Text = umTime.getDivisao();
                txtLocal.Text =    umTime.getLocalidade();
            }
            TimeDAL.consultaUmTime(umTime);
            TimeDAL.atualizaUmTime(umTime);
        }

        private void btnInseri_Click(object sender, EventArgs e)
        {
            umTime.setCodigo(txtCodigo.Text);
            umTime.setTime(txtTime.Text);
            umTime.setDivisao(txtDivisao.Text);
            umTime.setLocalidade(txtLocal.Text);
            
            TimeBLL.validaDados(umTime, 'i');

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Clube adicionado com sucesso!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimeBLL.conecta();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimeBLL.desconecta();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtTime.Text = "";
            txtDivisao.Text = "";
            txtLocal.Text = "";
        }
    }
}
