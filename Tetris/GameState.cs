namespace Tetris
{
    public class GameState
    {
        //campo de apoio para o bloco atual
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                //quando atualizamos o bloco atual o método RedefinirRotarionEPosition é chamado para definir a posição correta e rotação
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        //adicionar propriedades para a grade do jogo, a fila de bloco e um game over que vai ser um tipo bool
        //na grade do jogo vamos iniciar a grade do game com 22 linhas e 10 colunas.
        public GameGrid GameGrid { get; }
        //a fila de bloco vamos fazer um metodo para obter um bloco aleatorio para a propriedade
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        //variavel que armazena a pontuação
        public int Score { get; private set; }
        public Block HeldBlock { get; private set; }
        public bool CanHold { get; private set; }

        public GameState()
        {
            //instanciando a grade do jogo
            GameGrid = new GameGrid(22, 10);
            //gerando o bloco aleatorio
            BlockQueue = new BlockQueue();
            //atualizando o bloco de apoio
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }
        //metodo que verifica se o bloco atual esta em uma posição valida
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                //o metodo faz um loop sobre as posições do bloco atual e se algum dele esta fora da grade ou sobreponto outro bloco, entao retornamos falso
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
                //caso contrario, se passar, retornamos verdadeiro
            }

            return true;
        }

        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }

            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            CanHold = false;
        }
        //metodo para girar o bloco no sentido horario, mas somente se for possivel fazer de onde esta
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            //se a posição nao for valida
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }
        //metodo para girar o bloco no sentido anti-horario, mas somente se for possivel fazer de onde esta
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }
       

        //metodo para ver se o bloco esta em uma posição valida
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }


        //metodo para mover para a direita
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            //se a posição nao for valida
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        //metodo para ver se o jogo terminou
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
            //se alguma das linhas do topo nao estiver vazia, entao o jogo esta perdido
        }
        //metodo chamado quando o bloco atual nao puder ser movido para baixo
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
                //primeiro ele faz um loop sobre e coloca as posições do bloco atual e define essas posições na grade do jogo iguais ao identificador do bloco
            }
            //entao limpamos todas as linhas cheias
            Score += GameGrid.ClearFullRows();

            //quando limpar, verificar se o jogo acabou
            if (IsGameOver())
            {
                //se acabou, o game over recebe verdadeiro
                GameOver = true;

                //senão, eu atualizo o bloco atual
            }
            else
            {
                //metodo que valida se posso mover para baixo
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        //ele funciona exatamente como os outros métodos de mover
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }


        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;

            foreach (Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
