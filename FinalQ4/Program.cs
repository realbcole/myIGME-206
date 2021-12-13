using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalQ4
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = Data.GetInstance();
            data.playername = "dschuh";
            data.level = 4;
            data.hp = 99;
            string[] inventory = { "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball", "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder" };
            data.inventory = inventory;
            data.license_key = "DFGU99-1454";


            string output = data.Save();

            Console.WriteLine(output);

            data = (Data)data.Load(output);

            

        }
    }

    public sealed class Data
    {
        
        public string playername;
        public int level;
        public int hp;
        public string[] inventory;
        public string license_key;

        public string Save()
        {
            return JsonConvert.SerializeObject(this);
        }

        public object Load(string s)
        {
           return JsonConvert.DeserializeObject<Data>(s);
        }

        private Data()
        {

        }

        private static Data instance;

        public static Data GetInstance()
        {
            if (instance == null)
            {
                instance = new Data();
            }
            return instance;
        }
    }
}
