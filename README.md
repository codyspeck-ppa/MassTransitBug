This repo demonstrates a bug within MassTransit's `EntityFrameworkOutboxContextFactory`.

To run, initialize dependencies by running `docker compose up -d` within the root of the project. Then from `./src/MassTransitBug`, run `dotnet ef database update`.   

This assumes corresponding docker and entity framework core tooling installed.