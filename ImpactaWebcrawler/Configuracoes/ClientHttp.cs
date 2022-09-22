using HtmlAgilityPack;
using ImpactaWebcrawler.Data;
using ImpactaWebcrawler.Domain;
using System;
using static ImpactaWebcrawler.Configuracoes.Constantes;

namespace ImpactaWebcrawler.Configuracoes
{
    internal class ClientHttp
    {
        public async Task objJson()
        {
            var ultimaPagina = await numeroPaginas();
            // Lista com todos os dados coletados
            List<ProxyServers> listaObj = new();
           
            var arq = new Arquivo();
            
           foreach (var contador in ultimaPagina.ToString())           
            {
                using var client = new HttpClient();
                var content = await client.GetStringAsync(ProxySettings.urlPage + contador.ToString());

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(content);

                // Lista com o resultado da table
                var listTbody = document.DocumentNode.Descendants("tr")
                                .Where(no => no.GetAttributeValue("valign", "").Equals("top"))
                                .ToArray();
                var listaTr = listTbody.Select(x => x.Descendants("td").Where(x => x.GetAttributeValue("class", "").Equals(""))).ToArray();

                for (int j= 0; j < listTbody.Length; j++)
                {
                    ProxyServers ps = new();

                    var auxiliar = listTbody[j].Elements("td").ToArray();
                    ps.IpAdress = auxiliar[1].InnerText.Trim();
                    ps.Port = auxiliar[2].InnerText.Trim();
                    ps.Country = auxiliar[3].InnerText.Trim();
                    ps.Protocol = auxiliar[5].InnerText.Trim();

                    listaObj.Add(ps);
                }
            }
            Resposta resp = new (){ horaInicio= DateTime.UtcNow, linhas = (listaObj.Count *6)+2, paginas=ultimaPagina };
            // Salvando os dados em arquivo json
            await arq.salvarAqruivoJson(listaObj);
            resp.horaFim = DateTime.UtcNow;
            CadastrarResposta(resp);
        }

        public async Task objHtml()
        {
            var ultimaPagina = await numeroPaginas();
            Console.WriteLine($"Contei {ultimaPagina} paginas...");
            var arq = new Arquivo();

            for(var i=0;i < ultimaPagina;i++)
            {
                using var client = new HttpClient();
                var content = await client.GetStringAsync(ProxySettings.urlPage + i);

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(content);
                
                // Salvando os dados em arquivo html
                await arq.salvarAqruivoHtml(document.Text, i);
            }
        }
        private async Task<int> numeroPaginas()
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync(ProxySettings.url);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(content);

            // Pegando o valor da ultima pagina.
            var ultimaPagina = Convert.ToInt32( document.DocumentNode.Descendants("li")
                                .Where(no => no.GetAttributeValue("class", "").Equals("page-item"))
                                .ToList().Last().InnerText.Trim());

            return ultimaPagina;
        }

        private void CadastrarResposta(Resposta resp)
        {
            using var db = new ApplicationContext();
            resp.Id = Guid.NewGuid();
            //var dados = new Resposta
            //{
            //    Id = Guid.NewGuid(),
            //};

            db.Respostas.AddAsync(resp);
            db.SaveChanges();
        }
    }
}
