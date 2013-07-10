using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CollectionUpdate
{
    public class Vm
    {
        private ObservableCollection<Dummy> _ints;
        public ObservableCollection<Dummy> Ints
        {
            get { return _ints ?? (_ints = new ObservableCollection<Dummy>()); }
        }
    }

    public class Dummy
    {
        public int Value { get; set; }
    }
}
