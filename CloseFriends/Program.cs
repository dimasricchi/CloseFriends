using System;
using System.Collections.Generic;
using System.Drawing;


namespace CloseFriends
{
    class Program
    {
        private const int COUNT = 9;

        static void Main(string[] args)
        {
            Friend [] friends = new Friend[COUNT];

            Random random = new Random();

            for(int i = 0; i < COUNT; i++)
            {
                friends[i] = new Friend(random.Next()%100, random.Next()%100, COUNT);
            }

            try
            {
                for (int i = 0; i < COUNT; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int current = int.MaxValue;
                        int index_k = COUNT;

                        for (int k = 0; k < COUNT; k++)
                        {
                            if (i != k && k != friends[i].closeFriends[0].indexEuclideanDistance
                                && k != friends[i].closeFriends[1].indexEuclideanDistance
                                && k != friends[i].closeFriends[2].indexEuclideanDistance)
                            {
                                int euclideanDistance = (int)(Math.Sqrt(Math.Pow(friends[i].X - friends[k].X, 2) + Math.Pow(friends[i].Y - friends[k].Y, 2)));

                                if (euclideanDistance < current)
                                {
                                    current = euclideanDistance;
                                    index_k = k;
                                }
                            }
                        }
                        if (index_k < COUNT)
                        {
                            friends[i].closeFriends[j].X = friends[index_k].X;
                            friends[i].closeFriends[j].Y = friends[index_k].Y;
                            friends[i].closeFriends[j].indexEuclideanDistance = index_k;
                        }
                    }
                }
                for (int i = 0; i < COUNT; i++)
                {
                    Console.WriteLine(string.Format("[{0},{1}] - [{2},{3}] [{4},{5}] [{6},{7}]",
                        friends[i].X, friends[i].Y,
                        friends[i].closeFriends[0].X, friends[i].closeFriends[0].Y,
                        friends[i].closeFriends[1].X, friends[i].closeFriends[1].Y,
                        friends[i].closeFriends[2].X, friends[i].closeFriends[2].Y));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}
