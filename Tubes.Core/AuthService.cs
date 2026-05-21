using System.Collections.Generic;
using System.Linq;

namespace Tubes.Core
{
    public class AuthService
    {
        private readonly List<User> _users = new List<User>
        {
            new User("admin", "admin123"),
            new User("user1", "user123")
        };
        public OperationResult Login(string username, string password)
        {
            // VALIDASI INPUT USERNAME DAN PASSWORD PAKAI .IsNullOrWhiteSpace
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return OperationResult.Fail("Username dan password tidak boleh kosong!");
            }
            // CARI PENGGUNA DENGAN USERNAME DAN PASSWORD YANG SESUAI
            var user = _users.FirstOrDefault(u =>
               u.Username == username &&
               u.Password == password);
            // VERIFIKASI APAKAH PENGGUNA DITEMUKAN
            if (user == null)
            {
                return OperationResult.Fail("Username atau password salah!");
            }
            // JIKA DITEMUKAN, KEMBALIKAN OPERATIONRESULT SUKSES
            return OperationResult.Success();
        }
    }
}
