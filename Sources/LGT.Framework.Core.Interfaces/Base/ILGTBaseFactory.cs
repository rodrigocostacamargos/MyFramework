namespace LGT.Framework.Core.Interfaces.Base
{
    public interface ILGTBaseFactory<T>
    {
        TObjectType GetInstance<TObjectType>() where TObjectType : T;
    }
}