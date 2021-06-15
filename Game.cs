using System;
class Game {
    public int Width { get; private set;}
    public int Height { get; set; }
    public Player[] Players { get; set; }
    public Piece[,] Placed { get; set; } // Piece[Column,Row]
    public Player Winner { get; set; }
    public Game(){
        Width = 7;
        Height = 6;
        this.Players = Players;
        Placed = new Piece[Width, Height];
        Players = new Player[2];
    }
    public void Start(){
        bool gameOver = false;
        bool invalidMove;
        int turnDeterminator = 0;
        AddPlayers();
        while(!gameOver){
            Print.Board(Placed);
            Print.RequestMove(Players[turnDeterminator]);
            invalidMove = true;
            while(invalidMove){
                (int, Piece) placement = Players[turnDeterminator].MakeMove();
                invalidMove = AddPieceToRow(placement);
            }
            gameOver = CheckForGameOver();
            turnDeterminator = (turnDeterminator + 1) % 2;
        }
        Print.Board(Placed);
        Print.AnnounceWinner(Winner);
    }
    void AddPlayers(){
        Print.Prompt("Player one name: ");
        Players[0] = new Player(Console.ReadLine(), Piece.Red);
        Print.Prompt("Player two name: ");
        Players[1] = new Player(Console.ReadLine(), Piece.Yellow);
        if(Players[0].Name.Equals(Players[1].Name)){ Console.Clear(); Print.Prompt("Both players cant have the same name. Enter any key to retry"); Console.ReadKey(false); AddPlayers();}
    }
    bool AddPieceToRow((int, Piece) placement){
        int col = placement.Item1;
        Piece piece = placement.Item2;
        for(int r = Height - 1; r>= 0; r--){
            if(Placed[col, r] == Piece.Empty){
                Placed[col, r] = piece;
                return false;
            }
            if(r == 0){
                return true;
            }
        }
        return true;
    }
    bool CheckForGameOver(){ //Checks always occur from bottom to top, left to right
        if(BoardFull()){ return true;}
        return ( CheckForWinner(6,5,0,3,0,-1) /* 4s in Colomnns */ || CheckForWinner(6,5,3,0,-1,0) /* 4s in Rows*/ || CheckForWinner(3,5,0,3,1,-1) /* / diagonals */
        || CheckForWinner(6,5,3,3,-1,-1) /* \ diagonals */);

    bool CheckForWinner(int cStart, int rStart, int cEnd, int rEnd, int dc, int dr){
        for(int r = rStart; r >= rEnd; r--){
                for(int c = cStart; c >= cEnd; c--){
                    if(Placed[c,r] != Piece.Empty &&  Placed[c,r] == Placed[c+dc,r+dr] && Placed[c+dc,r+dr] == Placed[c+2*dc,r+2*dr] && Placed[c,r] == Placed[c+3*dc,r+3*dr]){
                        Winner = Players[0].Piece == Placed[c,r] ? Players[0] : Players[1];
                        return true;
                    }
                }
            }
            return false;
    }
    bool BoardFull(){
        for(int r = Height-1 ; r >= 0 ; r--){
            for(int c = Height-1 ; c >= 0 ; c--){
                if(Placed[c,r] == Piece.Empty){ return false;}
            }
        }
        return true;
    }
    }

}