using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void GetThrowsExceptionWhenNoImplementationFound()
        {
            var container = new Container();
            Assert.Throws<InvalidOperationException>(() => container.Get<IContainerTestInterface>());
        }

        [Fact]
        public void BindThrowsExceptionWhenInterfaceTypeIsNull()
        {
            var container = new Container();
            Assert.Throws<ArgumentNullException>(() => container.Bind(null, typeof(ContainerTestClass)));
        }

        [Fact]
        public void BindThrowsExceptionWhenImplementationTypeIsNull()
        {
            var container = new Container();
            Assert.Throws<ArgumentNullException>(() => container.Bind(typeof(IContainerTestInterface), null));
        }

        [Fact]
        public void BindThrowsExceptionWhenImplementationTypeDoesNotImplementInterfaceType()
        {
            var container = new Container();
            Assert.Throws<ArgumentException>(() => container.Bind(typeof(IContainerTestInterface), typeof(object)));
        }
    }
}