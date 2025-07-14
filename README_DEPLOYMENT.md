# L-Connect Tencent Cloud Deployment Guide

## Prerequisites
- Tencent Cloud account
- CVM instance (Ubuntu 20.04)
- TencentDB for MySQL instance
- Domain name (optional)

## Step 1: Create Tencent Cloud Resources

### 1.1 Create CVM Instance
1. Log in to Tencent Cloud Console: https://console.cloud.tencent.com/
2. Navigate to **CVM** → **Instances**
3. Click **Create Instance**
4. Configure:
   - **Region**: Guangzhou (ap-guangzhou)
   - **Availability Zone**: ap-guangzhou-3
   - **Instance Type**: S5.MEDIUM4 (2 vCPU, 4GB RAM)
   - **Image**: Ubuntu Server 20.04 LTS
   - **System Disk**: 50GB Premium Cloud Storage
   - **Bandwidth**: 5Mbps
   - **Security Group**: Allow ports 22, 80, 443
   - **Login Method**: Password

### 1.2 Create TencentDB for MySQL
1. Navigate to **TencentDB for MySQL**
2. Click **Create Instance**
3. Configure:
   - **Region**: Same as CVM
   - **Availability Zone**: ap-guangzhou-3
   - **Instance Type**: MySQL 5.7
   - **Specification**: 1 vCPU, 1GB RAM, 25GB storage
   - **Network**: Same VPC as CVM
   - **Password**: Set strong password

## Step 2: Connect to CVM and Run Deployment Script

### 2.1 Connect via SSH
```bash
ssh root@YOUR_CVM_PUBLIC_IP
```

### 2.2 Upload and Run Deployment Script
```bash
# Upload the deployment script
# (You can copy-paste the deploy.sh content)

# Make it executable
chmod +x deploy.sh

# Run the deployment script
./deploy.sh
```

## Step 3: Upload Application Files

### 3.1 From Your Local Machine
```bash
# Upload published files
scp -r ./publish/* root@YOUR_CVM_PUBLIC_IP:/var/www/l-connect/

# Set correct permissions
ssh root@YOUR_CVM_PUBLIC_IP "chown -R www-data:www-data /var/www/l-connect"
```

## Step 4: Configure Database

### 4.1 Update Connection String
Edit `/var/www/l-connect/appsettings.Production.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_DB_HOST;Database=l_connect;User=YOUR_DB_USER;Password=YOUR_DB_PASSWORD;"
  }
}
```

### 4.2 Create Database and Run Migrations
```bash
# Connect to MySQL
mysql -h YOUR_DB_HOST -u YOUR_DB_USER -p

# Create database
CREATE DATABASE l_connect;
EXIT;

# Run migrations
cd /var/www/l-connect
dotnet ef database update
```

## Step 5: Start the Application

```bash
# Start the service
systemctl start l-connect

# Check status
systemctl status l-connect

# View logs
journalctl -u l-connect -f
```

## Step 6: Configure Domain (Optional)

### 6.1 Update Nginx Configuration
Edit `/etc/nginx/sites-available/l-connect`:
```nginx
server {
    listen 80;
    server_name YOUR_DOMAIN.com;

    # ... rest of configuration
}
```

### 6.2 Set up SSL Certificate
```bash
# Install Certbot
apt install -y certbot python3-certbot-nginx

# Get SSL certificate
certbot --nginx -d YOUR_DOMAIN.com
```

## Step 7: Monitor and Maintain

### 7.1 Check Application Status
```bash
# Service status
systemctl status l-connect

# Nginx status
systemctl status nginx

# View logs
tail -f /var/log/nginx/access.log
tail -f /var/log/nginx/error.log
journalctl -u l-connect -f
```

### 7.2 Update Application
```bash
# Stop service
systemctl stop l-connect

# Upload new files
scp -r ./publish/* root@YOUR_CVM_PUBLIC_IP:/var/www/l-connect/

# Start service
systemctl start l-connect
```

## Troubleshooting

### Common Issues:
1. **Port 80 not accessible**: Check security group rules
2. **Database connection failed**: Verify connection string and network access
3. **Service won't start**: Check logs with `journalctl -u l-connect -e`
4. **Nginx errors**: Check `/var/log/nginx/error.log`

### Useful Commands:
```bash
# Restart services
systemctl restart l-connect
systemctl restart nginx

# Check disk space
df -h

# Check memory usage
free -h

# Check running processes
ps aux | grep dotnet
```

## Security Recommendations

1. **Change default passwords**
2. **Use SSH keys instead of passwords**
3. **Configure firewall rules**
4. **Enable SSL/TLS**
5. **Regular security updates**
6. **Database backups**

## Backup Strategy

### Database Backup
```bash
# Create backup
mysqldump -h YOUR_DB_HOST -u YOUR_DB_USER -p l_connect > backup.sql

# Restore backup
mysql -h YOUR_DB_HOST -u YOUR_DB_USER -p l_connect < backup.sql
```

### Application Backup
```bash
# Backup application files
tar -czf l-connect-backup.tar.gz /var/www/l-connect/
```

## Support

For issues:
1. Check application logs
2. Check system logs
3. Verify network connectivity
4. Contact Tencent Cloud support if needed 