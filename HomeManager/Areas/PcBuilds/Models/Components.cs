﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Models
{
    public class Components
    {

        public Components()
        {
            Configuration = new Configuration();
            //SelectedCPUWatercoolerId = string.Empty;
            //SelectedFanId = string.Empty;
            //SelectedGraphicsCardId = string.Empty;
            //SelectedHardDriveId = string.Empty;
            //SelectedMotherboardId = string.Empty;
            //SelectedOtherId = string.Empty;
            //SelectedPCCaseId = string.Empty;
            //SelectedPowerSupplyId = string.Empty;
            //SelectedProcessorId = string.Empty;
            //SelectedRAMId = string.Empty;
        }

        public Configuration Configuration { get; set; }

        public List<CPUWatercooler> CPUWatercoolers { get; set; }
        public List<Fan> Fans { get; set; }
        public List<GraphicsCard> GraphicsCards { get; set; }
        public List<HardDrive> HardDrives { get; set; }
        public List<Motherboard> Motherboards { get; set; }
        public List<Other> Others { get; set; }
        public List<PCCase> PCCases { get; set; }
        public List<PowerSupply> PowerSupplies { get; set; }
        public List<Processor> Processors { get; set; }
        public List<RAM> RAMs { get; set; }


        // view
        public string SelectedCPUWatercoolerId { get; set; }
        public string SelectedFanId { get; set; }
        public string SelectedGraphicsCardId { get; set; }
        public string SelectedHardDriveId { get; set; }
        public string SelectedMotherboardId { get; set; }
        public string SelectedOtherId { get; set; }
        public string SelectedPCCaseId { get; set; }
        public string SelectedPowerSupplyId { get; set; }
        public string SelectedProcessorId { get; set; }
        public string SelectedRAMId { get; set; }
    }
}
