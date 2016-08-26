using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Transactions;

namespace LGT.Framework.Core.Factorys.Base
{
    public abstract class LGTBaseRealProxy<T> : RealProxy
    {
        // Fields
        private readonly Type _type;

        // Methods
        protected LGTBaseRealProxy()
            : this(typeof(T))
        {
        }

        protected LGTBaseRealProxy(Type type)
            : base(type)
        {
            this._type = type;
        }

        protected virtual void AfterInvoke()
        {
        }

        protected virtual void BeforeInvoke()
        {
        }

        public T GetTransparentProxy()
        {
            return (T)base.GetTransparentProxy();
        }

        public override IMessage Invoke(IMessage myIMessage)
        {
            MarshalByRefObject obj2 = (MarshalByRefObject)Activator.CreateInstance(this._type);
            string uRI = RemotingServices.Marshal(obj2).URI;
            myIMessage.Properties["__Uri"] = uRI;
            Type type = obj2.GetType();
            IMethodCallMessage callMessage = (IMethodCallMessage)myIMessage;
            MethodInfo pMehotdInfo = type.GetMethods().Where<MethodInfo>(delegate(MethodInfo x)
                                                                             {
                                                                                 return x.ToString().Equals(callMessage.MethodBase.ToString());
                                                                             }).FirstOrDefault<MethodInfo>();
            if (pMehotdInfo == null)
            {
                this.MethodNotFound(callMessage.MethodName, type.ToString());
            }
            IMessage message = null;
            TransactionScope scope = null;
            bool flag = false;
            try
            {
                if (this.UsingTransaction)
                {
                    scope = new TransactionScope();
                }
                this.BeforeInvoke();
                if (this.ValidateCanInvoke(pMehotdInfo))
                {
                    message = ChannelServices.SyncDispatchMessage(myIMessage);
                }
                this.AfterInvoke();
            }
            catch
            {
                flag = true;
                throw;
            }
            finally
            {
                if (scope != null)
                {
                    if (!flag)
                    {
                        scope.Complete();
                    }
                    scope.Dispose();
                }
            }
            return message;
        }

        protected abstract void MethodNotFound(string pMethodName, string pRealObjectType);
        protected virtual void OnExceptionInoke(Exception e)
        {
        }

        protected virtual bool ValidateCanInvoke(MethodInfo pMehotdInfo)
        {
            return true;
        }


        protected virtual bool UsingTransaction
        {
            get
            {
                return Helper.LGTHelperConfiguraton.UsingTransactionScopeProxy;
            }
        }
    }
}

