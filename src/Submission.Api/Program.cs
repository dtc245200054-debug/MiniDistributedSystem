
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Danh sach bai tap
var assignments = new[]
{
    new Assignment(1, "Bai tap 1", "Tao API dau tien"),
    new Assignment(2, "Bai tap 2", "Goi API tu client"),
    new Assignment(3, "Bai tap 3", "Mo rong ung dung phan tan")
};

// Kiem tra trang thai API
app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        service = "Submission.Api",
        status = "running"
    });
});

// Lay danh sach bai tap
app.MapGet("/api/assignments", () =>
{
    return Results.Ok(assignments);
});

// Tiep nhan bai nop
app.MapPost("/api/submissions", (CreateSubmissionRequest request) =>
{
    if (request.AssignmentId <= 0)
    {
        return Results.Json(
            new { message = "AssignmentId khong hop le" },
            statusCode: 400
        );
    }

    if (string.IsNullOrWhiteSpace(request.StudentCode))
    {
        return Results.Json(
            new { message = "StudentCode khong duoc de trong" },
            statusCode: 400
        );
    }

    if (string.IsNullOrWhiteSpace(request.RepositoryUrl))
    {
        return Results.Json(
            new { message = "RepositoryUrl khong duoc de trong" },
            statusCode: 400
        );
    }

    var submission = new SubmissionResult(
        Guid.NewGuid(),
        request.AssignmentId,
        request.StudentCode,
        "received",
        DateTimeOffset.UtcNow
    );

    return Results.Created(
        $"/api/submissions/{submission.Id}",
        submission
    );
});

app.Run();

record Assignment(
    int Id,
    string Title,
    string Description
);

record CreateSubmissionRequest(
    int AssignmentId,
    string StudentCode,
    string RepositoryUrl
);

record SubmissionResult(
    Guid Id,
    int AssignmentId,
    string StudentCode,
    string Status,
    DateTimeOffset ReceivedAt
);
