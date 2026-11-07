
using System.Net.Http.Json;

var apiBaseUrl = args.Length > 0
    ? args[0]
    : "http://localhost:5000";

using var http = new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
};

// Lay danh sach bai tap
var assignments =
    await http.GetFromJsonAsync<List<Assignment>>(
        "/api/assignments");

Console.WriteLine("Danh sach bai tap:");

foreach (var assignment in assignments ?? new List<Assignment>())
{
    Console.WriteLine(
        $"- {assignment.Id}: {assignment.Title}");
}

// Tao yeu cau nop bai
var request = new CreateSubmissionRequest(
    AssignmentId: 1,
    StudentCode: "DTC245200054",
    RepositoryUrl: "https://github.com/dtc245200054-debug/MiniDistributedSystem"
);

// Gui yeu cau den API
var response = await http.PostAsJsonAsync(
    "/api/submissions",
    request
);

response.EnsureSuccessStatusCode();

var result =
    await response.Content.ReadFromJsonAsync<SubmissionResult>();

Console.WriteLine($"Da nop bai. Ma luot nop: {result?.Id}");
Console.WriteLine($"Trang thai: {result?.Status}");

record Assignment(int Id, string Title, string Description);

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
