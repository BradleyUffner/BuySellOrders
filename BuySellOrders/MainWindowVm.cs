using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using AgentOctal.WpfLib;

namespace BuySellOrders
{
    class MainWindowVm : ViewModel
    {

        private DispatcherTimer _updateTimer;

        public MainWindowVm()
        {
            _rnd = new Random();

            Prices = new ObservableCollection<PriceEntryVm>();

            for (int i = 0; i < 8; i++)
            {
                var entry = new PriceEntryVm();
                Prices.Add(entry);
                entry.BuyOrders.CollectionChanged += OnOrderChanged;
                entry.SellOrders.CollectionChanged += OnOrderChanged;

                entry.Price = (decimal)110.91 + (decimal)i / 100;

                var numBuy = _rnd.Next(5);
                for (int orderIndex = 0; orderIndex < numBuy; orderIndex++)
                {
                    var order = new OrderVm();
                    order.Qty = _rnd.Next(70) + 5;
                    entry.BuyOrders.Add(order);
                }

                var numSell = _rnd.Next(5);
                for (int orderIOndex = 0; orderIOndex < numSell; orderIOndex++)
                {
                    var order = new OrderVm();
                    order.Qty = _rnd.Next(70) + 5;
                    entry.SellOrders.Add(order);
                }
            }

            _updateTimer = new DispatcherTimer();
            _updateTimer.Tick += OnUpdate;
            _updateTimer.Interval = TimeSpan.FromSeconds(0.01);
            _updateTimer.Start();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            var entryIndex = _rnd.Next(Prices.Count);
            var entry = Prices[entryIndex];

            OrderList list;
            list = _rnd.Next(2) == 1 ?
                       entry.BuyOrders :
                       entry.SellOrders;

            if (list.Any())
            {
                var order = list[_rnd.Next(list.Count)];
                order.Qty += _rnd.Next(0, 8) - 4;
            }
        }

        private void OnOrderChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var order = item as OrderVm;
                    if (order.Qty > LargestOrder)
                    {
                        LargestOrder = order.Qty;
                    }
                }
            }
        }

        private int _largestOrder;
        private Random _rnd;

        public int LargestOrder
        {
            get { return _largestOrder; }
            private set { SetValue(ref _largestOrder, value); }
        }


        public ObservableCollection<PriceEntryVm> Prices { get; }
    }
}
