using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerRunner
{
    class ProgramQR
    {

        static MazeRunner.Direction favoriteDirection(MazeRunner.Direction d)
        {
            if (d == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Right;
            if (d == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Up;
            if (d == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Down;
            if (d == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Left;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.Direction secondFavoriteDirection(MazeRunner.Direction favorite)
        {
            if (favorite == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Right;
            if (favorite == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Left;
            if (favorite == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Down;
            if (favorite == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Up;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.Direction thirdFavoriteDirection(MazeRunner.Direction favorite)
        {
            if (favorite == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Down;
            if (favorite == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Up;
            if (favorite == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Left;
            if (favorite == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Right;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.Direction leastFavoriteDirection(MazeRunner.Direction favorite)
        {
            if (favorite == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Left;
            if (favorite == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Right;
            if (favorite == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Up;
            if (favorite == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Down;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.CellType directionCellType(MazeRunner.Direction direction, MazeRunner.Cell[] cells, MazeRunner.Position playerPos)
        {
            if (direction == MazeRunner.Direction.Right)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X + 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunner.Direction.Left)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X - 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunner.Direction.Down)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y + 1)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunner.Direction.Up)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y - 1)
                    {
                        return c.CellType;
                    }
                }
            }

            return MazeRunner.CellType.Wall;
           
        }

        static MazeRunner.CellType directionCellTypeWall(MazeRunner.Direction direction, MazeRunner.Cell[] cells, MazeRunner.Position playerPos)
        {
            if (direction == MazeRunner.Direction.Right)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if(c.Position.X == playerPos.X+1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }
               
            else if (direction == MazeRunner.Direction.Left)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X - 1 && c.Position.Y == playerPos.Y)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunner.Direction.Down)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y + 1)
                    {
                        return c.CellType;
                    }
                }
            }

            else if (direction == MazeRunner.Direction.Up)
            {
                foreach (MazeRunner.Cell c in cells)
                {
                    if (c.Position.X == playerPos.X && c.Position.Y == playerPos.Y - 1)
                    {
                        return c.CellType;
                    }


                }
            }

            return MazeRunner.CellType.Wall;
        }


        static bool isADeadEnd(MazeRunner.Direction direction, MazeRunner.Cell[] cells)
        {
            int posX = cells[0].Position.X;
            int posY = cells[0].Position.Y;

            List<MazeRunner.Cell> rightPath = new List<MazeRunner.Cell>();
            List<MazeRunner.Cell> upperWall = new List<MazeRunner.Cell>();
            List<MazeRunner.Cell> downWall = new List<MazeRunner.Cell>();


            for (int i = 1; i<cells.Length; i++)
            {

            //====================================
             if (direction == MazeRunner.Direction.Right)
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

                //=======================================

                if (direction == MazeRunner.Direction.Left)
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
            //=======================================

                if (direction == MazeRunner.Direction.Up)
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
                //=======================================


                if (direction == MazeRunner.Direction.Down)
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
                //=======================================

                foreach (MazeRunner.Cell c in upperWall)
                {
                    if (c.CellType == MazeRunner.CellType.Empty)
                    {
                        return false;
                    }
                }

                foreach (MazeRunner.Cell c in downWall)
                {
                    if (c.CellType == MazeRunner.CellType.Empty)
                    {
                        return false;
                    }
                }

                foreach (MazeRunner.Cell c in rightPath)
                {
                    if (c.CellType == MazeRunner.CellType.End)
                    {
                        return false;
                    }
                }


            }

            return true;
        }



        static MazeRunner.Direction choosePlayerDirection(MazeRunner.Direction PlayerFace, MazeRunner.Cell[] visibles, MazeRunner.Position playerPos)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End))
            {
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }

        static MazeRunner.Direction choosePlayerDirectionWall(MazeRunner.Direction PlayerFace, MazeRunner.Cell[] visibles, MazeRunner.Position playerPos)
        {
            if ((directionCellTypeWall(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellTypeWall(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End || directionCellTypeWall(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Start))
            {
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellTypeWall(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellTypeWall(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End || directionCellTypeWall(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Start))
            {
                Console.WriteLine("go right ahead !" + (directionCellTypeWall(secondFavoriteDirection(PlayerFace), visibles, playerPos)));
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellTypeWall(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellTypeWall(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End || directionCellTypeWall(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Start))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellTypeWall(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellTypeWall(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End || directionCellTypeWall(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Start))
            {
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }




        static MazeRunner.Direction choosePlayerDirectionEagle(MazeRunner.Direction PlayerFace, MazeRunner.Cell[] visibles, MazeRunner.Position playerPos)
        {
            if ((directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End) && !isADeadEnd(favoriteDirection(PlayerFace), visibles))
            {
                return favoriteDirection(PlayerFace);
            }

            else if ((directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End) && !isADeadEnd(secondFavoriteDirection(PlayerFace), visibles))
            {
                return secondFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End) && !isADeadEnd(thirdFavoriteDirection(PlayerFace), visibles))
            {
                return thirdFavoriteDirection(PlayerFace);
            }

            else if ((directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles, playerPos) == MazeRunner.CellType.End) && !isADeadEnd(leastFavoriteDirection(PlayerFace), visibles))
            {             
                return leastFavoriteDirection(PlayerFace);
            }

            return favoriteDirection(PlayerFace); // penser à ajouter une exception
        }



        static public void playerSpeedThreadFunction(MazeRunner.PowerGameClient client,MazeRunner.Direction playerFace2, MazeRunner.Player player2, MazeRunner.Cell[] visibles2, string gameKey)
        {
            bool finish = false;

            while (!finish)
            {
                System.Threading.Thread.Sleep(250);

                MazeRunner.Direction moveTo2 = choosePlayerDirectionWall(playerFace2, visibles2, player2.CurrentPosition);

                Console.WriteLine(player2.Name + " moved " + moveTo2);

                player2 = client.MovePlayer(gameKey, player2.Key, moveTo2);

                playerFace2 = moveTo2;

                visibles2 = player2.VisibleCells;


                foreach (MazeRunner.Cell c in visibles2)
                {
                    Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);
                    

                    if (visibles2[0].CellType == MazeRunner.CellType.End)
                    {
                        finish = true;
                    }

                }
            }
            Console.WriteLine(player2.SecretMessage);
        }


        static public void playerThreadFunction(MazeRunner.PowerGameClient client, MazeRunner.Direction playerFace2, MazeRunner.Player player2, MazeRunner.Cell[] visibles2, string gameKey)
        {
            bool finish = false;

            while (!finish)
            {
                System.Threading.Thread.Sleep(500);

                MazeRunner.Direction moveTo2 = choosePlayerDirection(playerFace2, visibles2, player2.CurrentPosition);

                //Console.WriteLine(player2.Name + " moved " + moveTo2);

                player2 = client.MovePlayer(gameKey, player2.Key, moveTo2);

                playerFace2 = moveTo2;

                visibles2 = player2.VisibleCells;


                foreach (MazeRunner.Cell c in visibles2)
                {
                    //Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);


                    if (visibles2[0].CellType == MazeRunner.CellType.End)
                    {
                        finish = true;
                    }

                }
            }
            Console.WriteLine(player2.SecretMessage);
        }

        static public void playerWallThreadFunction(MazeRunner.PowerGameClient client, MazeRunner.Direction playerFace2, MazeRunner.Player player2, MazeRunner.Cell[] visibles2, string gameKey)
        {
            bool finish = false;

            while (!finish)
            {
                System.Threading.Thread.Sleep(500);

                MazeRunner.Direction moveTo2 = choosePlayerDirectionWall(playerFace2, visibles2, player2.CurrentPosition);

                //Console.WriteLine(player2.Name + " moved " + moveTo2);

                player2 = client.MovePlayer(gameKey, player2.Key, moveTo2);

                playerFace2 = moveTo2;

                visibles2 = player2.VisibleCells;

                foreach (MazeRunner.Cell c in visibles2)
                {
                    //Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);

                    
                        if (c.Position.X == player2.CurrentPosition.X && c.Position.Y == player2.CurrentPosition.Y && c.CellType == MazeRunner.CellType.End )
                        {
                            finish = true;
                        }
                    

                }

            }
            Console.WriteLine(player2.SecretMessage);


        }







        static void MainQR(string[] args)
        {
            MazeRunner.PowerGameClient client = new MazeRunner.PowerGameClient();

            MazeRunner.Direction PlayerFace = MazeRunner.Direction.Right;
            MazeRunner.Direction PlayerFace2 = MazeRunner.Direction.Right;
            MazeRunner.Direction PlayerFace3 = MazeRunner.Direction.Right;
            MazeRunner.Direction PlayerFace4 = MazeRunner.Direction.Right;

            Boolean finish = false;
            Boolean finish2 = false;

            string finalkey = "11111111-b9d3-4e51-b73f-bd9dda66e29c";

            MazeRunner.UrlGame game1 = client.LoadGame(finalkey);

            client.ResetGame(finalkey);

            //MazeRunner.Player player1 = client.AddPlayer(game1.Key, "EagleEye", MazeRunner.Power.EagleVision);
            //MazeRunner.Player player2 = client.AddPlayer(game1.Key, "QuickFlash", MazeRunner.Power.SpeedUp);
            //MazeRunner.Player player3 = client.AddPlayer(game1.Key, "Duplicata", MazeRunner.Power.Duplicate);
            //MazeRunner.Player player4 = client.AddPlayer(game1.Key, "Ghost", MazeRunner.Power.WallVision);

            string key1 = "d75caaee-176e-4808-85bd-ed517aabe132";
            string key2 = "f78e9e41-65d8-415b-a077-1f955073eece";
            string key3 = "dadb9aa4-a9d4-4ed9-80ed-5d545749a76a";
            string key4 = "67eaf851-e555-4142-baee-cfb1adc53a6b";


            //Console.WriteLine(player1.Key);
            //Console.WriteLine(player2.Key);
            //Console.WriteLine(player3.Key);
            //Console.WriteLine(player4.Key);

            System.Threading.Thread.Sleep(500);

            MazeRunner.Player player1 = client.MovePlayer(finalkey, key1, MazeRunner.Direction.Right);
            MazeRunner.Player player2 = client.MovePlayer(finalkey, key2, MazeRunner.Direction.Right);
            MazeRunner.Player player3 = client.MovePlayer(finalkey, key3, MazeRunner.Direction.Right);
            MazeRunner.Player player4 = client.MovePlayer(finalkey, key4, MazeRunner.Direction.Right);


            int height = game1.Maze.Height;
            int width = game1.Maze.Width;

            String[][] mazeArray = new String[width][];

            for (int i = 0; i < width; i++)
            {
                mazeArray[i] = new String[height];
            }




            Console.WriteLine("game created : the key is...");
            Console.WriteLine(game1.Key);

            //MazeRunner.Player Player1 = client.AddPlayer(game1.Key, "Hawksterr");
            Console.WriteLine("Player " + player1.Name + " joined the game !");

            Console.WriteLine(game1.Url);



            MazeRunner.Position p1 = player1.CurrentPosition;
            MazeRunner.Position p2 = player2.CurrentPosition;
            MazeRunner.Position p3 = player3.CurrentPosition;
            MazeRunner.Position p4 = player4.CurrentPosition;

            //Console.WriteLine(player1.Name + " is at position : " + p1.X + ":" + p1.Y);

            MazeRunner.Cell[] visibles = player1.VisibleCells;
            MazeRunner.Cell[] visibles2 = player2.VisibleCells;
            MazeRunner.Cell[] visibles3 = player3.VisibleCells;
            MazeRunner.Cell[] visibles4 = player4.VisibleCells;

            //foreach (MazeRunner.Cell c in visibles)
            //{
            //    Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);
            //    mazeArray[c.Position.X][c.Position.Y] = c.CellType.ToString();

            //}

            Thread threadSpeed = new Thread(() => playerSpeedThreadFunction(client, PlayerFace2, player2, visibles2, game1.Key));
            threadSpeed.Start();

            Thread threadClone = new Thread(() => playerThreadFunction(client, PlayerFace3, player3, visibles3, game1.Key));
            threadClone.Start();

            Thread threadWall = new Thread(() => playerWallThreadFunction(client, PlayerFace4, player4, visibles4, game1.Key));
            threadWall.Start();
                        


            while (!finish)
            {

                System.Threading.Thread.Sleep(500);

                MazeRunner.Direction moveTo = choosePlayerDirectionEagle(PlayerFace, visibles, player1.CurrentPosition);
         


                //Console.WriteLine( player1.Name + " moved " + moveTo);
                

                player1 = client.MovePlayer(game1.Key, player1.Key, moveTo);
                  

                //Console.WriteLine("player facing " + moveTo);

                    PlayerFace = moveTo;
                  

                

                p1 = player1.CurrentPosition;
            

                //Console.WriteLine(player1.Name + " is at position : " + p1.X + ":" + p1.Y);


                visibles = player1.VisibleCells;
              


                foreach (MazeRunner.Cell c in visibles)
                {
                    //Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);
                    mazeArray[c.Position.X][c.Position.Y] = c.CellType.ToString();

                  if (visibles[0].CellType == MazeRunner.CellType.End)
                    {
                        finish = true;
                    }

                }
            }

            Console.WriteLine("YOU WIN");
            Console.WriteLine("the secret message is....");
            Console.WriteLine(player1.SecretMessage);

            Console.ReadLine();
            client.Close();


        }
    }
}
