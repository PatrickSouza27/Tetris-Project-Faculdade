using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block
    {
        //aqui to fazendo um construtor para que o deslocamento atual comece recebendo as informações de aonde o bloco vai iniciar
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        //identificador do bloco
        public abstract int Id { get; }
        
        //estado de rotação
        private int rotationState;
        //posição
        private Position offset;

        public Block()
        {
            //É a interface base para todas as coleções não genéricas que podem ser enumeradas. Isso funciona para acesso somente leitura a uma coleção que implementa que IEnumerable pode ser usado com uma instrução foreach.
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }
        //aqui é um metodo para ter uma rotação no sentido horario
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        //aqui é um metodo para ter uma rotação no sentido anti-horario
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        //metodo para mover o bloco
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        //metodo para resetar o bloco 
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
