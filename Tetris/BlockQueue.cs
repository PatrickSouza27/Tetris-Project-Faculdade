using System;

namespace Tetris
{
    //Classe Sorteador de blocos
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            //aqui to instanciando o atributo blocks recebendo todas as opções de sorteiro
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        //aqui é para gerar um Random(aleatorio)
        private readonly Random random = new Random();

        //Atributo Proximo Bloco
        public Block NextBlock { get; private set; }

        //O proximo Bloco vai receber Um bloco Aleatorio no seu construtor
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //aqui é para atualizar o bloco e não deixar que o mesmo bloco gerar dois iguais em seguida
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
