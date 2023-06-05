# PostgreSQL Docker image with pre-created tables for saving timeseries data

This Docker image extends the official PostgreSQL image and includes a SQL script to create a database and table with pre-defined schema.

## Prerequisites

Make sure you have Docker installed on your machine. You can download Docker from the official website: [https://www.docker.com/](https://www.docker.com/)

## Build the Docker Image

1. Clone or download this repository to your local machine.
2. Open a terminal or command prompt and navigate to the PostgreSQL directory.

```bash
cd ATG/ATG.Collector.Target/Database/PostgreSQL
```

3. Run the following command to build the Docker image:

```bash
docker build -t atg-collector-pgdb:v0.1 .
```

Replace `atg-collector-pgdb:v0.1` with your desired image name and version.

4. Docker will download the base PostgreSQL image and execute the SQL script to create the database and table with the specified schema. The resulting image will be built and tagged with the provided image name.

## Run a Container with the PostgreSQL Image

Once you have built the Docker image, you can run a container based on it to have a PostgreSQL database with the pre-created tables.

We will also create a docker volume to allow our container to remain persistent across restarts.

1. Create a Docker volume to store the database data:1. Create a Docker volume to store the database data:

```bash
docker volume create pgdata
```

2. Start the PostgreSQL container with the following command:

```bash
docker run -d -p 5432:5432 -v pgdata:/var/lib/postgresql/data --name atg-pgdb atg-collector-pgdb:v0.1
```

In this command:
- `-p 5432:5432` maps the host's port 5432 to the container's port 5432, allowing you to connect to the database.
- `-v pgdata:/var/lib/postgresql/data` mounts the Docker volume `pgdata` to the container's data directory.
- `--name atg-pgdb` assigns the name `atg-pgdb` to the running container. You can use a different name if desired.

3. Access the PostgreSQL database using your preferred PostgreSQL client and connect to `localhost:5432`. The default username is `postgres` and the password is specified in the Dockerfile (change it if needed). For example:

```bash
docker exec -it atg-pgdb psql -U postgres
```

4. If you need to explore the running container further, you can enter a bash terminal with the following command.

```bash
docker exec -it atg-pgdb bash
```

## Managing the Docker Volume

You can manage the Docker volume using the following commands:

- To list all volumes:

```bash
docker volume ls
```

- To inspect a volume:

```bash
docker volume inspect pgdata
```

- To remove a volume:

```bash
docker volume rm pgdata
```

Note: Removing the volume will delete all the data stored in the PostgreSQL container.

## Customization

If you need to customize the database schema or add more tables, you can modify the `init_postgres.sql` script before building the Docker image. Make sure to rebuild the image after making any changes.

## License

This project is licensed under the [MIT License](LICENSE).

Feel free to customize and use this Docker image to meet your specific requirements.

If you encounter any issues or have suggestions for improvements, please create an issue in this repository.
