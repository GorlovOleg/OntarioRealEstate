using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntarioRealEstate.Models.Property
{ 
    [Table("pBrokerage")]
    public class pBrokerage 
    {
        public pBrokerage() 
        {
            //this.Services = new List<Service>();
            //this.pListiners = new List<pListiner>();
            LastUpdated = DateTime.UtcNow;
        }

        /// <summary>
        /// 1 pBrokerage.cs       
        /// pBrokerageId
        /// </summary>
        [Key]
        public int pBrokerageId { get; set; }

        /// <summary>
        /// 2 pBrokerage.cs       
        /// pBrokerageName
        /// </summary>             
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string pBrokerageName { get; set; } 

        /// <summary>
        /// 3 pBrokerage.cs        
        /// Street
        /// </summary>    
        [Required]
        [Display(Name = "Street Address")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Street cannot be longer than 255 characters.")]
        public string Street { get; set; }

        /// <summary>
        /// 4 pBrokerage.cs       
        /// City
        /// </summary> 
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        /// <summary>
        /// 5 pBrokerage.cs        
        /// City
        /// </summary> 
        [StringLength(7, MinimumLength = 1, ErrorMessage = "PostalCode cannot be longer than 7 characters.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 6 pBrokerage.cs       
        /// Phone
        /// </summary
        [Phone]
        //        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        //        [StringLength(12, MinimumLength = 1, ErrorMessage = "Phone cannot be longer than 12 characters.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 7 pBrokerage.cs       
        /// Email
        /// </summary
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }


        /// <summary>
        /// 8 pBrokerage.cs      
        /// Website
        /// </summary
        public string Website { get; set; }


        /// <summary>
        /// 10 pBrokerage.cs
        /// 3  PropertyContext.cs
        /// One-To-Many
        /// May have a pServices or not
        /// pBrokerage to pServices by pBrokerageId_FK
        
        //---  oct, 08 public virtual ICollection<pService> pServices { get; set; }
        public virtual ICollection<pService> pServices { get; set; }

        /// <summary>
        /// 11 pBrokerage.cs        
        /// 4  PropertyContext.cs
        /// One-To-Many
        /// May have a pListiners or not
        /// pBrokerage to pListiners by pBrokerageId_FK
        /// </summary>

        //---  oct, 08 public virtual ICollection<pListiner> pListiners { get; set; }
        public virtual ICollection<pListiner> pListiners { get; set; }

        /// <summary>
        /// 12 pBrokerage.cs
        /// 5 PropertyContext.cs
        /// One-To-Many
        /// May have a pBroker or not
        /// pBrokerage to pBrokers by pBrokerageId_FK
        /// </summary>

        //---  oct, 08 public virtual ICollection<pBroker> pBrokers { get; set; }
        public virtual ICollection<pBroker> pBrokers { get; set; }

        /// <summary>
        /// 11 pBrokerage.cs
        /// Timestamp
        /// </summary>
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        /// <summary>
        /// 12 pBrokerage.cs
        /// LastUpdated
        /// </summary>
        [Editable(false, AllowInitialValue = true)]
        public DateTime LastUpdated { get; set; }
    }
}