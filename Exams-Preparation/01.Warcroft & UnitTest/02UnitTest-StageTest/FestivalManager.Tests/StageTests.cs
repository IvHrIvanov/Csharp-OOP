// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void PlayMethodTest()
        {
            List<Performer> per = new List<Performer>();
            List<Song> songCount = new List<Song>();
            TimeSpan time = new TimeSpan(0, 1, 20);
            Performer performer = new Performer("Ivan", "Ivanov", 20);
            Song song = new Song("Gogit", time);
            Stage stage = new Stage();
            string fulName = performer.FullName;
            per.Add(performer);
            songCount.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("Gogit", fulName);
            string returnString = stage.Play();
            Assert.AreEqual(returnString, $"{per.Count} performers played {songCount.Count} songs");
        }
        [Test]
        public void CtorTestSong()
        {
            List<Song> song = new List<Song>();
            Stage stage = new Stage();
            TimeSpan time = new TimeSpan(0, 2, 20);
            Song songs = new Song("ivan", time);
            stage.AddSong(songs);
            song.Add(songs);
            Assert.AreEqual(songs, song[0]);
        }
        [Test]
        public void CtorTestPerformer()
        {
            List<Performer> performers = new List<Performer>();
            Stage stage = new Stage();

            Performer performer = new Performer("ivan", "Boko", 20);
            stage.AddPerformer(performer);
            performers.Add(performer);
            Assert.AreEqual(performer, performers[0]);
        }
        [Test]
        public void AddPerformerTestFail()
        {
            string name = "Ivan";
            string lastName = "Ivan";
            int age = 10;
            Performer performer = new Performer(name, lastName, age);
            Stage stage = new Stage();

            Assert.That(() =>
            {
                stage.AddPerformer(performer);
            }, Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));

        }
        [Test]
        public void AddPerformerTest()
        {
            string name = "Dragan";
            string lastName = "Ivan";
            int age = 20;
            Performer performer = new Performer(name, lastName, age);

            Stage stage = new Stage();
            List<Performer> list = new List<Performer>();
            list.Add(performer);
            stage.AddPerformer(performer);

            Assert.That(list[0], Is.EqualTo(performer));
        }
        [Test]
        [TestCase(null)]
        public void AddPerformExeption(Performer performer)
        {
            Stage stage = new Stage();

            Assert.That(() =>
            {
                stage.AddPerformer(performer);
            }, Throws.ArgumentNullException.With.Message.EqualTo("Can not be null!" + " " + $"(Parameter '{nameof(performer)}')"));

        }
        [Test]
        public void AddSongTest()
        {
            string name = "Joni";
            TimeSpan time = new TimeSpan(0, 0, 20);

            Song song = new Song(name, time);

            Stage stage = new Stage();


            Assert.That(() =>
        {
            stage.AddSong(song);
        }, Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
        }

        [Test]
        public void AddSongTestSuccesful()
        {
            string name = "Joni";
            TimeSpan time = new TimeSpan(0, 1, 20);

            Song song = new Song(name, time);
            List<Song> list = new List<Song>();
            Stage stage = new Stage();
            list.Add(song);
            stage.AddSong(song);
            Assert.AreEqual(list[0], song);

        }
        [Test]
        [TestCase(null)]
        public void AddSongNull(Song song)
        {
            Stage stage = new Stage();
            Assert.That(() =>
            {
                stage.AddSong(song);
            }, Throws.ArgumentNullException.With.Message.EqualTo($"Can not be null!" + " " + $"(Parameter '{nameof(song)}')"));

        }
        [Test]
        public void AddSongToPerformerTest()
        {
            TimeSpan time = new TimeSpan(0, 1, 20);
            Performer performer = new Performer("Ivan","Ivanov",20);
            Song song = new Song("Gogit",time);
            Stage stage = new Stage();
            string fulName = performer.FullName;
           
            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSongToPerformer("Gogit", fulName);
            Assert.AreEqual(performer.SongList.Count, 1);
        }
        [Test]
        public void AddSontFailPerformer()
        {
            TimeSpan time = new TimeSpan(0, 1, 20);
            Performer performer = new Performer("Ivan", "Ivanov", 20);
            Song song = new Song("Gogit", time);
            Stage stage = new Stage();
            string fulName = performer.FullName;

            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.That(() =>
            {
                stage.AddSongToPerformer("Gogit", "Ivan");

            }, Throws.ArgumentException.With.Message.EqualTo("There is no performer with this name."));


        }
        [Test]
        public void FailSongAddPerformer()
        {
            TimeSpan time = new TimeSpan(0, 1, 20);
            Performer performer = new Performer("Ivan", "Ivanov", 20);
            Song song = new Song("Goit", time);
            Stage stage = new Stage();
            string fulName = performer.FullName;

            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.That(() =>
            {
                stage.AddSongToPerformer("Gogit", fulName);

            }, Throws.ArgumentException.With.Message.EqualTo("There is no song with this name."));


        }
        [Test]
        public void AddSongToPerformerTestReturn()
        {
            TimeSpan time = new TimeSpan(0, 1, 20);
            Performer performer = new Performer("Ivan", "Ivanov", 20);
            Song song = new Song("Gogit", time);
            Stage stage = new Stage();
            string fulName = performer.FullName;

            stage.AddPerformer(performer);
            stage.AddSong(song);
            string retur = stage.AddSongToPerformer("Gogit", fulName);
            Assert.AreEqual(retur, $"{song} will be performed by {fulName}");
        }
    }
}