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
            var missingFields = false;  // flag false if any required fields are missing
            var result = false;
            var count = 0;  // count of required fields found in this passport

            foreach (var f in RequiredPassportFields)
            {
                if (!_passportItems.ContainsKey(f) || _passportItems[f] == "")
                {
                    missingFields = true;
                }
                else
                {
                    count += 1;
                }
            }

            // if this passport contains all the required fields then it is complete:  return true
            if (!missingFields && count == RequiredPassportFields.Count)
            {
                result = true;
            }

            // hack:  if the only missing field (missing or empty string) is country code "cid" then call it complete: return true
            if (!_passportItems.ContainsKey("cid") && count == RequiredPassportFields.Count - 1)
            // || (count == RequiredPassportFields.Count
            //    && !missingFields
            //    && string.IsNullOrWhiteSpace(_passportItems["cid"])))
            {
                result = true;
            }

            return result;
        }

    }
}