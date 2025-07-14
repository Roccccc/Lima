#!/bin/bash

# L-Connect Deployment Script for Tencent Cloud
echo "Starting L-Connect deployment..."

# Update system
echo "Updating system packages..."
apt update && apt upgrade -y

# Install .NET 9.0
echo "Installing .NET 9.0..."
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
apt update
apt install -y apt-transport-https
apt install -y dotnet-sdk-9.0
apt install -y aspnetcore-runtime-9.0

# Install Nginx
echo "Installing Nginx..."
apt install -y nginx

# Install MySQL client
echo "Installing MySQL client..."
apt install -y mysql-client

# Create application directories
echo "Creating application directories..."
mkdir -p /var/www/l-connect
mkdir -p /var/www/l-connect/documents
chown -R www-data:www-data /var/www/l-connect

# Configure Nginx
echo "Configuring Nginx..."
cat > /etc/nginx/sites-available/l-connect << 'EOF'
server {
    listen 80;
    server_name _;

    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }

    location /static/ {
        alias /var/www/l-connect/wwwroot/;
        expires 1y;
        add_header Cache-Control "public, immutable";
    }
}
EOF

# Enable the site
ln -sf /etc/nginx/sites-available/l-connect /etc/nginx/sites-enabled/
rm -f /etc/nginx/sites-enabled/default
nginx -t
systemctl reload nginx

# Configure systemd service
echo "Configuring systemd service..."
cat > /etc/systemd/system/l-connect.service << 'EOF'
[Unit]
Description=L-Connect Web Application
After=network.target

[Service]
Type=notify
ExecStart=/usr/bin/dotnet /var/www/l-connect/L-Connect.dll
WorkingDirectory=/var/www/l-connect
Restart=always
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=l-connect
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target
EOF

# Reload systemd and enable service
systemctl daemon-reload
systemctl enable l-connect

echo "Deployment script completed!"
echo "Next steps:"
echo "1. Upload your application files to /var/www/l-connect/"
echo "2. Update database connection string"
echo "3. Start the service: systemctl start l-connect" 