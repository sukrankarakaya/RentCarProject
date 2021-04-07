using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card
            )
        {
            _cardDal.Add(card);
            return new SuccessResult("Kartınız kaydedildi.");

        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult("Kartınız silindi");
        }

        public IDataResult<List<Card>> GetAll()
        {
            _cardDal.GetAll();
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(),"Kartlar Listelendi.");
        }

        public IDataResult<Card> GetById(int Id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(p => p.CardId == Id));
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult("Kart Bilgileri Güncellendi.");
        }
    }
}
