using System;

namespace lab5
{
    public class MusicService : IMusicService
    {
        public void DownloadSong(string songName)
        {
            Console.WriteLine($"Песня «{songName}» скачана.");
        }
    }
}