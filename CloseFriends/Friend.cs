using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseFriends
{
    class Friend
    {
        public int X;
        public int Y;
        public int indexEuclideanDistance;

        public Friend[] closeFriends = new Friend[3];

        public Friend(int count)
        {
            indexEuclideanDistance = count;
        }

        public Friend(int x, int y, int count)
        {
            X = x;
            Y = y;
            indexEuclideanDistance = count;

            closeFriends[0] = new Friend(count);
            closeFriends[1] = new Friend(count);
            closeFriends[2] = new Friend(count);
        }
    }
}
