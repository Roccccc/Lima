using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L_Connect.Models.Domain
{
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string TrackingNumber { get; set; }
        
        [ForeignKey("Client")]
        public int? ClientId { get; set; }
        public virtual User Client { get; set; }
        
        [ForeignKey("Admin")]
        public int? CreatedByAdminId { get; set; }
        public virtual User Admin { get; set; }

        public string? QrCodeImage { get; set; }
        
        [ForeignKey("Pricing")]
        public int? AppliedPriceId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Weight { get; set; }
        
        [Required]
        [StringLength(255)]
        public string OriginAddress { get; set; }
        
        [Required]
        [StringLength(255)]
        public string DestinationAddress { get; set; }
        
        [Required]
        [StringLength(50)]
        public string CurrentStatus { get; set; }
        public string CurrentLocation { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal FinalCost { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }//update ERD to include this as this will help in calculating the delivery date

        //later phase
        // Navigation property for status history
        // Navigation property for documents
        // Helper method to generate tracking number
        // Helper method to update current status

        // 
        [Required]
        [StringLength(50)]
        public string ServiceType { get; set; }

        // Navigation property for documents
        public ICollection<Document> Documents { get; set; }
    }
}