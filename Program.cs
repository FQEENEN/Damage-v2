using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damage
{
    class Program
    {
        static long DamageDegree = 1000;
        static long DamageWave = 1000;
        static bool ExitProgram = false;
        static bool RandomDamage = false;
        static void Main(string[] args)
        {
            Console.WriteLine(@" ______          _        ____    ____        _          ______    ________           _____   ");
            Console.WriteLine(@"|_   _ `.       / \      |_   \  /   _|      / \       .' ___  |  |_   __  |         / ___ `. ");
            Console.WriteLine(@"     | | `. \     / _ \       |   \/   |       / _ \     / .'   \_|    | |_ \_|  _   __|_/___) | ");
            Console.WriteLine(@"  | |  | |    / ___ \      | |\  /| |      / ___ \    | |   ____    |  _| _  [ \ [  ].'____.' ");
            Console.WriteLine(@"    _| |_.' /  _/ /   \ \_   _| |_\/_| |_   _/ /   \ \_  \ `.___]  |  _| |__/ |  \ \/ // /_____  ");
            Console.WriteLine(@"|______.'  |____| |____| |_____||_____| |____| |____|  `._____.'  |________|   \__/ |_______| ");
            Console.WriteLine("/*Damage v2 by Slacksoft(Mr.Yang)*/");
            while (!ExitProgram)
            {
                Console.Write("Input file path:");
                byte[] Old_File_Byte = File.ReadAllBytes(Console.ReadLine());
                Console.WriteLine("Length:" + Old_File_Byte.Length.ToString());
                Console.Write("Input \"y\" to damage file:");
                if (Console.ReadLine() == "y")
                {
                    Console.Write("Input damage degree(long):");
                    DamageDegree = long.Parse(Console.ReadLine());
                    Console.Write("Input damage wave(long):");
                    DamageWave = long.Parse(Console.ReadLine());
                    Console.Write("Random damage?(y)");
                    if (Console.ReadLine() == "y") { RandomDamage = true; }
                    byte[] New_File_Byte = new byte[Old_File_Byte.Length];
                    long wait = 0;
                    long effect = DamageDegree;
                    for (int i = 0; i != Old_File_Byte.Length; i++)
                    {
                        if (wait != DamageWave)
                        {
                            New_File_Byte[i] = Old_File_Byte[i];
                            wait++;
                        }
                        else
                        {
                            if (effect != 0)
                            {
                                if (RandomDamage)
                                {
                                    Random random = new Random();
                                    New_File_Byte[i] = (byte)(Old_File_Byte[i] + random.Next(-280, 270));

                                }
                                else
                                {
                                    New_File_Byte[i] = 0;
                                }
                                effect--;
                            }
                            else
                            {
                                New_File_Byte[i] = Old_File_Byte[i];
                                wait = 0;
                                effect = DamageDegree;
                            }
                        }
                    }
                    Console.Write("Input new file path:");
                    File.WriteAllBytes(Console.ReadLine(), New_File_Byte);

                }
                Console.Write("Again?(n)");
                if (Console.ReadLine() == "n") { ExitProgram = true; }
            }
            Console.Write("See you again...");
            Console.ReadKey();
        }
    }
}
