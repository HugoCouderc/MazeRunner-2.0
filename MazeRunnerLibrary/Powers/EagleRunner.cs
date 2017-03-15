using MazeRunnerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class EagleRunner : SuperRunner

    {

        public override MazeRunnerLibrary.PowerRunner.Power power { get { return MazeRunnerLibrary.PowerRunner.Power.EagleVision; } }



        public bool isADeadEnd(MazeRunnerLibrary.PowerRunner.Direction direction, MazeRunnerLibrary.PowerRunner.Cell[] cells)
        {
            int posX = cells[0].Position.X;
            int posY = cells[0].Position.Y;

            List<MazeRunnerLibrary.PowerRunner.Cell> rightPath = new List<MazeRunnerLibrary.PowerRunner.Cell>();
            List<MazeRunnerLibrary.PowerRunner.Cell> upperWall = new List<MazeRunnerLibrary.PowerRunner.Cell>();
            List<MazeRunnerLibrary.PowerRunner.Cell> downWall = new List<MazeRunnerLibrary.PowerRunner.Cell>();


            for (int i = 1; i < cells.Length; i++)
            {

                if (direction == MazeRunnerLibrary.PowerRunner.Direction.Right)
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

                if (direction == MazeRunnerLibrary.PowerRunner.Direction.Left)
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
 
                if (direction == MazeRunnerLibrary.PowerRunner.Direction.Up)
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
               
                if (direction == MazeRunnerLibrary.PowerRunner.Direction.Down)
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
               
                foreach (MazeRunnerLibrary.PowerRunner.Cell c in upperWall)
                {
                    if (c.CellType == MazeRunnerLibrary.PowerRunner.CellType.Empty)
                    {
                        return false;
                    }
                }

                foreach (MazeRunnerLibrary.PowerRunner.Cell c in downWall)
                {
                    if (c.CellType == MazeRunnerLibrary.PowerRunner.CellType.Empty)
                    {
                        return false;
                    }
                }

                foreach (MazeRunnerLibrary.PowerRunner.Cell c in rightPath)
                {
                    if (c.CellType == MazeRunnerLibrary.PowerRunner.CellType.End)
                    {
                        return false;
                    }
                }


            }

            return true;
        }


        protected override MazeRunnerLibrary.PowerRunner.Direction choosePlayerDirection(MazeRunnerLibrary.PowerRunner.Direction PlayerFace, MazeRunnerLibrary.PowerRunner.Cell[] visibles)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start) && !isADeadEnd(favoriteDirection(PlayerFace), visibles))
            {  
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start) && !isADeadEnd(secondFavoriteDirection(PlayerFace), visibles))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start) && !isADeadEnd(thirdFavoriteDirection(PlayerFace), visibles))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.End || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunnerLibrary.PowerRunner.CellType.Start) && !isADeadEnd(leastFavoriteDirection(PlayerFace), visibles))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }

    }
}
