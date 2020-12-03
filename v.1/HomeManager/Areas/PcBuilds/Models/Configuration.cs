using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Models
{
    /// <summary>
    /// Class responsible for getting nested objects: pcBuildHardDrives
    /// </summary>
    public class PCBuildHardDrives
    {
        /// <summary>
        /// (Guid) PC build ID.
        /// </summary>
        public Guid pcBuildId { get; set; }

        /// <summary>
        /// (Guid) Hard drive ID.
        /// </summary>
        public Guid hardDriveId { get; set; }

        /// <summary>
        /// (HardDrive) Hard drive object.
        /// </summary>
        public HardDrive hardDrive { get; set; }
    }

    /// <summary>
    /// Class responsible for getting nested objects: pcBuildOthers
    /// </summary>
    public class PCBuildOthers
    {
        /// <summary>
        /// (Guid) PC build ID.
        /// </summary>
        public Guid pcBuildId { get; set; }

        /// <summary>
        /// (Guid) Other ID.
        /// </summary>
        public Guid otherId { get; set; }

        /// <summary>
        /// (Other) Other object.
        /// </summary>
        public Other other { get; set; }
    }

    public class Configuration
    {
        public Configuration()
        {
            Fan = new Fan();
            GraphicsCard = new GraphicsCard();
            Motherboard = new Motherboard();
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
        
        [Display(Name= "Last time pc configuration was modified by")]
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
        public CPUWatercooler CPUWatercooler { get; set; }
        public Fan Fan { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

        [Display(Name = "Qty")]
        [Range(1, Int32.MaxValue)]
        public int GraphicsCardQty { get; set; }
        public Motherboard Motherboard { get; set; }
        public PCCase PCCase { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public Processor Processor { get; set; }
        public RAM RAM { get; set; }

        public List<PCBuildHardDrives> pcBuildHardDrives { get; set; }
        public List<PCBuildOthers> pcBuildOthers { get; set; }
    }
}
