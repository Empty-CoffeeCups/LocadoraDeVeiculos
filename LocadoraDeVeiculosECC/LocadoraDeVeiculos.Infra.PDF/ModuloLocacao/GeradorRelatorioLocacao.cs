using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using System.IO;

namespace LocadoraDeVeiculos.Infra.PDF.ModuloLocacao
{
    public class GeradorRelatorioLocacao : IGeradorRelatorioLocacao
    {

        public void GerarRelatorioPdf(Locacao locacao) {

            Document document = new Document(PageSize.A4, 20f, 20f, 30f, 30f);

            FileStream fileStream = new FileStream(@"C:\pdf\" + $"{locacao.Id}.pdf", FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));


            iTextSharp.text.Image PatientSign = iTextSharp.text.Image.GetInstance(locacao.Veiculo.Foto); // image from database
            PatientSign.SetAbsolutePosition(10, 10);
            PatientSign.ScaleAbsolute(2, 2);
            

            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo2.Alignment = Element.ALIGN_CENTER;

            paragrafo2.Add("Comprovante de locação" + "\n\n");
            paragrafo.Add("------------------------------------------------------------------" + "\n\n");
            paragrafo.Add("Id da locação: " + locacao.Id + "\n");
            paragrafo.Add("Nome do Cliente: " + locacao.Cliente.Nome + "\n");
            //paragrafo.Add("Placa do veículo: " + locacao.Veiculo.Placa + "\n");
            //paragrafo.Add("Grupo de veículos: " + locacao.Veiculo.GrupoDeVeiculos.NomeDoGrupo + "\n");
            paragrafo.Add("Plano de cobrança: " + locacao.PlanoDeCobranca.ToString() + "\n");
            paragrafo.Add("Data de locação: " + locacao.DataLocacao.ToShortDateString() + "\n");
            
            paragrafo.Add("Data de devolução prevista: " + locacao.DataDevolucaoPrevista.ToShortDateString() + "\n");
            

            //paragrafo.Add("Quilometragem atual percorrida pelo veículo: " + locacao.Veiculo.QuilometragemPercorrida + " Km" + "\n");
            paragrafo.Add("Taxas adicionadas: " + "\n");
            int j = 1;
            for (int i = 0; i < locacao.Taxas.Count; i++)
            {

                paragrafo.Add("Taxa " + j + ": " + locacao.Taxas[i].Descricao + "\n");
                j++;

            }

            paragrafo2.Add("Foto do veículo:");
            paragrafo2.Add(PatientSign);


            paragrafo.Add("Valor total previsto: " + "R$" + locacao.ValorTotalPrevisto + "\n");

            document.Open();
            document.Add(paragrafo2);
            document.Add(paragrafo);
            document.Close();
            
        }



    }
}
