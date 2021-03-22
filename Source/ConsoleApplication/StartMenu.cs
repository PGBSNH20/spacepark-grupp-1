using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class StartMenu
    {
       // public APIFetch Person =new APIFetch();

        public List<string> URLStringListToGetShipID = new List<string>();
        public List<int> starShipsIntList = new List<int>();
        public List<StarshipData> starshipsAvailable = new List<StarshipData>();
        

        // public List<PersonData> confirmedPeople = new List<PersonData>();

        public PersonData CPerson { get; set; }
        public StarshipData CStarship { get; set; }
        public int ConfirmedShipID { get; set; }
        public int CPersonID { get; set; }




        public void ValidateName(string name)
        {
           
            var x = APIFetch.GetPerson(name);
            
           
            if (x.Name == name)
            {
               
                Console.WriteLine("Welcome "+name);
                CPerson = x;
                CPersonID = GetPersonID(x.url);
                GetShipListByName(name);
                //ChooseShip();

            }           
        }

        public void  GetShipListByName(string name)
        {
           var x= APIFetch.GetPerson(name);

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

        public int GetPersonID(string input)
        {

            string toDidital = string.Empty;
            int val;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                    toDidital += input[i];
            }
            val = int.Parse(toDidital);
            

            return val;
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

        public void AddStarShipsToList()
        {

            for (int i = 0; i < starShipsIntList.Count; i++)
            {
               starshipsAvailable.Add(APIFetch.GetSpaceShip(starShipsIntList[i]));
            }

            ValidateShip();
        }


        public void ValidateShip()
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

            GetShipByIndex();
        }

        public void GetShipByIndex()
        {
           var x= APIFetch.GetSpaceShip(ConfirmedShipID);
            CStarship = x;
            Print();
        }



        public void Print()
        {
            Console.WriteLine("All details has been saved to DataBase Welcome in!");
            
                Console.WriteLine($"Name:{CPerson.Name}" /*Model:{item.Model}*/);
                



            Console.WriteLine($"ShipID:{CStarship.Name}" /*Model:{item.Model}*/);
            

        }

        public void AddToDataBase()
        {
            SpaceParkContext context = new SpaceParkContext();
            var ship = new StarshipData()
            {
                Name = CStarship.Name,
                StarshipID = ConfirmedShipID,
                Model = CStarship.Model
            };

            var person = new PersonDb()
            {
                PersonID = CPersonID,
                Name = CPerson.Name,
                StarshipID= ConfirmedShipID

            };
                context.Add(ship);
            context.Add(person);
            context.SaveChanges();


        }
    }
}
