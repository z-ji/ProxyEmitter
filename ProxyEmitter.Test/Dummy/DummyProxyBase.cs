using System;
using System.Diagnostics;
using System.Linq;
using Xunit.Abstractions;

namespace ProxyEmitter.Test.Dummy
{
    /// <summary>
    /// Dummy ProxyBase implementations for reference
    /// Nothing is implemented.
    /// </summary>
    public class DummyProxyBase : ProxyBase
    {
        #region ProxyBase

        protected override object Invoke(string @namespace, string methodName, object[] arguments)
        {
            CurrentNameSpace = @namespace;
            if (arguments != null)
                output.WriteLine("{0}({1})", methodName, string.Join(", ", arguments));
            else
                output.WriteLine("{0}()", methodName);
            switch (methodName)
            {
                case "Fn1":
                case "Fn3":
                    return null;
            }
            if (arguments == null)
                return 0;
            int sum = arguments.Cast<int>().Sum();
            return sum;
        }

        public string CurrentNameSpace { get; private set; }

        protected override TRet ConvertReturnValue<TRet>(object returnValue)
        {
            if (typeof(TRet) != typeof(int))
                return default(TRet);
            return (TRet)returnValue;
        }
        #endregion

        #region For Test

        private readonly ITestOutputHelper output;

        public DummyProxyBase(ITestOutputHelper output)
        {
            this.output = output;
        }
        #endregion
    }
}