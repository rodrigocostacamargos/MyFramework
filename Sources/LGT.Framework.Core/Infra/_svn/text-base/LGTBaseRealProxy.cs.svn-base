using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Transactions;

namespace LGT.Framework.Core.Infra
{
    public class LGTBaseRealProxy<T> : RealProxy
    {
        private readonly object _realObject;

        public LGTBaseRealProxy()
            : this(typeof(T))
        {

        }

        public LGTBaseRealProxy(Type type)
            : base(type)
        {
            _realObject = Activator.CreateInstance(type);
        }

        public new T GetTransparentProxy()
        {
            return (T)base.GetTransparentProxy();
        }


        protected virtual void BeforeInvoke()
        {
        }

        protected virtual void AfterInvoke()
        {
        }

        protected virtual void OnExceptionInoke(Exception e)
        {
        }


        protected virtual bool ValidateCanInvoke(MethodInfo pMehotdInfo)
        {
            return true;
        }

        public override IMessage Invoke(IMessage msg)
        {
            var callMessage = (IMethodCallMessage)msg;
            var paramTypes = GetTypes(callMessage.Args);
            var methodInfo = _realObject.GetType().GetMethod(callMessage.MethodName, paramTypes);

            object returnObject = null;
            try
            {
                using (var ts = new TransactionScope())
                {
                    BeforeInvoke();
                    if (ValidateCanInvoke(methodInfo))
                        returnObject = methodInfo.Invoke(_realObject, callMessage.Args);
                    AfterInvoke();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                OnExceptionInoke(e);
                throw;
            }

            var returnMessage = new ReturnMessage(returnObject, null, 0, callMessage.LogicalCallContext, callMessage);
            return returnMessage;
        }

        private static Type[] GetTypes(IList<object> parameters)
        {
            var types = new Type[parameters.Count];
            for (var i = 0; i < parameters.Count; i++)
            {
                types[i] = parameters[i].GetType();
            }

            return types;
        }
    }
}