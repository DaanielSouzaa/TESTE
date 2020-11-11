using System;

class MainClass {
  public static void Main (string[] args) {
    ideias ideia = new ideias();

    bool validaCad = true;
    while(validaCad == true){
      validaCad = ideia.cadIdeia();
    }

    bool visualizaIdeias = false;
    while(visualizaIdeias == false){
      ideia.getIdeia();
      visualizaIdeias = ideia.curtir();

      visualizaIdeias = ideia.votarNovamente();
      ideia.exibeRanking();
    }
  }
}