using System;
using System.Collections.Generic;

namespace lab4
{
    // Элемент плейлиста
    public class Track
    {
        public string Title { get; }

        public int DurationSeconds { get; }

        public Track(string title, int durationSeconds)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Нужно указать название трека.", nameof(title));
            }

            if (durationSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(durationSeconds), "Длительность должна быть положительной.");
            }

            Title = title;
            DurationSeconds = durationSeconds;
        }

        public override string ToString()
        {
            int minutes = DurationSeconds / 60;
            int seconds = DurationSeconds % 60;

            return $"{Title} ({minutes}:{seconds:D2})";
        }
    }

    public interface IIterator<T>
    {
        bool HasNext();

        T Next();
    }

    public class Playlist
    {
        private readonly List<Track> tracks =
            new List<Track>();

        public void Add(Track track)
        {
            ArgumentNullException.ThrowIfNull(track);

            tracks.Add(track);
        }

        public IIterator<Track> CreateForwardIterator()
        {
            return new ForwardIterator(tracks);
        }

        public IIterator<Track> CreateReverseIterator()
        {
            return new ReverseIterator(tracks);
        }

        // Прямой обход
        private class ForwardIterator : IIterator<Track>
        {
            private readonly List<Track> snapshot;

            private int position;

            public ForwardIterator(List<Track> tracks)
            {
                snapshot = new List<Track>(tracks);

                position = 0;
            }

            public bool HasNext()
            {
                return position < snapshot.Count;
            }

            public Track Next()
            {
                if (!HasNext())
                {
                    throw new InvalidOperationException("Треки в этом обходе закончились.");
                }

                Track track = snapshot[position];

                position++;

                return track;
            }
        }

        // Обратный обход
        private class ReverseIterator : IIterator<Track>
        {
            private readonly List<Track> snapshot;

            private int position;

            public ReverseIterator(List<Track> tracks)
            {
                snapshot = new List<Track>(tracks);

                position = snapshot.Count - 1;
            }

            public bool HasNext()
            {
                return position >= 0;
            }

            public Track Next()
            {
                if (!HasNext())
                {
                    throw new InvalidOperationException("Треки в этом обходе закончились.");
                }

                Track track = snapshot[position];

                position--;

                return track;
            }
        }
    }
}

