using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.EF.Config
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CI)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(c => c.FechaNacimiento)
                .IsRequired();

            builder.Property(c => c.Direccion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.ResponsablePagoId)
                .IsRequired(false);

            builder.HasOne(c => c.ClienteResponsablePago)
                .WithMany(c => c.ClientesACargo)
                .HasForeignKey(c => c.ResponsablePagoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Cliente_NoAutoResponsable",
                "\"ResponsablePagoId\" IS NULL OR \"ResponsablePagoId\" <> \"Id\""
            ));

            builder.Metadata
                .FindNavigation(nameof(Cliente.ClientesACargo))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(c => c.FormaPago)
                .IsRequired()
                .HasMaxLength(100);

<<<<<<< Updated upstream
			builder.Property(c => c.Eliminado)
				.IsRequired();
			
			builder.OwnsOne(c => c.NombreCompleto, nomC =>
			{
				nomC.Property(n => n.Nombre)
					.HasColumnName("Nombre")
					.IsRequired()
					.HasMaxLength(100);

				nomC.Property(n => n.Apellido)
					.HasColumnName("Apellido")
					.IsRequired()
					.HasMaxLength(100);
			});
			
			builder.OwnsOne(c => c.Email, email =>
			{
				email.Property(e => e.Value)
					.HasColumnName("Email")
					.IsRequired()
					.HasMaxLength(150);
			});
			
			builder.OwnsOne(c => c.Telefono, telefono =>
			{
				telefono.Property(t => t.Value)
					.HasColumnName("Telefono")
					.IsRequired()
					.HasMaxLength(20);
			});
			
			builder.OwnsOne(c => c.Celular, celular =>
			{
				celular.Property(cel => cel.Value)
					.HasColumnName("Celular")
					.IsRequired()
					.HasMaxLength(20);
			});

			// Relaciones
	
			builder.HasOne(c => c.Plan)
				.WithMany()
				.HasForeignKey(c => c.TipoPlanId)
				.OnDelete(DeleteBehavior.Restrict);
			
			builder.HasOne(c => c.ClienteResponsablePago)
				.WithMany(c => c.ClientesACargo)
				.HasForeignKey(c => c.ResponsablePagoId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);
=======
            builder.Property(c => c.Observaciones)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.TipoPlanId)
                .IsRequired();

            builder.Property(c => c.Eliminado)
                .IsRequired();

            // Value Object: NombreCompleto
            builder.OwnsOne(c => c.NombreCompleto, nomC =>
            {
                nomC.Property(n => n.Nombre)
                    .HasColumnName("Nombre")
                    .IsRequired()
                    .HasMaxLength(100);

                nomC.Property(n => n.Apellido)
                    .HasColumnName("Apellido")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Value Object: Email
            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(150);
            });

            // Value Object: Telefono
            builder.OwnsOne(c => c.Telefono, telefono =>
            {
                telefono.Property(t => t.Value)
                    .HasColumnName("Telefono")
                    .IsRequired()
                    .HasMaxLength(20);
            });
>>>>>>> Stashed changes

            // Value Object: Celular
            builder.OwnsOne(c => c.Celular, celular =>
            {
                celular.Property(cel => cel.Value)
                    .HasColumnName("Celular")
                    .IsRequired()
                    .HasMaxLength(20);
            });

<<<<<<< Updated upstream
			builder.HasMany(c => c.ServiciosDisponibles)
				.WithOne()
				.HasForeignKey("ClienteDisponibleId")
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(c => c.ServiciosExtras)
				.WithOne()
				.HasForeignKey("ClienteExtraId")
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
=======
            // Relaciones
            builder.HasOne(c => c.Plan)
                .WithMany()
                .HasForeignKey(c => c.TipoPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Suscripcion)
                .WithMany()
                .HasForeignKey(c => c.SuscripcionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.ServiciosDisponibles)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ServiciosExtras)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
>>>>>>> Stashed changes
}
