var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PetShopDataTransferObjects>("petshopdatatransferobjects");

builder.Build().Run();
