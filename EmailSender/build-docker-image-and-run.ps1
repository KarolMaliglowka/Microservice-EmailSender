docker build --tag mailsender .
docker run --name mail-sender -d -p 4040:4040 mailsender