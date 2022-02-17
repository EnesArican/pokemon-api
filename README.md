# pokemon-api

A custom 'Pokedex' REST API that returns pokemon information.

## How To Run

**Prerequisites** </br>
To run the application, you will need to have [docker](https://docs.docker.com/get-docker/) installed on your machine.
</br>

**Build and run the Docker image** </br>
Open a command prompt and navigate to the project `src` folder. Firstly build the docker image with the following command:
```shell
docker build -t poke-local:0.1 .
```

Once completed you can now create and start a container from your docker image with the [docker run](https://docs.docker.com/engine/reference/run/) command:
```shell
docker run -it --rm -p 8080:80 --name my_pokemon_app poke-local:0.1
```
The app should now be running on http://localhost:8080.
</br>
</br>

## Things that could be done for a production API

- Add [exception filter](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0#exception-filters) middleware,  to better manage and have more granular control on errors returned.

- Include unit tests that would cover clients and controller methods, proving that they behave as expected.

