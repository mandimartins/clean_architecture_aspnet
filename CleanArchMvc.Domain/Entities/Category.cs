using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category: Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid Name. Too short, minimum 3 characters.");

            Name = name;
        }
    }
}
