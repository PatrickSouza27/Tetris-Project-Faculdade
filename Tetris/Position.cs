namespace Tetris
{
    //aqui é uma classe para pegar as posições
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        //construtor da classe pegando como parametro linha e coluna
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
