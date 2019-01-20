using System;
using AlgoLearning;
using Xunit;
using Xunit.Abstractions;

namespace AlgoTests
{
    public class ArrayTests
    {
        private readonly Array<int> _sqList;
        private readonly ITestOutputHelper _output;

        public ArrayTests(ITestOutputHelper output)
        {
            _sqList = new Array<int>(10);
            _output = output;
        }

        private void PrintList()
        {
            for (int index = 0; index < _sqList.Length; index++)
            {
                var elem = _sqList.Find(index);
                _output.WriteLine(elem.ToString());
            }
        }

        [Fact]
        public void Length_Equal_0_When_List_Is_Empty()
        {
            Assert.True(_sqList.Length == 0);
        }

        [Fact]
        public void Length_Equals_1_After_InsertOneElement()
        {
            _sqList.Insert(1, 2);
            Assert.True(_sqList.Length == 1);
        }

        [Fact]
        public void Insert_ThrowIndexOutofRangeException_When_PositionGreaterThanLenghth()
        {
            _sqList.Insert(1, 1);
            var ex = Assert.Throws<IndexOutOfRangeException>(() => _sqList.Insert(3, 1));
            Assert.IsType<IndexOutOfRangeException>(ex);
        }

        [Fact]
        public void Insert_ThrowIndexOutofRangeException_When_IndexLessThanZero()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => _sqList.Insert(-1, 1));
            Assert.IsType<IndexOutOfRangeException>(ex);
        }

        [Fact]
        public void Insert_ThorowOutOfMemoryException_When_ListIsFull()
        {
            _sqList.Insert(0, 10);
            _sqList.Insert(1, 9);
            _sqList.Insert(2, 8);
            _sqList.Insert(3, 7);
            _sqList.Insert(4, 6);
            _sqList.Insert(5, 5);
            _sqList.Insert(6, 4);
            _sqList.Insert(7, 3);
            _sqList.Insert(8, 2);
            _sqList.Insert(9, 1);

            PrintList();

            Exception ex = Assert.Throws<OutOfMemoryException>(() => _sqList.Insert(10, 101));
        }

        [Fact]
        public void Delete_ThrowIndexOutofRangeException_When_IndexLessThanZero()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => _sqList.Delete(-1));
            Assert.IsType<IndexOutOfRangeException>(ex);
        }

        [Fact]
        public void Delete_ThrowIndexOutofRangeException_When_IndexGreaterThanLength()
        {

            _sqList.Insert(0, 10);
            _sqList.Insert(1, 20);

            var ex = Assert.Throws<IndexOutOfRangeException>(() => _sqList.Delete(3));
            Assert.IsType<IndexOutOfRangeException>(ex);
        }

        [Fact]
        public void Delete_Element_Success()
        {
            _sqList.Insert(0, 10);
            _sqList.Insert(1, 20);

            var result = _sqList.Delete(0);
            Assert.True(result);
            Assert.Equal(1, _sqList.Length);
            Assert.Equal(20, _sqList.Find(0));
        }

        [Fact]
        public void Delete_Move_Element()
        {
            _sqList.Insert(0, 10);
            _sqList.Insert(1, 20);
            _sqList.Insert(2, 30);

            Assert.True(_sqList.Delete(1));
            Assert.Equal(30, _sqList.Find(1));
        }

        [Fact]
        public void Clear_Success()
        {
            _sqList.Insert(0, 10);
            _sqList.Insert(1, 9);
            _sqList.Insert(2, 8);
            _sqList.Insert(3, 7);
            _sqList.Insert(4, 6);
            _sqList.Insert(5, 5);
            _sqList.Insert(6, 4);
            _sqList.Insert(7, 3);
            _sqList.Insert(8, 2);
            _sqList.Insert(9, 1);

            Assert.Equal(10, _sqList.Length);

            _sqList.Clear();

            Assert.Equal(0, _sqList.Length);
        }
    }
}