//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerShop.model.database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Computer : Product
    {
        public string Producer { get; set; }
        public string Type { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string OpticalDrive { get; set; }
        public string GraphicsCard { get; set; }
        public Nullable<int> Cores { get; set; }
        public Nullable<int> Frequency { get; set; }
        public Nullable<int> RamSize { get; set; }
        public string HardDriveType { get; set; }
        public Nullable<int> HardDriveSize { get; set; }
        public string OperatingSystem { get; set; }
        public string Interfaces { get; set; }
        public string Equipment { get; set; }
        public string Case { get; set; }
    }
}