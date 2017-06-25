using System;
using ProxyEmitter.Test.Dummy;
using Xunit;
using Xunit.Abstractions;

namespace ProxyEmitter.Test
{
    public class EmitterTest
    {
        private readonly ITestOutputHelper output;
        public EmitterTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestEmit()
        {
            var service = ProxyEmitter.CreateProxy<DummyProxyBase, IDummyService>(output);
            service.Fn1();
            var @base = service as DummyProxyBase;
            Assert.Equal("CatX", @base.CurrentNameSpace);
            service.Fn3(0, 0);
            Assert.Equal("CatX", @base.CurrentNameSpace);
            Assert.Equal(0, service.Fn2());
            Assert.Equal("CatX", @base.CurrentNameSpace);
            Assert.Equal(3, service.Fn4(1, 2));
            Assert.Equal("CatX", @base.CurrentNameSpace);
            Assert.Equal(10, service.Fn5(1, 2, 3, 4));
            Assert.Equal("CatX", @base.CurrentNameSpace);
        }
    }
}
