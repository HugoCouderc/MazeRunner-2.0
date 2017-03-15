using MazeRunnerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class GodLikeRunner
    {
        public event EventHandler<OnMove> onMove;
        public event EventHandler<OnStart> onStart;
        public event EventHandler<OnFinish> onFinish;

        public virtual int cooldown { get { return 250; } }


        public bool isADeadEnd(MazeRunnerLibrary.GodRunner.Direction direction, MazeRunnerLibrary.GodRunner.Cell[] cells, MazeRunnerLibrary.GodRunner.Position playerPos)
        {
            int posX = playerPos.X;
            int posY = playerPos.Y;

            List<MazeRunnerLibrary.GodRunner.Cell> rightPath = new List<MazeRunnerLibrary.GodRunner.Cell>();
            List<MazeRunnerLibrary.GodRunner.Cell> upperWall = new List<MazeRunnerLibrary.GodRunner.Cell>();
            List<MazeRunnerLibrary.GodRunner.Cell> downWall = new List<MazeRunnerLibrary.GodRunner.Cell>();


            for (int i = 1; i < cells.Length; i++)
            {

                if (direction == MazeRunnerLibrary.GodRunner.Direction.Right)
                {
                    if (cells[i].Position.Y == posY && cells[i].Position.X > posX)
                    {
                        rightPath.Add(cells[i]);
                    }

                    if (cells[i].Position.Y == posY - 1 && cells[i].Position.X > posX)
                    {
                        upperWall.Add(cells[i]);
                    }

                    if (cells[i].Position.Y == posY + 1 && cells[i].Position.X > posX)
                    {
                        downWall.Add(cells[i]);
                    }
                }

                if (direction == MazeRunnerLibrary.GodRunner.Direction.Left)
                {
                    if (cells[i].Position.Y == posY && cells[i].Position.X < posX)
                    {
                        rightPath.Add(cells[i]);
                    }

                    if (cells[i].Position.Y == posY - 1 && cells[i].Position.X < posX)
                    {
                        upperWall.Add(cells[i]);
                    }

                    if (cells[i].Position.Y == posY + 1 && cells[i].Position.X < posX)
                    {
                        downWall.Add(cells[i]);
                    }
                }

                if (direction == MazeRunnerLibrary.GodRunner.Direction.Up)
                {
                    if (cells[i].Position.X == posX && cells[i].Position.Y < posY)
                    {
                        rightPath.Add(cells[i]);
                    }

                    if (cells[i].Position.X == posX - 1 && cells[i].Position.Y < posY)
                    {
                        upperWall.Add(cells[i]);
                    }

                    if (cells[i].Position.X == posX + 1 && cells[i].Position.Y < posY)
                    {
                        downWall.Add(cells[i]);
                    }
                }

                if (direction == MazeRunnerLibrary.GodRunner.Direction.Down)
                {
                    if (cells[i].Position.X == posX && cells[i].Position.Y > posY)
                    {
                        rightPath.Add(cells[i]);
                    }

                    if (cells[i].Position.X == posX - 1 && cells[i].Position.Y > posY)
                    {
                        upperWall.Add(cells[i]);
                    }

                    if (cells[i].Position.X == posX + 1 && cells[i].Position.Y > posY)
                    {
                        downWall.Add(cells[i]);
                    }
                }

                foreach (MazeRunnerLibrary.GodRunner.Cell c in upperWall)
                {
                    if (c.CellType == MazeRunnerLibrary.GodRunner.CellType.Empty)
                    {
                        return false;
                    }
                }

                foreach (MazeRunnerLibrary.GodRunner.Cell c in downWall)
                {
                    if (c.CellType == MazeRunnerLibrary.GodRunner.CellType.Empty)
                    {
                        return false;
                    }
                }

                foreach (MazeRunnerLibrary.GodRunner.Cell c in rightPath)
                {
                    if (c.CellType == MazeRunnerLibrary.GodRunner.CellType.End)
                    {
                        return false;
                    }
                }


            }

            return true;
        }




        protected MazeRunnerLibrary.GodRunner.Direction favoriteDirection(MazeRunnerLibrary.GodRunner.Direction d)
        {
            if (d == MazeRunnerLibrary.GodRunner.Direction.Down)
                return MazeRunnerLibrary.GodRunner.Direction.Right;
            if (d == MazeRunnerLibrary.GodRunner.Direction.Right)
                return MazeRunnerLibrary.GodRunner.Direction.Up;
            if (d == MazeRunnerLibrary.GodRunner.Direction.Left)
                return MazeRunnerLibrary.GodRunner.Direction.Down;
            if (d == MazeRunnerLibrary.GodRunner.Direction.Up)
                return MazeRunnerLibrary.GodRunner.Direction.Left;

            return MazeRunnerLibrary.GodRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.GodRunner.Direction secondFavoriteDirection(MazeRunnerLibrary.GodRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Right)
                return MazeRunnerLibrary.GodRunner.Direction.Right;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Left)
                return MazeRunnerLibrary.GodRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Down)
                return MazeRunnerLibrary.GodRunner.Direction.Down;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Up)
                return MazeRunnerLibrary.GodRunner.Direction.Up;

            return MazeRunnerLibrary.GodRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.GodRunner.Direction thirdFavoriteDirection(MazeRunnerLibrary.GodRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Right)
                return MazeRunnerLibrary.GodRunner.Direction.Down;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Left)
                return MazeRunnerLibrary.GodRunner.Direction.Up;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Down)
                return MazeRunnerLibrary.GodRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Up)
                return MazeRunnerLibrary.GodRunner.Direction.Right;

            return MazeRunnerLibrary.GodRunner.Direction.Left;
        }

        protected MazeRunnerLibrary.GodRunner.Direction leastFavoriteDirection(MazeRunnerLibrary.GodRunner.Direction favorite)
        {
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Right)
                return MazeRunnerLibrary.GodRunner.Direction.Left;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Left)
                return MazeRunnerLibrary.GodRunner.Direction.Right;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Down)
                return MazeRunnerLibrary.GodRunner.Direction.Up;
            if (favorite == MazeRunnerLibrary.GodRunner.Direction.Up)
                return MazeRunnerLibrary.GodRunner.Direction.Down;

            return MazeRunnerLibrary.GodRunner.Direction.Left;
        }


        static MazeRunnerLibrary.GodRunner.CellType directionCellType(MazeRunnerLibrary.GodRunner.Direction direction, MazeRunnerLibrary.GodRunner.Cell[] cells, MazeRunnerLibrary.GodRunner.Position playerPos)
        {
            if (direction == MazeRunnerLibrary.GodRunner.Direction.Right)
            {
                foreach (MazeRunnerLibrary.GodRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X + 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunnerLibrary.GodRunner.Direction.Left)
            {
                foreach (MazeRunnerLibrary.GodRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X - 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunnerLibrary.GodRunner.Direction.Down)
            {
                foreach (MazeRunnerLibrary.GodRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y + 1)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunnerLibrary.GodRunner.Direction.Up)
            {
                foreach (MazeRunnerLibrary.GodRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y - 1)
                    {
                        return c.CellType;
                    }
                }
            }

            return 0;
        }


        protected MazeRunnerLibrary.GodRunner.Direction choosePlayerDirection(MazeRunnerLibrary.GodRunner.Direction PlayerFace, MazeRunnerLibrary.GodRunner.Cell[] visibles, MazeRunnerLibrary.GodRunner.Position playerPos)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Start) && !isADeadEnd(favoriteDirection(PlayerFace), visibles, playerPos))
            {
                return favoriteDirection(PlayerFace);
                
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.End || directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Start) && !isADeadEnd(secondFavoriteDirection(PlayerFace), visibles, playerPos))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.End || directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Start) && !isADeadEnd(thirdFavoriteDirection(PlayerFace), visibles, playerPos))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.End || directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunnerLibrary.GodRunner.CellType.Start) && !isADeadEnd(leastFavoriteDirection(PlayerFace), visibles, playerPos))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }


        public void playerThreadFunction()
        {

            MazeRunnerLibrary.GodRunner.GodGameClient client = new MazeRunnerLibrary.GodRunner.GodGameClient();

            MazeRunnerLibrary.GodRunner.Direction playerFace = MazeRunnerLibrary.GodRunner.Direction.Right;
            Boolean finish = false;

            MazeRunnerLibrary.GodRunner.UrlPlayerGame game1 = client.CreateGame(MazeRunnerLibrary.GodRunner.Difficulty.Extreme, "Hawksterr");

            int height = game1.Maze.Height;
            int width = game1.Maze.Width;

            MazeRunnerLibrary.GodRunner.Cell[] visibles = game1.Player.VisibleCells;

            Console.WriteLine(game1.Url);
            System.Diagnostics.Process.Start("http://ingesup-maze.azurewebsites.net" + game1.Url);

            while (!finish)
            {
                System.Threading.Thread.Sleep(cooldown);


                MazeRunnerLibrary.GodRunner.Direction moveTo = choosePlayerDirection(playerFace, visibles, game1.Player.CurrentPosition);

                OnMove move = new OnMove(moveTo.ToString(), game1.Player.CurrentPosition.X + ":" + game1.Player.CurrentPosition.Y);

                

                game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, moveTo);

                onMove?.Invoke(this, move);

                playerFace = moveTo;

                visibles = game1.Player.VisibleCells;


                foreach (MazeRunnerLibrary.GodRunner.Cell c in visibles)
                {



                    if (c.Position.X == game1.Player.CurrentPosition.X && c.Position.Y == game1.Player.CurrentPosition.Y && c.CellType == MazeRunnerLibrary.GodRunner.CellType.End)
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
