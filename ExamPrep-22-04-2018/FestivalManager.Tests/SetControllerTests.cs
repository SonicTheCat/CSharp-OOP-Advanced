namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController controller;

        [SetUp]
        public void InitializeBeforeEacheTest()
        {
            this.stage = new Stage();
            this.controller = new SetController(this.stage);
        }

        [Test]
        public void AddPerformer_WithoutInstrumunet_SouldNotPerform()
        {
            ISet set = new Short("Seta");
            IPerformer performer = new Performer("Hasan", 12);
            ISong song = new Song("", new System.TimeSpan(00, 01, 20));

            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddSet(set);

            var expected = "1. Seta:\r\n-- Did not perform";
            var actual = this.controller.PerformSets();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddPerformer_WithInstrument_ShouldPerform()
        {
            ISet set = new Short("Seta");
            IPerformer performer = new Performer("Jay-Z", 15);
            IInstrument instrument = new Microphone();
            ISong song = new Song("...", new System.TimeSpan(00, 01, 20));

            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddSet(set);

            var expected = "1. Seta:\r\n-- 1. ... (01:20)\r\n-- Set Successful";
            var actual = this.controller.PerformSets();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CheckInstrument_AfterPerformance_ShouldBeWornDown()
        {
            ISet set = new Short("Seta");
            IPerformer performer = new Performer("Jay-Z", 15);
            IInstrument instrument = new Drums();
            ISong song = new Song("Vijda mu se kraq", new System.TimeSpan(00, 01, 20));

            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddSet(set);
            this.controller.PerformSets();

            var expected = 80;
            var actual = instrument.Wear;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}