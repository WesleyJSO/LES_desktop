namespace les_desktop.Model
{
    public class User : DomainEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AccountNonExpired { get; set; }
        public bool AccountNonLocked { get; set; }
        public bool CredentialsNonExpired { get; set; }
        public bool Enabled { get; set; }
        public Authentication Authentication { get; set; }
    }
}
