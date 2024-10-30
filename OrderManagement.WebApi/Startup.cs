namespace OrderManagement.WebApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddControllers();
    }
 
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}