using sharptorrent.bencode;
using sharptorrent.bencode.value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bencode_test {

    public class Test {

        static void Main(string[] args) {
            string[] tests = {"4:spam", "0:", 
                                   "i3e", 
                                   "l4:spam4:eggse", "le", 
                                   "d3:cow3:moo4:spam4:eggse", "d4:spaml1:a1:bee", 
                                   "d9:publisher3:bob17:publisher-webpage15:www.example.com18:publisher.location4:homee", "de"};
            foreach(string code in tests){
                Bencode bencode = code;
                Console.WriteLine("Bencode: " + bencode.Code);
                foreach(BValue value in bencode.Values) {
                    Console.WriteLine("Type: " + value.Type);
                    Console.WriteLine("Value: " + value);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
