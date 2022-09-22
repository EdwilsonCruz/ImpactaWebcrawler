using ImpactaWebcrawler.Configuracoes;
using ImpactaWebcrawler.Data;
using ImpactaWebcrawler.Domain;

ClientHttp chttp = new();
int menu = 0;
String s;
do
{
    Console.WriteLine("---------------");
    Console.WriteLine("Funções");
    Console.WriteLine("1- Extrair dados");
    Console.WriteLine("2- Salvar arquivos Html");
    Console.WriteLine("0- Sair");

    Console.WriteLine("---------------");
    s = Console.ReadLine();
    
    menu = Convert.ToInt32(s);

    switch (menu)
    {
        case 1:            
            await chttp.objJson();
            break;
        case 2:
            await chttp.objHtml();            
            break;
        case 3:
            break;
        default:
            break;
    }

} while (menu != 0);



