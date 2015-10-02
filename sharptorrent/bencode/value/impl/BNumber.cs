using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode.value.impl {

    public class BNumber : BValue {

        private long value;

        public BNumber(long value = 0) : base(BType.Number) {
            Value = value;
        }

        public long Value {
            get {
                return value;
            }
            set {
                this.value = value;
            }
        }

        public override bool Equals(object obj) {
            if(obj is long)
                return value.Equals(obj);
            else if(obj is BNumber)
                return value.Equals((obj as BNumber).value);
            else
                return false;
        }

        public override int GetHashCode() {
            return value.GetHashCode();
        }

        public override string ToString() {
            return value.ToString();
        }

        public static implicit operator BNumber(long value) {
            return new BNumber(value);
        }

    }
}
