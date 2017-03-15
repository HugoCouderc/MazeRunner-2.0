using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
   public class Runner
    {
        public event EventHandler<OnMove> onMove;
        public event EventHandler<OnStart> onStart;
        public event EventHandler<OnFinish> onFinish;

        public virtual int cooldown { get { return 500; } }


        protected MazeRunnerLibrary.BaseRunner.Direction favoriteDirection(MazeRunnerLibrary.BaseRunner.Direction d)
        {
            if (d == MazeRunnerLibrary.BaseRunner.Direction.Down)
                return MazeRunnerLibrary.BaseRunner.Direction.Right;
            if (d == MazeRunnerLibrary.BaseRunner.Direction.Right)
                return MazeRunnerLibrary.BaseRunner.Direction.Up;
            if (d == MazeRunnerLibrary.BaseRunner.Direction.Left)
                return MazeRunnerLibrary.BaseRunner.Direction.Down;
            if (d == MazeRunnerLibrary.BaseRunner.Direction.Up)
                return MazeRunnerLibrary.BaseRunner.Direction.Left;

            return MazeRunnerLibrary.BaseRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.BaseRunner.Direction secondFavoriteDirection(MazeRunnerLibrary.BaseRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Right)
                return MazeRunnerLibrary.BaseRunner.Direction.Right;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Left)
                return MazeRunnerLibrary.BaseRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Down)
                return MazeRunnerLibrary.BaseRunner.Direction.Down;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Up)
                return MazeRunnerLibrary.BaseRunner.Direction.Up;

            return MazeRunnerLibrary.BaseRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.BaseRunner.Direction thirdFavoriteDirection(MazeRunnerLibrary.BaseRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Right)
                return MazeRunnerLibrary.BaseRunner.Direction.Down;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Left)
                return MazeRunnerLibrary.BaseRunner.Direction.Up;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Down)
                return MazeRunnerLibrary.BaseRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Up)
                return MazeRunnerLibrary.BaseRunner.Direction.Right;

            return MazeRunnerLibrary.BaseRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.BaseRunner.Direction leastFavoriteDirection(MazeRunnerLibrary.BaseRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Right)
                return MazeRunnerLibrary.BaseRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Left)
                return MazeRunnerLibrary.BaseRunner.Direction.Right;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Down)
                return MazeRunnerLibrary.BaseRunner.Direction.Up;
            if (favorite == MazeRunnerLibrary.BaseRunner.Direction.Up)
                return MazeRunnerLibrary.BaseRunner.Direction.Down;

            return MazeRunnerLibrary.BaseRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.BaseRunner.CellType directionCellType(MazeRunnerLibrary.BaseRunner.Direction direction, MazeRunnerLibrary.BaseRunner.Cell[] cells)
        {
            if (direction == MazeRunnerLibrary.BaseRunner.Direction.Right)
                return cells[2].CellType;
            else if (direction == MazeRunnerLibrary.BaseRunner.Direction.Left)
                return cells[1].CellType;
            else if (direction == MazeRunnerLibrary.BaseRunner.Direction.Down)
                return cells[4].CellType;
            else if (direction == MazeRunnerLibrary.BaseRunner.Direction.Up)
                return cells[3].CellType;

            return 0;
        }



        protected MazeRunnerLibrary.BaseRunner.Direction choosePlayerDirection(MazeRunnerLibrary.BaseRunner.Direction PlayerFace, MazeRunnerLibrary.BaseRunner.Cell[] visibles)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.End))
            {
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.End))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.End))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.BaseRunner.CellType.End))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }


        public void playerThreadFunction()
        {

            MazeRunnerLibrary.BaseRunner.GameClient client = new MazeRunnerLibrary.BaseRunner.GameClient();

            MazeRunnerLibrary.BaseRunner.Direction playerFace = MazeRunnerLibrary.BaseRunner.Direction.Right;
            Boolean finish = false;

            MazeRunnerLibrary.BaseRunner.PlayerGame game1 = client.CreateGame(MazeRunnerLibrary.BaseRunner.Difficulty.Extreme, "Hawksterr");

            int height = game1.Maze.Height;
            int width = game1.Maze.Width;

            MazeRunnerLibrary.BaseRunner.Cell[] visibles = game1.Player.VisibleCells;


            while (!finish)
            {
                System.Threading.Thread.Sleep(cooldown);

                MazeRunnerLibrary.BaseRunner.Direction moveTo = choosePlayerDirection(playerFace, visibles);

                OnMove move = new OnMove(moveTo.ToString(), game1.Player.CurrentPosition.X + ":" + game1.Player.CurrentPosition.X);

                onMove?.Invoke(this, move);

                game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, moveTo);

                playerFace = moveTo;

                visibles = game1.Player.VisibleCells;


                foreach (MazeRunnerLibrary.BaseRunner.Cell c in visibles)
                {
                    


                    if (visibles[0].CellType == MazeRunnerLibrary.BaseRunner.CellType.End)
                    {
                        finish = true;

                        OnFinish fin = new OnFinish(game1.Player.SecretMessage);

                        onFinish?.Invoke(this, fin);

                    }

                }
            }
            Console.WriteLine(game1.Player.SecretMessage);
        }


    }
}
