namespace WebApplicationADs_Eixo2.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EmailUnique : ValidationAttribute
    {
        private readonly DbContext _context;


        public EmailUnique(DbContext context)
        {
            _context = context;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;
            if (string.IsNullOrEmpty(email))
            {
                return ValidationResult.Success;
            }

            var dbSet = _context.Set<Usuarios>(); 

            var existingUser = dbSet.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                return new ValidationResult("Este email já está em uso.");
            }

            return ValidationResult.Success;
        }
    }
}
