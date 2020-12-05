using System.Collections.Generic;

namespace Day04_PassportProcessing
{
    public class Passportz
    {

        public Passportz()
        {
            Complete = false;
            PassportFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
            _passportItems = new Dictionary<string, string>();
        }

        private Dictionary<string, string> _passportItems;
        public Dictionary<string, string> PassportItems
        {
            get { return _passportItems; }
        }

        public List<string> PassportFields { get; set; }
        public bool Complete { get; set; }

        public bool IsComplete()
        {
            foreach (var f in PassportFields)
            {
                if (f == "")
                {
                    return false;
                }
            }
            return true;
        }

    }
}