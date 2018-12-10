using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab08Lib;
using System.IO;

namespace Lab14
{
    class MainCode
    {
        static List<Sub> subs;
        static void PrintSubs()
        {
            foreach (Sub sub in subs)
            {
                Console.WriteLine(sub.Info().Replace('і', 'i'));
            }
            Console.WriteLine(); }
        static void Main(string[] args)
        {
            subs = new List<Sub>();
            FileStream fs = new FileStream("TEST.subs", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            try
            {
                Sub sub;
                
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    sub = new Sub();
                    for (int i = 1; i <= 8; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                sub.Name = reader.ReadString();
                                break;

                            case 2:
                                sub.SecondName = reader.ReadString();
                                break;

                            case 3:
                                sub.PhoneNum = reader.ReadString();
                                break;

                            case 4:
                                sub.Country = reader.ReadString();
                                break;

                            case 5:
                                sub.Cost = reader.ReadInt32();
                                break;

                            case 6:
                                sub.HasCost = reader.ReadBoolean();
                                break;
                        }
                    }
                    subs.Add(sub);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: {0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }
            Console.WriteLine("    Не отсортированый список: {0}", subs.Count);
            PrintSubs();
            subs.Sort();
            Console.WriteLine("    Отсортированый список: {0}", subs.Count);
            PrintSubs();
            Console.WriteLine("    Добавляем нового абонента: Гриша");
            Sub subNikita = new Sub("Гриша", "Чумачук", "(095)092-3292", "Украина", 175, true);
            subs.Add(subNikita);
            subs.Sort();
            Console.WriteLine("    Список абонентов: {0}", subs.Count);
            PrintSubs();
            Console.WriteLine("    Удаляем последнего абонента:");
            subs.RemoveAt(subs.Count - 1);
            Console.WriteLine("    Обновленный список: {0}", subs.Count);
            PrintSubs();
            Console.ReadKey();

        }
    }
 }


