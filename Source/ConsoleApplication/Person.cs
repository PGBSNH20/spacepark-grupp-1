using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class Person
    {
        public int PersonID { get; set; }
        public string PersonName { get; set; }
        public int StarShipID { get; set; }
        public int PersonWallet { get; set; }
        public StarshipData StarShip { get; set; }


        private List<string> URLStringListToGetShipID = new List<string>();
        private List<int> starShipsIntList = new List<int>();
        private List<StarshipData> starshipsAvailable = new List<StarshipData>();
        private int ConfirmedShipID { get; set; }

        public Person(string name)
        {
            var x = APIFetch.GetPerson(name);

            if (name==x.Name)
            {
                Console.WriteLine("Welcome "+name);
                PersonName = name;
                PersonID = StartMenu.GetPersonID(x.url);
                GetShipListByName(name);
                foreach (var item in x.Starships)
                {
                    GetShipID(item);
                }
                StarShipID = ConfirmedShipID;
                StarShip = GetShipByIndex();
            }
           
            


        }

        public StarshipData GetShipByIndex()
        {
            var x = APIFetch.GetSpaceShip(ConfirmedShipID);
            return x;
        }
        public void GetShipListByName(string name)
        {
            var x = APIFetch.GetPerson(name);

            foreach (var item in x.Starships)
            {
                URLStringListToGetShipID.Add(item);
            }

            GetStarShipList();
        }
        public void GetStarShipList()
        {
            for (int i = 0; i < URLStringListToGetShipID.Count; i++)
            {
                GetShipID(URLStringListToGetShipID[i]);
            }

            AddStarShipsToList();
        }
        public void AddStarShipsToList()
        {

            for (int i = 0; i < starShipsIntList.Count; i++)
            {
                starshipsAvailable.Add(APIFetch.GetSpaceShip(starShipsIntList[i]));
            }

            ValidateShip();
        }
        public List<int> GetShipID(string input)
        {

            string toDidital = string.Empty;
            int val;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                    toDidital += input[i];
            }
            val = int.Parse(toDidital);
            starShipsIntList.Add(val);

            return starShipsIntList;
        }
        public int ValidateShip()
        {

            Console.WriteLine("Choose a shipID to park?");

            for (int i = 0; i < starshipsAvailable.Count; i++)
            {
                Console.WriteLine("ID:" + starShipsIntList[i] + "--" + "(" + starshipsAvailable[i].Name + ")");

            }

            int ID = int.Parse(Console.ReadLine());

            for (int i = 0; i < starshipsAvailable.Count; i++)
            {
                if (ID == starShipsIntList[i])
                {
                    ConfirmedShipID = ID;
                }

            }

          //  GetShipByIndex();
            return ConfirmedShipID;
        }
        public void Print()
        {
            Console.WriteLine("All details has been saved to DataBase Welcome in!");
            Console.WriteLine($"PersonID:{PersonID}" /*Model:{item.Model}*/);
            Console.WriteLine($"PersonName:{PersonName}" /*Model:{item.Model}*/);
            Console.WriteLine($"StarShipID:{StarShipID}" /*Model:{item.Model}*/);
            Console.WriteLine($"StarShipID:{StarShip.Name}" /*Model:{item.Model}*/);







        }



    }
}
