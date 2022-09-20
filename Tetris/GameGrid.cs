//essa classe faz as grades do projeto, e ela ira conter a matriz 
namespace Tetris
{
    //o atributo vai ser privado, so pode ser alterado atravez da propria classe do assembly.
    //readonly é um modigicador
    //int[,] grade <- como dizer que um atributo é uma matriz, porem, ainda não instanciei ela ainda falando quanto de quanto ela vai ter
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c]
        {
            //Nessa linha vou passar um indexador para o array ter facil acesso
            //Os indexadores permitem que instâncias de uma classe ou struct sejam indexados como matrizes,Os indexadores parecem com propriedades, a diferença é que seus acessadores usam parâmetros
            get => grid[r, c];
            //operador de referencia
            set => grid[r, c] = value;
            //nesse caso estou usando isso para indexar diretamente em um objeto "grade"
        }

        public GameGrid(int rows, int columns)
        //vou pegar o numero de linhas e colunas atravez do construtor
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];//ja com as informações do construtor, eu posso instanciar minha matriz
        }

        public bool IsInside(int r, int c)
        {
            //aqui to verificando se uma determinada linha e coluna está dentro da grade
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
            //para estar dentro da grade a linha deve ser maior ou igual a 0 e menor que as linhas da grade
        }

        //metodo para ver se a célula esta vazia
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        //metodo para verificar todas as linhas completadas
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                //aqui vou verificar se tem alguma linha completa vazia, no caso é a mesma operação da de cima, so muda a verificação de igual a zero para diferente de 0;
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }
        //essa verificações são pra quando existirem linhas completas, elas precisam ser apagadas e as linhas de cima deve ser movida para baixo
        //aqui acontece a mesma coisa com o private la de cima, so poder ser acessada pela propria classe

        //aqui acontece a mesma coisa com o private la de cima, so poder ser acessada pela propria classe, nesse caso o comando seria para apagar a linha  
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //metodo para mover a linha
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        //metodo para limpar todas as linhas
        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
