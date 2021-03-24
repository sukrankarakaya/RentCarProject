using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            CarImage newCarImage = CreatedFile(file, carImage);
            var result = BusinessRules.Run(CheckIfCarImageExceded(carImage));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(newCarImage);

            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(IFormFile file, CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarImageId == carImage.CarImageId);
            if (result == null)
            {
                return new ErrorResult("Arabanın resmi yok.");
            }
            FileHelper.Delete(carImage.ImagePath);
            DateTime Date = DateTime.Now;
            _carImageDal.Delete(carImage);
            return new SuccessResult("Resim silindi.");
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }

        private IResult CheckIfCarImageExceded(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult("Fotoğraf ekleme sınırını aştşnız. Arabanın 5 adet fotoğrafı var.");
            }
            return new SuccessResult();

        }
        private List<CarImage> CheckIfCarImageNull(int carImageId)
        {
            string image = @"/wwroot/images/Logo.jpg";
            var result = _carImageDal.GetAll(c => c.CarImageId == carImageId);
            if (result == null)
            {
                return new List<CarImage> { new CarImage { CarId = carImageId, ImagePath = image, Date = DateTime.Now, CarImageId = carImageId } };
            }

            return _carImageDal.GetAll(c => c.CarImageId == carImageId);

        }

        private CarImage CreatedFile(IFormFile file, CarImage carImage)
        {
            var newImagePath = FileHelper.Add(file).Message;
            var time = DateTime.Now;

            return new CarImage
            {
                CarId = carImage.CarId,
                Date = time,
                ImagePath = newImagePath
            };


        }
        private IResult CheckIfCarImageIdIsNotExists(int carImageId)
        {
            var result = _carImageDal.Get(c => c.CarImageId == carImageId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarImageIsNotExists);
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, CarImageId = 0, ImagePath = "/images/Logo.jpg" });

            return new SuccessDataResult<List<CarImage>>(images);
        }
    }   
}