# Command Query Responsibility Segregation (CQRS)
Command Query Responsibility Segregation (CQRS) is a software architecture pattern that separates read (Query) and write (Command) operations into different models to improve scalability, maintainability, and performance.

✅ CQRS separates Read and Write models.

✅ Commands (Write operations) → Modify data in the database.

✅ Queries (Read operations) → Fetch optimized read models.

✅ MediatR simplifies CQRS → Decouples request handling.

✅ Better scalability → Read and Write operations are independently optimized.

# CQRS Architecture
CQRS splits the system into two main models:

<ol>
  <li>
    Command Model (Write Side)
    <ul>
      <li>Handles Create, Update, Delete operations (CUD).</li>
      <li>Modifies data in the database.</li>
      <li>Ensures data consistency.</li>
    </ul>
  </li>
  <li>
    Handles Read operations.
    <ul>
      <li>Handles Read operations.</li>
      <li>Uses optimized read models (e.g., DTOs).</li>
      <li>Can leverage caching or a separate read database.</li>
    </ul>
  </li>
</ol>

#
```sql
+-------------+         +----------------------+         +--------------+
|  Client UI  | ----->  |    Command Handler   | ----->  |  Write DB    |
+-------------+         +----------------------+         +--------------+
       |                        |
       |                        v
       |                 +----------------------+
       |                 |    Query Handler     |
       |----------------> |  Read Optimized DB  |
                         +----------------------+

```
