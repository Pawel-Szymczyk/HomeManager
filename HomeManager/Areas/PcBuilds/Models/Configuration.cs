using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Models
{

    public class Configuration
    {
        public Configuration()
        {
            CPUWatercooler = new CPUWatercooler();
            Fan = new Fan();
            //GraphicsCards = new List<GraphicsCard>();
            //pcBuildGraphicsCards = new pcBuildGraphicsCards();

            HardDrives = new List<HardDrive> ();

            Motherboard = new Motherboard();
            Others = new List<Other>();
            PCCase = new PCCase();
            PowerSupply = new PowerSupply();
            Processor = new Processor();
            RAM = new RAM();
        }

        public Guid PCBuildId { get; set; }

        public string Description { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }


        [Display(Name = "Total price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }


        public CPUWatercooler CPUWatercooler { get; set; }

        public Fan Fan { get; set; }



        //public pcBuildGraphicsCards pcBuildGraphicsCards { get; set; }

        //public List<GraphicsCard> GraphicsCards { get; set; }






        public List<HardDrive> HardDrives { get; set; }

        public Motherboard Motherboard { get; set; }

        public List<Other> Others { get; set; }

        public PCCase PCCase { get; set; }

        public PowerSupply PowerSupply { get; set; }

        public Processor Processor { get; set; }

        public RAM RAM { get; set; }
    }
}
