using System;

namespace lab5
{
    public class MusicServiceProxy : IMusicService
    {
        private readonly IMusicService musicService;
        private readonly bool hasSubscription;

        public MusicServiceProxy(
            IMusicService musicService,
            bool hasSubscription)
        {
            this.musicService = musicService;
            this.hasSubscription = hasSubscription;
        }

        public void DownloadSong(string songName)
        {
            if (hasSubscription)
            {
                musicService.DownloadSong(songName);
            }
            else
            {
                Console.WriteLine(
                    $"Нельзя скачать «{songName}»: нужна подписка.");
            }
        }
    }
}