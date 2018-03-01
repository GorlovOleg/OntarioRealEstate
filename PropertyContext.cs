/*
Author:		Sr Programmer Analyst Oleg Gorlov
Description:	Data access layer (DAL). Reral Estate 
Group-Admiral Realty Inc. http://www.ontario-real-estate.com, Toronto 
email: oleg_gorlov@yahoo.com

*/
using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using OntarioRealEstate.Models.Property;
using System.ComponentModel.DataAnnotations.Schema;
using OntarioRealEstate.DAL;
using OntarioRealEstate.Models;

namespace OntarioRealEstate.DAL
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext()
            : base()
        { }

        public DbSet<pBroker> pBrokers { get; set; }
        public DbSet<pBrokerage> pBrokerages { get; set; }
        public DbSet<pListiner> pListiners { get; set; }
        public DbSet<pAddress> pAddresses { get; set; }
        public DbSet<pPrice> pPrices { get; set; }
        public DbSet<pBuildingType> pBuildingTypes { get; set; }
        public DbSet<pCity> pCities { get; set; } 
        public DbSet<pTitle> pTitles { get; set; }
        public DbSet<pService> pServices { get; set; }
        public DbSet<pImage> pImages { get; set; }
        public DbSet<pCategory> pCategories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ForSqlServer().UseIdentity();

            #region pBroker
            //--- pBroker
            builder.Entity<pBroker>()
                .HasKey(c => c.pBrokerId);

            builder.Entity<pBroker>()
            .Property<int>(c => c.pBrokerId);
            #endregion

            #region pBrokerage
            //--- pBrokerage
            builder.Entity<pBrokerage>()
                .HasKey(c => c.pBrokerageId);

            builder.Entity<pBrokerage>()
            .Property<int>(c => c.pBrokerageId);
            #endregion

            #region pPrice
            //--- pPrice
            builder.Entity<pPrice>()
                .HasKey(c => c.pListinerId);

            builder.Entity<pPrice>()
            .Property<int>(c => c.pListinerId);
            #endregion

            #region pAddress
            //--- pAddress
            builder.Entity<pAddress>()
                .HasKey(c => c.pListinerId);

            builder.Entity<pAddress>()
            .Property<int>(c => c.pListinerId);
            #endregion

            #region pListiner
            //--- pListiner
            builder.Entity<pListiner>()
                .HasKey(c => c.pListinerId);

            builder.Entity<pListiner>()
                .Property<int>(c => c.pListinerId);

            builder.Entity<pListiner>()
                .HasOne(o => o.pPrice)
                .WithOne(d => d.pListiner);

            builder.Entity<pListiner>()
                .HasOne(o => o.pAddress)
                .WithOne(d => d.pListiner);
            #endregion

            #region pBuildingType
            //--- pBuildingType
            builder.Entity<pBuildingType>()
                .HasKey(c => c.pBuildingTypeId);

            builder.Entity<pBuildingType>()
            .Property<int>(c => c.pBuildingTypeId);
            #endregion

            #region pCity
            //--- pCity
            builder.Entity<pCity>()
                .HasKey(c => c.pCityId);

            builder.Entity<pCity>()
            .Property<int>(c => c.pCityId);
            #endregion

            #region pTitle
            //--- pTitle
            builder.Entity<pTitle>()
                .HasKey(c => c.pTitleId);

            builder.Entity<pTitle>()
            .Property<int>(c => c.pTitleId);
            #endregion

            #region pService
            //--- pService
            builder.Entity<pService>()
                .HasKey(c => c.pServiceId);

            builder.Entity<pService>()
            .Property<int>(c => c.pServiceId);
            #endregion

            #region pImage
            //--- pImage
            builder.Entity<pImage>()
                .HasKey(c => c.pImageId);

            builder.Entity<pImage>()
            .Property<int>(c => c.pImageId);
            #endregion

            #region pCategory
            //--- pCategory
            builder.Entity<pCategory>()
                .HasKey(c => c.pCategoryId);

            builder.Entity<pCategory>()
            .Property<int>(c => c.pCategoryId);

            builder.Entity<pCategory>()
                .HasOne(c => c.pParentCategory)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.pParentCategoryId);
            #endregion



        }
        

        public DbSet<Listiner> Listiner { get; set; }
    }
}
