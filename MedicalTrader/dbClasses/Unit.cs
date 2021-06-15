

namespace MedicalTrader
{
   public  class Unit
    {
        public int id { get; set; }
        public string name { get; set; }

        public Unit(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Unit()
        {
        }
    }
}
