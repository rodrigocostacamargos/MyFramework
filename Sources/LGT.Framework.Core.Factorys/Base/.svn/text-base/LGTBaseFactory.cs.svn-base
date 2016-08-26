using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using LGT.Framework.Core.Interfaces.Base;

namespace LGT.Framework.Core.Factorys.Base
{
    public abstract class LGTBaseFactory<T> : ILGTBaseFactory<T>
    {
        // Fields
        private Assembly _currentAssembyFromClassType;
        private static readonly Hashtable Hastable;
        private static readonly object ObjectLock;

        // Methods
        static LGTBaseFactory()
        {

            Hastable = new Hashtable();
            ObjectLock = new object();
        }

        protected abstract string ConcrectObjectAssemblyName();
        private T1 CreateInstance<T1>()
        {
            Func<Type, bool> predicate = null;
            T1 local = default(T1);
            var type = typeof(T1);
            Type concretType = null;
            try
            {
                if (type.IsInterface)
                {

                    predicate = delegate(Type m)
                                    {
                                        return (m.IsClass && !m.IsAbstract) && m.GetInterfaces().Any(x => x.Name.ToUpper().Equals(type.Name.ToString().ToUpper()));
                                    };

                    concretType = this.CurrentAssembyFromClassType.GetTypes().Where(predicate).FirstOrDefault();
                }


                if (type.IsInterface && (concretType == null))
                {
                    this.NotFindConcretTypeForInterface(type.Name, this.ConcrectObjectAssemblyName());
                }
                else
                {
                    local = (T1)this.CreateInstance<T1>(concretType);
                }
            }
            catch (ReflectionTypeLoadException exception)
            {
                var builder = new StringBuilder();
                foreach (var exception2 in exception.LoaderExceptions)
                {
                    builder.AppendLine(exception2.Message);
                }
                throw new Exception(builder.ToString());
            }
            return local;
        }

        protected virtual T1 CreateInstance<T1>(Type concretType)
        {
            T1 objectReturn;
            if (concretType != null)
                objectReturn = (T1)Activator.CreateInstance(concretType);
            else
                objectReturn = Activator.CreateInstance<T1>();
            return objectReturn;
        }

        public T1 GetInstance<T1>() where T1 : T
        {
            var name = typeof(T1).Name;
            if (!Hastable.ContainsKey(name))
            {
                lock (ObjectLock)
                {
                    if (!Hastable.ContainsKey(name))
                    {
                        var local = this.CreateInstance<T1>();
                        if (typeof(T1).IsInterface)
                        {
                            name = local.GetType().Name;
                            if (!Hastable.ContainsKey(name))
                            {
                                Hastable.Add(name, local);
                            }
                        }
                    }
                }
            }
            return (T1)LGTBaseFactory<T>.Hastable[name];

            //var name = typeof(T1).Name;
            //if (CallContext.GetData(name) == null)
            //{
            //    lock (ObjectLock)
            //    {
            //        if (CallContext.GetData(name) == null)
            //        {
            //            var local = this.CreateInstance<T1>();
            //            if (typeof(T1).IsInterface)
            //            {
            //                name = local.GetType().Name;
            //                if (CallContext.GetData(name) == null)
            //                {
            //                    CallContext.SetData(name, local);

            //                }
            //            }
            //        }
            //    }
            //}
            //return (T1)CallContext.GetData(name);
        }

        protected abstract void LoadDependeceAssembly();
        protected abstract void NotFindConcretTypeForInterface(string pInterfaceName, string pAssemblyName);

        // Properties
        private Assembly CurrentAssembyFromClassType
        {
            get
            {
                if (this._currentAssembyFromClassType == null)
                {
                    this.LoadDependeceAssembly();
                    this._currentAssembyFromClassType = Assembly.LoadFrom(this.ConcrectObjectAssemblyName());
                }
                return this._currentAssembyFromClassType;
            }
        }
    }
}

