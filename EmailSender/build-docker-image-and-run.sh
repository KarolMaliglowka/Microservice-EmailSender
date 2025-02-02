echo "Checking docker installation"
if command -v docker &> /dev/null; then
    echo "Docker installation found"
    echo "Building docker image"
    docker build --tag mailsender .
    echo "Start docker container"
    docker run --name mail-sender -d -p 4040:4040 mailsender
    echo "You probably need to allow a specific port in your firewall, e.g.: "ufw allow 4040/tcp"
else
    echo "Docker installation not found. Please install docker."
    exit 1
fi