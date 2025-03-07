namespace obl_opg_1_PROG_TEK_Lasse
{
    public class Trophy
    {
        private string competition;
        private int year;

        public int Id { get; set; }

        public string Competition
        {
            get => competition;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Competition cannot be null");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Competition must be over 3 characters");
                }
                competition = value;
            }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 1970)
                {
                    throw new ArgumentOutOfRangeException("Year must be 1970 or later");
                }
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException($"Year cannot be later than {DateTime.Now.Year}");
                }
                year = value;
            }
        }


        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";

        }

    }
}
