namespace TheListLibrary
{
    public class Item
    {
        private string _name;                //encapsulation is applied
        private string _quantity;
        private bool _bought;
        private string _addedby;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public bool Bought
        {
            get { return _bought; }
            set { _bought = value; }
        }

        public string Addedby
        {
            get { return _addedby; }
            set { _addedby = value; }
        }
    }
}
