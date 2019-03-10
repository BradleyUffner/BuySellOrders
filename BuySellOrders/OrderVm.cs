using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentOctal.WpfLib;

namespace BuySellOrders
{
    public class OrderVm : ViewModel
    {
        private int _qty;
        public int Qty
        {
            get { return _qty; }
            set { SetValue(ref _qty, value); }
        }

    }
}
