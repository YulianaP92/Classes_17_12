using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-B5-Player3/10. Method
//-B5-Player4/10. Properties

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            //player.Start();
            //player.Song = GetSongData();
            //TraceInfo(player);
            player.Volume = 500;
            Console.WriteLine($"Volume: {player.Volume}");
            player.VolumeUp();
            Console.WriteLine($"Volume: {player.Volume}");
            player.VolumeChange(-6);
            Console.WriteLine($"Volume:{player.Volume}");
            player.VolumeChange(300);
            Console.WriteLine($"Volume:{player.Volume}");
            player.Volume = -25;
            Console.WriteLine($"Volume:{player.Volume}");
            player.Lock();
            player.Unlock();
            //player.Stop();

            //B5-Player6/10. MethodParameters
            var song = CreateDefaultSong();
            var song_2 = CreateNamedSong("Show must go on");
            var artist = new Artist("Queen", "Rock");
            var album = new Album()
            {
                Name = "Bohemian Rhapsody",
                Year = 1975
            };
            var song_3 = CreateSong(100, "We will Rock you", artist, album);
            player.Song = new[] { song, song_2, song_3 };
            TraceInfo(player);

            //B5-Player7/10. OutRefParameters
            Song[] songs = new Song[5];
            Artist[] artists = new Artist[5];
            Album[] albums = new Album[5];

            int theShortestSong = 0;
            int theLongestSong = 100000;

            int duDuration = GetSongsDuration(songs, artists, albums, ref theShortestSong, ref theLongestSong);
            Console.WriteLine($"the total length of the songs: {duDuration}");
            Console.WriteLine($"the Shortest Song Duration:{theShortestSong}");
            Console.WriteLine($"the Shortest Song Duration:{theLongestSong}");

            //B5-Player8/10. ParamsParameters
            player.ParamsParameters(song);
            player.ParamsParameters(song, song_2);
            player.ParamsParameters(songs);

            //B5-Player9/10. MethodOverloading.
            var songs_1 = CreateSongs();
            var songs_2 = CreateSongs("Show must go on");
            var songs_3 = CreateSongs(100, "We will Rock you", artist, album);
            player.Song = new[] { songs_1, songs_2, songs_3 };
            TraceInfo(player);

            //B5-Player10/10. DefaultAndNamedParamters.
            var artist_ = AddArtist();
            var artist_2 = AddArtist("Metallica");
            var album_ = AddAlbum();
            var album_2 = AddAlbum("Metall");
            AddAlbum(year: 1975, name: "Bohemian Rhapsody");
            Console.ReadLine();
        }

        //public static Song[] GetSongData()
        //{
        //    var artist = new Artist();
        //    //var artist_1 = new Artist("Slipknot");
        //    var album = new Album();
        //    var song = new Song()
        //    {
        //        Duration = 100,
        //        Name = "New song",
        //        Album = album,
        //        Artist = artist
        //    };
        //    artist.Name = "Slipknot";
        //    artist.Genre = "Rock";
        //    album.Name = "New Album";
        //    album.Year = 2018;

        //    return new Song[] { song };
        //}

        public static void TraceInfo(Player player)
        {
            foreach (var i in player.Song)
            {
                Console.WriteLine($"Name Artist: {i.Artist.Name}");
                Console.WriteLine($"Name song: {i.Name}");
                Console.WriteLine($"Genre: {i.Artist.Genre}");
                Console.WriteLine($"Album: {i.Album.Name}");
                Console.WriteLine($"Year of album release: {i.Album.Year}");
                Console.WriteLine($"Duration song: {i.Duration} second\n");
            }
            Console.WriteLine($"Number of songs in player:{player.Song.Length}");
        }

        //B5-Player6/10. MethodParameters
        public static Song CreateDefaultSong()
        {
            var artist = new Artist("Queen", "Rock");
            var album = new Album();
            album.Name = "Bohemian Rhapsody";
            album.Year = 1975;
            var song = new Song()
            {
                Album = album,
                Duration = 100,
                Name = "I want to break free",
                Artist = artist
            };

            return song;
        }

        public static Song CreateNamedSong(string name)
        {
            var song = CreateDefaultSong();
            song.Name = name;

            return song;
        }

        public static Song CreateSong(int duration, string name, Artist artist, Album album)
        {
            var song = CreateNamedSong(name);
            song.Duration = duration;
            song.Artist = artist;
            song.Album = album;

            return song;
        }

        //B5-Player7/10. OutRefParameters

        public static int GetSongsDuration(Song[] songs, Artist[] artist, Album[] album, ref int theShortestSong, ref int theLongestSong)
        {
            Artist artist_1 = new Artist("Queen", "Rock");
            Artist artist_2 = new Artist("Marilyn Manson", "Rock");
            Artist artist_3 = new Artist("Maroon 5", "Rock");
            Artist artist_4 = new Artist("Nirvana", "Rock");
            Artist artist_5 = new Artist("Green Day", "Rock");

            artist[0] = artist_1;
            artist[1] = artist_2;
            artist[2] = artist_3;
            artist[3] = artist_4;
            artist[4] = artist_5;

            Album album_1 = new Album("Queen II", 1974);
            Album album_2 = new Album("Sweet Dreams", 2000);
            Album album_3 = new Album("Makes Me Wonder", 2008);
            Album album_4 = new Album("Nevermind", 1991);
            Album album_5 = new Album("Greatest", 2017);

            album[0] = album_1;
            album[1] = album_2;
            album[2] = album_3;
            album[3] = album_4;
            album[4] = album_5;

            songs[0] = CreateSong(120, "I want to break free", artist[0], album[0]);
            songs[1] = CreateSong(130, "Bowling for Columbine", artist[1], album[1]);
            songs[2] = CreateSong(200, "Makes Me Wonder", artist[2], album[2]);
            songs[3] = CreateSong(240, "Flash Gordon", artist[3], album[3]);
            songs[4] = CreateSong(300, "Windowpane", artist[4], album[4]);

            int durationSongs = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                durationSongs += songs[i].Duration;
            }
            string nameTheShortestSong = null;
            string nameTheLongestSong = null;
            theShortestSong = songs[0].Duration;
            theLongestSong = songs[0].Duration;
            for (int i = 0; i < songs.Length; i++)
            {
                if (theShortestSong > songs[i].Duration)
                {
                    theShortestSong = songs[i].Duration;
                    nameTheShortestSong = songs[i].Name;
                }
                else nameTheShortestSong = songs[0].Name;
            }
            for (int i = 0; i < songs.Length; i++)
            {
                if (theLongestSong < songs[i].Duration)
                {
                    theLongestSong = songs[i].Duration;
                    nameTheLongestSong = songs[i].Name;
                }
                else nameTheLongestSong = songs[0].Name;

            }
            Console.WriteLine($"the Shortest Song: {nameTheShortestSong}");
            Console.WriteLine($"the Longest Song: {nameTheLongestSong}");
            return durationSongs;
        }

        //B5-Player9/10. MethodOverloading.
        public static Song CreateSongs()
        {
            var artist = new Artist("Queen", "Rock");
            var album = new Album();
            album.Name = "Bohemian Rhapsody";
            album.Year = 1975;
            var song = new Song()
            {
                Album = album,
                Duration = 100,
                Name = "I want to break free",
                Artist = artist
            };

            return song;
        }

        public static Song CreateSongs(string name)
        {
            var song = CreateSongs();
            song.Name = name;

            return song;
        }

        public static Song CreateSongs(int duration, string name, Artist artist, Album album)
        {
            var song = CreateSongs(name);
            song.Duration = duration;
            song.Artist = artist;
            song.Album = album;

            return song;
        }

        //B5-Player10/10. DefaultAndNamedParamters.
        public static Artist AddArtist(string name = "Unknown Artist")
        {
            var artist = new Artist(name);
            Console.WriteLine(artist.Name);
            return artist;
        }

        public static Album AddAlbum(string name = "Unknown Album", int year = default(int))
        {
            var album = new Album(name, year);
            Console.WriteLine($"{album.Name} - {album.Year}");
            return album;
        }
    }
}
