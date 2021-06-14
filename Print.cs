using System;
static class Print
{
    public static void Board(Piece[,] Board)
    {
        Console.Clear();
        Console.WriteLine("───────────────");
        for (int r = 0; r <= 5; r++)
        {
            Console.Write("│");
            for (int c = 0; c <= 6; c++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (Board[c, r] == Piece.Empty) {   Console.Write("o");}
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (Board[c, r] == Piece.Yellow){   Console.Write("o");}
                Console.ForegroundColor = ConsoleColor.Red;
                if (Board[c, r] == Piece.Red) {     Console.Write("o");}
                Console.ResetColor();
                Console.Write("│");
            }
            Console.WriteLine();
            Console.WriteLine("───────────────");
        }
        Console.WriteLine(" 1 2 3 4 5 6 7");
    }
    public static void Prompt(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
    }
    public static void AnnounceWinner(Player player){
        if(player == null){
            Console.WriteLine("Draw!");
            return;
        }
        Console.WriteLine(player.Name + " with " + (player.Piece == Piece.Yellow ? "🟡":"🔴") + " Has won!");
    }
}