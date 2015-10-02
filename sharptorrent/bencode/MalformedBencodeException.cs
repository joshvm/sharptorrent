using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode {

    public class MalformedBencodeException : Exception {

        public MalformedBencodeException(string bencode, Exception cause) : base(bencode, cause) {
        }

    }
}
