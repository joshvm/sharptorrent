using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode.value.impl {

    public class BList : BValue {

        private List<BValue> list;

        public BList(List<BValue> list = null) : base(BType.List) {
            List = list;
        }

        public void Add(params BValue[] values) {
            list.AddRange(values);
        }

        public List<BValue> List {
            get {
                return list;
            }
            set {
                list = value ?? new List<BValue>();
            }
        }

        public override bool Equals(object obj) {
            if(obj is List<BValue>)
                return list.Equals(obj);
            else if(obj is BList)
                return list.Equals((obj as BList).list);
            else
                return false;
        }

        public override int GetHashCode() {
            return list.GetHashCode();
        }

        public override string ToString() {
            return "List[" + string.Join(", ", list) + "]";
        }

        public static implicit operator BList(List<BValue> list) {
            return new BList(list);
        }

    }
}
