var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.event_management_system_Server>("event-management-system-server");

builder.Build().Run();
