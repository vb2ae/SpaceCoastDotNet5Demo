# Introduction to .net 5


Demo given at the space coast sql/.net online user group meeting on Jan 14,2020


# To compile a .net standard library for .net 5.0


Change TargetFramework

     <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
     </PropertyGroup>


To TargetFrameworks so it can compile for .net standard and .net 5.0

      <PropertyGroup>
        <TargetFrameworks>netstandard2.0;.net5.0</TargetFrameworks>
      </PropertyGroup>
      
 
 # Simplified Console apps
 
 To make it easier for people to learn c# 9 you can remove alot of the code on a console app.
 
 
 You can replace 
 
     namespace CsharpDemo
      {
           class Program
           {
                static void Main(string[] args)
                {     
                      Console.WriteLine(lastName);
                }  
           }      
      }

With

     System.Console.Write("Hello world!");
     
     
# Records with C#

immutable  classes

      namespace CsharpDemo
      {

            public record Person(string firstName, string lastName);

      }
      
      
# Init properties

Properties that can only have values set when class is being created

    public class Employee
    {
        public string Name { get; init; }

        public string position { get; init; }
    }
      
      
# Deconstructors

pull properties into variables

            var person = new Person("Ken", "Tucker");
            var (firstName, lastName) = person;


# Json Serialization

Can serialize records and classes with init properties

            var person = new Person("Ken", "Tucker");

            var employee = new Employee(){Name = "Ken", position = "Dev"};

            string json = System.Text.Json.JsonSerializer.Serialize(person);

            var person2 = System.Text.Json.JsonSerializer.Deserialize<Person>(json);

            string json2 = System.Text.Json.JsonSerializer.Serialize(employee);

            var employee2 = System.Text.Json.JsonSerializer.Deserialize<Employee>(json2);


# Networking changes

Added ability to tell if network call was cancelled or was a timeout

           var cts = new CancellationTokenSource();
            try
            {
                // Pass in the token.
                using var response = await _client.GetAsync("https://localhost:5001/Time?seconds=14", cts.Token);
            }
            // If the token has been canceled, it is not a timeout.
            catch (TaskCanceledException ex) when (cts.IsCancellationRequested)
            {
                // Handle cancellation.
                Console.WriteLine("Canceled: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeout.
                Console.WriteLine("Timed out: " + ex.Message);
            }

# SWAGGER

Swagger added by default to web api projects

Make following changes if you can to be able to add a web client reference

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpaceCoastWebApi", Version = "v1" });
                c.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(o => o.SerializeAsV2 = true);
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpaceCoastWebApi v1"));
            }
