using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] xPos = new int[50];
				xPos[0] = 35;
			int[] yPos = new int[50];
				yPos[0] = 20;
			int appleX = 10;
			int appleY = 10;
			int applEatem = 0;
			bool zjadles;
			Random rand = new Random();
			Console.CursorVisible = false;
			bool isGameOn = true;
			bool isWallHit = false;
			decimal gameSpeed = 150m;
			//utworz snake

			//move a snake
			Console.SetCursorPosition(xPos[0], yPos[0]);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine((char)214);
			//build boundary
			setApple(rand, out appleX, out appleY);
			paintApple(appleX, appleY);

			buildWall();

			//sprawdz czy nie jebnal

			ConsoleKey command = Console.ReadKey().Key;
			do
			{ 

				switch (command)
				{
					case ConsoleKey.LeftArrow:
						Console.SetCursorPosition(xPos[0], yPos[0]);
						Console.Write(" ");
						xPos[0]--;
						break;
					case ConsoleKey.UpArrow:
						Console.SetCursorPosition(xPos[0], yPos[0]);
						Console.Write(" ");
						yPos[0]--;
						break;
					case ConsoleKey.RightArrow:
						Console.SetCursorPosition(xPos[0], yPos[0]);
						Console.Write(" ");
						xPos[0]++;
						break;
					case ConsoleKey.DownArrow:
						Console.SetCursorPosition(xPos[0], yPos[0]);
						Console.Write(" ");
						yPos[0]++;
						break;
					
					default:
						break;
				}

				//paint snake
				paintSnake(applEatem, xPos, yPos, out xPos, out yPos);
				

				isWallHit = DidSnakeHit(xPos[0], yPos[0]);
				if (isWallHit)
				{
					isGameOn = false;
					Console.SetCursorPosition(28, 20);
					Console.WriteLine("Snake Hit the wall. GAME OVER ");
				}

				zjadles = determineIfAppleEaten(xPos[0], yPos[0], appleX, appleY);
				if (zjadles)
				{
					setApple(rand, out appleX, out appleY);
					paintApple(appleX, appleY);
					applEatem++;
					gameSpeed *= .925m;
				}

				if (Console.KeyAvailable) 
				{
					command = Console.ReadKey().Key;
					
				}
				Thread.Sleep(Convert.ToInt32(gameSpeed));



				
			} while (isGameOn);


			// end vid1 

			// umiesc jedzenie - random
			
			// sprawdz czy zjadl
				// przyspiesz
				// zwieksz snake
				// sledz ile jablek
			// end vid 2
			// build welcome screen
			// give a player read to direction
			//show score

			//replay game
		}

		private static void paintSnake(int applEatem, int[] xPos1IN, int[] yPos1IN, out int[] xPos2OUT, out int[] yPos2OUT)
		{
			//paint head
			Console.SetCursorPosition(xPos1IN[0], yPos1IN[0]);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine((char)214);
			// body
			for (int i = 1; i < applEatem +1; i++)
			{
				Console.SetCursorPosition(xPos1IN[i], yPos1IN[i]);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("o");
			}
			//zwieksz ostatni part
			Console.SetCursorPosition(xPos1IN[applEatem+1], yPos1IN[applEatem+1]);
			Console.WriteLine(" ");
			//zarejestruj lokacje
			for (int i = applEatem+1; i >0; i--)
			{
				xPos1IN[i] = xPos1IN[i - 1];
				yPos1IN[i] = yPos1IN[i - 1];
			}
			//zwroc nowa tab
			xPos2OUT = xPos1IN;
			yPos2OUT = yPos1IN;
		}

		private static bool determineIfAppleEaten(int xPos, int yPos, int appleX, int appleY)
		{
			if (xPos == appleX && yPos == appleY)
			{
				return true;
			}
			return false;
		}

		private static void paintApple(int appleX, int appleY)
		{
			Console.SetCursorPosition(appleX, appleY);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("*");
		}

		private static void setApple(Random rand, out int appleX, out int appleY)
		{
			appleX = rand.Next(2, 70 );
			appleY = rand.Next( 2, 38);
		}

		private static bool DidSnakeHit(int xPos, int yPos)
		{
			if (xPos == 1 || xPos == 70 || yPos == 1 || yPos == 40)
			{
				return true;
			}
			return false;
		}
		private static void buildWall()
		{
			for (int i = 1; i < 41; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(1, i);
				Console.WriteLine("#");
				Console.SetCursorPosition(70, i);
				Console.WriteLine("#");
			}
			for (int i = 1; i < 71; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(i, 1);
				Console.WriteLine("#");
				Console.SetCursorPosition(i, 40);
				Console.WriteLine("#");
			}
		}
	}
}
