using HtmlAgilityPack;
using ImpactaWebcrawler.Domain;
using System.Text.Json;

namespace ImpactaWebcrawler.Configuracoes
{
    public class Arquivo
    {
        private string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "/impactaWebcrawler/");

        public async Task salvarAqruivoJson(List<ProxyServers> listaProxyServers)
        {
            
            if (!Directory.Exists(pathFile))
            {
                Console.WriteLine("Diretorio do arquivo não existe,vou criar...");
                Directory.CreateDirectory(pathFile);
            }
            var path = Path.Combine(pathFile, DateTime.Now.ToString("MMddyyyy_HHmmss") + ".json");
            if (!File.Exists(path))
            {

                var xJson = JsonSerializer.Serialize(listaProxyServers);
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(xJson);
                }
            }

            Console.WriteLine($"Caminho do arquivo {path}");
        }

        public async Task salvarAqruivoHtml(string document, int contador)
        {
            criaDiretorio(pathFile);
            var path = Path.Combine(pathFile,$"{DateTime.Now.ToString("HHmmss")}_page{contador +1}.html");
            if (!File.Exists(path))
            {   
                // Criando arquivo html
                using (StreamWriter sw = File.CreateText(path))
                {
                    await sw.WriteLineAsync(document);
                }
                Console.WriteLine($"Caminho do arquivo {path}");
            }
        }

        private void criaDiretorio(string caminho)
        {
            if (!Directory.Exists(caminho))
            {
                Console.WriteLine("Diretorio do arquivo não existe,vou criar...");
                Directory.CreateDirectory(caminho);
            }
        }
    }
}
