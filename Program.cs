using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using System.IO;
using Snake_Janika;
using Snake_game;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			Sounds music = new Sounds();
			music.MainMusic();

			Walls walls = new Walls(120, 25);
			walls.Draw();
		
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(120, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			int xOffsetO4ki = 50;
			int yOffsetO4ki = 26;

			int o4ki = 0;
			WriteText("Баллы:"+o4ki, xOffsetO4ki, yOffsetO4ki);

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					music.EatSound();
					food = foodCreator.CreateFood();
					food.Draw();
					o4ki++;
					Console.SetCursorPosition(xOffsetO4ki, yOffsetO4ki);
					WriteText("Баллы:" + o4ki, xOffsetO4ki, yOffsetO4ki);

				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			music.GameOver();
			WriteGameOver(o4ki);
			Console.ReadLine();
		}

		static void WriteGameOver(int x)
		{
			int xOffset = 25;
			int yOffset = 9;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Введите своё имя:", xOffset + 2, yOffset++);
			yOffset++;
			StreamReader from_file = new StreamReader(@"C:\Users\Lenovo\Desktop\Snake\Users.txt", true);
			for (int i = 0; i <= 5; i++)
			{
				string text = from_file.ReadToEnd();
				Console.WriteLine(text);
				yOffset++;
			}
			from_file.Close();
			WriteText("Автор: Janika Valjataga", xOffset + 2, yOffset++);
			WriteText("Группа: TARpv19", xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);

			Console.SetCursorPosition(xOffset + 2, yOffset - 4);
			string NameU = Console.ReadLine();

			Save saveFiles = new Save();
			saveFiles.to_file(NameU, x);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
