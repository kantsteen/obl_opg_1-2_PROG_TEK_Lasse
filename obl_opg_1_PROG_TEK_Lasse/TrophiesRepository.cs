using obl_opg_1_PROG_TEK_Lasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obl_opg_1_2_PROG_TEK_Lasse
{
    public class TrophiesRepository
    {
        private List<Trophy> _trophies = new List<Trophy>();
        private int _nextId;

        public List<Trophy> GetTrophies()
        {
            return new List<Trophy>(_trophies);
        }

        public List<Trophy> GetTrophies(int? year)
        {
            return new List<Trophy>(_trophies.FindAll(t => t.Year == year));
        }

        public List<Trophy> GetTrophiesSortedByYear(bool ascending = true)
        {
            if (ascending)
            {
                return new List<Trophy>(_trophies.OrderBy(t => t.Year).ToList());
            }
            else
            {
                return new List<Trophy>(_trophies.OrderByDescending(t => t.Year).ToList());
            }
        }

        public List<Trophy> GetTrophiesSortedByComp(bool ascending = true)
        {
            if (ascending /*== true*/)
            {
                return new List<Trophy>(_trophies.OrderBy(t => t.Competition).ToList());
            }
            else
            {
                return new List<Trophy>(_trophies.OrderByDescending(t => t.Competition).ToList());
            }
        }

        public Trophy GetById(int id)
        {
            // Returnerer Trophy objektet med det angivne id - eller null.

            Trophy? foundTrophy = _trophies.Find(t => t.Id == id);

            if (foundTrophy == null)
            {
                return null;

                //throw new ArgumentNullException("Trophy not found");
            }
            else
            {
                return foundTrophy;
            }

        }


        public Trophy Add(Trophy trophy)
        {
            // Tilføj id til trophy objektet. Tilføjer trophy til listen. Returnerer Trophy objektet
            int nextId = _nextId++;
            trophy.Id = nextId;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy Remove(int id)
        {
            // Sletter Trophy objektet med det angivne id. Returnerer Trophy objektet - eller null.

            // Find trophy with id 1
            // Delete trophy with id 1
            // If id doesnt exist, return null

            Trophy? trophy = _trophies.Find(t => t.Id == id);
            if (trophy == null)
            {
                return null;

                //throw new ArgumentNullException("Trophy not found");
            }
            else
            {
                _trophies.Remove(trophy);
                return trophy;
            }
        }

        public Trophy Update(int id, Trophy values)
        {
            // Trophy objektet med det angivne id opdateres med values.
            // Returnerer det opdaterede Trophy objekt - eller null.

            Trophy? trophy = _trophies.Find(t => t.Id == id);
            if (trophy == null)
            {
                return null;

                //throw new ArgumentNullException($"Trophy with id: {id} is null");
            }
            else
            {
                trophy.Id = values.Id;
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;

                return trophy;
            }
        }
    }
}
