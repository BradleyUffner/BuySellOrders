using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentOctal.WpfLib;

namespace BuySellOrders
{
    public class PriceEntryVm: ViewModel
    {
        public PriceEntryVm()
        {
            BuyOrders = new OrderList(this);
            SellOrders = new OrderList(this);
        }

        private Decimal _price;
        public Decimal Price
        {
            get {return _price;}
            set {SetValue(ref _price, value);}
        }

        public OrderList BuyOrders { get; }
        public OrderList SellOrders { get; }
    }
}
