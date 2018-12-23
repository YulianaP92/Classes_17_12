using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Player
    {
        private const int minVolume = 0;
        private const int maxVolume = 300;
        private int _volume;
        public bool Locked;
        //public bool Playing;
        private bool playing;

        //B5-Player3/10. Method.
        //B5-Player4/10. Properties
        public bool Playing
        {
            get { return playing; }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value < minVolume)
                {
                    _volume = minVolume;
                }
                if (value > maxVolume)
                {
                    _volume = maxVolume;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public Song[] Song;

        public void VolumeUp()
        {
            Volume++;
            Console.WriteLine("Increase volume by one");
        }
        public void VolumeDown()
        {
            Volume--;
            Console.WriteLine("Decrease volume by one");
        }
        public void VolumeChange(int step)
        {
            Volume += step;
            Console.WriteLine($"To change the volume on: {step}");
        }

        public void Lock()
        {
            Locked = true;
            Console.WriteLine("Player is locked");
        }
        public void Unlock()
        {
            Locked = false;
            Console.WriteLine("Player is unlocked");
        }

        //методы Stop() и Start() закомментированы, т.к. поле  playing св-вa Playing защищено от записи
        //public bool Stop()
        //{
        //    if (!Locked)
        //    {
        //        Playing = false;
        //        Console.WriteLine("Player is stopped");
        //    }
        //    else
        //        Console.WriteLine("Player is locked");
        //    return Playing;
        //}
        //public bool Start()
        //{
        //    if (!Locked)
        //    {
        //        Playing = true;
        //        Console.WriteLine("Player is playing");
        //    }
        //    else
        //        Console.WriteLine("Player is locked");
        //    return Playing;
        //}

        //B5-Player8/10. ParamsParameters
        public void ParamsParameters(params Song[] songs)
        {
            foreach (var i in songs)
            {
                Console.WriteLine($"Name Artist: {i.Artist.Name}");
                Console.WriteLine($"Name song: {i.Name}");
            }
            Console.WriteLine();
        }
    }
}
