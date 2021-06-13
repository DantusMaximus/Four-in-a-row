using System;
class Player{
    public string Name { get; set; }
    public Piece Piece { get; set; }
    public Player(string name, Piece piece){
        Name = name;
        Piece = piece;
    }
    public (int, Piece) MakeMove(){
        bool invalidMove = true;
        int col = 1;
        while(invalidMove){
        col = Console.ReadKey(true).KeyChar - 48;
        if(col >= 1 && col <= 7){ invalidMove = false;}
        }
        return (col-1, Piece); 
    }
}