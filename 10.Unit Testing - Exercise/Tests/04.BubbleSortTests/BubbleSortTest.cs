using NUnit.Framework;
using BubbleSortTest;

namespace Tests.BubbleSortTests
{
    [TestFixture]
    public class BubbleSortTest
    {
        private Bubble bubble;

        [SetUp]
        public void SetUpBubbleObjectBeforeEachTest()
        {
            this.bubble = new Bubble();
        }

        [Test]
        public void TestSoritingWithPositiveNumbers()
        {
            int[] collection = new int[] { 1000, 101, 0, 10 };
            int[] expectedCollection = new int[] { 0, 10, 101, 1000 };

            this.bubble.SortCollection(collection);
            Assert.That(collection, Is.EquivalentTo(expectedCollection));
        }

        [Test]
        public void TestSortingWithNegativeNumbers()
        {
            int[] collection = new int[] { -1000, 20, -101, -0, -10, 0 };
            int[] expectedCollection = new int[] { -1000, -101, -10, -0, 0, 20 };

            this.bubble.SortCollection(collection);
            Assert.That(collection, Is.EquivalentTo(expectedCollection));
        }

        [Test]
        public void TestSortingEqualIntegers()
        {
            int[] collection = new int[] { 1, 1, 2, 1, 3, 4, 1, 1, -1, 1 };
            int[] expectedCollection = new int[] { -1, 1, 1, 1, 1, 1, 1, 2, 3, 4 };

            this.bubble.SortCollection(collection);
            Assert.That(collection, Is.EquivalentTo(expectedCollection));
        }

        [Test]
        public void TestPassingEmptyCollection()
        {
            int[] collection = new int[] { };
            int[] expectedCollection = new int[] { };

            this.bubble.SortCollection(collection);
            Assert.That(collection, Is.EquivalentTo(expectedCollection));
        }

        [Test]
        public void TestPassingOneElement()
        {
            int[] collection = new int[] { 0 };
            int[] expectedCollection = new int[] { 0 };

            this.bubble.SortCollection(collection);
            Assert.That(collection, Is.EquivalentTo(expectedCollection));
        }

        [Test]
        public void TestPassingIntegerMaxAndMinValues()
        {
            int[] collection = new int[] { int.MaxValue, int.MinValue, 0 };
            int[] expectedCollection = new int[] { int.MinValue, 0, int.MaxValue };

            this.bubble.SortCollection(collection);
            Assert.That(collection, Is.EquivalentTo(expectedCollection));
        }
    }
}