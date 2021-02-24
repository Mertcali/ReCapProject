﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult Add(Car car)
        {

            
            if(car.CarName.Length<2 && car.DailyPrice<0)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarsAdded);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            
            return new SuccessResult("Ürün Silindi");
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if(DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);         
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId), "marka seçimine göre listelendi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), "renk seçimine göre listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),"Araç detayları:");
        }

        public IResult Update(Car car)
        {
             _carDal.Update(car);
            return new SuccessResult(Messages.CarsUpdated);
        }
    }
}
