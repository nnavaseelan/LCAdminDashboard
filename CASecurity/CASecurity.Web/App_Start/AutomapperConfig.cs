using CASecurity.Domain.Dtos;
using CASecurity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASecurity.Web
{
    public class AutomapperConfig : AutoMapper.Profile
    {
        public AutomapperConfig()
        {
            Configure();
        }        

        protected void Configure()
        {
            // IDataReader to Entity mappings
            CreateMap<AppModel, App>();//.ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.GetInt64(src.GetOrdinal("OwnerID"))));

            //AutoMapper.Mapper.CreateMap<IDataReader, VehicleDto>().ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.GetInt64(src.GetOrdinal("VehicleID"))));

            //AutoMapper.Mapper.CreateMap<IDataReader, VehicleDto>()
            //    .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.GetInt64(src.GetOrdinal("VehicleID"))))
            //    .ForMember(dest => dest.Owner,
            //   opts => opts.MapFrom(
            //       src => new OwnerDto
            //       {
            //           ID = src.GetInt64(src.GetOrdinal("OwnerID")),
            //           Location = src.GetString(src.GetOrdinal("Location")),
            //           OwnerName = src.GetString(src.GetOrdinal("OwnerName"))
            //       }));


            ////.ForMember(dest => dest.ID, pts => opts.MapFrom(src => src.VehicleID));
            //AutoMapper.Mapper.CreateMap<IDataReader, CustomerDto>().ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.GetInt64(src.GetOrdinal("CustomerID"))));
            //AutoMapper.Mapper.CreateMap<IDataReader, AuctionDto>().ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.GetInt64(src.GetOrdinal("AuctionID"))));

        }

        /// <summary>
        /// class for Integer Type Converter.
        /// </summary>
        //private class IntTypeConverter : TypeConverter<string, int>
        //{
        //    /// <summary>
        //    /// Converts the core.
        //    /// </summary>
        //    /// <param name="source">The source.</param>
        //    /// <returns>returns Integer</returns>
        //    protected override int ConvertCore(string source)
        //    {
        //        if (source == null)
        //        {
        //            throw new Exception("null string value cannot convert to non-nullable return type.");
        //        }
        //        else
        //        {
        //            return int.Parse(source);
        //        }
        //    }
        //}
    }
}