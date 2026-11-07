\# MINI DISTRIBUTED SYSTEM



\## 1. Giới thiệu



Bài thực hành xây dựng ứng dụng phân tán cơ bản bằng ASP.NET Core .NET 10.



Dự án gồm hai thành phần chính:

\- Submission.Api: cung cấp API để quản lý bài tập và tiếp nhận bài nộp.

\- Submission.Client: ứng dụng Client giao tiếp với API thông qua HTTP.



\## 2. Công nghệ sử dụng



\- C#

\- ASP.NET Core

\- .NET 10

\- HTTP

\- REST API

\- JSON



\## 3. Cấu trúc dự án



```text

MiniDistributedSystem/

├── src/

│   ├── Submission.Api/

│   │   ├── Program.cs

│   │   └── Submission.Api.csproj

│   └── Submission.Client/

│       ├── Program.cs

│       └── Submission.Client.csproj

├── .gitignore

├── MiniDistributedSystem.slnx

└── README.md

```



\## 4. Nội dung thực hành



\### Ý 1. Xây dựng và chạy ứng dụng API, Client



\- Khởi chạy Submission.Api.

\- Khởi chạy Submission.Client.

\- Kiểm tra khả năng giao tiếp HTTP giữa hai thành phần.



\### Ý 2. Bổ sung bài tập mới



\- Thêm bài tập số 3 vào danh sách API.

\- Kiểm tra danh sách bài tập sau khi cập nhật.

\- Xác nhận Client nhận được dữ liệu từ API.



\### Ý 3. Kiểm tra khi API không hoạt động



\- Dừng Submission.Api.

\- Tiếp tục chạy Submission.Client.

\- Quan sát lỗi kết nối khi Client không thể liên hệ với máy chủ.



\### Ý 4. Kiểm tra dữ liệu gửi lên không hợp lệ



\- Gửi yêu cầu thiếu StudentCode.

\- Gửi yêu cầu thiếu RepositoryUrl.

\- Kiểm tra API trả về HTTP 400 Bad Request.

\- Gửi dữ liệu hợp lệ và kiểm tra kết quả HTTP 201 Created.



\## 5. Cách chạy dự án



\### Bước 1. Build



```powershell

dotnet build

```



\### Bước 2. Chạy API



```powershell

dotnet run --project .\\src\\Submission.Api\\Submission.Api.csproj --no-launch-profile -- --urls http://localhost:5000

```



\### Bước 3. Chạy Client



Mở Terminal mới:



```powershell

dotnet run --project .\\src\\Submission.Client\\Submission.Client.csproj

```



\## 6. API sử dụng



| Phương thức | Endpoint | Chức năng |

|---|---|---|

| GET | /api/assignments | Lấy danh sách bài tập |

| POST | /api/submissions | Gửi bài tập |



\## 7. Kết quả kiểm thử



\- Build thành công với .NET 10.

\- API trả về danh sách bài tập.

\- Client giao tiếp với API.

\- Client phát hiện lỗi khi API dừng.

\- API từ chối dữ liệu không hợp lệ bằng HTTP 400.

\- API tiếp nhận dữ liệu hợp lệ bằng HTTP 201.



\## 8. Kết luận



Bài thực hành giúp tìm hiểu cách xây dựng ứng dụng phân tán cơ bản, giao tiếp giữa Client và API thông qua HTTP, xử lý dữ liệu JSON và kiểm tra lỗi trong quá trình trao đổi dữ liệu.

