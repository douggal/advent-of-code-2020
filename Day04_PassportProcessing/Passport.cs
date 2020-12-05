using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day04_PassportProcessing
{
    public class Passport
    {
        List<string> _validColorCodes = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

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

        // FIELD VALIDATORS

        public bool IsValidBirthYr()
        {
            bool result = false;
            if (_passportItems.ContainsKey("byr"))
            {
                var f = _passportItems["byr"];
                var r = new Regex(@"^([0-9]{4})$");
                // Console.WriteLine($"{f} : {r.Match(f).Success}");
                if (r.Match(f).Success)
                {
                    var n = int.Parse(f);
                    result = (n >= 1920 && n <= 2002);
                }

            }
            return result;
        }

        public bool IsValidIssueYr()
        {
            bool result = false;
            if (_passportItems.ContainsKey("iyr"))
            {
                var f = _passportItems["iyr"];
                var r = new Regex(@"^([0-9]{4})$");
                if (r.Match(f).Success)
                {
                    var n = int.Parse(f);
                    result = (n >= 2010 && n <= 2020);
                }

            }
            return result;
        }

        public bool IsValidExpirationYr()
        {
            bool result = false;
            if (_passportItems.ContainsKey("eyr"))
            {
                var f = _passportItems["eyr"];
                var r = new Regex(@"^([0-9]{4})$");
                if (r.Match(f).Success)
                {
                    var n = int.Parse(f);
                    result = (n >= 2020 && n <= 2030);
                }

            }
            return result;
        }

        public bool IsValidHeight()
        {
            bool result = false;
            if (_passportItems.ContainsKey("hgt"))
            {
                var f = _passportItems["hgt"];
                var r = new Regex(@"^([0-9]{2,3})(cm|in)$");
                if (r.Match(f).Success)
                {
                    var unit = f.Substring(f.Length - 2);
                    var n = int.Parse(f.Substring(0, f.Length - 2));
                    if (unit == "cm")
                    {
                        result = (n >= 150 && n <= 193);
                    }
                    else if (unit == "in")
                    {
                        result = (n >= 59 && n <= 76);
                    }
                }
            }
            return result;
        }

        public bool IsValidHairColor()
        {
            bool result = false;
            if (_passportItems.ContainsKey("hcl"))
            {
                var f = _passportItems["hcl"];
                var r = new Regex(@"^#([a-f0-9]{6})$");
                result = r.Match(f).Success;
            }
            return result;
        }

        public bool IsValidEyeColor()
        {
            bool result = false;
            if (_passportItems.ContainsKey("ecl"))
            {
                var f = _passportItems["ecl"];
                var r = new Regex(@"^([a-z]{3})$");
                result = r.Match(f).Success && _validColorCodes.Contains(f);
            }
            return result;
        }

        public bool IsValidPassportID()
        {
            bool result = false;
            if (_passportItems.ContainsKey("pid"))
            {
                var f = _passportItems["pid"];
                var r = new Regex(@"^([0-9]{9})$");
                result = r.Match(f).Success && f.Length == 9;
            }
            return result;
        }
        public bool IsValidCountryID()
        {
            return true;
        }
    }
}