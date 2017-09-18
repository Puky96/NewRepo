using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAzure.Models.ReportViewModels
{
    public class MOriginatorReport
    {
        [Required(ErrorMessage = "Introduceti o imagine!")]
        [Display(Name = "Imagine Problema")]
        public IFormFile ImagePath { get; set; }

        [Display(Name = "Imagine Problema")]
        public IFormFile ImagePath1 { get; set; }

        [Display(Name = "Imagine Problema")]
        public IFormFile ImagePath2 { get; set; }


        public string IdentificationNumber { get; set; }


        public string ServerPath { get; set; }
        public string ServerPath1 { get; set; }
        public string ServerPath2 { get; set; }

        [Display(Name = "Imagine eticheta supplier")]
        [Required(ErrorMessage = "Introduceti fotografie cu eticheta de palet/eticheta supplier")]
        public IFormFile EtiqueteImagePath { get; set; }

        public string EtiquetePath { get; set; }


        //[Required]
        [Display(Name = "Echipament")]
        public string Equipment { get; set; }   //dropdown list - selection from database

        //[Required(ErrorMessage = "Introduceti Linia")]
        [Display(Name = "Linie")]
        public string Area { get; set; }      //dropdown list

        public DateTime DateHour { get; set; }

        [Required(ErrorMessage = "Introduceti GCAS")]
        public string GCAS { get; set; }

        [Display(Name = "Vendor  BATCH")]
        public string VendorBatch { get; set; }

        [Display(Name = "Batch SAP")]
        public string BatchSAP { get; set; }

        [Required(ErrorMessage = "Introduceti PO")]
        public string PO { get; set; }    //manual input

        [Display(Name = "Descrierea fenomenului")]
        //[Required]
        public List<string> PhenomenaDescriptions { get; set; }   //dropdown list

        public TimeSpan Downtime { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        [Required]
        [Display(Name = "Numar Stop-uri")]
        public int NumberOfStops { get; set; }     //manual input

        [Required]
        [Display(Name = "Mostra?")]
        public bool HasSample { get; set; }        //check it or not

        [Required]
        [Display(Name = "Lot blocat?")]
        public bool BlockedBatch { get; set; }     //check it or not

        [Display(Name = "Batch No.")]
        public string BatchNo { get; set; }       //manual input

        [Required]
        [Display(Name = "Cantitate")]
        public int Quantity { get; set; }      //manual input

        //[Required]
        [Display(Name = "Tip material")]
        public string PhenomenaCategory { get; set; }

        //[Required]
        [Display(Name = "Problema")]
        public string QuestionName { get; set; }
    }
}
