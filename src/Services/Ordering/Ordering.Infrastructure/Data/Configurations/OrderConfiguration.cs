using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasConversion(
                orderId => orderId.Value,
                dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();

            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            builder.ComplexProperty(
                o => o.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
                });

            builder.ComplexProperty(
                o => o.ShippingAddress, saBuilder =>
                {
                    saBuilder.Property(sa => sa.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    saBuilder.Property(sa => sa.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                    saBuilder.Property(sa => sa.EmailAddress)
                    .HasMaxLength(50);

                    saBuilder.Property(sa => sa.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                    saBuilder.Property(sa => sa.Country)
                    .HasMaxLength(50);

                    saBuilder.Property(sa => sa.State)
                    .HasMaxLength(50);

                    saBuilder.Property(sa => sa.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
                });

            builder.ComplexProperty(
                o => o.BillingAddress, baBuilder =>
                {
                    baBuilder.Property(ba => ba.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    baBuilder.Property(sa => sa.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                    baBuilder.Property(sa => sa.EmailAddress)
                    .HasMaxLength(50);

                    baBuilder.Property(sa => sa.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                    baBuilder.Property(sa => sa.Country)
                    .HasMaxLength(50);

                    baBuilder.Property(sa => sa.State)
                    .HasMaxLength(50);

                    baBuilder.Property(sa => sa.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
                });

            builder.ComplexProperty(
                o => o.Payment, paymentBuilder =>
                {
                    paymentBuilder.Property(p => p.CardNumber)
                    .HasMaxLength(50);

                    paymentBuilder.Property(p => p.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                    paymentBuilder.Property(p => p.Expiration)
                    .HasMaxLength(10);

                    paymentBuilder.Property(p => p.Expiration)
                    .HasMaxLength(3);

                    paymentBuilder.Property(p => p.PaymentMethod);
                });

            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.Property(o => o.TotalPrice);
        }
    }
}
