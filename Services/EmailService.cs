using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace HeThongQuanLyPhongTro.Services
{
    public class EmailService
    {
        private const string SENDER_EMAIL = "phongtroxinhh@gmail.com";
        private const string SENDER_PASSWORD = "xxyhvsajcqeppcma";  // App Password
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;

        public async Task<bool> GuiEmailHoaDon(string toEmail, string toName, string maHoaDon, byte[] pdfBytes)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(SENDER_EMAIL));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = $"HÓA ĐƠN THANH TOÁN - {maHoaDon}";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
                    <h2>PHÒNG TRỌ XINH</h2>
                    <p>Kính gửi <strong>{toName}</strong>,</p>
                    <p>Cảm ơn bạn đã thanh toán hóa đơn <strong>{maHoaDon}</strong>.</p>
                    <p>Vui lòng xem chi tiết trong file đính kèm.</p>
                    <br/>
                    <p>Trân trọng,<br/>Phòng Trọ Xinh</p>
                ";
                bodyBuilder.Attachments.Add($"HoaDon_{maHoaDon}.pdf", pdfBytes);
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(SMTP_SERVER, SMTP_PORT, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(SENDER_EMAIL, SENDER_PASSWORD);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        // Gửi email OTP cho chức năng quên mật khẩu
        public async Task<bool> GuiEmailOTP(string emailNhan, string otp)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(SENDER_EMAIL));
                email.To.Add(MailboxAddress.Parse(emailNhan));
                email.Subject = "Mã xác thực Quên Mật Khẩu - Hệ thống Phòng Trọ Xinh";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
                    <div style='font-family: Arial, sans-serif; padding: 30px; max-width: 500px; margin: auto; border: 1px solid #e5e7eb; border-radius: 12px; background-color: #ffffff; box-shadow: 0 4px 6px rgba(0,0,0,0.05);'>
                        <div style='text-align: center; margin-bottom: 20px;'>
                            <h2 style='color: #2563eb; margin: 0;'>YÊU CẦU ĐẶT LẠI MẬT KHẨU</h2>
                        </div>
                        <p style='color: #374151; font-size: 16px; line-height: 1.5;'>Chào bạn,</p>
                        <p style='color: #374151; font-size: 16px; line-height: 1.5;'>Hệ thống nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn. Mã xác thực (OTP) của bạn là:</p>
                        
                        <div style='text-align: center; margin: 30px 0;'>
                            <span style='font-size: 36px; font-weight: bold; color: #dc2626; letter-spacing: 8px; border: 2px dashed #fca5a5; background-color: #fef2f2; padding: 15px 30px; border-radius: 8px; display: inline-block;'>{otp}</span>
                        </div>
                        
                        <p style='color: #6b7280; font-size: 14px; text-align: center;'>Mã này có hiệu lực trong 5 phút. Vui lòng không chia sẻ cho bất kỳ ai.</p>
                        <hr style='border: 0; border-top: 1px solid #f3f4f6; margin: 25px 0;' />
                        <p style='font-size: 12px; color: #9ca3af; text-align: center;'>Đây là email tự động từ hệ thống Phòng Trọ Xinh, vui lòng không trả lời.</p>
                    </div>";

                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(SMTP_SERVER, SMTP_PORT, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(SENDER_EMAIL, SENDER_PASSWORD);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi OTP: {ex.Message}");
                return false;
            }
        }
        // Thêm hàm gửi thông báo chung (Dùng cho thông báo sửa chữa)
        public async Task<bool> GuiEmailThongBao(string emailNhan, string tieuDe, string noiDungHtml)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(SENDER_EMAIL));
                email.To.Add(MailboxAddress.Parse(emailNhan));
                email.Subject = tieuDe;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = noiDungHtml;
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(SMTP_SERVER, SMTP_PORT, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(SENDER_EMAIL, SENDER_PASSWORD);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email thông báo: {ex.Message}");
                return false;
            }
        }
    }

}