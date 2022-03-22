using Projeto_M.Class01;
using System;
using System.Windows.Forms;
namespace Projeto_M
{
    public partial class frmDadosProposta : Form
    {
        public string numeroNota, totalServico, cotacao;

        GerarPDF pdf = new GerarPDF();



        public frmDadosProposta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void frmDadosProposta_Load(object sender, EventArgs e)
        {

        }


        private void btnGerarProposta_Click(object sender, EventArgs e)
        {           
            try
            {
                DadosPdf dados = new DadosPdf();

                dados.nota = numeroNota;
                string[] info = dados.DadosCliente();
                string[] infoNota = dados.DadosServico();


                //Parametros/Dados PDF
                pdf.NumeroNota = numeroNota;

                ////Informações Cliente
                pdf.Cep = info[0];
                pdf.Lorgradouro = info[1];
                pdf.NumeroEndereco = info[2];
                pdf.Complemento = info[3];
                pdf.Bairro = info[4];
                pdf.Cidade = info[5];
                pdf.Uf = info[6];

                pdf.RazaoSocial = info[7];
                pdf.NomeEmpresa = info[8];
                //pdf.Telefone = info[9];
                pdf.Telefone = infoNota[8]; // Telefone do solicitante
                //pdf.Email = info[9];
                pdf.Email = infoNota[9];
                pdf.Cnpj = info[10];


                //Dados Cotação
                pdf.DataSolicitacao = infoNota[0];
                pdf.Descricao = rtDescricaoDoServico.Text; //infoNota[1];
                pdf.CodEquipamento = infoNota[2];
                pdf.Responsavel = infoNota[3];
                //pdf.Area = infoNota[4];
                pdf.Equipamento = infoNota[5];
                pdf.Solicitacao = tbSolicitacao.Text; //infoNota[6];
                pdf.Solicitante_Area = infoNota[7];

                //Valores
                pdf.ValorUnit = totalServico;
                pdf.ValorTotal = totalServico;

                //Informações Finais

                //0-Descrição da Proposta
                pdf.DescricaoDaCapa = rtDescricaoProposta.Text;

                //1-Proposta Técnica/Comercial
                pdf.ReferenciaPropostaTecninca = txtRefProposta.Text;
                pdf.TextoPropostaTecninca = rtTextoProposta.Text;

                //2-Proposta Comercial
                pdf.CondicoesPagamento = tbCodicaoPagamento.Text;
                pdf.ValidadeProposta = tbValidadeProposta.Text;
                pdf.QuantidadeDias = tbQuantidade.Text;
                //////pdf.Periodo = tbPeriodo.Text;
                pdf.ResumoProposta = rtDescricaoDoServico.Text;
                pdf.Referencia = tbReferencia.Text;
                pdf.Area = tbArea.Text;

                //3-Escopo do Serviços e Responsabilidades
                pdf.EspecializacaoDoSesvico = cbEspecializacaoServico.Text;
                pdf.EscopoResponsabilidade = rtResponsabilidadeMenplan.Text;

                pdf.Cotacao = tbSiglaEmpresa.Text + cotacao;
                pdf.CriarPDF();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
