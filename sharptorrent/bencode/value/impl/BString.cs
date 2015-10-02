using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode.value.impl {

    public class BString : BValue {

        private string value;

        public BString(string value = null) : base(BType.String) {
            Value = value;
        }

        public string Value {
            get {
                return value;
            }
            set {
                this.value = value ?? "";
            }
        }

        public override bool Equals(object obj) {
            if(obj is String)
                return value.Equals(obj);
            else if(obj is BString)
                return value.Equals((obj as BString).value);
            else
                return false;
        }

        public override int GetHashCode() {
            return value.GetHashCode();
        }

        public override string ToString() {
            return value;
        }

        public static implicit operator BString(string value) {
            return new BString(value);
        }

    }
}
