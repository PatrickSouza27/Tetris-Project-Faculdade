namespace Tetris
{
    public class JBlock : Block
    {
        //o identificador do bloco em s vai ser o 2
        public override int Id => 2;

        //a posição de origem dele aonde ele ira começar é na coluna 3, linha 0(primeiro quadradro do bloco)
        protected override Position StartOffset => new(0, 3);

        //aqui to sobrescrevendo todas os posições do bloco
        protected override Position[][] Tiles => new Position[][] {
            new Position[] {new(0, 0), new(1, 0), new(1, 1), new(1, 2)},
            new Position[] {new(0, 1), new(0, 2), new(1, 1), new(2, 1)},
            new Position[] {new(1, 0), new(1, 1), new(1, 2), new(2, 2)},
            new Position[] {new(0, 1), new(1, 1), new(2, 1), new(2, 0)}
        };
    }
}
