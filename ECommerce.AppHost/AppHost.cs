var builder = DistributedApplication.CreateBuilder(args);
var productApi = builder.AddProject<Projects.ECommerce_ProductService>("apiservice-product");
var orderapi = builder.AddProject<Projects.ECommerce_OrderService>("apiservice-order");
builder.AddProject<Projects.ECommerce_Web>("webfrontend").WithReference(productApi).WithReference(orderapi);
builder.Build().Run();
