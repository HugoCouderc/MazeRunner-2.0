using MazeRunnerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class SuperRunner
    {

        public event EventHandler<OnMove> onMove;
        public event EventHandler<OnStart> onStart;
        public event EventHandler<OnFinish> onFinish;

        public virtual int cooldown { get { return 500; } }

        public virtual MazeRunnerLibrary.PowerRunner.Power power { get { return MazeRunnerLibrary.PowerRunner.Power.Duplicate; } }


        protected MazeRunnerLibrary.PowerRunner.Direction favoriteDirection(MazeRunnerLibrary.PowerRunner.Direction d)
        {
            if (d == MazeRunnerLibrary.PowerRunner.Direction.Down)
                return MazeRunnerLibrary.PowerRunner.Direction.Right;
            if (d == MazeRunnerLibrary.PowerRunner.Direction.Right)
                return MazeRunnerLibrary.PowerRunner.Direction.Up;
            if (d == MazeRunnerLibrary.PowerRunner.Direction.Left)
                return MazeRunnerLibrary.PowerRunner.Direction.Down;
            if (d == MazeRunnerLibrary.PowerRunner.Direction.Up)
                return MazeRunnerLibrary.PowerRunner.Direction.Left;

            return MazeRunnerLibrary.PowerRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.PowerRunner.Direction secondFavoriteDirection(MazeRunnerLibrary.PowerRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Right)
                return MazeRunnerLibrary.PowerRunner.Direction.Right;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Left)
                return MazeRunnerLibrary.PowerRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Down)
                return MazeRunnerLibrary.PowerRunner.Direction.Down;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Up)
                return MazeRunnerLibrary.PowerRunner.Direction.Up;

            return MazeRunnerLibrary.PowerRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.PowerRunner.Direction thirdFavoriteDirection(MazeRunnerLibrary.PowerRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Right)
                return MazeRunnerLibrary.PowerRunner.Direction.Down;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Left)
                return MazeRunnerLibrary.PowerRunner.Direction.Up;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Down)
                return MazeRunnerLibrary.PowerRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Up)
                return MazeRunnerLibrary.PowerRunner.Direction.Right;

            return MazeRunnerLibrary.PowerRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.PowerRunner.Direction leastFavoriteDirection(MazeRunnerLibrary.PowerRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Right)
                return MazeRunnerLibrary.PowerRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Left)
                return MazeRunnerLibrary.PowerRunner.Direction.Right;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Down)
                return MazeRunnerLibrary.PowerRunner.Direction.Up;
            if (favorite == MazeRunnerLibrary.PowerRunner.Direction.Up)
                return MazeRunnerLibrary.PowerRunner.Direction.Down;

            return MazeRunnerLibrary.PowerRunner.Direction.Left;
        }

        protected virtual MazeRunnerLibrary.PowerRunner.CellType directionCellType(MazeRunnerLibrary.PowerRunner.Direction direction, MazeRunnerLibrary.PowerRunner.Cell[] cells)
        {
            if (direction == MazeRunnerLibrary.PowerRunner.Direction.Right)
                return cells[2].CellType;
            else if (direction == MazeRunnerLibrary.PowerRunner.Direction.Left)
                return cells[1].CellType;
            else if (direction == MazeRunnerLibrary.PowerRunner.Direction.Down)
                return cells[4].CellType;
            else if (direction == MazeRunnerLibrary.PowerRunner.Direction.Up)
                return cells[3].CellType;

            return 0;
        }



        protected virtual MazeRunnerLibrary.PowerRunner.Direction choosePlayerDirection(MazeRunnerLibrary.PowerRunner.Direction PlayerFace, MazeRunnerLibrary.PowerRunner.Cell[] visibles)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }


        public virtual void playerThreadFunction()
        {

            MazeRunnerLibrary.PowerRunner.PowerGameClient client = new MazeRunnerLibrary.PowerRunner.PowerGameClient();

            MazeRunnerLibrary.PowerRunner.Direction playerFace = MazeRunnerLibrary.PowerRunner.Direction.Right;
            Boolean finish = false;

            MazeRunnerLibrary.PowerRunner.UrlPlayerGame game1 = client.CreateGame(MazeRunnerLibrary.PowerRunner.Difficulty.Extreme, "Hawksterr", power);

            int height = game1.Maze.Height;
            int width = game1.Maze.Width;

            MazeRunnerLibrary.PowerRunner.Cell[] visibles = game1.Player.VisibleCells;

            Console.WriteLine(game1.Url);
            System.Diagnostics.Process.Start("http://ingesup-maze.azurewebsites.net" + game1.Url);

            while (!finish)
            {
                System.Threading.Thread.Sleep(cooldown);

                MazeRunnerLibrary.PowerRunner.Direction moveTo = choosePlayerDirection(playerFace, visibles);

                OnMove move = new OnMove(moveTo.ToString(), game1.Player.CurrentPosition.X + ":" + game1.Player.CurrentPosition.Y);

                onMove?.Invoke(this, move);

                game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, moveTo);

                playerFace = moveTo;

                visibles = game1.Player.VisibleCells;


                foreach (MazeRunnerLibrary.PowerRunner.Cell c in visibles)
                {



                    if (visibles[0].CellType == MazeRunnerLibrary.PowerRunner.CellType.End)
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
