using System;
using BitHelp.Core.Validation.pt_BR.Extends;
using BitHelp.Core.Validation.pt_BR.Test.Resources;
using Xunit;

namespace BitHelp.Core.Validation.Test.ExtendsTest
{
    public class CpfIsValidExtTest
    {
        readonly ValidationNotification _notification = new ValidationNotification();

        [Theory]
        [InlineData(null)]
        [InlineData("190.896.074-47")]
        [InlineData("19089607447")]
        public void Check_value_is_valid(object value)
        {
            var single = new SingleValues
            {
                Object = value
            };

            _notification.Clear();
            _notification.CpfIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("190.896.074-00")]
        [InlineData("19089607400")]
        [InlineData("190 896 074 00")]
        [InlineData("")]
        public void Check_value_not_is_valid(object value)
        {
            var single = new SingleValues
            {
                Object = value
            };

            _notification.Clear();
            _notification.CpfIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.Object);
            Assert.False(single.IsValid());
        }

        [Theory]
        [InlineData("190.896.074-47", "19089607447")]
        public void Check_value_array_is_valid(params object[] value)
        {
            var single = new ArrayValues
            {
                Object = value
            };

            _notification.Clear();
            _notification.CpfIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.Object);
            Assert.True(single.IsValid());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("abc")]
        [InlineData("", 123)]
        [InlineData("abc", 123)]
        [InlineData(null, 123)]
        public void Check_value_array_not_is_valid(params object[] value)
        {
            var single = new ArrayValues
            {
                Object = value
            };

            _notification.Clear();
            _notification.CpfIsValid(single.Object);
            Assert.False(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.Object);
            Assert.False(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.Object);
            Assert.False(single.IsValid());
        }

        [Fact]
        public void Check_empty_array_is_valid()
        {
            var single = new ArrayValues
            {
                Object = Array.Empty<object>()
            };

            _notification.Clear();
            _notification.CpfIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.Object);
            Assert.True(single.IsValid());
        }

        [Fact]
        public void Check_null_array_is_valid()
        {
            var single = new ArrayValues
            {
                Object = null
            };

            _notification.Clear();
            _notification.CpfIsValid(single.Object);
            Assert.True(_notification.IsValid());

            _notification.Clear();
            _notification.CpfIsValid(single, x => x.Object);
            Assert.True(_notification.IsValid());

            single.Notifications.Clear();
            single.CpfIsValid(x => x.Object);
            Assert.True(single.IsValid());
        }
    }
}