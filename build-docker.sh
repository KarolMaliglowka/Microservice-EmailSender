echo "Checking docker installation"
if command -v docker &> /dev/null; then
    echo "Docker installation found"
    echo "Building docker image"
    docker compose up -d
    echo "You probably need to allow a specific port in your firewall, e.g.: "ufw allow 4040/tcp"
else
    echo "Docker installation not found. Please install docker."
    exit 1
fi