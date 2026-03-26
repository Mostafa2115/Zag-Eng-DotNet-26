
#region Part 1

// 1. What are the fundamental differences between ASP.NET and ASP.NET Core?
// ASP.NET القديم بيشتغل على Windows فقط وكان تقيل (System.Web)
// ASP.NET Core Cross-platform وسريع وخفيف ويدعم Dependency Injection بشكل مدمج

// 2. What does it mean for an API to be "Stateless"?
// يعني السيرفر مش بيخزن أي بيانات عن المستخدم بين الطلبات
// كل Request لازم يكون فيه كل المعلومات المطلوبة

// 3. Break down the anatomy of an HTTP Request URL?
// URL بيتكون من:
// Protocol: https
// Host: api.example.com
// Port: 443
// Path: /products/10
// Query: ?sort=asc

// 4. What are the primary HTTP Methods (Verbs) and their uses?
// GET: جلب بيانات
// POST: إنشاء
// PUT: تعديل كامل
// PATCH: تعديل جزئي
// DELETE: حذف

// 5. What is the role of Program.cs?
// هو نقطة بداية التطبيق
// فيه إعداد الخدمات (DI) و Middleware وتشغيل التطبيق

// 6. Why Swagger only in Development?
// لأسباب أمنية علشان ميعرضش تفاصيل الـ APIs في الإنتاج

// 7. What is Dependency Injection?
// هو إنك تمرر الـ dependencies للكلاس بدل ما ينشئها بنفسه

// 8. Service Lifetimes?
// Transient: كل مرة instance جديد
// Scoped: واحد لكل request
// Singleton: واحد طول عمر التطبيق

// 9. Why use Interface?
// يقلل الربط (Coupling) ويسهل التعديل والاختبار

// 10. Launch Profiles?
// إعدادات التشغيل زي URL و Environment

// 11. JSON role?
// فورمات خفيف لتبادل البيانات بين الأنظمة

#endregion


#region Question 1 - What is Dependency?

// 1. Tight Coupling (مرتبط بكلاسات مباشرة)
// 2. صعب الاختبار (Testing)
// 3. كسر مبدأ Single Responsibility
// 4. Hardcoded values

public class Order { }

public class OrderService
{
    public void CreateOrder(Order order)
    {
        // Save to database
        var connection = new SqlConnection("connection_string");

        // Send email
        var emailSender = new EmailSender();
        emailSender.Send("Order created!");

        // Log
        var logger = new FileLogger();
        logger.Log("Order created");
    }
}

public class SqlConnection
{
    public SqlConnection(string conn) { }
}

public class EmailSender
{
    public void Send(string msg) { }
}

public class FileLogger
{
    public void Log(string msg) { }
}

#endregion


#region Question 2 - What's the difference between A and B? Which one is better?

// A: Tight Coupling 
// B: Loose Coupling باستخدام Interface  وهو الأفضل

public class User { public string Email { get; set; } }

// Scenario A
public class EmailService
{
    public void SendWelcomeEmail(string email) { }
}

public class UserServiceA
{
    private EmailService _emailService = new EmailService();

    public void RegisterUser(User user)
    {
        _emailService.SendWelcomeEmail(user.Email);
    }
}

// Scenario B
public interface IEmailService
{
    void SendWelcomeEmail(string email);
}

public class UserServiceB
{
    private readonly IEmailService _emailService;

    public UserServiceB(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void RegisterUser(User user)
    {
        _emailService.SendWelcomeEmail(user.Email);
    }
}

#endregion


#region Question 3 - What happens when a request is received?

// 1. ييجي Request لل Controller
// 2. الـ DI Container ينشئ ProductService
// 3. يحقن IRepository (SqlRepository)
// 4. يتم تنفيذ العملية

public interface IRepository
{
    void Save(object data);
}

public class SqlRepository : IRepository
{
    public void Save(object data)
    {
        Console.WriteLine("Saving to SQL Database");
    }
}

public class ProductService
{
    private readonly IRepository _repository;

    public ProductService(IRepository repository)
    {
        _repository = repository;
    }

    public void AddProduct(string product)
    {
        Console.WriteLine($"Adding product: {product}");
        _repository.Save(product);
    }
}

// builder.Services.AddScoped<IRepository, SqlRepository>();
// builder.Services.AddScoped<ProductService>();

#endregion


#region Question 4 - What is the output for each registration?

// Transient - Registration A  => false
// Scoped - Registration B  => true
// Singleton - Registration C  => true

// builder.Services.AddTransient<IEmailService, EmailService>();
// builder.Services.AddScoped<IEmailService, EmailService>();
// builder.Services.AddSingleton<IEmailService, EmailService>();

public class HomeController : ControllerBase
{
    private readonly IEmailService _email1;
    private readonly IEmailService _email2;

    public HomeController(IEmailService email1, IEmailService email2)
    {
        _email1 = email1;
        _email2 = email2;
    }

    [HttpGet]
    public IActionResult Test()
    {
        var same = Object.ReferenceEquals(_email1, _email2);
        return Ok(new { AreSameInstance = same });
    }
}

#endregion


#region Question 5 - Which implementation will Controller A receive? / How many services will be injected into Controller B?

// ControllerA: آخر تسجيل => MailgunEmailService
// ControllerB: 3 خدمات (Smtp + SendGrid + Mailgun)

public class SmtpEmailService : IEmailService
{
    public void SendWelcomeEmail(string email) { }
}

public class SendGridEmailService : IEmailService
{
    public void SendWelcomeEmail(string email) { }
}

public class MailgunEmailService : IEmailService
{
    public void SendWelcomeEmail(string email) { }
}

// builder.Services.AddScoped<IEmailService, SmtpEmailService>();
// builder.Services.AddScoped<IEmailService, SendGridEmailService>();
// builder.Services.AddScoped<IEmailService, MailgunEmailService>();

public class ControllerA
{
    private readonly IEmailService _email;

    public ControllerA(IEmailService email)
    {
        _email = email;
    }
}

public class ControllerB
{
    private readonly IEnumerable<IEmailService> _emails;

    public ControllerB(IEnumerable<IEmailService> emails)
    {
        _emails = emails;
    }
}

#endregion
