using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Tests.CustomLinkedListTests
{
    public class CustomLinkedListTest
    {
        private const string headFieldName = "head";
        private const string tailFieldName = "tail";

        private DynamicList<string> dynamicList;
        private Type type = typeof(DynamicList<string>);
        private FieldInfo[] fieldInfos = typeof(DynamicList<string>)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        [SetUp]
        public void SetUpListBeforeEachTest()
        {
            this.dynamicList = new DynamicList<string>();
        }

        [Test]
        public void GettingElementByIndex_ValidIndex_SouldPass()
        {
            var headField = FindFieldsViaReflection(headFieldName);

            var counter = fieldInfos.First(f => f.FieldType == typeof(int));

            headField.SetValue(this.dynamicList, new Node<string>("C#"));
            counter.SetValue(this.dynamicList, 1);

            Assert.That(this.dynamicList[0], Is.EqualTo("C#"));
        }

        [Test]
        public void SettingByIndex_InvalidIndex_ShouldThrow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList[1] = null, "Setting invalid indexer does Not throw exception!");
        }

        [Test]
        public void GettingByIndex_InvalidIndex_ShouldThrow()
        {
            var prop = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .First(p => p.PropertyType == typeof(string));

            Assert.Throws<ArgumentOutOfRangeException>(() => prop.SetValue(this.dynamicList[0], null), "Try Getting invalid index does Not throw Exception!");
        }

        [TestCase("C#")]
        public void AddOneValidElement_ShouldPass(string value)
        {
            this.dynamicList.Add(value);

            var headField = FindFieldsViaReflection(headFieldName);
            var tailField = FindFieldsViaReflection(tailFieldName);

            var headFieldValue = (Node<string>)headField.GetValue(this.dynamicList);
            var tailFieldValue = (Node<string>)tailField.GetValue(this.dynamicList);

            Assert.That(headFieldValue.Element, Is.EqualTo(value));
            Assert.That(headFieldValue.NextNode, Is.EqualTo(null));
            Assert.That(tailFieldValue.Element, Is.EqualTo(value));
            Assert.That(tailFieldValue.NextNode, Is.EqualTo(null));

            Assert.That(tailFieldValue, Is.EqualTo(headFieldValue));
        }

        [TestCase("C#")]
        public void AddMutltipleElements_ShouldPass(string value)
        {
            this.dynamicList.Add(value);
            this.dynamicList.Add(value + ".NET");

            var headField = FindFieldsViaReflection(headFieldName);
            var tailField = FindFieldsViaReflection(tailFieldName);

            var headFieldValue = (Node<string>)headField.GetValue(this.dynamicList);
            var tailFieldValue = (Node<string>)tailField.GetValue(this.dynamicList);

            Assert.That(headFieldValue.Element, Is.EqualTo(value));
            Assert.That(headFieldValue.NextNode, Is.EqualTo(tailFieldValue));
            Assert.That(tailFieldValue.Element, Is.EqualTo(value + ".NET"));
            Assert.That(tailFieldValue.NextNode, Is.EqualTo(null));

            this.dynamicList.Add(value + value);
            Assert.That(tailFieldValue.NextNode, Is.Not.EqualTo(null));
        }

        /*
         * REMOVE METHOD: 
         *      - remove item that exists should return integer = the index
         *      - try remove item that not exists should return -1
         *  
         *  REMOVEAT METHOD:
         *      - try pass invalid index should throw exception
         *      - passing valid index should return T element 
         *                   --- check fields values for head and tail  
         *  
         *  INDEXOF METHOD:
         */

        private FieldInfo FindFieldsViaReflection(string wantedField)
        {
            return fieldInfos
               .First(f => f.Name == wantedField &&
               f.FieldType == typeof(Node<string>));
        }
    }
}