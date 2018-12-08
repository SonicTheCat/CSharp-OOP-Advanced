namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        //// да си вкарват през полетата бе
        //public readonly List<ISet> Sets;
        //public readonly List<ISong> Songs;
        //public readonly List<IPerformer> Performers;

        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>(); 
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer); 
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song); 
        }

        public IPerformer GetPerformer(string name)
        {
            var performer = this.performers.FirstOrDefault(x => x.Name == name);

            if (performer == null)
            {
                throw new ArgumentException();
            }

            return performer;
        }

        public ISet GetSet(string name)
        {
            var set = this.sets.FirstOrDefault(x => x.Name == name);

            if (set == null)
            {
                throw new ArgumentException();
            }

            return set;
        }

        public ISong GetSong(string name)
        {
            var song = this.songs.FirstOrDefault(x => x.Name == name);

            if (song == null)
            {
                throw new ArgumentException();
            }

            return song;
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(x => x.Name == name); 
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(x => x.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.songs.Any(x => x.Name == name);
        }
    }
}
