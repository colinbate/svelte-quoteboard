using Microsoft.Data.Sqlite;
using Dapper;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
  Args = args,
  WebRootPath = "public"
});

var connectionString = builder.Configuration.GetConnectionString("QuoteDb") ?? "Data Source=quotes.db";
builder.Services.AddScoped(_ => new SqliteConnection(connectionString));

var app = builder.Build();
app.UseFileServer();

// Initialize DB
await Initialize(app.Services);

app.MapGet("/quotes", async (SqliteConnection db) => 
  await db.QueryAsync<Quote>("SELECT * FROM Quotes"));

app.MapGet("/quote/{id}", async (int id, SqliteConnection db) =>
  await db.QuerySingleOrDefaultAsync<Quote>("SELECT * FROM Quotes WHERE Id = @id", new { id }));

app.MapPost("/quotes", async (Quote quote, SqliteConnection db) => {
  var newQuote = await db.QuerySingleAsync<Quote>(
    "INSERT INTO Quotes (Text, Author, Date) VALUES (@Text, @Author, @Date) RETURNING *", quote
  );
  return Results.Created($"/quote/{newQuote.Id}", newQuote);
});

app.Run();

async Task Initialize(IServiceProvider services)
{
  using var db = services.CreateScope().ServiceProvider.GetRequiredService<SqliteConnection>();
  var sql = @"CREATE TABLE IF NOT EXISTS Quotes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    Text TEXT NOT NULL,
    Author TEXT NOT NULL,
    Date TEXT NOT NULL
  );";
  await db.ExecuteAsync(sql);
}

public class Quote
{
  public int Id { get; set; }
  public string? Text { get; set; }
  public string? Author { get; set; }
  public DateTime Date { get; set; }
}