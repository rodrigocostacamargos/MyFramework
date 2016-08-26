
using LGT.Framework.Core.Interfaces.ControllerView;

namespace LGT.Framework.Core.ControllerView
{
    public class LGTBaseController<T> : ILGTBaseController where T : ILGTBaseView
    {
        protected T CurrentView { get; private set; }
        public LGTBaseController(T view)
        {
            this.CurrentView = view;
        }

    }
}
