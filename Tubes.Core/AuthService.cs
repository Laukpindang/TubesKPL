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

            // CARI PENGGUNA DENGAN USERNAME DAN PASSWORD YANG SESUAI

            // VERIFIKASI APAKAH PENGGUNA DITEMUKAN

            // JIKA DITEMUKAN, KEMBALIKAN OPERATIONRESULT SUKSES
            return OperationResult.Success();
        }
    }
}
