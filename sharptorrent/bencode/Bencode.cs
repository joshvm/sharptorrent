using sharptorrent.bencode.value;
using sharptorrent.bencode.value.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharptorrent.bencode {

    public class Bencode {

        private readonly string code;
        private readonly List<BValue> values;

        private Bencode(string code, List<BValue> values) {
            this.code = code;
            this.values = values;
        }

        public string Code {
            get {
                return code;
            }
        }

        public List<BValue> Values {
            get {
                return values;
            }
        }

        public static implicit operator Bencode(string code) {
            return Decode(code);
        }

        public static Bencode Decode(string code) {
            List<BValue> values = new List<BValue>();
            int index = 0;
            while(index < code.Length) {
                BValue value = DecodeValue(code, ref index);
                if(value != null)
                    values.Add(value);
                index++;
            }
            return new Bencode(code, values);
        }

        public static BValue DecodeValue(string code, ref int index) {
            if(char.IsDigit(code[index]))
                return DecodeString(code, ref index);
            else if(code[index] == 'i')
                return DecodeNumber(code, ref index);
            else if(code[index] == 'l')
                return DecodeList(code, ref index);
            else if(code[index] == 'd')
                return DecodeDictionary(code, ref index);
            else
                return null;
        }

        public static BString DecodeString(string code, ref int index) {
            try {
                string lengthString = "";
                while(code[index] != ':')
                    lengthString += code[index++];
                index++;
                int length = int.Parse(lengthString);
                string value = "";
                for(int i = 0; i < length; i++)
                    value += code[index++];
                return new BString(value);
            } catch(Exception ex) {
                throw new MalformedBencodeException(code, ex);
            }
        }

        public static BNumber DecodeNumber(string code, ref int index) {
            try {
                index++;
                string valueStr = "";
                while(code[index] != 'e')
                    valueStr += code[index++];
                index++;
                long value = long.Parse(valueStr);
                return new BNumber(value);
            } catch(Exception ex) {
                throw new MalformedBencodeException(code, ex);
            }
        }

        public static BList DecodeList(string code, ref int index) {
            try {
                index++;
                List<BValue> values = new List<BValue>();
                while(code[index] != 'e') {
                    BValue value = DecodeValue(code, ref index);
                    if(value != null)
                        values.Add(value);
                    else
                        index++;
                }
                return new BList(values);
            } catch(Exception ex) {
                throw new MalformedBencodeException(code, ex);
            }
        }

        public static BDictionary DecodeDictionary(string code, ref int index) {
            try {
                index++;
                Dictionary<BValue, BValue> dictionary = new Dictionary<BValue, BValue>();
                while(code[index] != 'e') {
                    BValue key = DecodeValue(code, ref index);
                    if(key == null)
                        index++;
                    BValue value = DecodeValue(code, ref index);
                    if(value == null)
                        index++;
                    if(key != null && value != null)
                        dictionary.Add(key, value);
                }
                return new BDictionary(dictionary);
            } catch(Exception ex) {
                throw new MalformedBencodeException(code, ex);
            }
        }

    }
}
