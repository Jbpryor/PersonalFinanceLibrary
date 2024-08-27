using P_Finance.UI.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Finance.UI.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly ModalNavStore _navStore;

        public CloseModalCommand(ModalNavStore navStore)
        {
            _navStore = navStore;
        }

        public override void Execute(object? parameter)
        {
            _navStore.CloseModal();
        }
    }
}
