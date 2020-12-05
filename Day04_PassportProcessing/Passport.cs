using System.Collections.Generic;

namespace Day04_PassportProcessing
{
    public class Passport
    {

        public Passport()
        {
            Complete = false;
            RequiredPassportFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };
            _passportItems = new Dictionary<string, string>();
        }

        private Dictionary<string, string> _passportItems;
        public Dictionary<string, string> PassportItems
        {
            // it's possible passport could have items other than 8 required fields
            get { return _passportItems; }
        }

        public List<string> RequiredPassportFields { get; set; }
        public bool Complete { get; set; }

        public bool IsComplete()
        {
            foreach (var f in RequiredPassportFields)
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