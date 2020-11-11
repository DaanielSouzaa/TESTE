using System;
using System.Collections.Generic;

class ideias {

  private List<string> descricao = new List<string>();
  private List<string> areaAtuacao = new List<string>();
  private List<string> autor = new List<string>();
  private List<double> valorMinNecessario = new List<double>();
  private List<int> votos = new List<int>();
  private int totalVotos;

  public void setIdeia(string a,string b,string c,double d){
    this.descricao.Add(a);
    this.areaAtuacao.Add(b);
    this.autor.Add(c);
    this.valorMinNecessario.Add(d);
    this.votos.Add(0);
  }

  public void getIdeia(){
    for(int i = 0;i < this.valorMinNecessario.Count;i++){
      Console.WriteLine("Ideia | Descrição | Área | Autor");
      Console.WriteLine("{0} | {1} | {2} | {3}",i,this.descricao[i],this.areaAtuacao[i],this.autor[i]);
    }
  }

  public bool cadIdeia(){
    string desc = "";
    string area = "";
    string autor = "";
    string valorMin = "";
    string confirm;

    while (desc == "" || area == "" || autor == "" || valorMin == ""){
      try {
        if (desc == ""){
          Console.WriteLine("Digite a descrição de sua ideia!");
          desc = Console.ReadLine();
        }

        if (area == ""){
          Console.WriteLine("Digite a área de atuação de sua ideia!");
          area = Console.ReadLine();
        }

        if (autor == ""){
          Console.WriteLine("Digite seu nome:");
          autor = Console.ReadLine();
        }

        if (valorMin == ""){
          Console.WriteLine("Digite o valor mínimo para que sua ideia seja executada!");
          valorMin = Console.ReadLine();
        }

        Console.WriteLine("Digite 's' para cadastrar outra ideia ou qualquer outra tecla para sair!");
        confirm = Console.ReadLine();

        double valorConvert = double.Parse(valorMin);
        
        setIdeia(desc,area,autor,valorConvert);

        if (confirm != "s"){
          return false;
        }

      } catch (FormatException)
      {
        Console.WriteLine("Valor digitado inválido!");
      }
    }
    return true;
  }

  public void exibeRanking(){
    int primeiro = -4;
    int segundo = -4;
    int terceiro = -4;

    for(int i = 0;i < this.valorMinNecessario.Count;i++){

      int comp = this.votos[i];

      if(comp >= primeiro){
        terceiro = segundo;
        segundo = primeiro;
        primeiro = i;       
      } else if(comp <= primeiro && comp > segundo){
        terceiro = segundo;
        segundo = i;
      } else if(comp > terceiro && comp <= segundo){
        terceiro = i;
      }
    }

    double totVotos = (this.votos[primeiro]/this.totalVotos);
    totVotos = totVotos * totVotos;
    totVotos = totVotos * 30000;

    Console.WriteLine("1º lugar -> Autor: {0} | Votos:{1} | Valor Arrecadado: {2}",this.autor[primeiro],this.votos[primeiro],totVotos);
    Console.WriteLine("2º lugar -> Autor: {0} | Votos:{1}",this.autor[segundo],this.votos[segundo]);
    Console.WriteLine("3º lugar -> Autor: {0} | Votos:{1}",this.autor[terceiro],this.votos[terceiro]);

  }

  public bool votarNovamente(){
    string votAgain;

    Console.WriteLine("Digite 's' para votar novamente ou qualquer tecla para sair!");
    votAgain = Console.ReadLine();

    if(votAgain == "s"){
      return false;
    } else {
      return true;
    }    

  }

  public bool curtir(){
    int indexVotado;

    try{
      Console.WriteLine("Digite o número da ideia que deseja votar!");
      indexVotado = int.Parse(Console.ReadLine());
      if (indexVotado >= 0 && indexVotado < this.descricao.Count ){
        this.votos[indexVotado]++;
        totalVotos++;
        return true;
      }      
    } catch(FormatException){
      Console.WriteLine("Valor inválido!");
    }

    return false;
  }


}