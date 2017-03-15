using MazeRunnerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class WallRunner :SuperRunner
    {
        public override MazeRunnerLibrary.PowerRunner.Power power { get { return MazeRunnerLibrary.PowerRunner.Power.WallVision; } }

        public MazeRunnerLibrary.PowerRunner.CellType directionCellType(MazeRunnerLibrary.PowerRunner.Direction direction, MazeRunnerLibrary.PowerRunner.Cell[] cells, MazeRunnerLibrary.PowerRunner.Position playerPos)
        {
            if (direction == MazeRunnerLibrary.PowerRunner.Direction.Right)
            {
                foreach (MazeRunnerLibrary.PowerRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X + 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunnerLibrary.PowerRunner.Direction.Left)
            {
                foreach (MazeRunnerLibrary.PowerRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X - 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunnerLibrary.PowerRunner.Direction.Down)
            {
                foreach (MazeRunnerLibrary.PowerRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y + 1)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunnerLibrary.PowerRunner.Direction.Up)
            {
                foreach (MazeRunnerLibrary.PowerRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y - 1)
                    {
                        return c.CellType;
                    }
                }
            }

            return 0;
        }

        public MazeRunnerLibrary.PowerRunner.Direction choosePlayerDirection(MazeRunnerLibrary.PowerRunner.Direction PlayerFace, MazeRunnerLibrary.PowerRunner.Cell[] visibles, MazeRunnerLibrary.PowerRunner.Position playerPos)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.PowerRunner.CellType.Start))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }




        public override void playerThreadFunction()
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

                MazeRunnerLibrary.PowerRunner.Direction moveTo = choosePlayerDirection(playerFace, visibles, game1.Player.CurrentPosition);

                OnMove move = new OnMove(moveTo.ToString(), game1.Player.CurrentPosition.X + ":" + game1.Player.CurrentPosition.Y);

                game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, moveTo);

                playerFace = moveTo;

                visibles = game1.Player.VisibleCells;


                foreach (MazeRunnerLibrary.PowerRunner.Cell c in visibles)
                {



                    if (visibles[0].CellType == MazeRunnerLibrary.PowerRunner.CellType.End)
                    {
                        finish = true;

                        OnFinish fin = new OnFinish(game1.Player.SecretMessage);

                    }

                }
            }
            Console.WriteLine(game1.Player.SecretMessage);
        }


    }
}
