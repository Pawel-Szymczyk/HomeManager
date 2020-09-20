using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Models
{
    public class Processor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductCollection { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfThreads { get; set; }
        public int Cache { get; set; }
        public int TDP { get; set; }
        public decimal ProcessorBaseFrequency { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
    }
}
