using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Paradox_Simulation
{
    internal class SetVisualizer
    {
        private class RoomState
        {
            internal bool isPrize;
            internal bool isChosen;
            internal bool isOpen;
        }
        private RoomState[] rooms = new RoomState[3];


        public SetVisualizer(Set set, bool[] openRooms, int choice)
        {            
            for (int i = 0; i < 3; i++)
            {
                rooms[i] = new RoomState();
                if (i==set.WinningNum) rooms[i].isPrize = true;
                if (openRooms[i]) rooms[i].isOpen = true;
                if (i==choice) rooms[i].isChosen = true;
            }
        }

        public void PrintSet ()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                if (rooms[i].isChosen) Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("\t");
                Console.Write(GetRoomContent(i, rooms[i].isOpen, rooms[i].isPrize));                
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        private string GetRoomContent (int number,bool isOpen, bool isPrize)
        {
            StringBuilder sb = new StringBuilder ();
            sb.Append("[");
            if (isOpen)
            {
                if (isPrize)
                    sb.Append("$");
                else
                    sb.Append("0");
            }
            else
                sb.Append (number+1);
            sb.Append (']');
            return sb.ToString ();
        }


    }
}
