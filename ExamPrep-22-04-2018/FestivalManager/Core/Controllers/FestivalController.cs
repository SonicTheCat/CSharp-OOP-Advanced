namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;
        private ISongFactory songFactory; 

		private readonly IStage stage;

		public FestivalController(IStage stage)
		{
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.songFactory = new SongFactory(); 
		}

		public string ProduceReport()
		{
            StringBuilder result = new StringBuilder(); 

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            if (totalFestivalLength.Hours >=1)
            {
                result.AppendLine($"Festival length: {totalFestivalLength.TotalMinutes}:{totalFestivalLength:ss}");
            }
            else
            {
                result.AppendLine($"Festival length: {totalFestivalLength:mm\\:ss}");
            }
			

			foreach (var set in this.stage.Sets)
			{
                if (set.ActualDuration.Hours >= 1)
                {
                    result.AppendLine($"--{set.Name} ({set.ActualDuration.TotalMinutes}:{set.ActualDuration:ss}):");
                }
                else
                {
                    result.AppendLine($"--{set.Name} ({set.ActualDuration:mm\\:ss}):");
                }
				
				var performersOrderedDescendingByAge = set
                    .Performers
                    .OrderByDescending(p => p.Age);

				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string
                        .Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result.AppendLine($"---{performer.Name} ({instruments})");
				}

				if (!set.Songs.Any())
					result.AppendLine("--No songs played");
				else
				{
                    result.AppendLine("--Songs played:");
					foreach (var song in set.Songs)
                    {
						result.AppendLine($"----{song.Name} ({song.Duration:mm\\:ss})");
					}
				}
			}

			return result.ToString().Trim();
		}

		public string RegisterSet(string[] args)
		{
            var name = args[0];
            var type = args[1];

            var set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instruments = args.Skip(2).ToArray();

			var instances = instruments
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instance in instances)
			{
				performer.AddInstrument(instance);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            var name = args[0];
            var duration = TimeSpan.Parse("00:" + args[1]);

            var song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

			return $"Registered song {song.ToString()}";
		}

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (this.stage.HasSet(setName) == false)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (this.stage.HasSong(songName) == false)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var song = this.stage.GetSong(songName);
            var set = this.stage.GetSet(setName);
            set.AddSong(song);

            return $"Added {song.ToString()} to {setName}";
        }

		public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}