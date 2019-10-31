using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoFang.MobileSite.Domain.Entity;

namespace MoFang.MobileSite.Data.EntityFramework.Context
{
    public class MoFangMobileSiteContext : DbContext
    {
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Advertise> Advertise { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Bizarea> Bizarea { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Cityarea> Cityarea { get; set; }
        public virtual DbSet<Collect> Collect { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Cooperation> Cooperation { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Helpinfo> Helpinfo { get; set; }
        public virtual DbSet<Housekeepingcomment> Housekeepingcomment { get; set; }
        public virtual DbSet<Maintain> Maintain { get; set; }
        public virtual DbSet<Moerinfo> Moerinfo { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<Notify> Notify { get; set; }
        public virtual DbSet<Notifylog> Notifylog { get; set; }
        public virtual DbSet<Opencity> Opencity { get; set; }
        public virtual DbSet<Orderlog> Orderlog { get; set; }
        public virtual DbSet<Paidlog> Paidlog { get; set; }
        public virtual DbSet<Param> Param { get; set; }
        public virtual DbSet<Paramvalue> Paramvalue { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Recommend> Recommend { get; set; }
        public virtual DbSet<Reserve> Reserve { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Roomtype> Roomtype { get; set; }
        public virtual DbSet<Roomtypedevice> Roomtypedevice { get; set; }
        public virtual DbSet<Roomtypeimage> Roomtypeimage { get; set; }
        public virtual DbSet<Searchlog> Searchlog { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Storedevice> Storedevice { get; set; }
        public virtual DbSet<Storeimage> Storeimage { get; set; }
        public virtual DbSet<Storemanager> Storemanager { get; set; }
        public virtual DbSet<Usermenus> Usermenus { get; set; }

        public MoFangMobileSiteContext(DbContextOptions<MoFangMobileSiteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable<Activity>("activity");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Amount).HasColumnType("int(11)");

                entity.Property(e => e.ArticleId).HasMaxLength(20);

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(256);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Players).HasColumnType("int(11)");

                entity.Property(e => e.Progress).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.Property(e => e.Type).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Advertise>(entity =>
            {
                entity.ToTable<Advertise>("advertise");

                entity.Property(e => e.Id).HasMaxLength(32);

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Content).HasMaxLength(64);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.IsValid)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Link).HasMaxLength(64);

                entity.Property(e => e.Photo).HasMaxLength(128);

                entity.Property(e => e.Seq).HasColumnType("int(11)");

                entity.Property(e => e.Title).HasMaxLength(64);

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable<Article>("article");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Author).HasMaxLength(256);

                entity.Property(e => e.Banner).HasMaxLength(256);

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.OriginUrl).HasMaxLength(512);

                entity.Property(e => e.Photos).HasMaxLength(4000);

                entity.Property(e => e.SubTitle).HasMaxLength(256);

                entity.Property(e => e.Summary).HasMaxLength(512);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable<Banner>("banner");

                entity.Property(e => e.Id).HasMaxLength(32);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.IsPushTop)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsValid)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Link).HasMaxLength(64);

                entity.Property(e => e.Photo).HasMaxLength(128);

                entity.Property(e => e.Seq).HasColumnType("int(11)");

                entity.Property(e => e.Title).HasMaxLength(32);
            });

            modelBuilder.Entity<Bizarea>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.ParentCode });

                entity.ToTable<Bizarea>("bizarea");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.ParentCode).HasMaxLength(128);

                entity.Property(e => e.District).HasMaxLength(128);

                entity.Property(e => e.HasStore)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.Lat).HasColumnType("double(20,10)");

                entity.Property(e => e.Lng).HasColumnType("double(20,10)");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Seq).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable<Brand>("brand");

                entity.Property(e => e.BrandId).HasMaxLength(20);

                entity.Property(e => e.Background).HasMaxLength(1000);

                entity.Property(e => e.BrandAddr).HasMaxLength(100);

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Brandword).HasMaxLength(1000);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Introduction).HasMaxLength(1000);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Thumb)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Cityarea>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.ParentCode });

                entity.ToTable<Cityarea>("cityarea");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.ParentCode).HasMaxLength(64);

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.Location).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Seq).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Collect>(entity =>
            {
                entity.ToTable<Collect>("collect");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PhoneNumber).HasMaxLength(128);

                entity.Property(e => e.RoomTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable<Comment>("comment");

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ApartmenEnvironmentScore).HasColumnType("int(11)");

                entity.Property(e => e.ApiStoreId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.AverageScore).HasColumnType("float(11,2)");

                entity.Property(e => e.CommentTime).HasColumnType("datetime");

                entity.Property(e => e.CommunityActivityScore).HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.ContractId)
                    .HasColumnName("ContractID")
                    .HasMaxLength(20);

                entity.Property(e => e.HouseKeepingScore).HasColumnType("float(11,2)");

                entity.Property(e => e.IsPushTop)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsReplied)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsValid)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NetWorkScore).HasColumnType("int(11)");

                entity.Property(e => e.ReplyContent)
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ReplyId)
                    .HasColumnName("ReplyID")
                    .HasMaxLength(20);

                entity.Property(e => e.ReplyTime).HasColumnType("datetime");

                entity.Property(e => e.RoomScore).HasColumnType("int(11)");

                entity.Property(e => e.StoreName).HasMaxLength(64);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Cooperation>(entity =>
            {
                entity.ToTable<Cooperation>("cooperation");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Type).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable<Device>("device");

                entity.Property(e => e.DeviceId).HasMaxLength(20);

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DeviceType).HasColumnType("int(11)");

                entity.Property(e => e.IconUrl).HasMaxLength(200);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ProId).HasColumnType("int(20)");

                entity.Property(e => e.Seq).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable<Feedback>("feedback");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Photos).HasColumnType("text");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Helpinfo>(entity =>
            {
                entity.HasKey(e => e.HelpId);

                entity.ToTable<Helpinfo>("helpinfo");

                entity.Property(e => e.HelpId).HasColumnType("int(11)");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.IsEnabled)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Housekeepingcomment>(entity =>
            {
                entity.ToTable<Housekeepingcomment>("housekeepingcomment");

                entity.HasIndex(e => new { e.Id, e.CommentId })
                    .HasName("Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CommentId).HasColumnType("int(11)");

                entity.Property(e => e.CommentTime).HasColumnType("datetime");

                entity.Property(e => e.ContractId)
                    .HasColumnName("ContractID")
                    .HasMaxLength(20);

                entity.Property(e => e.IsValid)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Score).HasColumnType("int(11)");

                entity.Property(e => e.StoreManagerName).HasMaxLength(20);

                entity.Property(e => e.StoreManagerPhone).HasMaxLength(20);

                entity.Property(e => e.StoreName).HasMaxLength(64);

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Maintain>(entity =>
            {
                entity.ToTable<Maintain>("maintain");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Desc).HasColumnType("text");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Photos).HasColumnType("text");

                entity.Property(e => e.SeriviceTime).HasColumnName("SeriviceTIme");

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<Moerinfo>(entity =>
            {
                entity.ToTable<Moerinfo>("moerinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Recname)
                    .HasColumnName("recname")
                    .HasMaxLength(255);

                entity.Property(e => e.Rectel)
                    .HasColumnName("rectel")
                    .HasMaxLength(255);

                entity.Property(e => e.Store)
                    .HasColumnName("store")
                    .HasMaxLength(255);

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable<Notice>("notice");

                entity.Property(e => e.NoticeId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.IsEnabled)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.LinkUrl).HasMaxLength(500);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Notify>(entity =>
            {
                entity.ToTable<Notify>("notify");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ActualTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Content).HasMaxLength(5000);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsPushTop)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsSys)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Link).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Thumb).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Notifylog>(entity =>
            {
                entity.ToTable<Notifylog>("notifylog");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.NotifyId).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ReadTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<Opencity>(entity =>
            {
                entity.HasKey(e => e.CityCode);

                entity.ToTable<Opencity>("opencity");

                entity.Property(e => e.CityCode).HasMaxLength(20);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Orderlog>(entity =>
            {
                entity.ToTable<Orderlog>("orderlog");

                entity.Property(e => e.Id).HasColumnType("int(20)");

                entity.Property(e => e.CaseCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CloseReason).HasMaxLength(256);

                entity.Property(e => e.Contact).HasMaxLength(64);

                entity.Property(e => e.ContactPhone).HasMaxLength(20);

                entity.Property(e => e.CouponPaid).HasColumnType("decimal(10,2)");

                entity.Property(e => e.CouponStatus).HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Guest).HasMaxLength(64);

                entity.Property(e => e.IsPayDeposit).HasColumnType("tinyint(1)");

                entity.Property(e => e.IsSeeRoom).HasColumnType("tinyint(1)");

                entity.Property(e => e.Lease).HasColumnType("int(11)");

                entity.Property(e => e.Message).HasMaxLength(256);

                entity.Property(e => e.PapersNo).HasMaxLength(64);

                entity.Property(e => e.PapersType).HasMaxLength(20);

                entity.Property(e => e.PayMethod).HasMaxLength(20);

                entity.Property(e => e.PayType).HasColumnType("int(11)");

                entity.Property(e => e.Payment).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PointPaid).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.Property(e => e.RawPrice).HasColumnType("decimal(10,2)");

                entity.Property(e => e.RefundStatus).HasColumnType("int(11)");

                entity.Property(e => e.Remark).HasMaxLength(256);

                entity.Property(e => e.RoomId).HasColumnType("int(20)");

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.SeeAlterRoom).HasMaxLength(256);

                entity.Property(e => e.SeeRoomDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(20)");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Type).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<Paidlog>(entity =>
            {
                entity.ToTable<Paidlog>("paidlog");

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BillNo).HasMaxLength(32);

                entity.Property(e => e.BillType).HasColumnType("int(11)");

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.Contact).HasMaxLength(64);

                entity.Property(e => e.ContractId)
                    .HasColumnName("ContractID")
                    .HasMaxLength(128);

                entity.Property(e => e.ContractMonthCount).HasColumnType("int(11)");

                entity.Property(e => e.CouponStatus).HasColumnType("int(11)");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(64);

                entity.Property(e => e.OmsAccountSubjectCode)
                    .HasColumnName("OMS_AccountSubjectCode")
                    .HasMaxLength(20);

                entity.Property(e => e.OmscreditCount)
                    .HasColumnName("OMSCreditCount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Omsstatus)
                    .HasColumnName("OMSStatus")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OrderType).HasColumnType("int(11)");

                entity.Property(e => e.OrgName).HasMaxLength(64);

                entity.Property(e => e.PayMethod).HasMaxLength(32);

                entity.Property(e => e.PayMonthCount).HasColumnType("int(11)");

                entity.Property(e => e.PaySource).HasMaxLength(64);

                entity.Property(e => e.Payment).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Paytime).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(128);

                entity.Property(e => e.RoomName).HasMaxLength(64);

                entity.Property(e => e.RoomTypeName).HasMaxLength(64);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.Property(e => e.StoreId)
                    .HasColumnName("StoreID")
                    .HasMaxLength(20);

                entity.Property(e => e.TradeNo).HasMaxLength(32);
            });

            modelBuilder.Entity<Param>(entity =>
            {
                entity.HasKey(e => e.ParamCode);

                entity.ToTable<Param>("param");

                entity.Property(e => e.ParamCode).HasMaxLength(20);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParamName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Paramvalue>(entity =>
            {
                entity.ToTable<Paramvalue>("paramvalue");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParamCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ParamValueCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ParamValueName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Seq).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable<Question>("question");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Answers).HasMaxLength(255);

                entity.Property(e => e.Correct).HasMaxLength(30);

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.Question1)
                    .HasColumnName("Question")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Recommend>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Type });

                entity.ToTable<Recommend>("recommend");

                entity.Property(e => e.Key).HasMaxLength(128);

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsValid)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Reserve>(entity =>
            {
                entity.ToTable<Reserve>("reserve");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'预约单号'");

                entity.Property(e => e.CaseCode).HasMaxLength(20);

                entity.Property(e => e.Contact).HasMaxLength(32);

                entity.Property(e => e.ContactPhone).HasMaxLength(64);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(64);

                entity.Property(e => e.OrgId)
                    .HasColumnName("OrgID")
                    .HasMaxLength(64);

                entity.Property(e => e.OrgName).HasMaxLength(64);

                entity.Property(e => e.PhoneNumber).HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Reason).HasColumnType("text");

                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .HasMaxLength(64);

                entity.Property(e => e.RoomName).HasMaxLength(64);

                entity.Property(e => e.SeeRoomDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable<Room>("room");

                entity.HasIndex(e => e.RoomId)
                    .HasName("Id");

                entity.Property(e => e.RoomId).HasColumnType("int(11)");

                entity.Property(e => e.Area)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.IsShowIndex)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RoomTypeId).HasColumnType("int(11)");

                entity.Property(e => e.RoomTypeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Weight)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Roomtype>(entity =>
            {
                entity.ToTable<Roomtype>("roomtype");

                entity.HasIndex(e => e.RoomTypeId)
                    .HasName("Id");

                entity.Property(e => e.RoomTypeId).HasColumnType("int(11)");

                entity.Property(e => e.ApiRoomTypeId).HasMaxLength(20);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Desc).HasColumnType("text");

                entity.Property(e => e.IsShowIndex)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");

                entity.Property(e => e.RoomTypeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StoreId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Roomtypedevice>(entity =>
            {
                entity.ToTable<Roomtypedevice>("roomtypedevice");

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RoomTypeId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Roomtypeimage>(entity =>
            {
                entity.ToTable<Roomtypeimage>("roomtypeimage");

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceType)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ImgType).HasColumnType("int(11)");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IsEnabled)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RoomTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Searchlog>(entity =>
            {
                entity.ToTable<Searchlog>("searchlog");

                entity.HasIndex(e => e.Id)
                    .HasName("Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BizAreaName)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable<Service>("service");

                entity.Property(e => e.ServiceId).HasColumnType("int(11)");

                entity.Property(e => e.Badge).HasMaxLength(20);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(20);

                entity.Property(e => e.IconUrl).HasMaxLength(200);

                entity.Property(e => e.IndexSeq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsApponly)
                    .HasColumnName("IsAPPOnly")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.IsEnabled)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.IsShowIndex)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.LinkUrl).HasMaxLength(200);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.NullPopMessage).HasMaxLength(50);

                entity.Property(e => e.OperationTag).HasMaxLength(20);

                entity.Property(e => e.OperationType).HasColumnType("int(11)");

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ServiceType).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable<Station>("station");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.City).HasMaxLength(64);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HasStore)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsValid).HasColumnType("tinyint(1)");

                entity.Property(e => e.Lat).HasColumnType("double(20,10)");

                entity.Property(e => e.Lng).HasColumnType("double(20,10)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Parent)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Seq).HasColumnType("int(11)");

                entity.Property(e => e.Type).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable<Store>("store");

                entity.HasIndex(e => e.StoreId)
                    .HasName("Id");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ApiStoreId).HasMaxLength(20);

                entity.Property(e => e.AvgPrice)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Background)
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CityCode).HasMaxLength(20);

                entity.Property(e => e.CityName).HasMaxLength(20);

                entity.Property(e => e.CloseTime).HasMaxLength(10);

                entity.Property(e => e.Contact).HasMaxLength(255);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Full360Url).HasMaxLength(200);

                entity.Property(e => e.Lat).HasColumnType("double(20,10)");

                entity.Property(e => e.Lng).HasColumnType("double(20,10)");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OpenTime).HasMaxLength(10);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Photo).HasMaxLength(4000);

                entity.Property(e => e.Receive).HasMaxLength(255);

                entity.Property(e => e.Services).HasMaxLength(1000);

                entity.Property(e => e.StartPrice).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Status).HasColumnType("int(11)");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Thumb).HasMaxLength(1024);

                entity.Property(e => e.Traffic).HasMaxLength(1000);
            });

            modelBuilder.Entity<Storedevice>(entity =>
            {
                entity.ToTable<Storedevice>("storedevice");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.StoreId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Storeimage>(entity =>
            {
                entity.ToTable<Storeimage>("storeimage");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceType)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ImgType).HasColumnType("int(11)");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsEnabled)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'1\\''");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Seq)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Storemanager>(entity =>
            {
                entity.ToTable<Storemanager>("storemanager");

                entity.Property(e => e.Id).HasColumnType("int(20)");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.StoreCode).HasMaxLength(20);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserImg).HasMaxLength(200);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserType).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Usermenus>(entity =>
            {
                entity.ToTable<Usermenus>("usermenus");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NullPopMessage).HasMaxLength(50);

                entity.Property(e => e.TagIcon).HasMaxLength(255);

                entity.Property(e => e.Type).HasColumnType("int(11)");

                entity.Property(e => e.Url).HasMaxLength(225);
            });
        }
    }
}
