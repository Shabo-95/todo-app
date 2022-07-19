using Microsoft.EntityFrameworkCore;

namespace todo_app_server.Data
{
    internal static class EntriesRepository
    {
        // Get All Todos
        internal async static Task<List<Entry>> GetAllTodosAsync()
        {
            using (var db = new DatabaseContext())
            {
                return await db.Entries.ToListAsync();
            }
        }

        // Get Todo By ID
        internal async static Task<Entry> GetTodoByIDAsync(int id)
        {
            using (var db = new DatabaseContext())
            {
                return await db.Entries.FirstOrDefaultAsync(entry => entry.TodoID == id);
            }
        }

        // Create Todo
        internal async static Task<bool> CreateTodoAsync(Entry todoToCreate)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    await db.Entries.AddAsync(todoToCreate);

                    // When the returned number of "SaveChangesAsync" ist 1 or more then the todo-item was added successfully and will return true
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        // Update Todo
        internal async static Task<bool> UpdateTodoAsync(Entry todoToUpdate)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    db.Entries.Update(todoToUpdate);

                    // When the returned number of "SaveChangesAsync" ist 1 or more then the todo-item was added successfully and will return true
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        // Delete Todo By ID
        internal async static Task<bool> DeleteTodoByIDAsync(int id)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    Entry todoToDelete = await GetTodoByIDAsync(id);

                    db.Remove(todoToDelete);

                    // When the returned number of "SaveChangesAsync" ist 1 or more then the todo-item was added successfully and will return true
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
