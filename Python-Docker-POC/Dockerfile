FROM ubuntu

RUN apt-get update
RUN apt-get -y install python3

COPY . /app

WORKDIR /app

ENTRYPOINT [ "python3", "app.py" ]