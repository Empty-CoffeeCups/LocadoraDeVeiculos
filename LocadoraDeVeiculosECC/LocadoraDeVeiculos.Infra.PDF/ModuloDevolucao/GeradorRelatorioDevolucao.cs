using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using System.IO;

namespace LocadoraDeVeiculos.Infra.PDF.ModuloDevolucao
{
    public class GeradorRelatorioDevolucao : IGeradorRelatorioDevolucao
    {


        public void GerarRelatorioPdf(Devolucao devolucao)
        {

            Document document = new Document(PageSize.A4, 20f, 20f, 30f, 30f);

            FileStream fileStream = new FileStream(@"C:\pdf\" + $"{devolucao.Id}.pdf", FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));


            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo2.Alignment = Element.ALIGN_CENTER;

            paragrafo2.Add("Comprovante de devolução" + "\n\n");
            paragrafo.Add("------------------------------------------------------------------" + "\n\n");
            paragrafo.Add("Id da devolução: " + devolucao.Id + "\n");
            paragrafo.Add("Nome do Cliente: " + devolucao.Locacao.Cliente.Nome + "\n");
            paragrafo.Add("Nome do Condutor: " + devolucao.Locacao.Condutor.Nome  + "\n");
            paragrafo.Add("Funcionário: " + devolucao.Locacao.Funcionario.Nome + "\n");
            //paragrafo.Add("Placa do veículo: " + devolucao.Locacao.Veiculo.Placa + "\n");
            //paragrafo.Add("Grupo de veículos: " + devolucao.Locacao.Veiculo.GrupoVeiculos.Nome + "\n");
            paragrafo.Add("Plano de cobrança: " + devolucao.Locacao.PlanoDeCobranca.ToString() + "\n");
            paragrafo.Add("Data de locação: " + devolucao.Locacao.DataLocacao.ToShortDateString() + "\n");
            paragrafo.Add("Data de devolução: " + devolucao.DataDeDevolucao.ToShortDateString() + "\n");
            //paragrafo.Add("Quilometragem percorrida: " + (devolucao.KmVeiculo - devolucao.Locacao.Veiculo.QuilometragemPercorrida) + " Km" + "\n");
            paragrafo.Add("Nivel do tanque: " + devolucao.NivelDoTanque + "%" + "\n");





            paragrafo.Add("Valor total: " + "R$" + devolucao.ValorTotal + "\n");

            document.Open();
            document.Add(paragrafo2);
            document.Add(paragrafo);
            document.Close();
        }

    }
}
