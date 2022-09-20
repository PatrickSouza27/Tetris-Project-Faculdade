namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            //instanciando, poderia ser direto tbm como foi na subclasse bloco S, mas usaremos esses dois exemplos
            new Position[] { new(0,0), new(0,1), new(1,0), new(1,1) }
        };

        //o identificador do bloco em s vai ser o 4
        public override int Id => 4;
        //a posição de origem dele aonde ele ira começar é na coluna 4, linha 0(primeiro quadradro do bloco)
        protected override Position StartOffset => new Position(0, 4);

        //aqui o tiles vai sobrescrever o Tiles
        protected override Position[][] Tiles => tiles;
    }
}
