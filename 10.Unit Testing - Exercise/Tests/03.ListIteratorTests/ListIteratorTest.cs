using ListIteratorTask;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests.ListIteratorTests
{
    [TestFixture]
    public class ListIteratorTest
    {
        private const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

        private ListIterator<string> iterator;
        private Type type = typeof(ListIterator<string>);
    
        [TestCase(new object[] { "C#", "JS", "Java" })]
        [TestCase(new object[] { "Ebasi testovete" })]
        [TestCase(new object[] { "" })]
        [TestCase(new object[] { })]
        public void Constructor_InitializedWithValidCollection_ShouldPass(params string[] values)
        {
            Assert.DoesNotThrow(() => this.iterator = new ListIterator<string>(values));

            var field = GetCollectionFieldUsingReflection();
            var collection = (List<string>)field.GetValue(this.iterator);

            Assert.That(collection, Is.EquivalentTo(values), "Unmathing Collections!");
        }

        [TestCase("Pesho")]
        [TestCase("")]
        public void Constructor_InitializeWithValidParams_ShouldPass(string value)
        {
            Assert.DoesNotThrow(() => this.iterator = new ListIterator<string>(value));

            var field = GetCollectionFieldUsingReflection();
            var str = ((List<string>)field.GetValue(this.iterator))[0];

            Assert.That(str, Is.EquivalentTo(value), "Unmathing Collections!");
        }

        [Test]
        public void Constructor_TryInitializeWithInvalidCollection_ShoudThrow()
        {
            var values = new string[] { "C#", "Java", null };
            Assert.That(() => this.iterator = new ListIterator<string>(values), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_TryInitializeWithNull_ShoudThrow()
        {
            Assert.That(() => this.iterator = new ListIterator<string>(null), Throws.ArgumentNullException);
        }

        [TestCase(new object[] { "C#", "JS", "Java" })]
        public void HasNext_ShoudReturnTrue(params string[] values)
        {
            this.iterator = new ListIterator<string>();
            var field = GetCollectionFieldUsingReflection();
            field.SetValue(iterator, new List<string>(values));
            Assert.That(this.iterator.HasNext(), Is.True);
        }

        [TestCase("OneString")]
        [TestCase(new object[] { "C#", "JS", "Java" })]
        public void HasNext_ShouldReturnFalse(params string[] values)
        {
            this.iterator = new ListIterator<string>();
            var field = GetCollectionFieldUsingReflection();
            field.SetValue(iterator, new List<string>(values));

            var currentIndex = GetIndexFieldUsingReflection();

            currentIndex.SetValue(this.iterator, values.Length - 1);
            Assert.That(this.iterator.HasNext(), Is.False);
        }

        [TestCase("1", "2", "3", "4")]
        [TestCase(new object[] { "C#", "JS", "Java" })]
        public void Move_PassMoreThanOneString_SouldBeTrue(params string[] values)
        {
            this.iterator = new ListIterator<string>(values);
            var index = GetIndexFieldUsingReflection();

            Assert.That((int)index.GetValue(this.iterator), Is.EqualTo(0));
            Assert.That(this.iterator.Move, Is.True);
            Assert.That((int)index.GetValue(this.iterator), Is.EqualTo(1));
            Assert.That(this.iterator.Move, Is.True);
        }

        [TestCase("1")]
        [TestCase(new object[] { "C#", "JS", "Java" })]
        public void Move_PassOneString_SouldBeFalse(params string[] values)
        {
            this.iterator = new ListIterator<string>(values);
            this.iterator.Move();
            this.iterator.Move();
            Assert.That(this.iterator.Move, Is.False);
        }

        [TestCase(new object[] { "C#", "JS", "Java" })]
        public void Print_ValidCollection_ShouldReturnElement(params string[] values)
        {
            this.iterator = new ListIterator<string>(values);
            Assert.That(this.iterator.Print(), Is.EqualTo("C#"));
            this.iterator.Move();
            Assert.That(this.iterator.Print(), Is.EqualTo("JS"));
            this.iterator.Move();
            Assert.That(this.iterator.Print(), Is.EqualTo("Java"));
        }

        [Test]
        public void Print_OnEmptyCollection_ShouldThrow()
        {
            this.iterator = new ListIterator<string>();
            Assert.That(() => this.iterator.Print(), Throws.InvalidOperationException);
        }

        private FieldInfo GetCollectionFieldUsingReflection()
        {
            return type
                .GetFields(flags)
                .First(f => f.FieldType == typeof(List<string>));
        }

        private FieldInfo GetIndexFieldUsingReflection()
        {
            return type
                 .GetFields(flags)
                 .First(f => f.FieldType == typeof(int));
        }
    }
}