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
            GraphicsCard = new GraphicsCard();
            HardDrive = new HardDrive();
            Motherboard = new Motherboard();
            Other = new Other();
            PCCase = new PCCase();
            PowerSupply = new PowerSupply();
            Processor = new Processor();
            RAM = new RAM();
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        [Display(Name = "Total price")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }


        public CPUWatercooler CPUWatercooler { get; set; }

        public Fan Fan { get; set; }

        public GraphicsCard GraphicsCard { get; set; }

        public HardDrive HardDrive { get; set; }

        public Motherboard Motherboard { get; set; }

        public Other Other { get; set; }

        public PCCase PCCase { get; set; }

        public PowerSupply PowerSupply { get; set; }

        public Processor Processor { get; set; }

        public RAM RAM { get; set; }
    }
}
