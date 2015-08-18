using System.Linq;
using jsL.Models;

namespace jsL.Services
{
    public class CharacterService : ServiceBase<Character>
    {
        public void Update2(Character c)
        {
            Db.Characters.Attach(c);
            Db.SaveChanges();
        }
    }


//db.Users.Attach(updatedUser);
//var entry = db.Entry(updatedUser);
//entry.Property(e => e.Email).IsModified = true;
//// other changed properties
//db.SaveChanges();
}