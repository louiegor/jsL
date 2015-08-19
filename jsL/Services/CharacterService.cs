using System;
using System.Linq;
using jsL.Context;
using jsL.Models;

namespace jsL.Services
{
    public class CharacterService : ServiceBase<Character>
    {
        public CharacterService(OpContext db) : base(db)
        {
            
        }
    }
    
}