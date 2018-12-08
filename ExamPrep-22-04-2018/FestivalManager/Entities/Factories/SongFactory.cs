namespace FestivalManager.Entities.Factories
{
	using System;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
            //var model = Assembly
            //    .GetCallingAssembly()
            //    .GetType("FestivalManager.Entities.Song");

            //if (model == null)
            //{
            //    throw new ArgumentException("Song Type Does Not Exist!");
            //}

            //return (ISong)Activator.CreateInstance(model, new object[] { name, duration });

            var song = new Song(name, duration);
			return song;
		}
	}
}