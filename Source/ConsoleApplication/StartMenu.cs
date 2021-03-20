using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class StartMenu
    {
        public APIFetch Person =new APIFetch();

        public List<string> URLStringList = new List<string>();
        public List<int> starShipsIntList = new List<int>();
        public List<StarshipData> starshipsAvailable = new List<StarshipData>();
        public int ConfirmedShipID { get; set; }
        // public List<PersonData> confirmedPeople = new List<PersonData>();

        public PersonData CPerson { get; set; }
        public StarshipData CStarship { get; set; }
        




        public void ValidateName(string name)
        {
           
            var x = Person.GetPerson(name);
           
            if (x.Name == name)
            {
               
                Console.WriteLine("Welcome "+name);
                CPerson = x;
                GetShipListByName(name);
                //ChooseShip();

            }           
        }

        public void  GetShipListByName(string name)
        {
           var x=  Person.GetPerson(name);

            foreach (var item in x.Starships)
            {
                URLStringList.Add(item);
            }
            
            GetStarShipList();
        }

        public void GetStarShipList()
        {
            for (int i = 0; i < URLStringList.Count; i++)
            {
                GetID(URLStringList[i]);
            }

            AddStarShipsToList();
        }


        public List<int> GetID(string input)
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
               starshipsAvailable.Add( Person.GetSpaceShip(starShipsIntList[i]));
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
           var x= Person.GetSpaceShip(ConfirmedShipID);
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
            var data = new StarshipData()
            {
                Name = CStarship.Name,
                StarshipID= ConfirmedShipID,
                Model = CStarship.Model
            };
            context.Add(data);
            context.SaveChanges();


        }
    }
}
