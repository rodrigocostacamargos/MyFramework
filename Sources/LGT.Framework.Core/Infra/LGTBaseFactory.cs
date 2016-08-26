using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using LGT.Framework.Core.Interfaces.Base;

namespace LGT.Framework.Core.Infra
{
    public abstract class LGTBaseFactory<T> : ILGTBaseFactory<T>
    {
        private static readonly Hashtable Hastable = new Hashtable();
        private static readonly object ObjectLock = new object();

        /// <summary>
        /// Cria uma instância o objeto definido como parâmetro
        /// </summary>
        /// <typeparam name="T1">Tipo do Objeto podendo ser uma classe ou uma interface</typeparam>
        /// <returns>Objecto criado</returns>
        public T1 GetInstance<T1>() where T1 : T
        {
            var typeKey = typeof(T1).Name;
            if (!Hastable.ContainsKey(typeKey))
            {
                lock (ObjectLock)
                {
                    if (!Hastable.ContainsKey(typeKey))
                    {
                        var currentObject = CreateInstance<T1>();
                        if (typeof(T1).IsInterface)
                        {
                            typeKey = currentObject.GetType().Name;
                            if (!Hastable.ContainsKey(typeKey))
                            {
                                Hastable.Add(typeKey, currentObject);
                            }
                        }
                    }
                }
            }
            return (T1)Hastable[typeKey];
        }

        private T1 CreateInstance<T1>()
        {
            var type = typeof(T1);
            Type concretType = null;
            if (type.IsInterface)
            {


                concretType = CurrentAssembyFromClassType.GetTypes()
                    .Where(m => m.IsClass && !m.IsAbstract
                                && m.GetInterfaces().Any(x => x.Name.ToUpper().Equals(type.Name.ToUpper()))).
                    FirstOrDefault();
                
            }

            return CreateInstance<T1>(concretType);

        }

        private Assembly _currentAssembyFromClassType;
        private Assembly CurrentAssembyFromClassType
        {
            get
            {
                if (_currentAssembyFromClassType == null)
                {
                    LoadDependeceAssembly();
                    _currentAssembyFromClassType = Assembly.LoadFrom(ConcrectObjectAssembly());
                }
                return _currentAssembyFromClassType;
            }
        }

        /// <summary>
        /// Método que é sobrescrito nas factorys concretas para carregar as dependencias necessárias
        /// </summary>
        protected abstract void LoadDependeceAssembly();
        /// <summary>
        /// Método virtual que deve ser sobrescrito na factory real que cria o objeto para 
        /// permitir que o objeto seja envolvido por um proxy transparente ou simplesmente devolve
        /// uma instancia do objeto
        /// </summary>
        /// <typeparam name="T1">Tipo do Objeto</typeparam>
        /// <returns>Objecto criado</returns>
        protected abstract T1 CreateInstance<T1>(Type concretType);

        /// <summary>
        /// Nome do assembly que contem as implemtanções dos objetos 
        /// que se deseja usar na factory, este assembly só será necessário se for informado 
        /// uma interface para o método GetInstantce
        /// </summary>
        /// <returns></returns>
        protected abstract string ConcrectObjectAssembly();

    }
}