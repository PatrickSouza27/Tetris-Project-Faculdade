namespace Tetris
{
    public class IBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //instanciando, poderia ser direto tbm como foi na subclasse bloco S, mas usaremos esses dois exemplos
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) },
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2) },
            new Position[] { new(2,0), new(2,1), new(2,2), new(2,3) },
            new Position[] { new(0,1), new(1,1), new(2,1), new(3,1) }
        };

        //o identificador do bloco em s vai ser o 1
        public override int Id => 1;
        //a posição de origem dele aonde ele ira começar é na coluna 3, linha -1(primeiro quadradro do bloco)
        protected override Position StartOffset => new Position(-1, 3);
        //aqui o tiles vai sobrescrever o Tiles
        protected override Position[][] Tiles => tiles;
    }
}
