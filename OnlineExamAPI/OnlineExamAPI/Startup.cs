using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnlineExam.Business.BusinessLayer;
using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using SendGridEmail;

namespace OnlineExamAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.AddDbContext<OnlineExamContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:ExamDB"]));
            services.AddControllers().AddNewtonsoftJson(Options => Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IOnlineExam<Questions>, QuestionBusiness>();
            services.AddScoped<IOnlineExam<CreateReview>, ChoiceBusiness>();
            services.AddScoped<IOnlineExam<UserAnswers>, UserAnswerBusiness>();
            services.AddScoped<IOnlineExam<Users>, UserBusiness>();
            services.AddScoped<IUserProfile<UserProfile>, UserProfileBusiness>();
            services.AddScoped<IScheduleInterview<ScheduleInterview>, ScheduleInterviewBusiness>();
            services.AddScoped<Isendgrid, SendGridMail>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineExamAPI", Version = "v1" });
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineExamAPI v1"));
            }
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
