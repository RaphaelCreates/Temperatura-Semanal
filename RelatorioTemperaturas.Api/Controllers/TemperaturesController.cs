using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

//classe do Controller
namespace RelatorioTemperaturas.Api.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturesController : ControllerBase
    {
   [HttpGet("report")]
   public IActionResult GetTemperatureReport() // O corpo do método aqui dentro
   {

    // 1. Entrada de dados
    int[] temperaturas = { 22, 25, 18, 20, 23, 27, 19};
    string[] dias = {"Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"};
    
    // 2. preparar variáveis
    int soma = 0;
    int TempMaior = temperaturas[0];
    int TempMenor = temperaturas[0];
    string diaMaior = dias[0];
    string diaMenor = dias[0];
    string clima = "";

    //lista para armazenar dados (vazia)
    var dailyReports = new List<object>();

    // 3. percorre cada indice de 0 a 6
for (int i = 0; i < temperaturas.Length; i++)
  {
int tempAtual = temperaturas[i];
string diaAtual = dias[i];

soma += tempAtual; // soma as temperaturas

if (tempAtual > TempMaior) // verifica se a temperatura atual é maior que a maior
{
    TempMaior = tempAtual;
    diaMaior = diaAtual; 
}
if (tempAtual < TempMenor) 
{
 TempMenor = tempAtual;
 diaMenor = diaAtual;
}
//clasificar o clima do dia
if (tempAtual >= 25)
{
    clima = "Quente";
}
else if (tempAtual >= 18)
{
    clima = "Agradável";
}
else
{
    clima = "Frio";
}

dailyReports.Add(new
{  
    dia = diaAtual,
    temperatura = tempAtual,
    clima = clima
});

 }
    // 4. calcular a média
    double media = (double)soma / temperaturas.Length;

    // 5. verifica se houve onda de calor
    bool alertaOndaDeCalor = media > 24;


    // 6. retornar o relatório
    return Ok(new {
        media = media,
        TempMaior = TempMaior,
        diaMaior = diaMaior,
        TempMenor = TempMenor,
        diaMenor = diaMenor,
        alertaOndaDeCalor = alertaOndaDeCalor,
        dailyReports = dailyReports
    });

    }
     }  
} // fim do namespace
