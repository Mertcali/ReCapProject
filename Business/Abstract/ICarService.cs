﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        //List<Car> GetById(int carId);
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetCarDetails();
    }
}
