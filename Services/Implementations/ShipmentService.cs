using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L_Connect.Data;
using L_Connect.Models.Domain;
using L_Connect.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using QRCoder;

namespace L_Connect.Services.Implementations
{
    // Service implementation for shipment-related operations
    public class ShipmentService: IShipmentService
    {
        private readonly ApplicationDbContext _context;
        
        public ShipmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Shipment> GetShipmentByTrackingNumberAsync(string trackingNumber)
        {
            if (string.IsNullOrEmpty(trackingNumber))
                return null;

            return await _context.Shipments
                .FirstOrDefaultAsync(s => s.TrackingNumber == trackingNumber);
        }

        public async Task<List<ShipmentStatus>> GetShipmentsByStatusHistoryAsync(int shipmentId)
        {
            return await _context.ShipmentStatuses
                .Where(s => s.ShipmentId == shipmentId)
                .OrderByDescending(s => s.UpdatedAt)
                .ToListAsync();
        }

        public async Task<List<ShipmentStatus>> GetShipmentStatusHistoryAsync(int shipmentId)
        {
            return await _context.ShipmentStatuses
                .Where(s => s.ShipmentId == shipmentId)
                .OrderByDescending(s => s.UpdatedAt)
                .ToListAsync();
        }
        
        public async Task<bool> ValidateTrackingNumberAsync(string trackingNumber)
        {
            if (string.IsNullOrEmpty(trackingNumber))
                return false;

            return await _context.Shipments
                .AnyAsync(s => s.TrackingNumber == trackingNumber);
        }
        
        public async Task<List<Shipment>> GetShipmentsByClientIdAsync(int clientId)
        {
            return await _context.Shipments
                .Where(s => s.ClientId == clientId)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        // UPDATED METHODS BELOW - Fixed to work with your Shipment model

        public async Task<Shipment> CreateShipmentAsync(Shipment shipment)
        {
            // Generate a unique tracking number
            shipment.TrackingNumber = GenerateTrackingNumber();
            shipment.QrCodeImage= GenerateQrCodeBase64(shipment.TrackingNumber);
            // Set creation date
            shipment.CreatedAt = DateTime.UtcNow;
            
            // Set initial status to "Pending"
            shipment.CurrentStatus = "Pending";
            shipment.CurrentLocation = shipment.OriginAddress;
            
            // ServiceType is now directly set from the input parameter
            // No need to calculate or derive it
            
            // Calculate estimated delivery date based on service type
            int deliveryDays = 5; // Default
            
            if (shipment.ServiceType == "Express")
            {
                deliveryDays = 3;
            }
            else if (shipment.ServiceType == "International")
            {
                deliveryDays = 10;
            }
            
            shipment.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(deliveryDays);

            // Add to database
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            // Create initial status record
            var initialStatus = new ShipmentStatus
            {
                ShipmentId = shipment.ShipmentId,
                Status = "Pending",
                Location = shipment.OriginAddress,
                Notes = "Shipment created and awaiting processing",
                UpdatedAt = DateTime.UtcNow,
                UpdatedByAdminId = shipment.CreatedByAdminId
            };

            _context.ShipmentStatuses.Add(initialStatus);
            await _context.SaveChangesAsync();

            return shipment;
        }

        public async Task<Shipment> GetShipmentByIdAsync(int id)
        {
            // Get shipment by ID
            var shipment = await _context.Shipments
                .Include(s => s.Client)
                .FirstOrDefaultAsync(s => s.ShipmentId == id); // Note: using ShipmentId

            return shipment;
        }

     public async Task<bool> UpdateShipmentAsync(Shipment shipment, int updatedByAdminId, string statusNotes = null)
    {
        var existingShipment = await _context.Shipments.FindAsync(shipment.ShipmentId);
        if (existingShipment == null) return false;

        // Save previous values to detect changes
        string prevStatus = existingShipment.CurrentStatus;
        string prevLocation = existingShipment.CurrentLocation;

        // Apply updates
        existingShipment.CurrentStatus = shipment.CurrentStatus;
        existingShipment.CurrentLocation = shipment.CurrentLocation;
        // ... update other fields ...

        // CRITICAL: Create history record if status/location changed OR notes are provided
        if (prevStatus != shipment.CurrentStatus || prevLocation != shipment.CurrentLocation || !string.IsNullOrEmpty(statusNotes))
        {
            var statusUpdate = new ShipmentStatus
            {
                ShipmentId = shipment.ShipmentId,
                Status = shipment.CurrentStatus,
                Location = shipment.CurrentLocation,
                Notes = statusNotes ?? "Status updated",
                UpdatedAt = DateTime.UtcNow,
                UpdatedByAdminId = updatedByAdminId
            };
            _context.ShipmentStatuses.Add(statusUpdate);
        }

        await _context.SaveChangesAsync();
        return true;
    }

        private string GenerateTrackingNumber()
        {
            // Format: LC-YYYYMMDD-XXXX where XXXX is a random 4-digit number
            var dateComponent = DateTime.UtcNow.ToString("yyyyMMdd");
            var random = new Random();
            var randomComponent = random.Next(1000, 9999).ToString();
            
            return $"LC-{dateComponent}-{randomComponent}";
        }

        // public Task<List<Shipment>> GetAllShipmentsAsync()
        // {
        //     throw new NotImplementedException();
        // }
        public async Task<List<Shipment>> GetAllShipmentsAsync()
        {
            return await _context.Shipments
                .Include(s => s.Client)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> DeleteShipmentAsync(int shipmentId)
        {
            try
            {
                // Get shipment
                var shipment = await _context.Shipments.FindAsync(shipmentId);
                
                if (shipment == null)
                    return false;
                    
                // Validate status
                if (shipment.CurrentStatus != "Pending" && shipment.CurrentStatus != "Cancelled")
                    return false;
                    
                // Remove from database
                _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<(List<Shipment> shipments, int totalCount)> SearchShipmentsAsync(
            string trackingNumber = null,
            string clientName = null,
            string service = null,
            string status = null,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.Shipments.AsQueryable();
            
            // Apply filters
            if (!string.IsNullOrWhiteSpace(trackingNumber))
                query = query.Where(s => s.TrackingNumber.Contains(trackingNumber));
                
            if (!string.IsNullOrWhiteSpace(clientName))
            {
                // Assuming Client is a navigation property or there's a ClientID property
                // and we have a Users table to join with
                query = query.Where(s => s.ClientId != null && 
                    _context.Users.Any(u => u.UserId == s.ClientId && 
                        (u.FullName.Contains(clientName) || u.Email.Contains(clientName))));
            }
                
            // Adjust based on your actual property names
            if (!string.IsNullOrWhiteSpace(service))
                query = query.Where(s => s.ServiceType == service); // Assuming ServiceType property
                
            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(s => s.CurrentStatus == status); // Assuming CurrentStatus property
                
            // Get total count for pagination
            var totalCount = await query.CountAsync();
            
            // Apply pagination
            var shipments = await query
                .OrderByDescending(s => s.CreatedAt) // Assuming CreatedDate property
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                
            return (shipments, totalCount);
        }
        private string GenerateQrCodeBase64(string trackingNumber) 
        {
            using QRCodeGenerator qrGenerator = new QRCodeGenerator();
            using QRCodeData qrCodeData = qrGenerator.CreateQrCode(trackingNumber, QRCodeGenerator.ECCLevel.Q);
            using PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
            return Convert.ToBase64String(qrCodeAsPngByteArr);
        }
    }
}