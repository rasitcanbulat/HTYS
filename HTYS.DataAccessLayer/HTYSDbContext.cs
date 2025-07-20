using Microsoft.EntityFrameworkCore;
using HTYS.Entities;

namespace HTYS.DataAccessLayer
{
    public class HTYSDbContext : DbContext
    {
        public HTYSDbContext(DbContextOptions<HTYSDbContext> options) : base(options)
        {
        }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Avukat> Avukatlar { get; set; }
        public DbSet<LoginAccount> LoginAccounts { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Semt> Semtler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Ihtar> Ihtarlar { get; set; }
        public DbSet<IcraTakip> IcraTakipleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Müiteri İhtar bağlantısı iptal.
            modelBuilder.Entity<Ihtar>()
                .HasOne(i => i.Borclu)
                .WithMany()
                .HasForeignKey(i => i.MusteriId)
                .OnDelete(DeleteBehavior.NoAction);

            // Müşteri İcra bağlantısı iptal.
            modelBuilder.Entity<IcraTakip>()
                .HasOne(it => it.Borclu)
                .WithMany()
                .HasForeignKey(it => it.MusteriId)
                .OnDelete(DeleteBehavior.NoAction);

            // Ürun ile İcra bağlantısı iptal.
            modelBuilder.Entity<IcraTakip>()
                .HasOne(it => it.Urun)
                .WithMany()
                .HasForeignKey(it => it.UrunId)
                .OnDelete(DeleteBehavior.NoAction);

            // Bir Avukat silinirse ona bağlı İcra silinmez.
            modelBuilder.Entity<IcraTakip>()
                .HasOne(it => it.Avukat)
                .WithMany()
                .HasForeignKey(it => it.AvukatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
