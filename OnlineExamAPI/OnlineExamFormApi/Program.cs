using Microsoft.EntityFrameworkCore;
using OnlineExam.Business.BusinessLayer;
using OnlineExam.Business.Interfaces;
using OnlineExam.Data;
using OnlineExam.Sql.Models;
using SendGridEmail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddDbContext<OnlineExamContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionString:ExamDB"]));
builder.Services.AddControllers().AddNewtonsoftJson(Options => Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IOnlineExam<Questions>, QuestionBusiness>();
builder.Services.AddScoped<IOnlineExam<CreateReview>, ChoiceBusiness>();
builder.Services.AddScoped<IOnlineExam<UserAnswers>, UserAnswerBusiness>();
builder.Services.AddScoped<IOnlineExam<Users>, UserBusiness>();
builder.Services.AddScoped<IUserProfile<UserProfile>, UserProfileBusiness>();
builder.Services.AddScoped<IScheduleInterview<ScheduleInterview>, ScheduleInterviewBusiness>();
builder.Services.AddScoped<Isendgrid, SendGridMail>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IInterviewerReviewService, InterviewerReviewService>();
builder.Services.AddScoped<IReviewTypeService, ReviewTypeService>();
builder.Services.AddHttpClient();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
