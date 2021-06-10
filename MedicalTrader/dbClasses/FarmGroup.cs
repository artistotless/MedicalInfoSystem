

namespace MedicalTrader
{
    class FarmGroup
    {
        public int id { get; set; }
        public string name { get; set; }

        public FarmGroup()
        {
        }

        public FarmGroup(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
