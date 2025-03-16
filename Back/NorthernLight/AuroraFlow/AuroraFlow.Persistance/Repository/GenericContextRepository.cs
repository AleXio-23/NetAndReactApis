using Microsoft.EntityFrameworkCore;

namespace AuroraFlow.Persistance.Repository;

public class GenericContextRepository<T>(AuroraFlowDbContext context) : Repository<T>(context)
    where T : class // Constrain T to class to ensure it can be used as an entity
{
    public AuroraFlowDbContext Context => (_context as AuroraFlowDbContext)!; // Assuming _context is defined in the base Repository class

    // Constructor should match the class name
}