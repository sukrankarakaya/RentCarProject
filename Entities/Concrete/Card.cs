using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int CardId { get; set; }
        public string NameSurname { get; set; }
        public int CardNo { get; set; }
        public string ExpirationDate { get; set; }
        public int Cvc { get; set; }
    }
}
