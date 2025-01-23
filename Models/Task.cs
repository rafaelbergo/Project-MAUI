using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? OrderId { get; set; }
        public string? TaskOwner { get; set; }
        public string? RelevantAspects { get; set; }
        public string? CriticalActivity { get; set; }
        public string? HowToDo { get; set; }
        public string? KeyPoint { get; set; }
        public string? LocalCoordinates { get; set; }
        public int? NumberOfPhotos { get; set; }
    }
}
