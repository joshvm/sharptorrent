using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode.value {

    public class BValue {

        public enum BType {
            String,
            Number,
            List,
            Dictionary
        }

        private readonly BType type;

        protected BValue(BType type) {
            this.type = type;
        }

        public BType Type {
            get {
                return type;
            }
        }

    }
}
