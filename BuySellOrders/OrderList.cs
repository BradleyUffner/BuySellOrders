using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentOctal.WpfLib;

namespace BuySellOrders
{
    public class OrderList : ObservableCollection<OrderVm>
    {
        public OrderList(PriceEntryVm priceEntry)
        {
            PriceEntry = priceEntry;
        }

        public PriceEntryVm PriceEntry { get; }

    }
}
