using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode.value.impl {

    public class BDictionary : BValue {

        private Dictionary<BValue, BValue> dictionary;

        public BDictionary(Dictionary<BValue, BValue> dictionary = null) : base(BType.Dictionary) {
            Dictionary = dictionary;
        }

        public void Add(BValue key, BValue value) {
            dictionary.Add(key, value);
        }

        public Dictionary<BValue, BValue> Dictionary {
            get {
                return dictionary;
            }
            set {
                dictionary = value ?? new Dictionary<BValue, BValue>();
            }
        }

        public override bool Equals(object obj) {
            if(obj is Dictionary<BValue, BValue>)
                return dictionary.Equals(obj);
            else if(obj is BDictionary)
                return dictionary.Equals((obj as BDictionary).dictionary);
            else
                return false;
        }

        public override int GetHashCode() {
            return dictionary.GetHashCode();
        }

        public override string ToString() {
            return "Dictionary[" + string.Join(", ", dictionary) + "]";
        }

        public static implicit operator BDictionary(Dictionary<BValue, BValue> dictionary) {
            return new BDictionary(dictionary);
        }

    }
}
